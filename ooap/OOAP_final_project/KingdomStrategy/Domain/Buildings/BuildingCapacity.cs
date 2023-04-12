namespace KingdomStrategy.Domain.Buildings;

public class BuildingCapacity : Any
{
    public uint Value { get; init; }
    public BuildingCapacity(uint value)
    {
        Value = value;
    }

    public BuildingCapacity Increase(uint value)
    {
        return new BuildingCapacity(Value + value);
    }

    public BuildingCapacity Decrease(uint value)
    {
        return new BuildingCapacity(Value - value);
    }
}