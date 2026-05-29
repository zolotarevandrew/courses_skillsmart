namespace Tasks.GraphAlgorithms.PathFinding;

public class PathFindingTests
{
    [Fact]
    public void FindPath_NoCyclesHasPath_ShouldBeTrue( )
    {
        // Arrange
        var node1 = new PathFinding.Vertex( 1 );
        var node2 = new PathFinding.Vertex( 2 );
        var node3 = new PathFinding.Vertex( 3 );
        var node4 = new PathFinding.Vertex( 4 );
        var node5 = new PathFinding.Vertex( 5 );
        var node6 = new PathFinding.Vertex( 6 );
        var graph = new PathFinding.Graph
        {
            Value = new Dictionary<PathFinding.Vertex, List<PathFinding.Vertex>>
            {
                { node1, [node2, node6] },
                { node2, [node3] },
                { node3, [node4] },
                { node4, [node5] },
            }
        };

        // Assert
        var path = PathFinding.FindPath( graph, node1, node5 );
        Assert.Equal( path.Count, 5 );
    }
    
    [Fact]
    public void FindPath_HasPathWithCycles_ShouldBeTrue( )
    {
        // Arrange
        var node1 = new PathFinding.Vertex( 1 );
        var node2 = new PathFinding.Vertex( 2 );
        var node3 = new PathFinding.Vertex( 3 );
        var node4 = new PathFinding.Vertex( 4 );
        var node5 = new PathFinding.Vertex( 5 );
        var node6 = new PathFinding.Vertex( 6 );
        var graph = new PathFinding.Graph
        {
            Value = new Dictionary<PathFinding.Vertex, List<PathFinding.Vertex>>
            {
                { node1, [node2, node6] },
                { node2, [node3] },
                { node3, [node4] },
                { node4, [node5] },
                { node5, [node6] },
            }
        };

        // Assert
        var path = PathFinding.FindPath( graph, node2, node6 );
        Assert.Equal( path.Count, 5 );
    }
}