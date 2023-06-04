using Xunit;

namespace h_work.lesson6.example1;

public class ItemQuantityTest
{
    public ItemQuantityTest()
    {
        
    }
    
    [Fact]
    public void Add_ShouldBeOk()
    {
        //Arrange
        var quantity = new ItemQuantity(1);

        //Act
        var res = quantity.Add(new ItemQuantity(2));

        //Assert
        Assert.True(3 == res.Value);
    }
    
    [Fact]
    public void CanRemove_Cant_ShouldBeFalse()
    {
        //Arrange
        var quantity = new ItemQuantity(1);

        //Act
        var res = quantity.CanRemove(new ItemQuantity(2));

        //Assert
        Assert.False(res);
    }
    
    [Fact]
    public void CanRemove_Can_ShouldBeTrue()
    {
        //Arrange
        var quantity = new ItemQuantity(2);

        //Act
        var res = quantity.CanRemove(new ItemQuantity(1));

        //Assert
        Assert.True(res);
    }
    
    [Fact]
    public void Remove_Cant_ShouldThrowException()
    {
        //Arrange
        var quantity = new ItemQuantity(1);

        //Act
        Assert.Throws<InvalidOperationException>(() => quantity.Remove(new ItemQuantity(2)));
    }
    
    [Fact]
    public void Remove_Can_ShouldBeOk()
    {
        //Arrange
        var quantity = new ItemQuantity(2);

        //Act
        var res = quantity.Remove(new ItemQuantity(1));
        
        //Assert
        Assert.True(res.Value == 1);
    }
}