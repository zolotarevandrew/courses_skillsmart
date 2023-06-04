using h_work.lesson6.example1;
using Xunit;

namespace h_work.lesson6.example2;

public class TotalPriceTest
{
    public TotalPriceTest()
    {
        
    }
    
    [Fact]
    public void Create_ShouldBeOk()
    {
        //Arrange
        var price = new TotalPrice(0);
    }
    
    [Fact]
    public void Create_Invalid_ShouldThrow()
    {
        //Arrange
        Assert.Throws<InvalidOperationException>(() => new TotalPrice(-1));
    }
    
    [Fact]
    public void Add_ShouldBeOk()
    {
        //Arrange
        var price = new TotalPrice(2);
        
        //Act
        TotalPrice res = price.Add(new TotalPrice(250));
        
        //Assert
        Assert.Equal(252, res.Value);
    }
}