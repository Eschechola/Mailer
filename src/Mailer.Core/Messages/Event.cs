using System;
using MediatR;


namespace Mailer.Core.Messages
{
    public abstract class Event : INotification
    {
        public DateTime TimeStamp { get; private set; }

        public Event()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
