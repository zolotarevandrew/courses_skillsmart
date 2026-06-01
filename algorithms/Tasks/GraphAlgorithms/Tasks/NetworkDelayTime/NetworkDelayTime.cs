namespace Tasks.GraphAlgorithms.Tasks.NetworkDelayTime;

public class NetworkDelayTime
{
    

    /*
     * You are given a network of N nodes labeled from 1 to n, represented by a list times.
     * Each element of times is [u,v,w], where u is the source node, v is the target node, and w is the time
     * it takes to travel from u to v.
     * A signal is sent from a starting node k. Return the time it takes for all nodes to receive a signal.
     * If it is impossible for all nodes to receive a signal return -1
     */

    public static int Run(
        (int u, int v, int w)[] times, 
        int n, 
        int k )
    {
        return RunBellmanFord( times, n, k );
        //return RunDijkstra( times, n, k );
    }

    private static int RunDijkstra( (int u, int v, int w)[] times, int n, int k )
    {
        Dictionary<int, int> dist = new Dictionary<int, int>();
        Dictionary<int, List<(int v, int w)>> graph = new Dictionary<int, List<(int v, int w)>>();
        for (int i = 1; i <= n; i++)
        {
            dist[i] = int.MaxValue;
            graph[i] = [];
        }
        
        foreach ( ( int u, int v, int w ) in times )
        {
            graph[u].Add( ( v, w ) );
        }

        dist[k] = 0;
        
        PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
        queue.Enqueue( k, dist[k] );

        while ( queue.TryDequeue( out int curNode, out var curDist ) )
        {
            if ( curDist > dist[curNode] )
            {
                continue;
            }

            foreach ( (int v, int w) neighbour in graph[curNode] )
            {
                int dst = curDist + neighbour.w;
                if ( dst < dist[neighbour.v] )
                {
                    dist[neighbour.v] = dst;
                    queue.Enqueue( neighbour.v, dst );
                }
            }
        }

        int max = ( from key in dist.Keys select dist[key] ).Max( );
        return max == int.MaxValue ? -1 : max;
    }
    
    private static int RunBellmanFord( (int u, int v, int w)[] times, int n, int k )
    {
        Dictionary<int, int> dist = new Dictionary<int, int>();
        for (int i = 1; i <= n; i++)
        {
            dist[i] = int.MaxValue;
        }

        dist[k] = 0;

        for ( int i = 0; i < n - 1; i++ )
        {
            foreach ( (int start,int end, int w) neighbour in times )
            {
                var startDist = dist[neighbour.start];
                if ( startDist == int.MaxValue ) continue;

                var curDist = startDist + neighbour.w;
                if ( curDist < dist[neighbour.end] )
                {
                    dist[neighbour.end] = curDist;
                }
            }
        }

        int max = ( from key in dist.Keys select dist[key] ).Max( );
        return max == int.MaxValue ? -1 : max;
    }
}