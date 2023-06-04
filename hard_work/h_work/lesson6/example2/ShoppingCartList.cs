using h_work.lesson6.example1;

namespace h_work.lesson6.example2;

public class ShoppingCartList
{
    private List<(ShoppingItem Iten, ItemQuantity Quantity, ItemPrice Price)> _list;
    private Dictionary<string, ShoppingItemTotalPrice> _priceById;

    public ShoppingCartList()
    {
        _list = new List<(ShoppingItem shoppingItem, ItemQuantity itemQuantity, ItemPrice itemPrice)>();
        _priceById = new Dictionary<string, ShoppingItemTotalPrice>();
    }
    public void Add(ShoppingItem shoppingItem, ItemQuantity itemQuantity, ItemPrice itemPrice)
    {
        _list.Add((shoppingItem, itemQuantity, itemPrice));

        if (!_priceById.ContainsKey(shoppingItem.Id))
        {
            _priceById[shoppingItem.Id] = new ShoppingItemTotalPrice();    
        }

        var totalPrice = _priceById[shoppingItem.Id];
        totalPrice.Add(itemPrice, itemQuantity);
        _priceById[shoppingItem.Id] = totalPrice;
    }

    public TotalPrice Total()
    {
        var sum = _priceById.Values.Sum(c => c.Price.Value);
        return new TotalPrice(sum);
    }
}

public class ItemTotalPrice
{
    
}