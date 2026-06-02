namespace Tasks.GraphAlgorithms.Tasks.CheapestFlights;

public class CheapestFlights
{
   
    
    // You are given n cities connected by flights, represented by a list flights.
    // Each flight u,v,p connects city u to city v with a price p.
    // Give a source city src, a destination city dst, and an integer k, return the cheapest price
    // from src to dst with at most k stops. If no such route exists return -1
    public static int Run( int n, (int u, int v, int p)[] prices, int start, int dest, int stops )
    {
        return RunBellmanFord(n, prices, start, dest, stops );
//        return RunDijkstra( n, prices, start, dest, stops );
    }

    private static int RunBellmanFord( int n, (int u, int v, int p)[] prices, int start, int dest, int stops )
    {
        var dist = new Dictionary<int, int>();
        for ( int i = 0; i < n; i++ )
        {
            dist[i] = int.MaxValue;
        }

        dist[start] = 0;
        for ( int i = 0; i < stops + 1; i++ )
        {
            Dictionary<int, int> tempDist = new Dictionary<int, int>( dist );
            foreach ( (int u, int v, int p) item in prices )
            {
                if (dist[item.u] == int.MaxValue) continue;
                int curDist = dist[item.u] + item.p;
                if ( curDist < tempDist[item.v] )
                {
                    tempDist[item.v] = curDist;
                }
            }

            dist = tempDist;
        }

        return dist[dest] == int.MaxValue
            ? -1
            : dist[dest];
    }

    private static int RunDijkstra( int n, (int u, int v, int p)[] prices, int start, int dest, int stops )
    {
        Dictionary<int, List<(int, int)>> graph = [];
        for ( int i = 0; i < n; i++ )
        {
            graph[i] = [];
        }

        foreach ( (int u, int v, int p) item in prices )
        {
            graph[item.u].Add( ( item.v, item.p ) );
        }

        PriorityQueue<int, (int, int)> queue = new PriorityQueue<int, (int, int)>( );
        queue.Enqueue( start, (0, 0) );
        while ( queue.TryDequeue( out int curNode, out (int price, int stops) curData ) )
        {
            if ( curNode == dest )
            {
                return curData.price;
            }

            if ( curData.stops > stops )
            {
                continue;
            }

            foreach ( (int neighbour, int price) item in graph[curNode] )
            {
                int curPrice = curData.price + item.price;
                queue.Enqueue( item.neighbour, (curPrice, curData.stops + 1) );
            }
        }

        return -1;
    }
}