namespace KingdomStrategy.Infrastructure;

using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;

public abstract class FluentMapping
{
    public string? CollectionName { get; protected set; }
    public Type? Type { get; protected set; }
    public abstract void Register();
}

public abstract class FluentMapping<TEntity> : FluentMapping
{
    protected FluentMapping(string collectionName)
    {
        ToCollection(collectionName);
    }
    protected abstract Action<BsonClassMap<TEntity>> Map();
    public override void Register()
    {
        BsonClassMap.RegisterClassMap(Map());
    }

    void ToCollection(string name)
    {
        Type = typeof(TEntity);
        CollectionName = name;
    }
}

internal class CollectionMappings
{
    internal static bool _inited = false;
    
    internal static void Init()
    {
        if (_inited) return;
        
        var conventionPack = new ConventionPack
        {
            new CamelCaseElementNameConvention(),
            new IgnoreExtraElementsConvention(true)
        };
        ConventionRegistry.Register("camelCase", conventionPack, t => true);
        _inited = true;
        
    }
    
    private static List<FluentMapping> _value = new ();
    internal static IReadOnlyList<FluentMapping> Value => _value;
    
    internal static void Add(FluentMapping mapping)
    {
        if (!_inited) 
            throw new InvalidOperationException("First register mongodb module, then add mappings");
        
        if (!_value.Any(v => v.Type == mapping.Type))
        {
            mapping.Register();
            _value.Add(mapping);    
        }
    }

    internal static FluentMapping? Get<TEntity>()
    {
        return _value
            .Where(v => !string.IsNullOrEmpty(v.CollectionName))
            .Where(v => v.Type != null && v.Type.Equals(typeof(TEntity)))
            .FirstOrDefault();
    }
}