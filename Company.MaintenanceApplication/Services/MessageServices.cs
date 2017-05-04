using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;

namespace Company.MaintenanceApplication.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link https://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public AuthMessageSender(IOptions<AuthMessageSenderOptions> options)
        {
            Options = options.Value;
        }
        public AuthMessageSenderOptions Options { get;  }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            return SendEmail(email, subject, message);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }

        public  Task SendEmail(string email, string subject, string messageContent)
        {

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(Options.MailBoxUserDisplayName, Options.MailBoxUserName));
            message.To.Add(new MailboxAddress("Welcome User", email));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = messageContent;
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect(Options.MailBoxHost, 587, false);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");                

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(Options.MailBoxUserName, Options.MailBoxPassword);

                client.Send(message);
                client.Disconnect(true);
            }
            return Task.FromResult(0);

        }
    }

}
