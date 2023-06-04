using Xunit;

namespace h_work.lesson6.example1.Warehouse;

public class WarehouseProviderTests
{
    
    [Fact]
    public async Task Request_IsInWarehouse_ShouldBeInStock()
    {
        //Arrange
        var warehouseProvider = new WarehouseProvider();
        
        //Act
        var availability = await warehouseProvider.Request("1", new ItemQuantity(1), new ItemPrice(25));

        //Assert
        Assert.True(availability.Value);
    }
    
    [Fact]
    public async Task Request_IsNotInWarehouse_ShouldBeNotInStock()
    {
        //Arrange
        var warehouseProvider = new WarehouseProvider();
        
        //Act
        var availability = await warehouseProvider.Request("1", new ItemQuantity(111), new ItemPrice(25));

        //Assert
        Assert.False(availability.Value);
    }
    
    [Fact]
    public async Task Request_MultipleTimes_ShouldBeNotInStock()
    {
        //Arrange
        var warehouseProvider = new WarehouseProvider();
        
        //Act
        var availability = await warehouseProvider.Request("1", new ItemQuantity(50), new ItemPrice(25));
        availability = await warehouseProvider.Request("1", new ItemQuantity(51), new ItemPrice(25));

        //Assert
        Assert.False(availability.Value);
    }
}