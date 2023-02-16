using EventBus.Events;

namespace EventBusRabbitMQ.example
{
    public class EventData : IntegrationEvent
    {
        public string Message { get; set; } = string.Empty;
    }
}
