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
        if (node == null) return null;

        ( node.Left, node.Right ) = ( node.Right, node.Left );

        Run( node.Left );
        Run( node.Right );

        return node;
    }
}