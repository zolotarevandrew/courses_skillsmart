using KingdomStrategy.Domain.Kingdoms.Events;
using KingdomStrategy.Domain.Kingdoms.Ratings.EventHandlers;
using KingdomStrategy.Infrastructure;
using KingdomStrategy.Infrastructure.Storage;

namespace KingdomStrategy.Domain.Kingdoms.Ratings;

public class KingdomRatingManager : Any
{
    private readonly List<KingdomRatingRule> _rules;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IMediator _mediator;
    private readonly KingdomRatingStorage _ratingStorage;
    public KingdomRatingManager(
        List<KingdomRatingRule> rules,
        IDateTimeProvider dateTimeProvider, 
        IMediator mediator, KingdomRatingStorage ratingStorage)
    {
        _rules = rules;
        _dateTimeProvider = dateTimeProvider;
        _mediator = mediator;
        _ratingStorage = ratingStorage;
    }

    public async Task Recalculate(KingdomEvent kingdomEvent)
    {
        var newRating = await _ratingStorage.GetByRef(kingdomEvent.Kingdom);
        foreach (var rule in _rules) {
            var rating = await rule.Calculate(kingdomEvent);
            newRating = newRating.Add(rating, _dateTimeProvider.UtcNow);
        }

        await _mediator.Publish(new KingdomRatingRecalculatedEvent
        {
            Rating = newRating
        });
    }
}