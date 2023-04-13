using KingdomStrategy.Domain.Kingdoms.Events;

namespace KingdomStrategy.Domain.Kingdoms.Ratings;

public abstract class KingdomRatingRule : Any
{
    protected KingdomRatingRule(string name)
    {
        Name = name;
    }

    public string Name { get; init; }
    
    public async Task<KingdomRating> Calculate(KingdomEvent @event)
    {
        return null;
    }
}