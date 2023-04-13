using KingdomStrategy.Domain.Kingdoms.Events;
using KingdomStrategy.Infrastructure;

namespace KingdomStrategy.Domain.Kingdoms.Ratings.EventHandlers;


public class KingdomEventMessageHandler : IMessageHandler<KingdomEvent>
{
    private readonly KingdomRatingManager _storage;

    public KingdomEventMessageHandler(KingdomRatingManager storage)
    {
        _storage = storage;
    }

    public Task Handle(KingdomEvent message, CancellationToken cancellationToken = default)
    {
        return _storage.Recalculate(message);
    }
}