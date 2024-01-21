using BookingServices.External.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Text;
using static AppConfigurations;

namespace BookingServices.External.Services;

public class EmailService : IEmailService
{
    private readonly EmailConfigurations _emailConfig;
    private readonly ILogger _logger;

    public EmailService(IOptions<EmailConfigurations> options, ILogger<EmailService> logger)
    {
        _emailConfig = options.Value;
        _logger = logger;
    }
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        Exception? exception = null;
        var smtpClient = new SmtpClient(_emailConfig.Host)
        {
            Port = _emailConfig.Port,
            Credentials = new NetworkCredential(_emailConfig.Username, _emailConfig.Password),
            EnableSsl = true,
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(_emailConfig.Username),
            To = { email },
            Subject = subject,
            Body = htmlMessage,
            IsBodyHtml = true,
            BodyEncoding = Encoding.UTF8,
        };

        try
        {
            smtpClient.Send(mailMessage);
            
        }catch(Exception ex)
        {
            _logger.LogError(ex, "Error sending email");
            exception = ex;
        }
        finally
        {
            smtpClient.Dispose();
            mailMessage.Dispose();
        }
        if(exception != null)
        {
            throw new Exception("Error sending email", exception);
        }else
        {
            return Task.CompletedTask;
        }
    }
}
