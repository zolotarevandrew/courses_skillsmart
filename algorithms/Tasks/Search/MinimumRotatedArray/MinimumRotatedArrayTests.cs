namespace Tasks.Search.MinimumRotatedArray;

public class MinimumRotatedArrayTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 8, 9, 10, 1, 2, 3, 4 };
        
        // Act
        var result = MinimumRotatedArray.Run(array);
        
        // Assert
        Assert.Equal( result, 1 );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 5, 6, 1, 2, 3, 4 };
        
        // Act
        var result = MinimumRotatedArray.Run(array);
        
        // Assert
        Assert.Equal( result, 1 );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 10, 12, 14, 3, 6, 8 };
        
        // Act
        var result = MinimumRotatedArray.Run(array);
        
        // Assert
        Assert.Equal( result, 3 );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 2 };
        
        // Act
        var result = MinimumRotatedArray.Run(array);
        
        // Assert
        Assert.Equal( result, 2 );
    }
    [Fact]
    public void Run_Case5_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 2, 1 };
        
        // Act
        var result = MinimumRotatedArray.Run(array);
        
        // Assert
        Assert.Equal( result, 1 );
    }
    
    [Fact]
    public void RunBinarySearch_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 8, 9, 10, 1, 2, 3, 4 };
        
        // Act
        var result = MinimumRotatedArray.RunBinarySearch(array);
        
        // Assert
        Assert.Equal( result, 1 );
    }
    
    [Fact]
    public void RunBinarySearch_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 5, 6, 1, 2, 3, 4 };
        
        // Act
        var result = MinimumRotatedArray.RunBinarySearch(array);
        
        // Assert
        Assert.Equal( result, 1 );
    }
    
    [Fact]
    public void RunBinarySearch_Case3_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 10, 12, 14, 3, 6, 8 };
        
        // Act
        var result = MinimumRotatedArray.RunBinarySearch(array);
        
        // Assert
        Assert.Equal( result, 3 );
    }
    
    [Fact]
    public void RunBinarySearch_Case4_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 2 };
        
        // Act
        var result = MinimumRotatedArray.RunBinarySearch(array);
        
        // Assert
        Assert.Equal( result, 2 );
    }
    [Fact]
    public void RunBinarySearch_Case5_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 2, 1 };
        
        // Act
        var result = MinimumRotatedArray.RunBinarySearch(array);
        
        // Assert
        Assert.Equal( result, 1 );
    }
}