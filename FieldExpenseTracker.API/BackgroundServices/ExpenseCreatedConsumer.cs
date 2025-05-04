using FieldExpenseTracker.Business.Services;
using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace FieldExpenseTracker.API.BackgroundServices;
public class ExpenseCreatedConsumer : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private RabbitMQ.Client.IModel _channel;
    private RabbitMQ.Client.IConnection _connection;

    public ExpenseCreatedConsumer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        var factory = new ConnectionFactory() { HostName = "localhost" };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare("expense-created-queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (sender, args) =>
        {
            var body = args.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            var expenseEvent = JsonSerializer.Deserialize<ExpenseCreatedEvent>(message);

            using var scope = _serviceProvider.CreateScope();
            var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

            var emailBody = $"New Expense Request\n\n" +
                            $"From: {expenseEvent.EmployeeName}\n" +
                            $"Amount: {expenseEvent.Amount:C}\n" +
                            $"Description: {expenseEvent.Description}\n" +
                            $"Date: {expenseEvent.CreatedAt:yyyy-MM-dd HH:mm}";

            await emailService.SendEmailAsync("admin@company.com", "New Expense Request Submitted", emailBody);
        };

        _channel.BasicConsume("expense-created-queue", true, consumer);
        return Task.CompletedTask;
    }
}
