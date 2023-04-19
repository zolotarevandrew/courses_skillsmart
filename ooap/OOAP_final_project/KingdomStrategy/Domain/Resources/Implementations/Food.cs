namespace KingdomStrategy.Domain.Resources.Implementations;

public class Food : Resource
{
    public Food(ResourceQuantity quantity) : base(ResourceType.Food, "Food", quantity)
    {
    }
}