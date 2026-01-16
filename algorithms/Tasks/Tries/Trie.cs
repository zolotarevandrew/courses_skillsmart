namespace Tasks.Tries;

public class TrieNode<T>( char val, T? metadata )
{
    public char Value { get; set; } = val;
    public Dictionary<char, TrieNode<T>> Children { get; init; } = new ( );
    public T? Metadata { get; init; } = metadata;
    public bool IsEnd { get; set; }
    
    public bool HasNoChildren => Children.Count == 0;
}

public class Trie<T>
{
    private TrieNode<T> _root;

    public Trie( TrieNode<T> root )
    {
        _root = root;
    }

    public bool Exists( string word )
    {
        TrieNode<T> node = _root;
        foreach ( char c in word )
        {
            if ( !node.Children.TryGetValue( c, out TrieNode<T>? child ) )
            {
                return false;
            }

            node = child;
        }

        return node.IsEnd;
    }
    
    public void Insert( string word )
    {
        TrieNode<T> node = _root;
        foreach ( char c in word )
        {
            if ( !node.Children.TryGetValue( c, out TrieNode<T>? child ) )
            {
                node.Children[c] = child = new TrieNode<T>( c, default(T) );
            }

            node = child;
        }

        node.IsEnd = true;
    }
    
    public bool SearchPrefix( string word )
    {
        TrieNode<T> node = _root;
        foreach ( char c in word )
        {
            if ( !node.Children.TryGetValue( c, out TrieNode<T>? child ) )
            {
                return false;
            }

            node = child;
        }

        return true;
    }
    
    public bool Delete( string word )
    {
        //var res = DeleteInternal( word, _root, 0 );
        //return res.WasDeleted;
        return DeleteStack( word );
    }

    private bool DeleteStack( string word )
    {
        if ( string.IsNullOrEmpty( word ) )
        {
            return false;
        }
        
        TrieNode<T> node = _root;
        Stack<TrieNode<T>> stack = new();
        stack.Push( _root );
        foreach ( char c in word )
        {
            if ( !node.Children.TryGetValue( c, out TrieNode<T>? child ) )
            {
                return false;
            }

            node = child;
            stack.Push( node );
        }

        if ( !node.IsEnd )
        {
            stack.Clear( );
            return false;
        }

        node.IsEnd = false;
        if ( !node.HasNoChildren )
        {
            stack.Clear( );
            return true;
        }

        // удаляем текущую Node - мы ее итак проверили
        stack.Pop( );
        int idx = word.Length;
        while ( stack.Count > 0 )
        {
            TrieNode<T> curNode = stack.Pop( );
            char ch = word[--idx];
            curNode.Children.Remove( ch );

            bool canDelete = !curNode.IsEnd && curNode.HasNoChildren;
            if ( !canDelete )
            {
                break;
            }
        }

        stack.Clear(  );
        return true;
    }

    private record struct DeleteResult( bool CanDelete, bool WasDeleted );

    private DeleteResult DeleteInternal( string word, TrieNode<T>? node, int idx )
    {
        if ( node is null ) return new DeleteResult( false, false );

        if ( idx == word.Length )
        {
            if ( !node.IsEnd )
            {
                return new DeleteResult( false, false );
            }

            node.IsEnd = false;
            return new DeleteResult( node.HasNoChildren, true );
        }

        char ch = word[idx];
        if ( !node.Children.TryGetValue( ch, out TrieNode<T>? child ) )
        {
            return new DeleteResult( false, false );
        }
        
        DeleteResult deleteResult = DeleteInternal( word, child, idx + 1 );
        if ( !deleteResult.WasDeleted )
        {
            return new DeleteResult( false, false );
        }

        if ( deleteResult.CanDelete )
        {
            node.Children.Remove( ch );
        }
        
        return new DeleteResult( !node.IsEnd && node.HasNoChildren, true );
    }
}