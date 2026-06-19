using Tasks.UnionFind.Simple;

namespace Tasks.MinimumSpanningTrees.MinimumCost;

public class MinimumCost
{
    /*
     * You are provided with an array points, each element point on 2D plane.
     * The cost to connect two points is defined as their manhattan distance.
     * Your task is to determine the minimum total cost required to connect all points.
     * Such that every pair of points has exactly one simple path between them
     */
    public static int Run( Point[] points )
    {
        RankUnionFind find = new RankUnionFind( points.Length );
        int total = 0;
        List<(int from, int to, int dist)> edges = [];
        for ( int src = 0; src < points.Length; src++ )
        {
            for ( int dst = src + 1; dst < points.Length; dst++ )
            {
                int dist = points[src].DistanceTo( points[dst] );
                edges.Add(  ( src, dst, dist ) );
            }
        }

        edges.Sort( ( a, b ) => a.dist.CompareTo( b.dist ) );
        int usedEdges = 0;
        foreach ( var edge in edges )
        {
            if ( find.Union( edge.from, edge.to ) )
            {
                total += edge.dist;
                usedEdges++;

                if (usedEdges == points.Length - 1)
                    return total;
            }
        }
        
        return total;
    }

    public readonly record struct Point( int X, int Y )
    {
        public int DistanceTo( Point other )
        {
            return Math.Abs( X - other.X ) + Math.Abs( Y - other.Y );
        }
    }
}