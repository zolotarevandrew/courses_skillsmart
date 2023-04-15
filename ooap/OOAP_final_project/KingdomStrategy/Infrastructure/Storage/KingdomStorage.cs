using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Domain.Resources;
using MongoDB.Driver;

namespace KingdomStrategy.Infrastructure.Storage;

public class Gold : Resource
{
    public Gold(ResourceQuantity quantity) : base(ResourceType.Gold, "Gold", quantity)
    {
    }
}

public abstract class KingdomStoredEntity
{
    public string Id { get; init; }
    public string Name { get; init; }

    protected KingdomStoredEntity(KingdomRef @ref)
    {
        Id = @ref.Value;
        Name = @ref.Name;
    }
}

public class KingdomResource : KingdomStoredEntity
{
    public Resource Resource { get; init; }

    public KingdomResource(
        KingdomRef @ref, 
        Resource resource) : base(@ref)
    {
        Resource = resource;
    }
}

public class KingdomStorage
{
    private readonly IMongoCollection<KingdomResource> _collection;
    public KingdomStorage(IMongoDatabase database)
    {
        _collection = database.GetCollection<KingdomResource>("resources");
    }

    public async Task<List<Resource>> GetByRef(KingdomRef @ref)
    {
        var resource = new Gold(new ResourceQuantity(15));
        await _collection.InsertOneAsync(new KingdomResource(@ref, resource));
        var found = (await _collection.FindAsync(c => c.Id == @ref.Value)).FirstOrDefault();
        return new List<Resource>();
    }
}