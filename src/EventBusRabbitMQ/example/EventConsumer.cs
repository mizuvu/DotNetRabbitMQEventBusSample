﻿using EventBus.Abstractions;

namespace EventBusRabbitMQ.example
{
    public class EventConsumer : BaseEventHandler<EventData>
    {
        const string _queue = "test-queue";

        public EventConsumer(IEventBus @event) : base(@event)
        {
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await ConsumeAsync();
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
    }
}
