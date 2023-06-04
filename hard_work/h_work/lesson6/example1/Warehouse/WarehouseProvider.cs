namespace h_work.lesson6.example1.Warehouse;

public interface IWarehouseProvider
{
    Task<WarehouseAvailability> Request(string id, ItemQuantity quantity, ItemPrice price);
}

public enum EWarehouseAvailability
{
    Full = 1,
    NotAvailable = 2,
}

public class WarehouseAvailability
{
    private readonly EWarehouseAvailability _type;
    public bool Value => _type is EWarehouseAvailability.Full;
    public WarehouseAvailability(EWarehouseAvailability type)
    {
        _type = type;
    }
}

public class WarehouseProvider : IWarehouseProvider
{
    private ItemQuantity _defaultQuantity;
    public WarehouseProvider()
    {
        _defaultQuantity = new ItemQuantity(100);
    }
    public async Task<WarehouseAvailability> Request(string id, ItemQuantity quantity, ItemPrice price)
    {
        if (!_defaultQuantity.CanRemove(quantity)) return new WarehouseAvailability(EWarehouseAvailability.NotAvailable);
        
        _defaultQuantity = _defaultQuantity.Remove(quantity);
        return new WarehouseAvailability(EWarehouseAvailability.Full);
    }
}