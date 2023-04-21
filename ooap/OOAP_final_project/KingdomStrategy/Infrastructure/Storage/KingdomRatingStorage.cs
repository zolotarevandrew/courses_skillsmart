using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Domain.Kingdoms.Ratings;
using MongoDB.Driver;

namespace KingdomStrategy.Infrastructure.Storage;

public class KingdomRatingStorage
{
    private readonly IMongoCollection<KingdomRating> _collection;

    public KingdomRatingStorage(IMongoDatabase database)
    {
        _collection = database.GetCollection<KingdomRating>("kingdom_ratings");
    }

    public async Task Store(KingdomRating rating, CancellationToken token = default)
    {
        await _collection.ReplaceOneAsync(c => c.Ref.Id == rating.Ref.Id, rating, new ReplaceOptions
        {
            IsUpsert = true
        }, cancellationToken: token);
    }
    
    public async Task<KingdomRating?> GetByRef(KingdomRef kingdomRef)
    {
        var cursor = await _collection.FindAsync( f => f.Ref.Id == kingdomRef.Id);
        return cursor.FirstOrDefault();
    } 
    
    public async Task<List<KingdomRating>> GetAll(CancellationToken token = default)
    {
        var cursor = await _collection.FindAsync( _ => true, cancellationToken: token);
        return await cursor.ToListAsync(cancellationToken: token);
    }
}