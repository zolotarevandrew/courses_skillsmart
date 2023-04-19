namespace KingdomStrategy.Domain.Resources.Implementations;

public class Gold : Resource
{
    public Gold(ResourceQuantity quantity) : base(ResourceType.Gold, "Gold", quantity)
    {
    }
}