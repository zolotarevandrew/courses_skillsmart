using h_work.lesson6.example1;
using Xunit;

namespace h_work.lesson6.example2;

public class ShoppingItemTotalPriceTests
{
    [Fact]
    public void NoAdded_ShouldBeOk()
    {
        //Arrange
        var price = new ShoppingItemTotalPrice();
        
        //Assert
        Assert.Equal(0, price.Price.Value);
    }
    
    [Fact]
    public void Add_OneAdded_ShouldBeOk()
    {
        //Arrange
        var price = new ShoppingItemTotalPrice();
        
        //Act
        price.Add(new ItemPrice(25), new ItemQuantity(2));
        
        //Assert
        Assert.Equal(50, price.Price.Value);
    }
    
    [Fact]
    public void Add_TwoAdded_ShouldBeOk()
    {
        //Arrange
        var price = new ShoppingItemTotalPrice();
        
        //Act
        price.Add(new ItemPrice(25), new ItemQuantity(2));
        price.Add(new ItemPrice(25), new ItemQuantity(2));
        
        //Assert
        Assert.Equal(100, price.Price.Value);
    }
}