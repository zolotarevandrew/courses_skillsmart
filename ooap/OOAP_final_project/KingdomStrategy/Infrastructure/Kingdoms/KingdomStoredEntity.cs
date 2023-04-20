using KingdomStrategy.Domain.Kingdoms;
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
    private readonly IMongoCollection<TEntity> _collection;
    private readonly IMongoCollection<ByKingdomState> _kingdomStateCollection;
    public KingdomBaseStorage(KingdomRef @ref, IMongoDatabase database)
    {
        _ref = @ref;
        var mapping = CollectionMappings.Get<TEntity>();
        _collection = database.GetCollection<TEntity>(mapping.CollectionName);
        
        var kingdomMapping = CollectionMappings.Get<ByKingdomState>();
        _kingdomStateCollection = database.GetCollection<ByKingdomState>(kingdomMapping.CollectionName);
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
        await _kingdomStateCollection.ReplaceOneAsync(c => c.StateId == byKingdomState.StateId, byKingdomState, new ReplaceOptions
        {
            IsUpsert = true
        });
    }
}

