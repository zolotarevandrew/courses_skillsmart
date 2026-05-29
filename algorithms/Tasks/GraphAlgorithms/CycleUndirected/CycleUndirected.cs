namespace Tasks.GraphAlgorithms.CycleUndirected;

public class CycleUndirected
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

    public static bool HasCycle( Graph graph )
    {
        HashSet<Vertex> visited = [];
        return graph.Value
            .Keys
            .Where( vertex => !visited.Contains( vertex ) )
            .Any( vertex => Dfs( vertex, graph, visited, null ) );
    }

    static bool Dfs( Vertex current, Graph graph, HashSet<Vertex> visited, Vertex? parent )
    {
        visited.Add( current );
        foreach ( Vertex neighbour in graph.Get( current ) )
        {
            if ( !visited.Contains( neighbour ) )
            {
                if ( Dfs( neighbour, graph, visited, current ) )
                {
                    return true;
                }
            }
            else if ( neighbour != parent )
            {
                return true;
            }
        }

        return false;
    }
}