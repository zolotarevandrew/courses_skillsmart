namespace KingdomStrategy.Domain.Resources;

public class RequestedResourcePool : Any
{
    private readonly Dictionary<ResourceType, ResourceQuantity> _typeByQuantity;

    public RequestedResourcePool(Dictionary<ResourceType, ResourceQuantity> typeByQuantity)
    {
        _typeByQuantity = typeByQuantity;
    }
}