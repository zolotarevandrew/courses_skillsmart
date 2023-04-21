using KingdomStrategy.Domain.Resources;
using KingdomStrategy.Domain.Resources.Implementations;
using MongoDB.Bson.Serialization;

namespace KingdomStrategy.Infrastructure.Storage.Mappings;

public class ResourceManagerStateMapping : FluentMapping<ResourceManagerState>
{
    public ResourceManagerStateMapping() : base("resources")
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

public class GoldMapping : FluentMapping<Gold>
{
    public GoldMapping() : base("")
    {
    }

    protected override Action<BsonClassMap<Gold>> Map()
    {
        return cm =>
        {
            cm.AutoMap();
        };
    }
}

public class WoodMapping : FluentMapping<Wood>
{
    public WoodMapping() : base("")
    {
    }

    protected override Action<BsonClassMap<Wood>> Map()
    {
        return cm =>
        {
            cm.AutoMap();
        };
    }
}

public class StoneMapping : FluentMapping<Stone>
{
    public StoneMapping() : base("")
    {
    }

    protected override Action<BsonClassMap<Stone>> Map()
    {
        return cm =>
        {
            cm.AutoMap();
        };
    }
}

public class FoodMapping : FluentMapping<Food>
{
    public FoodMapping() : base("")
    {
    }

    protected override Action<BsonClassMap<Food>> Map()
    {
        return cm =>
        {
            cm.AutoMap();
        };
    }
}