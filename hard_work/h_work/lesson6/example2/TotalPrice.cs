namespace h_work.lesson6.example2;

public class TotalPrice
{
    public decimal Value { get; init; }

    public TotalPrice(decimal value)
    {
        if (value < 0) throw new InvalidOperationException("value should be positive");

        Value = value;
    }

    public TotalPrice Add(TotalPrice totalPrice)
    {
        return new TotalPrice(totalPrice.Value + Value);
    }
}