using Microsoft.Extensions.Options;
using Editorial.UI.Application.Contracts;
using Taller.Domain.ComponentModels;
using Taller.Domain.ConfigurationModels;
using System.Net;
using System.Net.Mail;

namespace Taller.Application.Context
{
    public class EmailSender : IEmailSender
    {

        public EmailSender(IOptions<SmtpConfiguration> smtpConfiguration) 
        {
            SmtpConfiguration = smtpConfiguration.Value;
        }

        readonly SmtpConfiguration SmtpConfiguration;

        public void Send(Email email)
        {
            var client =
                new SmtpClient
                {
                    Host = SmtpConfiguration.Server,
                    Port = SmtpConfiguration.Port,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials =
                    new NetworkCredential
                        (SmtpConfiguration.UserName, SmtpConfiguration.Password)
                };

            var message =
                new MailMessage
                {
                    From = new MailAddress(SmtpConfiguration.Sender),
                    Subject = email.Subject,
                    Body = email.Body
                };

            message.To.Add(new MailAddress(email.Recipient));

            client.Send(message);
        }
    }
}
