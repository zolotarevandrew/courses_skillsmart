namespace Tasks.UnionFind.Simple;

public class RankUnionFind
{
    private List<int> _parent;
    private List<int> _ranks;
    public RankUnionFind( int n )
    {
        _parent = Enumerable
            .Range( 0, n )
            .ToList( );
        _ranks = new List<int>( n );
    }

    public int Find( int u )
    {
        if ( _parent[u] == u ) return _parent[u];
        _parent[u] = Find( _parent[u] );
        return _parent[u];
    }

    public void Union( int u, int v )
    {
        var rootU = Find( u );
        var rootV = Find( v );
        if ( rootU == rootV ) return;

        if ( _ranks[rootU] > _ranks[rootV] )
        {
            _parent[rootV] = _ranks[rootU];
            return;
        }
        
        _parent[rootU] = _ranks[rootV];
        if ( _ranks[rootU] == _ranks[rootV] )
        {
            _ranks[rootV]++;
        }
    }
}