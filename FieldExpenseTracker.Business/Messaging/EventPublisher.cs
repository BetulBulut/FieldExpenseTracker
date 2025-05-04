using System.Text;
using System.Text.Json;
using FieldExpenseTracker.Business.Interfaces;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
namespace FieldExpenseTracker.Business.Messaging;

public class EventPublisher : IEventPublisher
{
    private readonly IConfiguration _configuration;

    public EventPublisher(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async void PublishExpenseCreated(ExpenseCreatedEvent expenseEvent)
    {
        var factory = new ConnectionFactory()
        {
            HostName = _configuration["RabbitMQ:HostName"] ?? "localhost"
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "expense_created_queue",
                             durable: true,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var messageBody = JsonSerializer.Serialize(expenseEvent);
        var body = Encoding.UTF8.GetBytes(messageBody);

        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;

        channel.BasicPublish(exchange: "",
                             routingKey: "expense_created_queue",
                             basicProperties: properties,
                             body: body);
    }

   public async Task PublishUserCreatedOrPasswordReset(UserCreatedOrPasswordResetEvent userEvent)
    {
        var factory = new ConnectionFactory()
        {
            HostName = _configuration["RabbitMQ:Host"] ?? "localhost",
            UserName = _configuration["RabbitMQ:Username"] ?? "guest",
            Password = _configuration["RabbitMQ:Password"] ?? "guest"
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "user_event_queue",
                             durable: true,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var messageBody = JsonSerializer.Serialize(userEvent);
        var body = Encoding.UTF8.GetBytes(messageBody);

        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;

        channel.BasicPublish(exchange: "",
                             routingKey: "user_event_queue",
                             basicProperties: properties,
                             body: body);

    }
}
