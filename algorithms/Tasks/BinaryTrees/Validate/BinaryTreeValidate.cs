using System.Numerics;

namespace Tasks.BinaryTrees.Validate;

public class BinaryTreeValidate
{
    public class TreeNode<T>
    {
        public T Value { get; init; }
        public TreeNode<T>? Left { get; init; }
        public TreeNode<T>? Right { get; init; }
    }
    
    /*
     * Determine if a binary tree is a valid BST.
     * A valid BST satisfies:
     * - All left descendants are less than node's value
     * - All right descendants are greater than node's value
     */
    public static bool Check<T>( TreeNode<T>? root ) where T: INumber<T>
    {
        bool IsValid( TreeNode<T>? node, Option<T> min, Option<T> max )
        {
            if ( node == null ) return true;

            if ( min.HasValue && node.Value <= min.Value! )
            {
                return false;
            }
            
            if ( max.HasValue && node.Value >= max.Value! )
            {
                return false;
            }

            return IsValid( node.Left, min, new Option<T>( node.Value ) ) 
                   && IsValid( node.Right, new Option<T>( node.Value ), max );
        }

        return IsValid( root, new Option<T>( ), new Option<T>( ) );
    }

    readonly struct Option<T>
    {
        public T? Value { get; }
        public bool HasValue { get; }

        public Option( T val )
        {
            Value = val;
            HasValue = true;
        }

        public Option( )
        {
            HasValue = false;
            Value = default;
        }
    }
}