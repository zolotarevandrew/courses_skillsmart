using System.Numerics;

namespace Tasks.Trees.PathSum;

public class TreePathSum
{
    public class TreeNode<T>
    {
        public T Value { get; init; }
        public TreeNode<T>? Left { get; init; }
        public TreeNode<T>? Right { get; init; }
    }

    public static bool Run<T>( TreeNode<T>? root, T sum )
        where T : INumber<T>
    {
        bool Dfs( TreeNode<T>? node, T curSum )
        {
            if ( node == null ) return false;
            
            curSum += node.Value;

            if ( node.Left == null && node.Right == null )
            {
                return curSum == sum;
            }

            return Dfs( node.Left, curSum ) || Dfs( node.Right, curSum );
        }

        return Dfs( root, T.Zero );
    }
}