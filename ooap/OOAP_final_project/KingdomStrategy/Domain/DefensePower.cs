namespace KingdomStrategy.Domain;

public class DefensePower : Any
{
    public uint Value { get; }

    public DefensePower(uint value)
    {
        Value = value;
    }
    
    public DefensePower Decrease(DefensePower value)
    {
        return new DefensePower(Value - value.Value);
    }

    public DefensePower Increase(DefensePower value)
    {
        return new DefensePower(Value + value.Value);
    }
}