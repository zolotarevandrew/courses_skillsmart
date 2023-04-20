namespace KingdomStrategy.Domain.Kingdoms.Events;


public class KingdomEvent
{
    public KingdomRef Kingdom { get; init; }
    public object Payload { get; init; }
}