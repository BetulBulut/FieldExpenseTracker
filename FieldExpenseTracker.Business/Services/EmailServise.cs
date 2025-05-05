using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;
using MailKit.Security;

namespace FieldExpenseTracker.Business.Services;
public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string body);
}

public class EmailService: IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        var emailMessage = new MimeMessage();

        emailMessage.From.Add(new MailboxAddress("Field Expense System", _configuration["Email:From"]));
        emailMessage.To.Add(new MailboxAddress("", to));
        emailMessage.Subject = subject;

        var bodyBuilder = new BodyBuilder { HtmlBody = body };
        emailMessage.Body = bodyBuilder.ToMessageBody();

        using var client = new MailKit.Net.Smtp.SmtpClient();
        var smtpPort = _configuration["Email:SmtpPort"];
        if (string.IsNullOrEmpty(smtpPort))
        {
            throw new InvalidOperationException("SMTP port configuration is missing.");
        }
        await client.ConnectAsync(_configuration["Email:SmtpHost"], int.Parse(smtpPort), SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(_configuration["Email:From"], _configuration["Email:Password"]);
        await client.SendAsync(emailMessage);
        await client.DisconnectAsync(true);
    }
}

