namespace Tasks.DynamicProgramming.MinimumPath;

public class MinimumPathSumTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        int[,] arr = new int[,]
        {
            { 2, 4, 1 },
            { 3, 2, 1 },
            { 5, 3, 2 }
        };
        
        // Act
        var res = MinimumPathSum.Run( arr );

        // Assert
        Assert.Equal( 10, res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        int[,] arr = new int[,]
        {
            { 3, 1, 2 },
            { 6, 4, 3 }
        };
        
        // Act
        var res = MinimumPathSum.Run( arr );

        // Assert
        Assert.Equal( 9, res );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        int[,] arr = new int[,]
        {
        };
        
        // Act
        var res = MinimumPathSum.Run( arr );

        // Assert
        Assert.Equal( 0, res );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        // Arrange
        int[,] arr = new int[,]
        {
            { 1 }
        };
        
        // Act
        var res = MinimumPathSum.Run( arr );

        // Assert
        Assert.Equal( 1, res );
    }
    
    [Fact]
    public void Run_Case5_ShouldBeOk( )
    {
        // Arrange
        int[,] arr = new int[,]
        {
            { 1, 2 }
        };
        
        // Act
        var res = MinimumPathSum.Run( arr );

        // Assert
        Assert.Equal( 3, res );
    }
    
    [Fact]
    public void Run_Case6_ShouldBeOk( )
    {
        // Arrange
        int[,] arr = new int[,]
        {
            { 1, 2 },
            { 1, 1 }
        };
        
        // Act
        var res = MinimumPathSum.Run( arr );

        // Assert
        Assert.Equal( 3, res );
    }
}