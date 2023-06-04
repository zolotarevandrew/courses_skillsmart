using h_work.lesson6.example1;

namespace h_work.lesson6.example2;

public class ShoppingItemTotalPrice
{
    public TotalPrice Price { get; private set; }

    public ShoppingItemTotalPrice()
    {
        Price = new TotalPrice(0);
    }

    public void Add(ItemPrice price, ItemQuantity quantity)
    {
        var newSum = price.Value * quantity.Value;
        var newTotal = new TotalPrice(newSum);
        Price = Price.Add(newTotal);
    }
}