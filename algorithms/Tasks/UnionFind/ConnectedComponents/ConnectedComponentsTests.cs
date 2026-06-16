namespace Tasks.UnionFind.ConnectedComponents;

public class ConnectedComponentsTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        int n = 3;
        (int, int)[] edges = [
            ( 0, 1 ), 
            ( 0, 2 )
        ];

        // Act
        var res = ConnectedComponents.Run( edges, n );

        // Assert
        Assert.Equal( 1, res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        int n = 6;
        (int, int)[] edges = [
            ( 0, 1 ), 
            ( 1, 2 ),
            ( 2, 3 ),
            ( 4, 5 ),
        ];

        // Act
        var res = ConnectedComponents.Run( edges, n );

        // Assert
        Assert.Equal( 2, res );
    }
}