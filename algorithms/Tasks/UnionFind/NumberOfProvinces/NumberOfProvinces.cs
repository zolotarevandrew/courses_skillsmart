using Tasks.UnionFind.Simple;

namespace Tasks.UnionFind.NumberOfProvinces;

public class NumberOfProvinces
{
    /*
     * Given n cities, represented by n x n adjadency, matrix isConnected, where i,j = 1 means city i is
     * directly connected to city j. Return the total number of provinces (connected components)
     */
    public static int Run( int[,] adjacency )
    {
        int n = adjacency.GetLength( 0 );
        RankUnionFind find = new RankUnionFind( n );
        for ( int row = 0; row < n; row++ )
        {
            for ( int col = 0; col < n; col++ )
            {
                if ( adjacency[row, col] == 1 )
                {
                    find.Union( row, col );
                }
            }
        }

        return find.SetsCount();
    }
}