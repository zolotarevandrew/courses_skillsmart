namespace Tasks.Graphs.Clone;

public static class CloneGraph
{
    public record Node
    {
        public int Value { get; init; }
        public List<Node> Neighbors { get; init; } = [];
    }
    
    /// <summary>
    /// Given a reference to a node in a connected undirected graph, create a deep copy a clone of a graph.
    /// Each node contains value and a list of neighboring nodes
    /// </summary>
    public static Node Run( Node node )
    {
        Dictionary<Node, Node> cloned = [];
        return Dfs( node, cloned );
    }
    
    static Node Dfs( Node current, Dictionary<Node, Node> cloned )
    {
        if ( cloned.TryGetValue( current, out Node? dfs ) )
        {
            return dfs;
        }
        
        Node clonedNode = new Node
        {
            Value = current.Value
        };
        cloned[current] = clonedNode;
        foreach ( Node neighbor in current.Neighbors )
        {
            clonedNode.Neighbors.Add( Dfs( neighbor, cloned ) );
        }

        return clonedNode;
    }
}