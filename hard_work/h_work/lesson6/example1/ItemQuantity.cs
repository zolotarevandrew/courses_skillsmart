namespace h_work.lesson6.example1;

public class ItemQuantity
{
    private const int MinQuantity = 1;
    
    public uint Value { get; }
    public ItemQuantity(uint value)
    {
        if (value < MinQuantity) throw new InvalidOperationException("invalid quantity");
        Value = value;
    }

    public ItemQuantity Add(ItemQuantity quantity)
    {
        return new ItemQuantity(quantity.Value + Value);
    }
    
    public bool CanRemove(ItemQuantity itemQuantity)
    {
        return Value > itemQuantity.Value;
    }

    public ItemQuantity Remove(ItemQuantity itemQuantity)
    {
        if (!CanRemove(itemQuantity))
            throw new InvalidOperationException("cant remove");

        return new ItemQuantity(Value - itemQuantity.Value);
    }
}