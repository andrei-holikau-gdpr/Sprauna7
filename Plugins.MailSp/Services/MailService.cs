using System.Net.Mail;
using System.Net;
using Plugins.MailSp.Models;
using Plugins.MailSp.Interfaces;

namespace Plugins.MailSp.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailConfig;
        public MailService(MailSettings mailConfig)
        {
            _mailConfig = mailConfig;
        }

        public async Task SendEmailAsync(string ToEmail, string messageSubject, string HTMLBody)
        {
            MailMessage message = new()
            {
                From = new MailAddress(_mailConfig.FromEmail),
                Subject = messageSubject,
                IsBodyHtml = true,
                Body = HTMLBody
            };
            message.To.Add(new MailAddress(ToEmail));
            //message.To.Add(new MailboxAddress("Recipient Name", "recipient@example.com"));
            //message.Body = new TextPart("plain")
            //    {
            //        Text = "This is a test email."
            //    };

            using SmtpClient smtpClient = new();
            smtpClient.Port = _mailConfig.Port;
            smtpClient.Host = _mailConfig.Host;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(_mailConfig.Username, _mailConfig.Password);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtpClient.SendMailAsync(message);
        }

        // public string GetUsername()     => _mailConfig.Username;
        // public string GetPassword()     => _mailConfig.Password;
        // public string GetFromEmail()    => _mailConfig.FromEmail;
        // public string GetHost()         => _mailConfig.Host;
        // public int GetPort()            => _mailConfig.Port;
    }
}
