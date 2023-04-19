namespace KingdomStrategy.Domain.Resources.Implementations;

public class Wood : Resource
{
    public Wood(ResourceQuantity quantity) : base(ResourceType.Wood, "Wood", quantity)
    {
    }
}