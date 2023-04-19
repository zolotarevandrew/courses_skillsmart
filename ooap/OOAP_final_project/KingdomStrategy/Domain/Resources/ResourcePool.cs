namespace KingdomStrategy.Domain.Resources;
public class ResourcePool : Any
{
    private readonly Dictionary<ResourceType, Resource> _resourceByType;

    public ResourcePool(IEnumerable<Resource> items)
    {
        _resourceByType = items
            .ToDictionary(c => c.Type, c => c);
    }

    public Resource Get(ResourceType type)
    {
        return _resourceByType[type];
    }
}