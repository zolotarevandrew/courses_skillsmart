using KingdomStrategy.Infrastructure.Kingdoms;
using KingdomStrategy.Infrastructure.Storage.Interfaces;
using MongoDB.Bson.Serialization;

namespace KingdomStrategy.Infrastructure.Storage.Mappings;


public abstract class ByKingdomStateMapping<TValue> : FluentMapping<ByKingdomState<TValue>> 
    where TValue : State
{
    protected override Action<BsonClassMap<ByKingdomState<TValue>>> Map()
    {
        return cm =>
        {
            cm.AutoMap();
            cm.MapProperty("Value");
        };
    }

    protected ByKingdomStateMapping(string collectionName) : base(collectionName)
    {
    }
}