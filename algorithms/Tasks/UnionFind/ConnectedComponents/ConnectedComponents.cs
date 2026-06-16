using Tasks.UnionFind.Simple;

namespace Tasks.UnionFind.ConnectedComponents;

public class ConnectedComponents
{
    /*
     * Given n nodes, from 0 to n-1, and a list of edges. Return the number of connected components in a graph
     * directly connected to city j. Return the total number of provinces (connected components)
     */
    public static int Run( (int from, int to)[] edges, int n )
    {
        RankUnionFind find = new RankUnionFind( n );
        foreach ( (int from, int to) item in edges )
        {
            find.Union( item.from, item.to );
        }
        return find.SetsCount(  );
    }
}