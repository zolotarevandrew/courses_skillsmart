using KingdomStrategy.Domain.Kingdoms.Events;
using KingdomStrategy.Domain.Kingdoms.Ratings.EventHandlers;
using KingdomStrategy.Infrastructure;

namespace KingdomStrategy.Domain.Kingdoms.Ratings;

public class KingdomRatingManager : Any
{
    private readonly List<KingdomRatingRule> _rules;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IMediator _mediator;
    public KingdomRatingManager(
        IDateTimeProvider dateTimeProvider, 
        IMediator mediator)
    {
        //TODO _rules = rules;
        _dateTimeProvider = dateTimeProvider;
        _mediator = mediator;
    }

    public async Task Recalculate(KingdomEvent kingdomEvent)
    {
        var newRating = new KingdomRating(kingdomEvent.Kingdom, 0, _dateTimeProvider.UtcNow);
        foreach (var rule in _rules) {
            var rating = await rule.Calculate(kingdomEvent);
            newRating.Add(rating, _dateTimeProvider.UtcNow);
        }

        await _mediator.Publish(new KingdomRatingRecalculatedEvent
        {
            Rating = newRating
        });
    }
}