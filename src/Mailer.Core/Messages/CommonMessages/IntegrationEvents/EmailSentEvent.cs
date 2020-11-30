using System;
using Mailer.Core.Messages.CommonMessages.Base;

namespace Mailer.Core.Messages.CommonMessages.IntegrationEvents
{
    public class EmailSentEvent : IntegrationEvent
    {
        public EmailSentEvent(string email, string subject, string body)
        {
            Email = email;
            Subject = subject;
            Body = body;
            SendDate = DateTime.Now;
        }

        public string Email { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }
        public DateTime SendDate { get; private set; }

    }
}
