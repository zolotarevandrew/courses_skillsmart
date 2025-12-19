namespace Tasks.Trees.Diameter;

public static class TreeDiameter
{
    public class TreeNode<T>
    {
        public T Value { get; init; }
        public TreeNode<T>? Left { get; init; }
        public TreeNode<T>? Right { get; init; }
    }

    /*
     * Diameter is the longest path between any two nodes in the tree.
     * This path may or may not pass through the root.
     * The diameter at any node is the sum of the heights of its left and right subtrees.
     * As we recursively compute the heights of all nodes, we can simultaneously track the maximum diameter encountered.
     */
    public static int Run<T>( TreeNode<T>? root )
    {
        int maxDiameter = 0;
        int Height( TreeNode<T>? node )
        {
            if ( node == null ) return 0;

            int leftHeight = Height( node.Left );
            int rightHeight = Height( node.Right );

            int curDiameter = leftHeight + rightHeight;
            maxDiameter = Math.Max( maxDiameter, curDiameter );

            return Math.Max( leftHeight, rightHeight ) + 1;
        }

        Height( root );
        return maxDiameter;
    }
}