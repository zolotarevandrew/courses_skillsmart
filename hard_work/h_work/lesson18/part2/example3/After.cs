namespace h_work.lesson18.part2.example3;

public class SaleDiscount
{
    public static SaleDiscount Max = new SaleDiscount(1);
    public static SaleDiscount Min = new SaleDiscount(0.1);

    private double _value;
    private SaleDiscount(double value)
    {
        _value = value;
    }

    public double Value => _value;

    public void Increase()
    {
        _value += 0.1;
        if (_value > 1) _value = 1;
    }
    
    public void Decrease()
    {
        _value -= 0.1;
        if (_value <= 0.1) _value = 0.1;
    }
}
public class SalesPricing
{
    public static double GetDiscountedPrice(double originalPrice, SaleDiscount discount)
    {
        double discountedPrice = originalPrice * (1 - discount.Value);
        return discountedPrice;
    }
}