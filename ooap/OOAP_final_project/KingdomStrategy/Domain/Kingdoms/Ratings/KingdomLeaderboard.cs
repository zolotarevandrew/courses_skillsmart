using KingdomStrategy.Infrastructure.Storage;

namespace KingdomStrategy.Domain.Kingdoms.Ratings;

public class KingdomLeaderboard : Any
{
    private readonly KingdomRatingStorage _storage;

    public KingdomLeaderboard(KingdomRatingStorage storage)
    {
        _storage = storage;
    }
    public async Task<KingdomRating> GetByKingdom(KingdomRef kingdom)
    {
        var all = await GetAll();
        return all.FirstOrDefault(c => c.Ref == kingdom);
    }
    
    public Task<List<KingdomRating>> GetAll()
    {
        return _storage.GetAll();
    }
    
    public async Task<List<KingdomRating>> GetLastLeaders(int leaders = 5)
    {
        var all = await _storage.GetAll();
        return all
            .OrderByDescending(t => t.Value)
            .Take(leaders)
            .ToList();
    }
}