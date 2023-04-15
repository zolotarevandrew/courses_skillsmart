using KingdomStrategy.Domain.Kingdoms;
using MongoDB.Driver;

namespace KingdomStrategy.Infrastructure.Kingdoms;

public abstract class KingdomStoredEntity
{
    public string Id { get; init; }
    public string Name { get; init; }

    protected KingdomStoredEntity(KingdomRef @ref)
    {
        Id = @ref.Id;
        Name = @ref.Name;
    }
}

public class KingdomStoredEntity<TValue> : KingdomStoredEntity
{
    public KingdomStoredEntity(KingdomRef @ref, TValue value) : base(@ref)
    {
        Value = value;
    }
    public TValue Value { get; init; }
}

public abstract class KingdomBaseStorage<TEntity> where TEntity : KingdomStoredEntity
{
    private readonly IMongoCollection<KingdomStoredEntity<TEntity>> _collection;
    protected KingdomBaseStorage(IMongoDatabase database)
    {
        var mapping = CollectionMappings.Get<TEntity>();
        _collection = database.GetCollection<KingdomStoredEntity<TEntity>>(mapping.CollectionName);
    }

    public async Task<TEntity?> GetByRef(KingdomRef @ref, CancellationToken cancellationToken = default)
    {
        var cursor = await _collection.FindAsync(c => c.Id == @ref.Id, cancellationToken: cancellationToken);
        var kingdomEntity = await cursor.FirstOrDefaultAsync(cancellationToken: cancellationToken);
        return kingdomEntity?.Value;
    }
    
    public async Task ApplyChanges(KingdomRef @ref, TEntity value, CancellationToken cancellationToken = default)
    {
        var entity = new KingdomStoredEntity<TEntity>(@ref, value);
        await _collection.ReplaceOneAsync(c => c.Id == @ref.Id, entity, new ReplaceOptions
        {
            IsUpsert = true
        }, cancellationToken);
    }
}

public class KingdomStorageFactory
{
    private readonly IServiceProvider _serviceProvider;

    public KingdomStorageFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public KingdomBaseStorage<TEntity> Get<TEntity>(KingdomRef @kingdomRef) 
        where TEntity : KingdomStoredEntity
    {
        return _serviceProvider.GetRequiredService<KingdomBaseStorage<TEntity>>();
    }
}

