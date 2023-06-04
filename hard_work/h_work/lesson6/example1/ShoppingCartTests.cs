using h_work.lesson6.example1.Warehouse;
using NSubstitute;
using Xunit;

namespace h_work.lesson6.example1;

public class ShoppingCartTests
{
    public ShoppingCartTests()
    {
        
    }
    
    [Fact]
    public async Task AddItem_IsInWarehouse_ShouldBeAdded()
    {
        //Arrange
        var warehouseProvider = Substitute.For<IWarehouseProvider>();
        var cart = new ShoppingCart(warehouseProvider);

        warehouseProvider.Request(Arg.Any<string>(), Arg.Any<ItemQuantity>(), Arg.Any<ItemPrice>())
            .Returns(new WarehouseAvailability(EWarehouseAvailability.Full));

        //Act
        var isAdded = await cart.AddItem(new ShoppingItem("1", "2"), new ItemQuantity(1), new ItemPrice(25));

        //Assert
        Assert.True(isAdded);
    }
    
    [Fact]
    public async Task AddItem_NotInWarehouse_ShouldBeAdded()
    {
        //Arrange
        var warehouseProvider = Substitute.For<IWarehouseProvider>();
        var cart = new ShoppingCart(warehouseProvider);

        warehouseProvider.Request(Arg.Any<string>(), Arg.Any<ItemQuantity>(), Arg.Any<ItemPrice>())
            .Returns(new WarehouseAvailability(EWarehouseAvailability.NotAvailable));

        //Act
        var isAdded = await cart.AddItem(new ShoppingItem("1", "2"), new ItemQuantity(1), new ItemPrice(25));

        //Assert
        Assert.False(isAdded);
    }
}