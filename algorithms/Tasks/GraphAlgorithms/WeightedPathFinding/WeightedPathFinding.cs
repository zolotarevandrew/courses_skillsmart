namespace Tasks.GraphAlgorithms.WeightedPathFinding;

public class WeightedPathFinding
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

    public static Dictionary<Vertex, int> Dijkstra( Graph graph, Vertex start )
    {
        // O(V)
        Dictionary<Vertex, int> distances = [];
        foreach ( Vertex vertex in graph.Value.Keys )
        {
            distances[vertex] = int.MaxValue;
        }

        distances[start] = 0;

        PriorityQueue<Vertex, int> queue = new PriorityQueue<Vertex, int>( );
        queue.Enqueue( start, 0 );

        // Dequeue = o Log V + o e all edges
        while ( queue.TryDequeue( out Vertex? current, out int curDist ) )
        {
            if ( curDist > distances[current] )
            {
                continue;
            }

            foreach ( (Vertex v, int dist) in graph.Get( current ) )
            {
                int newDist = curDist + dist;
                if ( newDist < distances[v] )
                {
                    distances[v] = newDist;
                    queue.Enqueue( v, newDist );
                }
            }
        }

        return distances;

    }
    
    public static Dictionary<Vertex, int> BellmanFord( Graph graph, Vertex start )
    {
        Dictionary<Vertex, int> distances = [];
        foreach ( Vertex vertex in graph.Value.Keys )
        {
            distances[vertex] = int.MaxValue;
        }

        distances[start] = 0;

        for ( int i = 0; i < graph.Value.Keys.Count - 1; i++ )
        {
            foreach ( Vertex vertex in graph.Value.Keys )
            {
                int curDist = distances[vertex];
                foreach ( (Vertex v, int dist) in graph.Get( vertex ) )
                {
                    int newDist = curDist + dist;
                    if ( newDist < distances[v] )
                    {
                        distances[v] = newDist;
                    }
                }
            }
        }

        foreach ( Vertex vertex in graph.Value.Keys )
        {
            int curDist = distances[vertex];
            foreach ( (Vertex v, int dist) in graph.Get( vertex ) )
            {
                int newDist = curDist + dist;
                if ( newDist < distances[v] )
                {
                    throw new InvalidOperationException( "negative value detected" );
                }
            }
        }
        

        return distances;

    }
    public static List<List<int>> FloydWarshall( int[,] weights )
    {
        int size = weights.GetLength(0);
        List<List<int>> dist = [];
        for ( int i = 0; i < size; i++ )
        {
            List<int> row = [];
            for ( int j = 0; j < size; j++ )
            {
                if ( i == j )
                {
                    row.Add( 0 );
                    continue;
                }

                if ( weights[i, j] == 0 )
                {
                    row.Add( int.MaxValue );
                    continue;
                }
                
                row.Add( weights[i, j] );
            }    
            
            dist.Add( row );
        }

        for ( int k = 0; k < size; k++ )
        {
            for ( int i = 0; i < size; i++ )
            {
                for ( int j = 0; j < size; j++ )
                {
                    int start = dist[i][k];
                    int end = dist[k][j];
                    
                    // защита от переполнения
                    if (start == int.MaxValue || end == int.MaxValue)
                    {
                        continue;
                    }
                    
                    int check = dist[i][j];
                    if ( start + end < check )
                    {
                        dist[i][j] = start + end;
                    }
                }    
            }    
        }
        

        return dist;

    }
}