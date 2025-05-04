using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FieldExpenseTracker.Business.Services;
public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string body);
}

public class EmailService : IEmailService
{
    public Task SendEmailAsync(string to, string subject, string body)
    {
        var smtp = new SmtpClient("smtp.example.com")  // Gmail için smtp.gmail.com
        {
            Port = 587,
            Credentials = new NetworkCredential("your-email@example.com", "your-password"),
            EnableSsl = true
        };

        var message = new MailMessage("your-email@example.com", to, subject, body)
        {
            IsBodyHtml = true
        };

        return smtp.SendMailAsync(message);
    }
}
