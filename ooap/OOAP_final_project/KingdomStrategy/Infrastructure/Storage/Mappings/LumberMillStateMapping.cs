using KingdomStrategy.Domain.Buildings.Implementations;
using KingdomStrategy.Infrastructure.Storage.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace KingdomStrategy.Infrastructure.Storage.Mappings;


public class StateMapping : FluentMapping<State>
{
    public StateMapping() : base("")
    {
    }

    protected override Action<BsonClassMap<State>> Map()
    {
        return cm =>
        {
            cm.MapIdProperty(c => c.Id)
                .SetElementName("id")
                .SetIdGenerator(StringObjectIdGenerator.Instance)
                .SetSerializer(new StringSerializer(BsonType.String));
        };
    }
}

public class LumberMillStateMapping : FluentMapping<LumberMillState>
{
    public LumberMillStateMapping() : base("lumber_mills")
    {
    }

    protected override Action<BsonClassMap<LumberMillState>> Map()
    {
        return cm =>
        {
            cm.AutoMap();
        };
    }
}

public class GoldMineStateMapping : FluentMapping<GoldMineState>
{
    public GoldMineStateMapping() : base("gold_mines")
    {
    }

    protected override Action<BsonClassMap<GoldMineState>> Map()
    {
        return cm =>
        {
            cm.AutoMap();
        };
    }
}