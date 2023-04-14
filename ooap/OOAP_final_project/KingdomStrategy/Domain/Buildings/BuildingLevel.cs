using System.Numerics;

namespace KingdomStrategy.Domain.Buildings;

public class BuildingLevel : IEqualityOperators<BuildingLevel, BuildingLevel, bool>
{
    public byte Value { get; private set; }
    public BuildingLevel(byte value)
    {
        Value = value;
    }

    public void Up()
    {
        Value++;
    }

    public static bool operator ==(BuildingLevel left, BuildingLevel right)
    {
        return left.Value == right.Value;
    }

    public static bool operator !=(BuildingLevel? left, BuildingLevel? right)
    {
        return left.Value != right.Value;
    }
}