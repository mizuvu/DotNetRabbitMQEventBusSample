namespace EventBus.Events;

public class IntegrationEvent
{
    protected IntegrationEvent() => Id = Guid.NewGuid();

    public DateTime CreationDate { get; set; } = DateTime.UtcNow;

    public Guid Id { get; set; } = Guid.NewGuid();
}