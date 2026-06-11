namespace Tasks.UnionFind.RedudantConnection;

public class RedudantConnectionTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        (int, int)[] nodes = [
            (1, 2),
            (1, 3),
            (2, 3),
        ];

        // Act
        var res = RedudantConnection.Run( nodes, 3 );

        // Assert
        Assert.Equal( 2, res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        (int, int)[] nodes = [
            (1, 2),
            (2, 3),
            (3, 4),
            (1, 4),
            (1, 5),
        ];

        // Act
        var res = RedudantConnection.Run( nodes, 5 );

        // Assert
        Assert.Equal( 3, res );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        (int, int)[] nodes = [
            (1, 1)
        ];

        // Act
        var res = RedudantConnection.Run( nodes, 1 );

        // Assert
        Assert.Equal( 0, res );
    }
}