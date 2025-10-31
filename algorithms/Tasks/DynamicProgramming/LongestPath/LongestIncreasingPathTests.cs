namespace Tasks.DynamicProgramming.LongestPath;

public class LongestIncreasingPathTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            {9, 9, 4},
            {6, 6, 8},
            {2, 1, 1},
        };

        // Act
        var res = LongestIncreasingPath.Run(matrix);

        // Assert
        Assert.Equal( 4, res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            {3, 3, 8},
            {2, 4, 5},
            {2, 1, 6},
        };

        // Act
        var res = LongestIncreasingPath.Run(matrix);

        // Assert
        Assert.Equal( 4, res );
    }
}