using Tasks.UnionFind.Simple;

namespace Tasks.UnionFind.RedudantConnection;

public class RedudantConnection
{
    /*
     * Your are given an undirected graph
     * that started as a tree with n nodes, labeled from 1 to n.
     * One additional edge was added, making the graph contain exactly one cycle.
     * Return the edge that, when removed leaves a graph as a tree.
     * If there are multiple possible answers, return the edge that appears last in the input.
     */
    public static int? Run( (int from, int to)[] edges, int n )
    {
        return RunUnionFind( edges, n );
    }

    private static int? RunUnionFind( (int from, int to)[] edges, int n )
    {
        RankUnionFind find = new RankUnionFind( n );
        int idx = 0;
        foreach ( (int from, int to) item in edges )
        {
            if ( !find.Union( item.from, item.to ) )
            {
                return idx;
            }
            idx++;
        }

        return null;
    }

    private static int? RunDfs( (int from, int to)[] edges )
    {
        Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>( );
        int idx = 0;
        foreach ( (int from, int to) item in edges )
        {
            HashSet<int> visited = [];
            if ( CanBeCycle( item.from, item.to, graph, visited ) )
            {
                return idx;
            }

            if ( !graph.ContainsKey( item.from ) )
            {
                graph[item.from] = [];
            }
            if ( !graph.ContainsKey( item.to ) )
            {
                graph[item.to] = [];
            }
            
            graph[item.to].Add( item.from );
            graph[item.from].Add( item.to );
            idx++;
        }
        return null;
    }

    static bool CanBeCycle( int from, int to, Dictionary<int, HashSet<int>> graph, HashSet<int> visited )
    {
        if ( from == to ) return true;

        visited.Add( from );
        
        graph.TryGetValue( from, out var neighbours );
        foreach ( var neighbour in neighbours ?? [] )
        {
            if ( visited.Contains( neighbour ) )
            {
                continue;
            }

            if ( CanBeCycle( neighbour, to, graph, visited ) ) return true;
        }

        return false;
    }
}