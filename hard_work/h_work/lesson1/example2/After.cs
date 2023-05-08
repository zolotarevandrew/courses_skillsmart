using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace h_work.lesson1.example2;

public class JsonCryptoWriter
{
    private readonly ICrypto _crypto;
    
    private static readonly Dictionary<Type, EncryptionStrategy> StrategyMap = new Dictionary<Type, EncryptionStrategy>
    {
        { typeof(string), new StringEncryptionStrategy(typeof(string)) },
        { typeof(DateTime), new DateTimeEncryptionStrategy(typeof(DateTime)) },
        { typeof(DateTime?), new DateTimeEncryptionStrategy(typeof(DateTime?)) },
    };

    public JsonCryptoWriter(ICrypto crypto)
    {
        _crypto = crypto;
    }

    public void WriteJson(JsonWriter writer, object value)
    {
        var jobj = JObject.FromObject(value);
        var encryptedProperties = value
            .GetType()
            .GetProperties()
            .Select(prop =>
            {
                var strategy = GetStrategy(prop.PropertyType);
                var newValue = strategy.Encrypt(jobj[prop.Name], _crypto);
                return new
                {
                    Name = prop.Name, 
                    Value = JToken.FromObject(newValue)
                };
            })
            .ToDictionary(x => x.Name, x => x.Value);

        jobj.ReplaceAll(encryptedProperties.Values);
        jobj.WriteTo(writer);
    }
    
    private static EncryptionStrategy GetStrategy(Type tokenType)
    {
        if (!tokenType.IsValueType && !StrategyMap.ContainsKey(tokenType))
        {
            return new ObjectEncryptionStrategy(tokenType);
        }

        return StrategyMap.GetValueOrDefault(tokenType, new EmptyEncryptionStrategy(tokenType));
    }
}