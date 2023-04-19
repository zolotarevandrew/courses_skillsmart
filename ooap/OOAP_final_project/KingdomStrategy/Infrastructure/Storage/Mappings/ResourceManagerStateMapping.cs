using KingdomStrategy.Domain.Resources;
using MongoDB.Bson.Serialization;

namespace KingdomStrategy.Infrastructure.Storage.Mappings;

public class ResourceManagerStateMapping : FluentMapping<ResourceManagerState>
{
    public ResourceManagerStateMapping() : base("kingdom_resources")
    {
    }

    protected override Action<BsonClassMap<ResourceManagerState>> Map()
    {
        return cm =>
        {
            cm.MapField("_resources").SetElementName("resources");
            cm.AutoMap();
        };
    }
}