



namespace h_work.lesson18.part2.example3;

public class SalesPricing
{
    public static double GetDiscountedPriceForPass(double originalPrice)
    {
        double discountPercentage = 0.2;
        double discountedPrice = originalPrice * (1 - discountPercentage);
        return discountedPrice;
    }
}