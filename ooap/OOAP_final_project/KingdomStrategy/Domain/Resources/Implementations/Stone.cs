namespace KingdomStrategy.Domain.Resources.Implementations;

public class Stone : Resource
{
    public Stone(ResourceQuantity quantity) : base(ResourceType.Stone, "Stone", quantity)
    {
    }
}