using KingdomStrategy.Infrastructure.Kingdoms;
using MongoDB.Bson.Serialization;

namespace KingdomStrategy.Infrastructure.Storage.Mappings;


public class ByKingdomStateMapping : FluentMapping<ByKingdomState>
{
    protected override Action<BsonClassMap<ByKingdomState>> Map()
    {
        return cm =>
        {
            cm.AutoMap();
        };
    }

    public ByKingdomStateMapping() : base("kingdom_states")
    {
    }
}