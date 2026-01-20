namespace Tasks.Graphs.MaximumArea;

public class GraphMaximumIslandAreaTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        int[,] grid =
        {
            { 1, 1, 0, 0 },
            { 1, 0, 0, 1 },
            { 0, 0, 1, 1 },
            { 0, 0, 0, 0 }
        };

        // Act
        int res = GraphMaximumIslandArea.Run( grid );
        
        // Assert
        Assert.Equal( 3, res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        int[,] grid =
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        };

        // Act
        int res = GraphMaximumIslandArea.Run( grid );
        
        
        // Assert
        Assert.Equal( 0, res );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        int[,] grid =
        {
            { 1, 1, 1 },
            { 1, 1, 1 },
            { 1, 1, 1 }
        };

        // Act
        int res = GraphMaximumIslandArea.Run( grid );
        
        
        // Assert
        Assert.Equal( 9, res );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        // Arrange
        int[,] grid =
        {
            { 1, 0, 1 },
            { 0, 1, 0 },
            { 1, 0, 1 }
        };

        // Act
        int res = GraphMaximumIslandArea.Run( grid );
        
        
        // Assert
        Assert.Equal( 1, res );
    }
    
    [Fact]
    public void Run_Case5_ShouldBeOk( )
    {
        // Arrange
        int[,] grid =
        {
            { 1, 0, 0, 1, 0 },
            { 1, 0, 0, 1, 1 },
            { 0, 0, 0, 0, 0 },
            { 0, 1, 1, 0, 0 }
        };

        // Act
        int res = GraphMaximumIslandArea.Run( grid );
        
        
        // Assert
        Assert.Equal( 3, res );
    }
    
    [Fact]
    public void Run_Case6_ShouldBeOk( )
    {
        // Arrange
        int[,] grid =
        {
            { 1, 1, 1 },
            { 1, 0, 0 },
            { 1, 0, 1 },
        };

        // Act
        int res = GraphMaximumIslandArea.Run( grid );
        
        
        // Assert
        Assert.Equal( 5, res );
    }
    
    [Fact]
    public void Run_Case7_ShouldBeOk( )
    {
        // Arrange
        int[,] grid =
        {
            { 1, 0, 0, 0, 1 },
            { 0, 0, 1, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 1, 0, 0 },
        };

        // Act
        int res = GraphMaximumIslandArea.Run( grid );
        
        // Assert
        Assert.Equal( 5, res );
    }
}