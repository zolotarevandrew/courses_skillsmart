namespace KingdomStrategy.Domain.Armies.Troops;

public class TroopSize : Any
{
    public uint Value { get; }
    public TroopSize(uint value)
    {
        Value = value;
    }
}