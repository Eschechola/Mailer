using System.Threading.Tasks;
using ESCHENet.Emails.Model;
using Mailer.Sender.Interfaces;
using Microsoft.Extensions.Configuration;
using ESCHENet.Emails.Functions;

namespace Mailer.Sender.Utilities
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmail(string email, string subject, string body)
        {
            string emailApplication = _configuration["Email:Address"];
            string passwordApplication = _configuration["Email:Password"];

            var emailToSent = new Email
            {
                Subject = subject,
                Receiver = email,
                Body = body
            };

            var sender = new EmailSender(emailApplication, passwordApplication);

            await Task.Run(() =>
            {
                sender.SendEmail(emailToSent);
            });
        }
    }
}
