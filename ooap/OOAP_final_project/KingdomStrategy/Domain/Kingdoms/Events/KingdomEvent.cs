namespace KingdomStrategy.Domain.Kingdoms.Events;

public class KingdomEvent<TPayload> : KingdomEvent
{
    public TPayload Payload { get; init; }
}

public class KingdomEvent
{
    public KingdomRef Kingdom { get; init; }
}