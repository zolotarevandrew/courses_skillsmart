namespace KingdomStrategy.Domain;

public class AttackPower : Any
{
    public uint Value { get; }

    public AttackPower(uint value)
    {
        Value = value;
    }
    
    public AttackPower Decrease(AttackPower value)
    {
        return new AttackPower(Value - value.Value);
    }

    public AttackPower Increase(AttackPower value)
    {
        return new AttackPower(Value - value.Value);
    }
}