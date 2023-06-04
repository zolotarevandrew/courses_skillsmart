

using h_work.lesson6.example1.Warehouse;

namespace h_work.lesson6.example1;

public class ShoppingCart
{
    private readonly IWarehouseProvider _warehouseProvider;
    public ShoppingCart(IWarehouseProvider warehouseProvider)
    {
        _warehouseProvider = warehouseProvider;
    }
    
    public async Task<bool> AddItem(ShoppingItem item, ItemQuantity quantity, ItemPrice price)
    {
        var availability = await _warehouseProvider.Request(item.Id, quantity, price);
        return availability.Value;
    }
}

public record ShoppingItem
{
    public ShoppingItem(
        string id, 
        string name)
    {
        Id = id;
        Name = name;
    }

    public string Id { get; init; }
    public string Name { get; init; }
}

public class ItemPrice
{
    public decimal Value { get; }
    public ItemPrice(decimal value)
    {
        if (value < 0) throw new InvalidOperationException("invalid price");
        Value = value;
    }
}