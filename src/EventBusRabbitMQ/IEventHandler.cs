using EventBus.Events;

namespace EventBusRabbitMQ
{
    public interface IEventHandler<T>
         where T : IntegrationEvent
    {
        void Consume(string queue, Action<T> handler);
    }
}
