using System.Numerics;

namespace Tasks.Trees.LargestRow;

public class LargestRowValue
{
    public class TreeNode<T>
    {
        public T Value { get; init; }
        public TreeNode<T>? Left { get; init; }
        public TreeNode<T>? Right { get; init; }
    }
    
    /*
     * Return an array of the largest value in each row of a binary tree.
     */
    public static List<T> Visit<T>( TreeNode<T> tree )
        where T : INumber<T>
    {
        List<T> res = [];
        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>( );
        queue.Enqueue( tree );
        while ( queue.Count > 0 )
        {
            int size = queue.Count;
            T max = T.Zero;
            for ( int i = 0; i < size; i++ )
            {
                TreeNode<T> node = queue.Dequeue( );

                max = T.Max( node.Value, max );
                if ( node.Left != null )
                {
                    queue.Enqueue( node.Left );
                }
                
                if ( node.Right != null )
                {
                    queue.Enqueue( node.Right );
                }
            }
            res.Add( max );
        }
        return res;
    }
}