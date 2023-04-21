using KingdomStrategy.Domain.Armies.Troops;
using KingdomStrategy.Domain.Buildings.Constructors;
using KingdomStrategy.Domain.Kingdoms.Events;
using KingdomStrategy.Infrastructure;

namespace KingdomStrategy.Domain.Kingdoms.Ratings;

public abstract class KingdomRatingRule : Any
{
    protected KingdomRatingRule(string name)
    {
        Name = name;
    }

    public string Name { get; init; }

    public abstract Task<KingdomRating> Calculate(KingdomEvent @event);
}

public class TroopRatingRule : KingdomRatingRule
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public TroopRatingRule(IDateTimeProvider dateTimeProvider) : base("trooprating")
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public override async Task<KingdomRating> Calculate(KingdomEvent @event)
    {
        if (@event.Payload is TroopAttackedOpponentEvent or TroopAttackedOpponentEvent)
        {
            return new KingdomRating(@event.Kingdom, 10, _dateTimeProvider.UtcNow); 
        }

        return new KingdomRating(@event.Kingdom, 0, _dateTimeProvider.UtcNow);
    }
}

public class BuildingRule : KingdomRatingRule
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public BuildingRule(IDateTimeProvider dateTimeProvider) : base("buildingrule")
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public override async Task<KingdomRating> Calculate(KingdomEvent @event)
    {
        if (@event.Payload is BuildingConstructedEvent or BuildingModernizedEvent)
        {
            return new KingdomRating(@event.Kingdom, 20, _dateTimeProvider.UtcNow); 
        }

        return new KingdomRating(@event.Kingdom, 0, _dateTimeProvider.UtcNow);
    }
}

