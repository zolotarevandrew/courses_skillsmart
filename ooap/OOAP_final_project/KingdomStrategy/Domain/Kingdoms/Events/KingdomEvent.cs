using KingdomStrategy.Domain.Kingdoms.Ratings;

namespace KingdomStrategy.Domain.Kingdoms.Events;

public abstract class KingdomEvent
{
    public KingdomRef Kingdom { get; init; }
}