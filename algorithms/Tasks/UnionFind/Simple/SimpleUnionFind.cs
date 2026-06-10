using Tasks.Arrays.ProductExceptSelf;

namespace Tasks.UnionFind.Simple;

public class SimpleUnionFind
{
    private List<int> _parent;
    public SimpleUnionFind( int n )
    {
        _parent = Enumerable
            .Range( 0, n )
            .ToList( );
    }

    public int Find( int u )
    {
        return _parent[u] == u ? u : Find( _parent[u] );
    }

    public bool Union( int u, int v )
    {
        var rootU = Find( u );
        var rootV = Find( v );
        if ( rootU != rootV )
        {
            _parent[rootU] = rootV;
            return true;    
        }

        return false;
    }
}