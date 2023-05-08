using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace h_work.lesson1.example2;


public interface ICrypto
{
    string Encrypt(string str);
    string Decrypt(string str);
}

public class Crypto : ICrypto
{
    public string Encrypt(string str)
    {
        return str;
    }

    public string Decrypt(string str)
    {
        return str;
    }
}

public class L1Example2
{
    private readonly ICrypto? _crypto;

    public L1Example2(ICrypto? crypto)
    {
        _crypto = crypto;
    }
    
    public void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        if (_crypto is null)
        {
            writer.WriteValue(value);
        }

        JObject jobj = null;
        try
        {
            jobj = JObject.FromObject(value);
        }
        catch
        {
            // banana.
        }

        if (jobj is null)
        {
            writer.WriteValue(value);
            return;
        }

        var props = value.GetType().GetProperties();

        foreach (var prop in props)
        {
            var strategy = GetStrategy(prop.PropertyType);
            var newValue = strategy.Encrypt(jobj[prop.Name], _crypto);
            jobj[prop.Name] = JToken.FromObject(newValue);
        }

        jobj.WriteTo(writer);
    }

    private static EncryptionStrategy GetStrategy(Type tokenType)
    {
        if (tokenType == typeof(string))
        {
            return new StringEncryptionStrategy(tokenType);
        }
        else if (tokenType == typeof(DateTime) || tokenType == typeof(DateTime?))
        {
            return new DateTimeEncryptionStrategy(tokenType);
        }
        else if (!tokenType.IsValueType)
        {
            return new ObjectEncryptionStrategy(tokenType);
        }
        else
        {
            return new EmptyEncryptionStrategy(tokenType);
        }
    }
}

 public abstract class EncryptionStrategy
    {
        private readonly Type _type;

        public EncryptionStrategy(Type type)
        {
            _type = type;
        }
        public abstract object Encrypt(JToken input, ICrypto crypto);
        public abstract object Decrypt(JToken input, ICrypto crypto);
    }

public class EmptyEncryptionStrategy : EncryptionStrategy
{
    public override object Decrypt(JToken input, ICrypto crypto)
    {
        return input;
    }

    public override object Encrypt(JToken input, ICrypto crypto)
    {
        return input;
    }

    public EmptyEncryptionStrategy(Type type) : base(type)
    {
    }
}

public class StringEncryptionStrategy : EmptyEncryptionStrategy
{
    public StringEncryptionStrategy(Type type) : base(type)
    {
    }
}

public class DateTimeEncryptionStrategy : EmptyEncryptionStrategy
{
    public DateTimeEncryptionStrategy(Type type) : base(type)
    {
    }
}

public class ObjectEncryptionStrategy : EmptyEncryptionStrategy
{
    public ObjectEncryptionStrategy(Type type) : base(type)
    {
    }
}

