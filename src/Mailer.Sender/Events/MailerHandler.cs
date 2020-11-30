using MediatR;
using Mailer.Core.Messages.CommonMessages.IntegrationEvents;
using System.Threading.Tasks;
using System.Threading;
using Mailer.Sender.Interfaces;

namespace Mailer.Sender.Events
{
    public class MailerHandler : INotificationHandler<EmailSentEvent>
    {
        private readonly IEmailService _emailService;

        public MailerHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(EmailSentEvent notification, CancellationToken cancellationToken)
        {
            await _emailService.SendEmail(notification.Email, notification.Subject, notification.Body);
        }
    }
}
