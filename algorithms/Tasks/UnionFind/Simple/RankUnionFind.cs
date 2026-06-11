namespace Tasks.UnionFind.Simple;

public class RankUnionFind
{
    private List<int> _parent;
    private List<int> _ranks;
    public RankUnionFind( int n )
    {
        _parent = Enumerable
            .Range( 0, n + 1 )
            .ToList( );
        _ranks = Enumerable
            .Repeat( 0, n +1 )
            .ToList(  );
    }

    public int Find( int u )
    {
        if ( _parent[u] == u ) return _parent[u];
        _parent[u] = Find( _parent[u] );
        return _parent[u];
    }

    public bool Union( int u, int v )
    {
        var rootU = Find( u );
        var rootV = Find( v );
        if ( rootU == rootV ) return false;

        if ( _ranks[rootU] > _ranks[rootV] )
        {
            _parent[rootV] = _parent[rootU];
            return true;
        }
        _parent[rootU] = _parent[rootV];
        if ( _ranks[rootU] == _ranks[rootV] )
        {
            _ranks[rootV]++;
        }

        return true;
    }
}