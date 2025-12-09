namespace Tasks.Trees.ZigZag;

public class TreeZigZagTraversal
{
    public class TreeNode<T>
    {
        public T Value { get; init; }
        public TreeNode<T>? Left { get; init; }
        public TreeNode<T>? Right { get; init; }
    }

    /*
     * Perform a zigzag traversal, alternating between left-to-right, right-to-left traversal
     */
    public static List<T[]> Visit<T>( TreeNode<T>? tree )
    {
        List<T[]> res = [];
        if ( tree == null ) return res;

        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
        queue.Enqueue( tree );

        bool isLeftToRight = true;
        while ( queue.Count > 0 )
        {
            int size = queue.Count;
            T[] arr = new T[size];
            for ( int i = 0; i < size; i++ )
            {
                TreeNode<T> node = queue.Dequeue( );

                int idx = isLeftToRight ? i : size - 1 - i;
                arr[idx] = node.Value; 
                
                if ( node.Left != null )
                {
                    queue.Enqueue( node.Left );
                }
                
                if ( node.Right != null )
                {
                    queue.Enqueue( node.Right );
                }
            }

            res.Add( arr );
            isLeftToRight = !isLeftToRight;
        }
        return res;
    }
}