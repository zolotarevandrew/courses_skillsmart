namespace Tasks.Arrays.StockTrading;

public class ArrayStockTradingTest
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 2, 4, 1, 7, 3, 8 };
        
        // Act
        var result = ArrayStockTrading.Run(array);
        
        // Assert
        Assert.Equal( result, 7 );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 10, 9, 8, 7 };
        
        // Act
        var result = ArrayStockTrading.Run( array );
        
        // Assert
        Assert.Equal( result, 0 );
    }
    
    [Fact]
    public void RunSlidingWindow_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 2, 4, 1, 7, 3, 8 };
        
        // Act
        var result = ArrayStockTrading.RunSlidingWindow(array);
        
        // Assert
        Assert.Equal( result, 7 );
    }
    
    [Fact]
    public void RunSlidingWindow_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 10, 9, 8, 7 };
        
        // Act
        var result = ArrayStockTrading.RunSlidingWindow( array );
        
        // Assert
        Assert.Equal( result, 0 );
    }
}