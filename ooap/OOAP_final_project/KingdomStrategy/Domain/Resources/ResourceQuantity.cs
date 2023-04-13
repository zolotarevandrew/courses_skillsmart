using System.Numerics;

namespace KingdomStrategy.Domain.Resources;

public class ResourceQuantity : Any,
    IAdditionOperators<ResourceQuantity, ResourceQuantity,ResourceQuantity>,
    ISubtractionOperators<ResourceQuantity, ResourceQuantity, ResourceQuantity>
{
    public uint Value { get; }
    public ResourceQuantity(uint value)
    {
        Value = value;
    }

    public bool GreaterOrEqual(ResourceQuantity quantity)
    {
        return Value >= quantity.Value;
    }

    public static ResourceQuantity operator +(ResourceQuantity left, ResourceQuantity right)
    {
        return new ResourceQuantity(left.Value + right.Value);
    }

    public static ResourceQuantity operator -(ResourceQuantity left, ResourceQuantity right)
    {
        return new ResourceQuantity(left.Value - right.Value);
    }
}