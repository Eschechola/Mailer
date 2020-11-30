using Mailer.Core.Communication.Mediator;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mailer.Core.Messages.CommonMessages.IntegrationEvents;
using Mailer.Data.Entities;
using Mailer.Data.Interfaces;

namespace Mailer.Data.Services
{
    public class MailService : IMailService
    {
        private readonly IMailRepository _mailRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public MailService(IMailRepository mailRepository, IMediatorHandler mediatorHandler)
        {
            _mailRepository = mailRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<Mail> Sent(Mail mail)
        {
            await _mailRepository.Add(mail);

            await _mediatorHandler.PublishEvent(new EmailSentEvent(mail.Email, mail.Subject, mail.Body));

            mail.UpdateToEmailSent();

            await _mailRepository.Update(mail);

            return mail;
        }

        public async Task<List<Mail>> Get()
        {
            return await _mailRepository.Get();
        }

        public async Task<List<Mail>> Get(string id)
        {
            return await _mailRepository.Get(id);
        }

        public async Task<List<Mail>> GetSents()
        {
            return await _mailRepository.GetSents();
        }
    }
}
