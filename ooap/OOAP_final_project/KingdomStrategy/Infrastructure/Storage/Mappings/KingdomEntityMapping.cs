using KingdomStrategy.Infrastructure.Kingdoms;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace KingdomStrategy.Infrastructure.Storage.Mappings;


public class KingdomEntityMapping : FluentMapping<KingdomStoredEntity>
{
    protected override Action<BsonClassMap<KingdomStoredEntity>> Map()
    {
        return cm =>
        {
            cm.MapIdProperty(c => c.Id)
                .SetElementName("id")
                .SetIdGenerator(StringObjectIdGenerator.Instance)
                .SetSerializer(new StringSerializer(BsonType.String));
        };
    }

    public KingdomEntityMapping() : base("")
    {
    }
}