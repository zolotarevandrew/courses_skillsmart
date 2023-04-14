namespace KingdomStrategy.Domain.Resources;
public class ResourcePool : Any
{
    private readonly Dictionary<ResourceType, Resource> _resourceByType;

    public ResourcePool(IEnumerable<Resource> items)
    {
        _resourceByType = items
            .ToDictionary(c => c.Type, c => c);
    }
}