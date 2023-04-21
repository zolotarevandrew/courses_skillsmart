using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Infrastructure.Kingdoms;
using MongoDB.Driver;

namespace KingdomStrategy.Infrastructure.Storage;

public class KingdomStorage
{
    private readonly IMongoCollection<KingdomState> _collection;
    private readonly IMongoCollection<ByKingdomState> _kingdomStateCollection;
    public KingdomStorage(IMongoDatabase database)
    {
        var mapping = CollectionMappings.Get<KingdomState>();
        _collection = database.GetCollection<KingdomState>(mapping.CollectionName);
        
        var kingdomMapping = CollectionMappings.Get<ByKingdomState>();
        _kingdomStateCollection = database.GetCollection<ByKingdomState>(kingdomMapping.CollectionName);
    }

    public async Task<bool> Store(KingdomState kingdom)
    {
        var cursor = await _collection.FindAsync( k => k.Name == kingdom.Name);
        var res = cursor.FirstOrDefault();
        if (res != null) return false;
        
        await _collection.InsertOneAsync(kingdom);
        return true;
    }
    
    public async Task<List<KingdomState>> GetAll()
    {
        var cursor = await _collection.FindAsync( _ => true);
        return await cursor.ToListAsync();
    }
    
    public async Task<KingdomState?> GetByRef(KingdomRef kingdomRef)
    {
        var cursor = await _collection.FindAsync( f => f.Id == kingdomRef.Id);
        return await cursor.FirstOrDefaultAsync();
    }

    public async Task AddRelatedState(ByKingdomState byKingdomState)
    {
        await _kingdomStateCollection.ReplaceOneAsync(c => c.StateId == byKingdomState.StateId, byKingdomState, new ReplaceOptions
        {
            IsUpsert = true
        });
    }
    
    public async Task<List<ByKingdomState>> GetRelatedState(KingdomRef kingdomRef)
    {
        var cursor = await _kingdomStateCollection.FindAsync( f => f.KingdomId == kingdomRef.Id);
        return await cursor.ToListAsync();
    }
    
}