using System;

namespace Mailer.Data.Entities
{
    public class Mail
    {
        public string Id { get; private set; }
        public string Email { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }
        public bool IsSent { get; private set; }
        public DateTime? DateSent { get; set; }

        protected Mail() { }

        public Mail(string email, string subject, string body, DateTime? dateSent = null)
        {
            Id = Guid.NewGuid().ToString();
            Email = email;
            Subject = subject;
            Body = body;
            IsSent = false;
            DateSent = dateSent;
        }

        public void UpdateToEmailSent()
        {
            IsSent = true;
            DateSent = DateTime.Now;
        }
    }
}
