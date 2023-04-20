using KingdomStrategy.Domain.Kingdoms;
using MongoDB.Driver;

namespace KingdomStrategy.Infrastructure.Storage;

public class KingdomStorage
{
    private readonly IMongoCollection<KingdomState> _collection;

    public KingdomStorage(IMongoDatabase database)
    {
        var mapping = CollectionMappings.Get<KingdomState>();
        _collection = database.GetCollection<KingdomState>(mapping.CollectionName);
    }

    public async Task<bool> Store(KingdomState kingdom)
    {
        var cursor = await _collection.FindAsync( k => k.Name == kingdom.Name);
        var res = cursor.FirstOrDefault();
        if (res != null) return false;
        
        await _collection.InsertOneAsync(kingdom);
        return true;
    }
    
    public async Task<List<KingdomState>> GetAll(CancellationToken token = default)
    {
        var cursor = await _collection.FindAsync( _ => true, cancellationToken: token);
        return await cursor.ToListAsync(cancellationToken: token);
    }
}