using h_work.lesson6.example1;
using Xunit;

namespace h_work.lesson6.example2;

public class ShoppingCartListTest
{
    public ShoppingCartListTest()
    {
        
    }

    [Fact]
    public void TotalPrice_NoItemsAdded_ShouldBeZero()
    {
        //Arrange
        var list = new ShoppingCartList();

        //Act
        var total = list.Total();

        //Assert
        Assert.Equal(0, total.Value);
    }
    
    [Fact]
    public void TotalPrice_OneItemAdded_ShouldBeOk()
    {
        //Arrange
        var list = new ShoppingCartList();

        //Act
        list.Add(new ShoppingItem("1", "test"), new ItemQuantity(1), new ItemPrice(25));
        var total = list.Total();

        //Assert
        Assert.Equal(25, total.Value);
    }
    
    [Fact]
    public void TotalPrice_TwoSameItemsAdded_ShouldBeOk()
    {
        //Arrange
        var list = new ShoppingCartList();

        //Act
        list.Add(new ShoppingItem("1", "test"), new ItemQuantity(1), new ItemPrice(25));
        list.Add(new ShoppingItem("1", "test"), new ItemQuantity(2), new ItemPrice(25));
        var total = list.Total();

        //Assert
        Assert.Equal(75, total.Value);
    }
    
    [Fact]
    public void TotalPrice_TwoDifferentItemsAdded_ShouldBeOk()
    {
        //Arrange
        var list = new ShoppingCartList();

        //Act
        list.Add(new ShoppingItem("1", "test"), new ItemQuantity(1), new ItemPrice(25));
        list.Add(new ShoppingItem("21", "test2"), new ItemQuantity(3), new ItemPrice(25));
        var total = list.Total();

        //Assert
        Assert.Equal(100, total.Value);
    }
}