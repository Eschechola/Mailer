using Mailer.Core.Messages;
using System.Threading.Tasks;

namespace Mailer.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T eventSend) where T : Event;
    }
}
