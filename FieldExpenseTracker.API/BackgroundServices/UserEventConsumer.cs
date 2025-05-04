using System.Text;
using System.Text.Json;
using FieldExpenseTracker.Business.Messaging;
using FieldExpenseTracker.Business.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace FieldExpenseTracker.API.BackgroundServices;
public class UserEventConsumer : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public UserEventConsumer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "user_event_queue",
                             durable: true,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += async (model, ea) =>
        {
            using var scope = _serviceProvider.CreateScope();
            var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

            var body = ea.Body.ToArray();
            var json = Encoding.UTF8.GetString(body);
            var userEvent = JsonSerializer.Deserialize<UserCreatedOrPasswordResetEvent>(json);

            var message = $"Hello {userEvent.FullName},\n\nYour password is: {userEvent.Password}\n\nPlease change it after first login.";

            await emailService.SendEmailAsync(userEvent.Email, userEvent.Subject, message);
        };

        channel.BasicConsume(queue: "user_event_queue", autoAck: true, consumer: consumer);

        return Task.CompletedTask;
    }
}
