namespace Tasks.Trees.RightSideView;

public class RightSideView
{
    public class TreeNode<T>
    {
        public T Value { get; init; }
        public TreeNode<T>? Left { get; init; }
        public TreeNode<T>? Right { get; init; }
    }

    public static List<T> Visit<T>( TreeNode<T>? node )
    {
        if ( node == null ) return [];

        List<T> result = [];
        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
        queue.Enqueue( node );
        while ( queue.Count > 0 )
        {
            TreeNode<T> last = null;
            int size = queue.Count;
            for ( int i = 0; i < size; i++ )
            {
                last = queue.Dequeue();
                if ( last.Left != null )
                {
                    queue.Enqueue( last.Left );
                }

                if ( last.Right != null )
                {
                    queue.Enqueue( last.Right );
                }
            }
            result.Add( last!.Value );
        }
        return result;
    }
}