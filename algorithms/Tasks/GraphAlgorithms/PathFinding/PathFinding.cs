namespace Tasks.GraphAlgorithms.PathFinding;

public class PathFinding
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

    public static List<Vertex> FindPath( Graph graph, Vertex start, Vertex end )
    {
        if ( start == end ) return [start];
        
        HashSet<Vertex> visited = [];
        Queue<(Vertex, List<Vertex>)> queue = new Queue<(Vertex, List<Vertex>)>();
        queue.Enqueue( (start, [start]) );
        visited.Add( start );

        while ( queue.Count > 0 )
        {
            ( Vertex current, List<Vertex> path ) = queue.Dequeue( );
            if ( current == end )
            {
                return path;
            }
            
            foreach ( Vertex neighbour in graph.Get( current ) )
            {
                if ( visited.Contains( neighbour ) ) continue;

                queue.Enqueue( (neighbour, [..path, neighbour]) );
                visited.Add( neighbour );
            }
        }

        return [];

    }
}