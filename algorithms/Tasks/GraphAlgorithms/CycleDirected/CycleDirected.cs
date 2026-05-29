namespace Tasks.GraphAlgorithms.CycleDirected;

public class CycleDirected
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
        HashSet<Vertex> path = [];
        return graph.Value
            .Keys
            .Where( vertex => !visited.Contains( vertex ) )
            .Any( vertex => Dfs( vertex, graph, path, visited ) );
    }

    static bool Dfs( Vertex current, Graph graph, HashSet<Vertex> path, HashSet<Vertex> visited )
    {
        visited.Add( current );
        path.Add( current );
        foreach ( Vertex neighbour in graph.Get( current ) )
        {
            if ( !visited.Contains( neighbour ) )
            {
                if ( Dfs( neighbour, graph, path, visited ) )
                {
                    return true;
                }
            }
            else if ( path.Contains( neighbour ) )
            {
                return true;
            }
        }

        path.Remove( current );

        return false;
    }
}