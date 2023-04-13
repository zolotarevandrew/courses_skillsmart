namespace KingdomStrategy.Domain.Resources;

public class RequestedResourcePool : Any
{
    public List<Resource> Items { get; init; }

    public RequestedResourcePool(List<Resource> items)
    {
        Items = items;
    }
}