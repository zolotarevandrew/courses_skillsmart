using KingdomStrategy.Domain.Kingdoms;
using MongoDB.Bson.Serialization;

namespace KingdomStrategy.Infrastructure.Storage.Mappings;

public class KingdomMapping : FluentMapping<KingdomState>
{
    protected override Action<BsonClassMap<KingdomState>> Map()
    {
        return cm =>
        {
            cm.AutoMap();
        };
    }

    public KingdomMapping() : base("kingdoms")
    {
    }
}