using System.Numerics;

namespace Tasks.BinaryTrees.SmallestDifference;

public class BinaryTreeSmallestDifference
{
    public class TreeNode<T>
    {
        public T Value { get; init; }
        public TreeNode<T>? Left { get; init; }
        public TreeNode<T>? Right { get; init; }
    }
    
    /*
     * Given the root of BST, determine the smallest absolute difference
     * between the values of any two distinct nodes in the tree.
     */
    public static int Check( TreeNode<int>? root ) 
    {
        int minDiff = int.MaxValue;

        TreeNode<int>? prev = null;

        void Run( TreeNode<int>? node )
        {
            if ( node == null ) return;

            Run( node.Left );

            if ( prev is not null )
            {
                minDiff = Math.Min( minDiff, Math.Abs( node.Value - prev.Value ) );
            }

            prev = node;

            Run( node.Right );
        }

        Run( root );
        return minDiff;
    }
}