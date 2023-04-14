using System.Numerics;

namespace KingdomStrategy.Domain;

public class Level : IEqualityOperators<Level, Level, bool>
{
    public byte Value { get; private set; }
    public Level(byte value)
    {
        Value = value;
    }

    public void Up()
    {
        Value++;
    }

    public static bool operator ==(Level left, Level right)
    {
        return left.Value == right.Value;
    }

    public static bool operator !=(Level? left, Level? right)
    {
        return left.Value != right.Value;
    }
}