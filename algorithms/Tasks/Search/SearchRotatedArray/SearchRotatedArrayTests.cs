namespace Tasks.Search.SearchRotatedArray;

public class SearchRotatedArrayTests
{
    [Fact]
    public void RunBinarySearch_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 6, 7, 8, 1, 2, 3, 4 };

        // Act
        var result = SearchRotatedArray.RunBinarySearch( array, 3 );

        // Assert
        Assert.Equal( result, 5 );
    }
    
    [Fact]
    public void RunBinarySearch_Case11_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 30, 40, 50, 10, 20 };

        // Act
        var result = SearchRotatedArray.RunBinarySearch( array, 10 );

        // Assert
        Assert.Equal( result, 3 );
    }
    
    [Fact]
    public void RunBinarySearch_Case12_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 30, 40, 0, 10, 20 };

        // Act
        var result = SearchRotatedArray.RunBinarySearch( array, 10 );

        // Assert
        Assert.Equal( result, 3 );
    }

    [Fact]
    public void RunBinarySearch_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 3, 4, 5, 1, 2 };

        // Act
        var result = SearchRotatedArray.RunBinarySearch( array, 7 );

        // Assert
        Assert.Equal( result, -1 );
    }

    [Fact]
    public void RunBinarySearch_Case3_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 5 };

        // Act
        var result = SearchRotatedArray.RunBinarySearch( array, 5 );

        // Assert
        Assert.Equal( result, 0 );
    }

    [Fact]
    public void RunBinarySearch_Case4_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 2 };

        // Act
        var result = SearchRotatedArray.RunBinarySearch( array, 2 );

        // Assert
        Assert.Equal( result, 1 );
    }

    [Fact]
    public void RunBinarySearch_Case5_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 2, 1 };

        // Act
        var result = SearchRotatedArray.RunBinarySearch( array, 2 );

        // Assert
        Assert.Equal( result, 0 );
    }

    [Fact]
    public void RunBinarySearch_Case6_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 3, 1, 2 };

        // Act
        var result = SearchRotatedArray.RunBinarySearch( array, 1 );

        // Assert
        Assert.Equal( result, 1 );
    }

    [Fact]
    public void RunBinarySearch_Case7_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 2, 3 };

        // Act
        var result = SearchRotatedArray.RunBinarySearch( array, 1 );

        // Assert
        Assert.Equal( result, 0 );
    }

    [Fact]
    public void RunBinarySearch_Case8_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 2, 3, 4, 5, 6, 7 };

        // Act
        var result = SearchRotatedArray.RunBinarySearch( array, 4 );

        // Assert
        Assert.Equal( result, 3 );
    }

    [Fact]
    public void RunBinarySearch_Case9_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 6, 7, 1, 2, 3, 4, 5 };

        // Act
        var result = SearchRotatedArray.RunBinarySearch( array, 6 );

        // Assert
        Assert.Equal( result, 0 );
    }
}