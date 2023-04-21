using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Infrastructure.Storage;
using KingdomStrategy.Infrastructure.Storage.Interfaces;
using MongoDB.Driver;

namespace KingdomStrategy.Infrastructure.Kingdoms;


public record ByKingdomState 
{
    public ByKingdomState(KingdomRef @ref, string stateId, string stateType)
    {
        KingdomId = @ref.Id;
        KingdomName = @ref.Name;
        StateId = stateId;
        StateType = stateType;
    }
    public string KingdomId { get; init; }
    public string KingdomName { get; init; }
    public string StateId { get; init; }
    public string StateType { get; init; }
}

public class KingdomBaseStorageFactory
{
    private readonly IMongoDatabase _database;
    private readonly KingdomStorage _kingdomStorage;

    public KingdomBaseStorageFactory(IMongoDatabase database, KingdomStorage kingdomStorage)
    {
        _database = database;
        _kingdomStorage = kingdomStorage;
    }
    public KingdomBaseStorage<TEntity> Get<TEntity>(KingdomRef @ref) 
        where TEntity : State
    {
        return new KingdomBaseStorage<TEntity>(@ref, _database, _kingdomStorage);
    }
}

public class KingdomBaseStorage<TEntity> : StateStore<TEntity>
    where TEntity : State
{
    private readonly KingdomRef _ref;
    private readonly IMongoCollection<TEntity> _collection;
    private readonly KingdomStorage _kingdomStorage;
    public KingdomBaseStorage(KingdomRef @ref, IMongoDatabase database, KingdomStorage kingdomStorage)
    {
        _ref = @ref;
        _kingdomStorage = kingdomStorage;
        var mapping = CollectionMappings.Get<TEntity>();
        _collection = database.GetCollection<TEntity>(mapping.CollectionName);
    }

    public override async Task Save(TEntity state)
    {
        if (string.IsNullOrEmpty(state.Id))
        {
            await _collection.InsertOneAsync(state);
        }
        else
        {
            await _collection.ReplaceOneAsync(c => c.Id == state.Id, state, new ReplaceOptions
            {
                IsUpsert = true
            });
        }

        var byKingdomState = new ByKingdomState(_ref, state.Id, typeof(TEntity).Name);
        await _kingdomStorage.AddRelatedState(byKingdomState);
    }

    public async Task<List<TEntity>> Load(List<string> ids)
    {
        var cursor = await _collection.FindAsync(Builders<TEntity>.Filter.In("_id", ids));
        return await cursor.ToListAsync();
    }
    
    public async Task<TEntity> Load(string id)
    {
        var cursor = await _collection.FindAsync( c => c.Id == id);
        return await cursor.FirstOrDefaultAsync();
    }
}

