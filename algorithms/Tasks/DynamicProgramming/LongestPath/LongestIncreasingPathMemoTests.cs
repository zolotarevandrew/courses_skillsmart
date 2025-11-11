namespace Tasks.DynamicProgramming.LongestPath;

public partial class LongestIncreasingPathTests
{
    [Fact]
    public void RunMemo_Case1_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            {9, 9, 4},
            {6, 6, 8},
            {2, 1, 1},
        };

        // Act
        var res = LongestIncreasingPath.RunMemo(matrix);

        // Assert
        Assert.Equal( 4, res );
    }
    
    [Fact]
    public void RunMemo_Case2_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            {3, 3, 8},
            {2, 4, 5},
            {2, 1, 6},
        };

        // Act
        var res = LongestIncreasingPath.RunMemo(matrix);

        // Assert
        Assert.Equal( 4, res );
    }
    
    [Fact]
    public void RunMemo_Case3_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9},
        };

        // Act
        var res = LongestIncreasingPath.RunMemo(matrix);

        // Assert
        Assert.Equal( 5, res );
    }
    
    [Fact]
    public void RunMemo_Case4_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            {1, 2, 3},
            {6, 5, 4},
            {7, 8, 9},
        };

        // Act
        var res = LongestIncreasingPath.RunMemo(matrix);

        // Assert
        Assert.Equal( 9, res );
    }
    
    [Fact]
    public void RunMemo_Case5_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            {1, 1, 1}
        };

        // Act
        var res = LongestIncreasingPath.RunMemo(matrix);

        // Assert
        Assert.Equal( 1, res );
    }
    
    [Fact]
    public void RunMemo_Case6_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            {1, 2, 3}
        };

        // Act
        var res = LongestIncreasingPath.RunMemo(matrix);

        // Assert
        Assert.Equal( 3, res );
    }
    
    [Fact]
    public void RunMemo_Case7_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            {1}
        };

        // Act
        var res = LongestIncreasingPath.RunMemo(matrix);

        // Assert
        Assert.Equal( 1, res );
    }
    
    [Fact]
    public void RunMemo_Case8_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            
        };

        // Act
        var res = LongestIncreasingPath.RunMemo(matrix);

        // Assert
        Assert.Equal( 0, res );
    }
}