using System.Numerics;

namespace Tasks.Trees.Sum;

public static class TreeSumRootToLeaf
{
    public class TreeNode<T>
    {
        public T Value { get; init; }
        public TreeNode<T>? Left { get; init; }
        public TreeNode<T>? Right { get; init; }
        
        public T Accumulated { get; set; }
    }

    /*
     * Calculate the sum of all numbers formed by root to leaf paths
     */
    public static T Run<T>( TreeNode<T>? root )
        where T: INumber<T>
    {
        if ( root == null ) return default;

        T result = T.Zero;

        void InternalRun( TreeNode<T>? node, T accumulated )
        {
            if ( node == null )
            {
                return;
            }

            T newAccumulated = ( accumulated * T.CreateChecked( 10 ) ) + node.Value;

            if ( node.Left == null && node.Right == null )
            {
                result += newAccumulated;
                return;
            }

            if ( node.Left != null )
            {
                InternalRun( node.Left, newAccumulated );
            }

            if ( node.Right != null )
            {
                InternalRun( node.Right, newAccumulated );
            }
        }

        InternalRun( root, T.Zero );
        
        return result;
    }
}