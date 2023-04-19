using KingdomStrategy.Domain.Resources;
using KingdomStrategy.Infrastructure.Kingdoms;
using MongoDB.Bson.Serialization;

namespace KingdomStrategy.Infrastructure.Storage.Mappings;

public class ResourceManagerStateMapping : FluentMapping<ResourceManagerState>
{
    public ResourceManagerStateMapping() : base("")
    {
    }

    protected override Action<BsonClassMap<ResourceManagerState>> Map()
    {
        return cm =>
        {
            cm.MapField("_resources").SetElementName("resources");
        };
    }
}

public class ByKingdomResourceManagerStateMapping : ByKingdomStateMapping<ResourceManagerState>
{
    public ByKingdomResourceManagerStateMapping() : base("kingdom_resources")
    {
    }
    
}