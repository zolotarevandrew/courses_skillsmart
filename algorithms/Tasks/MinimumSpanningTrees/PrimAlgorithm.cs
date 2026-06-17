namespace Tasks.MinimumSpanningTrees;

public class PrimAlgorithm
{
    public class Graph
    {
        public Dictionary<Vertex, List<(Vertex V, int W)>> Value { get; set; }

        public List<(Vertex V, int W)> Get( Vertex vertex )
        {
            return Value.TryGetValue( vertex, out var value ) ? value : [];
        }
    }
    
    public record Vertex( int Value );

    public static int Run( Graph graph )
    {
        int total = 0;
        HashSet<Vertex> visited = [];
        PriorityQueue<Vertex, int> queue = new PriorityQueue<Vertex, int>( );
        queue.Enqueue( new Vertex( 0 ), 0 );
        while ( visited.Count < graph.Value.Count )
        {
            if ( !queue.TryDequeue( out var current, out var currentWeight ) )
            {
                continue;
            }

            if ( !visited.Add( current ) ) continue;

            foreach ( (Vertex V, int W) item in graph.Get( current ) )
            {
                if (visited.Contains( item.V )) continue;

                queue.Enqueue( item.V, item.W );
            }
            
            total += currentWeight;
        }

        return total;
    }
}