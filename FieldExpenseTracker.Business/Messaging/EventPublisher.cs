using System.Text;
using System.Text.Json;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Business.Services;
using FieldExpenseTracker.Core.Events;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
namespace FieldExpenseTracker.Business.Messaging;

public class EventPublisher : IEventPublisher
{
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService;
    private readonly IUnitOfWork _unitOfWork;

    public EventPublisher(IConfiguration configuration, IEmailService emailService, IUnitOfWork unitOfWork)
    {
        _configuration = configuration;
        _emailService = emailService;
        _unitOfWork = unitOfWork;
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
        await _emailService.SendEmailAsync(
                    to: "bulut.betulbb@gmail.com",
                    subject: "New Expense Request",
                    body: $"<p>New expense request created by {expenseEvent.EmployeeName}</p>"
                );
        // Örnek: Admin e-postalarını alıp e-posta gönderme
        /*var adminEmails = await _unitOfWork.UserRepository.GetAdminEmailsAsync();
        foreach (var email in adminEmails)
        {
            await _emailService.SendEmailAsync(
                to: email,
                subject: "New Expense Request created",
                body: $"New expense request created by {expenseEvent.EmployeeName}."
            );
        }*/
        
    }
}
