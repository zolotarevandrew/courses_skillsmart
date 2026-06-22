using Tasks.UnionFind.ConnectedComponents;

namespace Tasks.Backtraking;

public class BacktrackingTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Act
        var res = Backtracking.GenerateBinaryString( 3 );

        // Assert
        Assert.NotEmpty( res );
    }
}