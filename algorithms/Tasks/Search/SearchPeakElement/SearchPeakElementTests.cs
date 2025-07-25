namespace Tasks.Search.SearchPeakElement;

public class SearchPeakElementTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 5, 2, 4, 1 };
        
        // Act
        var res = SearchPeakElement.Run( array );

        // Assert
        Assert.Equal( res, 1 );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 2, 3, 4, 5 };
        
        // Act
        var res = SearchPeakElement.Run( array );

        // Assert
        Assert.Equal( res, 4 );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 3, 4, 3, 2, 1 };
        
        // Act
        var res = SearchPeakElement.Run( array );

        // Assert
        Assert.Equal( res, 1 );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 2 };
        
        // Act
        var res = SearchPeakElement.Run( array );

        // Assert
        Assert.Equal( res, 1 );
    }
    
    [Fact]
    public void Run_Case5_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 2, 1 };
        
        // Act
        var res = SearchPeakElement.Run( array );

        // Assert
        Assert.Equal( res, 0 );
    }
    
    [Fact]
    public void RunBinarySearch_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 5, 2, 4, 1 };
        
        // Act
        var res = SearchPeakElement.RunBinarySearch( array );

        // Assert
        Assert.Equal( res, 3 );
    }
    
    [Fact]
    public void RunBinarySearch_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 2, 3, 4, 5 };
        
        // Act
        var res = SearchPeakElement.RunBinarySearch( array );

        // Assert
        Assert.Equal( res, 4 );
    }
    
    [Fact]
    public void RunBinarySearch_Case3_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 3, 4, 3, 2, 1 };
        
        // Act
        var res = SearchPeakElement.RunBinarySearch( array );

        // Assert
        Assert.Equal( res, 1 );
    }
    
    [Fact]
    public void RunBinarySearch_Case4_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 2 };
        
        // Act
        var res = SearchPeakElement.RunBinarySearch( array );

        // Assert
        Assert.Equal( res, 1 );
    }
    
    [Fact]
    public void RunBinarySearch_Case5_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 2, 1 };
        
        // Act
        var res = SearchPeakElement.RunBinarySearch( array );

        // Assert
        Assert.Equal( res, 0 );
    }
}