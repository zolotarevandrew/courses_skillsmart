namespace KingdomStrategy.Domain;

public class Health : Any
{
    private uint _defaultValue;
    public uint Value { get; }

    public Health(uint value)
    {
        _defaultValue = value;
        Value = value;
    }

    public Health Decrease(Health value)
    {
        return new Health(Value - value.Value);
    }
    
    public Health RestoreFull()
    {
        return new Health(_defaultValue);
    }
    
    public Health Restore(Health health)
    {
        return new Health(health.Value + Value);
    }
    
    public Health Increase(Health value)
    {
        return new Health(Value + value.Value);
    }
}