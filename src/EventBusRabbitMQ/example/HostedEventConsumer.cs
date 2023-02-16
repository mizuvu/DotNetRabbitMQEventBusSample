using EventBus.Abstractions;

namespace EventBusRabbitMQ.example
{
    public class HostedEventConsumer : HostedEventHandler<EventData>
    {
        const string _queue = MessageQueue.Queue;

        public HostedEventConsumer(IEventBus @event) : base(@event)
        {
        }

        private async Task ConsumeAsync()
        {
            Consume(_queue, async data =>
            {
                Console.WriteLine($"----- [RabbitMQ] Message received: {data.Id}");
                await WriteValueAsync(data);
            });

            await Task.CompletedTask;
        }

        public static async Task WriteValueAsync(EventData data)
        {
            Console.WriteLine($"----- [RabbitMQ] Message received: {data.Message}");
            await Task.CompletedTask;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            await ConsumeAsync();
        }
    }
}
