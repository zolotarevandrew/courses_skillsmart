namespace Tasks.Search.MaximumRotatedArray;

public class MaximumRotatedArrayTests
{
    [Fact]
    public void RunBinarySearch_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 8, 9, 10, 1, 2, 3, 4 };

        // Act
        var result = MaximumRotatedArray.RunBinarySearch( array );

        // Assert
        Assert.Equal( result, 10 );
    }

    [Fact]
    public void RunBinarySearch_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 5, 6, 1, 2, 3, 4 };

        // Act
        var result = MaximumRotatedArray.RunBinarySearch( array );

        // Assert
        Assert.Equal( result, 6 );
    }

    [Fact]
    public void RunBinarySearch_Case3_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 4, 5, 6, 1, 2, 3 };

        // Act
        var result = MaximumRotatedArray.RunBinarySearch( array );

        // Assert
        Assert.Equal( result, 6 );
    }

    [Fact]
    public void RunBinarySearch_Case4_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 2 };

        // Act
        var result = MaximumRotatedArray.RunBinarySearch( array );

        // Assert
        Assert.Equal( result, 2 );
    }

    [Fact]
    public void RunBinarySearch_Case5_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 2, 1 };

        // Act
        var result = MaximumRotatedArray.RunBinarySearch( array );

        // Assert
        Assert.Equal( result, 2 );
    }
    
    [Fact]
    public void RunBinarySearch_Case51_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 2 };

        // Act
        var result = MaximumRotatedArray.RunBinarySearch( array );

        // Assert
        Assert.Equal( result, 2 );
    }

    [Fact]
    public void RunBinarySearch_Case6_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 3, 1, 2 };

        // Act
        var result = MaximumRotatedArray.RunBinarySearch( array );

        // Assert
        Assert.Equal( result, 3 );
    }

    [Fact]
    public void RunBinarySearch_Case7_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 2, 3 };

        // Act
        var result = MaximumRotatedArray.RunBinarySearch( array );

        // Assert
        Assert.Equal( result, 3 );
    }

    [Fact]
    public void RunBinarySearch_Case8_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 2, 3, 4, 5, 6, 7 };

        // Act
        var result = MaximumRotatedArray.RunBinarySearch( array );

        // Assert
        Assert.Equal( result, 7 );
    }

    [Fact]
    public void RunBinarySearch_Case9_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 6, 7, 1, 2, 3, 4, 5 };

        // Act
        var result = MaximumRotatedArray.RunBinarySearch( array );

        // Assert
        Assert.Equal( result, 7 );
    }
}