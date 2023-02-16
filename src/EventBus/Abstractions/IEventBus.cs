using EventBus.Events;

namespace EventBus.Abstractions
{
    public interface IEventBus
    {
        void Publish<T>(string queue, T message)
            where T : IntegrationEvent;

        void Consume<T>(string queue, Action<T> handler)
            where T : IntegrationEvent;
    }
}
