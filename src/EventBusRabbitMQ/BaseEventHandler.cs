using EventBus.Abstractions;
using EventBus.Events;
using Microsoft.Extensions.Hosting;

namespace EventBusRabbitMQ
{
    public abstract class BaseEventHandler<T> : BackgroundService, IEventHandler<T>
        where T : IntegrationEvent
    {
        private readonly IEventBus _event;

        protected BaseEventHandler(IEventBus @event)
        {
            _event = @event;
        }

        public void Consume(string queue, Action<T> handler)
        {
            _event.Consume(queue, handler);
        }
    }
}
