namespace Tasks.GraphAlgorithms.WeightedPathFinding;

public class WeightedPathFindingTests
{
    [Fact]
    public void FindPath_NoCyclesHasPath_ShouldBeTrue( )
    {
        // Arrange
        var node1 = new WeightedPathFinding.Vertex( 1 );
        var node2 = new WeightedPathFinding.Vertex( 2 );
        var node3 = new WeightedPathFinding.Vertex( 3 );
        var node4 = new WeightedPathFinding.Vertex( 4 );
        var node5 = new WeightedPathFinding.Vertex( 5 );
        var node6 = new WeightedPathFinding.Vertex( 6 );
        var graph = new WeightedPathFinding.Graph
        {
            Value = new Dictionary<WeightedPathFinding.Vertex, List<WeightedPathFinding.Vertex>>
            {
                { node1, [node2, node6] },
                { node2, [node3] },
                { node3, [node4] },
                { node4, [node5] },
            }
        };

        // Assert
        var path = WeightedPathFinding.FindPath( graph, node1, node5 );
        Assert.Equal( path.Count, 5 );
    }
    
    [Fact]
    public void FindPath_HasPathWithCycles_ShouldBeTrue( )
    {
        // Arrange
        var node1 = new WeightedPathFinding.Vertex( 1 );
        var node2 = new WeightedPathFinding.Vertex( 2 );
        var node3 = new WeightedPathFinding.Vertex( 3 );
        var node4 = new WeightedPathFinding.Vertex( 4 );
        var node5 = new WeightedPathFinding.Vertex( 5 );
        var node6 = new WeightedPathFinding.Vertex( 6 );
        var graph = new WeightedPathFinding.Graph
        {
            Value = new Dictionary<WeightedPathFinding.Vertex, List<WeightedPathFinding.Vertex>>
            {
                { node1, [node2, node6] },
                { node2, [node3] },
                { node3, [node4] },
                { node4, [node5] },
                { node5, [node6] },
            }
        };

        // Assert
        var path = WeightedPathFinding.FindPath( graph, node2, node6 );
        Assert.Equal( path.Count, 5 );
    }
}