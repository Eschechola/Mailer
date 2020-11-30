using MediatR;
using Mailer.Core.Messages;
using System.Threading.Tasks;

namespace Mailer.Core.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishEvent<T>(T eventSend) where T : Event
        {
            await _mediator.Publish(eventSend);
        }
    }
}
 