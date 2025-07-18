namespace Tasks.Arrays.MaximumSubArray;

public class MaximumSubArrayTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { -1, 2, 3, -5, 4 };
        
        // Act
        var result = MaximumSubArray.Run(array);
        
        // Assert
        Assert.Equal( result, 5 );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 0 };
        
        // Act
        var result = MaximumSubArray.Run(array);
        
        // Assert
        Assert.Equal( result, 0 );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 10, -2, 3, 1 };
        
        // Act
        var result = MaximumSubArray.Run(array);
        
        // Assert
        Assert.Equal( result, 12 );
    }
    
    [Fact]
    public void RunSlidingWindow_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { -1, 2, 3, -5, 4 };
        
        // Act
        var result = MaximumSubArray.RunSlidingWindow(array);
        
        // Assert
        Assert.Equal( result, 5 );
    }
    
    [Fact]
    public void RunSlidingWindow_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 0 };
        
        // Act
        var result = MaximumSubArray.RunSlidingWindow(array);
        
        // Assert
        Assert.Equal( result, 0 );
    }
    
    [Fact]
    public void RunSlidingWindow_Case3_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 10, -2, 3, 1 };
        
        // Act
        var result = MaximumSubArray.RunSlidingWindow(array);
        
        // Assert
        Assert.Equal( result, 12 );
    }
}