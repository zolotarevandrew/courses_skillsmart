using KingdomStrategy.Domain.Kingdoms.Events;
using KingdomStrategy.Infrastructure;
using KingdomStrategy.Infrastructure.Storage;

namespace KingdomStrategy.Domain.Kingdoms.Ratings.EventHandlers;

public class KingdomRatingRecalculatedEvent
{
    public KingdomRating Rating { get; init; }
}
public class KingdomRatingRecalculatedMessageHandler : IMessageHandler<KingdomRatingRecalculatedEvent>
{
    private readonly KingdomRatingStorage _storage;
    public KingdomRatingRecalculatedMessageHandler(KingdomRatingStorage storage)
    {
        _storage = storage;
    }
    
    public Task Handle(KingdomRatingRecalculatedEvent message, CancellationToken cancellationToken = default)
    {
        return _storage.Store(message.Rating, cancellationToken);
    }
}