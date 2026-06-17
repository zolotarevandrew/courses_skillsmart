using Tasks.UnionFind.Simple;

namespace Tasks.MinimumSpanningTrees;

public class KruskalAlgorithm
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

    public static int Run( int n, (int from, int to, int weight)[] edges )
    {
        RankUnionFind find = new RankUnionFind( n );
        Array.Sort( edges, ( a, b ) => a.weight.CompareTo( b.weight ) );
        return ( from edge in edges where find.Union( edge.@from, edge.to ) select edge.weight ).Sum( );
    }
}