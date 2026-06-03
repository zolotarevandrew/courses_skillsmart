namespace Tasks.GraphAlgorithms.Tasks.PathMaximumProbability;

public class PathMaximumProbability
{
   
    
    // Given a weighted undirected graph with n nodes, an edge list edges.
    // and an array succProb of edge probabilities.
    // Find the path with maximum probability from start to end.
    // Return the maximum probability, or 0 if no path exists.
    public static double Run( 
        int n, 
        (int from, int to)[] edges, 
        double[] probs, 
        int start, 
        int end )
    {
        Dictionary<int, double> probabilities = [];
        Dictionary<int, List<(int, double)>> graph = [];
        for ( int i = 0; i < n; i++ )
        {
            probabilities[i] = 0;
            graph[i] = [];
        }

        for ( int i = 0; i < edges.Length; i++ )
        {
            (int from, int to) edge = edges[i];
            double prob = probs[i];
            graph[edge.from].Add( ( edge.to, prob ) );
            graph[edge.to].Add( ( edge.from, prob ) );
        }

        probabilities[start] = 1.0;

        var queue = new PriorityQueue<int, double>(
            Comparer<double>.Create( ( x, y ) => y.CompareTo( x ) )
        );
        queue.Enqueue( start, probabilities[start] );
        while ( queue.TryDequeue( out var curNode, out var curProb ) )
        {
            if ( curNode == end )
            {
                return curProb;
            }

            foreach ( (int neighbour, double prob) item in graph[curNode] )
            {
                double prob = curProb * item.prob;
                if ( prob > probabilities[item.neighbour] )
                {
                    probabilities[item.neighbour] = prob;
                    queue.Enqueue( item.neighbour, prob );
                }
            }
        }

        return 0;
    }
}