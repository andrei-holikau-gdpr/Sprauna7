using MimeKit;
using MailKit.Net.Smtp;
using Plugins.MailKitSp.Interfaces;
using Plugins.MailKitSp.Models;

namespace Plugins.MailKitSp.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailConfig;
        public EmailService(EmailSettings emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public async Task SendEmailAsync(string ToEmail, string messageSubject, string HTMLBody)
        {
            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта Sprauna.by", _emailConfig.FromEmail));
            emailMessage.To.Add(new MailboxAddress("", ToEmail));
            emailMessage.Subject = messageSubject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = HTMLBody
            };
            //message.Body = new TextPart("plain")
            //    {
            //        Text = "This is a test email."
            //    };

            using var smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync(_emailConfig.Host, _emailConfig.Port, false);
            await smtpClient.AuthenticateAsync(_emailConfig.Username, _emailConfig.Password);
            await smtpClient.SendAsync(emailMessage);

            await smtpClient.DisconnectAsync(true);
        }
    }
}
