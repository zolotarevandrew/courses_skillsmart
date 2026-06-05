namespace Tasks.GraphAlgorithms.TopologicalSorting;

public class TopologicalSorting
{
    public class Graph
    {
        public Dictionary<Vertex, List<Vertex>> Value { get; set; }

        public List<Vertex> Get( Vertex vertex )
        {
            return Value.TryGetValue( vertex, out List<Vertex>? value ) ? value : [ ];
        }
    }

    public record Vertex( int Value );

    public static List<Vertex> DfsSort( Graph graph )
    {
        Stack<Vertex> stack = [];
        HashSet<Vertex> visited = [];
        foreach ( Vertex vertex in graph.Value.Keys )
        {
            if ( !visited.Contains( vertex ) )
            {
                Dfs( vertex, visited, stack, graph );
            }
        }
        return stack
            .ToList(  );
    }

    static void Dfs( Vertex current, HashSet<Vertex> visited, Stack<Vertex> stack, Graph graph )
    {
        visited.Add( current );

        foreach ( var neighbour in graph.Get( current ) )
        {
            if ( visited.Contains( neighbour ) ) continue;
            Dfs( neighbour, visited, stack, graph );
        }

        stack.Push( current );
    }
    
}