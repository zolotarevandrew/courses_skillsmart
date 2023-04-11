using System.Numerics;

namespace KingdomStrategy.Domain.Resources;

public class ResourceQuantity : Any, 
    IAdditionOperators<ResourceQuantity, ResourceQuantity,ResourceQuantity>,
    ISubtractionOperators<ResourceQuantity, ResourceQuantity, ResourceQuantity>
{
    public int Value { get; }
    public ResourceQuantity(int value)
    {
        Value = value;
    }

    public static ResourceQuantity operator +(ResourceQuantity left, ResourceQuantity right)
    {
        return new ResourceQuantity(left.Value + right.Value);
    }

    public static ResourceQuantity operator -(ResourceQuantity left, ResourceQuantity right)
    {
        var substraction = left.Value - right.Value;
        var res = substraction < 0 ? 0 : substraction;
        return new ResourceQuantity(res);
    }
}