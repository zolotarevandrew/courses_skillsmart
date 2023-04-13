using KingdomStrategy.Domain.Kingdoms.Ratings;

namespace KingdomStrategy.Infrastructure.Storage;

public class KingdomRatingStorage
{
    public KingdomRatingStorage()
    {
        
    }

    public async Task Store(KingdomRating rating, CancellationToken token = default)
    {
        
    }
    
    public async Task<List<KingdomRating>> GetAll(CancellationToken token = default)
    {
        return null;
    }
}