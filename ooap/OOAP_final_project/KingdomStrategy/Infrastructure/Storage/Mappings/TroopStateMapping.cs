using KingdomStrategy.Domain.Armies.Troops;
using MongoDB.Bson.Serialization;

namespace KingdomStrategy.Infrastructure.Storage.Mappings;


public class TroopStateMapping : FluentMapping<TroopState>
{
    public TroopStateMapping() : base("troops")
    {
    }

    protected override Action<BsonClassMap<TroopState>> Map()
    {
        return cm =>
        {
            cm.AutoMap();
        };
    }
}