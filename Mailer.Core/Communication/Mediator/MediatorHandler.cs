namespace Mailer.Core.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        Task PublishEvent<T>(T evento) where T : Event;
    }
}
