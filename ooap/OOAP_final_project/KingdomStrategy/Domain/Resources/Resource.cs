namespace KingdomStrategy.Domain.Resources;

public enum ResourceType
{
    Gold = 1,
    Food = 2,
    Stone = 3,
    Wood = 4,
}

public abstract class Resource : Any
{
    public string Name { get; private set; }
    public ResourceQuantity Quantity { get; private set; }
    public ResourceType Type { get; private set; }

    protected Resource(ResourceType type, string name, ResourceQuantity quantity)
    {
        Type = type;
        Name = name;
        Quantity = quantity;
    }

    public void AddQuantity(ResourceQuantity quantity)
    {
        Quantity += quantity;
    }

    public bool ConsumeQuantity(ResourceQuantity consumed)
    {
        if (!Quantity.GreaterOrEqual(consumed)) return false;
        
        Quantity -= consumed;
        return true;

    }
}