using Tasks.UnionFind.Simple;

namespace Tasks.MinimumSpanningTrees.ConnectingCities;

public class ConnectingCities
{
    /*
     * There are n cities numbered from 1 to n
     * You are given connections where connections[i] = [city1,city2,cost]
     * cost connect city1 to city2
     * Return the minimum cost so that for every pair of cities, there exists path of connections that connects that two cities together
     * The cost is the sum of the connections cost used. If the task impossible return -1
     */
    public static int Run( int n, (int from, int to, int weight)[] edges )
    {
        RankUnionFind find = new RankUnionFind( n + 1 );
        Array.Sort( edges, ( a, b ) => a.weight.CompareTo( b.weight ) );
        int total = 0;
        int usedEdges = 0;
        foreach ( var edge in edges )
        {
            if ( find.Union( edge.from, edge.to ) )
            {
                total += edge.weight;
                usedEdges++;

                if (usedEdges == n - 1)
                    return total;
            }
        }

        return -1;
    }
}