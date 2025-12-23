namespace Tasks.Trees.Balanced;

public class TreeBalanced
{
    public class TreeNode<T>
    {
        public T Value { get; init; }
        public TreeNode<T>? Left { get; init; }
        public TreeNode<T>? Right { get; init; }
    }
    
    /*
     * A binary tree is height-balanced if the depths of the two subtrees
     * of every node differ by at most 1.
     * 
     */
    public static bool Run<T>( TreeNode<T>? root )
    {
        if ( root == null ) return false;

        int Height( TreeNode<T>? node )
        {
            if ( node == null ) return 0;

            int left = Height( node.Left );
            if ( left == -1 ) return -1;
            
            int right = Height( node.Right );
            if ( right == -1 ) return -1;

            int diff = Math.Abs( left - right );
            if ( diff > 1 )
            {
                return -1;
            }

            return 1 + Math.Max( left, right );
        }
        
        return Height( root ) != -1;
    }
}