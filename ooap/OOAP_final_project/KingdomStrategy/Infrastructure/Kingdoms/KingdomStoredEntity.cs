using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Infrastructure.Storage.Interfaces;
using MongoDB.Driver;

namespace KingdomStrategy.Infrastructure.Kingdoms;

public abstract class ByKingdomState
{
    public string Id { get; init; }
    public string Name { get; init; }

    protected ByKingdomState(KingdomRef @ref)
    {
        Id = @ref.Id;
        Name = @ref.Name;
    }
}

public class ByKingdomState<TValue> : ByKingdomState 
    where TValue: State
{
    
    public ByKingdomState(KingdomRef @ref, TValue value) : base(@ref)
    {
        Value = value;
    }
    
    public TValue Value { get; init; }
}

public class KingdomBaseStorageFactory
{
    private readonly IMongoDatabase _database;

    public KingdomBaseStorageFactory(IMongoDatabase database)
    {
        _database = database;
    }
    public KingdomBaseStorage<TEntity> Get<TEntity>(KingdomRef @ref) 
        where TEntity : State
    {
        return new KingdomBaseStorage<TEntity>(@ref, _database);
    }
}

public class KingdomBaseStorage<TEntity> : StateStore<TEntity>
    where TEntity : State
{
    private readonly KingdomRef _ref;
    private readonly IMongoCollection<ByKingdomState<TEntity>> _collection;
    public KingdomBaseStorage(KingdomRef @ref, IMongoDatabase database)
    {
        _ref = @ref;
        var mapping = CollectionMappings.Get<ByKingdomState<TEntity>>();
        _collection = database.GetCollection<ByKingdomState<TEntity>>(mapping.CollectionName);
    }

    public async Task<TEntity?> Get()
    {
        var cursor = await _collection.FindAsync(c => c.Id == _ref.Id);
        var kingdomEntity = await cursor.FirstOrDefaultAsync();
        return kingdomEntity?.Value;
    }
    
    public override async Task Save(TEntity state)
    {
        var byKingdomState = new ByKingdomState<TEntity>(_ref, state);
        await _collection.ReplaceOneAsync(c => c.Id == _ref.Id, byKingdomState, new ReplaceOptions
        {
            IsUpsert = true
        });
    }
}

