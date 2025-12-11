namespace Tasks.Trees.Invert;

public class InvertTree
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T>? Left { get; set; }
        public TreeNode<T>? Right { get; set; }
    }

    /*
     * Invert a binary tree (swap left and right children at every node)
     */
    public static TreeNode<T>? Run<T>( TreeNode<T>? node )
    {
        return RunRecursion( node );
    }
    
    internal static TreeNode<T>? RunRecursion<T>( TreeNode<T>? node )
    {
        if (node == null) return null;

        ( node.Left, node.Right ) = ( node.Right, node.Left );

        Run( node.Left );
        Run( node.Right );

        return node;
    }
    
    internal static TreeNode<T>? RunQueue<T>( TreeNode<T>? tree )
    {
        if ( tree == null ) return null;
       
        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
        queue.Enqueue( tree );
        while ( queue.Count > 0 )
        {
            TreeNode<T> node = queue.Dequeue( );
            ( node.Left, node.Right ) = ( node.Right, node.Left );
            if ( node.Left != null )
            {
                queue.Enqueue( node.Left );
            }

            if ( node.Right != null )
            {
                queue.Enqueue( node.Right );
            }
        }

        return tree;
    }
}