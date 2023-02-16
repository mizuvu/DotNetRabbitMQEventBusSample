using EventBus.Abstractions;
using EventBus.Events;
using Microsoft.Extensions.Hosting;

namespace EventBusRabbitMQ
{
    public abstract class HostedEventHandler<T> : IHostedService, IEventHandler<T>
        where T : IntegrationEvent
    {
        private readonly IEventBus _event;

        protected HostedEventHandler(IEventBus @event)
        {
            _event = @event;
        }

        public void Consume(string queue, Action<T> handler)
        {
            _event.Consume(queue, handler);
        }

        public abstract Task StartAsync(CancellationToken cancellationToken);

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _event.Dispose();
            return Task.CompletedTask;
        }
    }
}
