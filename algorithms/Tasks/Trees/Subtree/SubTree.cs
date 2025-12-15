namespace Tasks.Trees.Subtree;

public static class SubTree
{
    public class TreeNode<T>
    {
        public T Value { get; init; }
        public TreeNode<T>? Left { get; init; }
        public TreeNode<T>? Right { get; init; }
    }

    /*
     * Determine if a tree subroot is a subtree of a root.
     * A subtree consists of a node in root and all its descendants
     * with the same structure and values as subroot.
     */
    public static bool Check<T>( TreeNode<T>? root, TreeNode<T>? subtree )
    {
        if ( root == null ) return false;

        bool IsIdentical( TreeNode<T>? a, TreeNode<T>? b )
        {
            if ( a == null && b == null ) return true;
            if ( a == null || b == null ) return false;
            
            return a.Value.Equals( b.Value )
                && IsIdentical( a.Left, b.Left )
                && IsIdentical( a.Right, b.Right );
        }

        return IsIdentical( root, subtree ) ||
               IsIdentical( root.Left, subtree ) ||
               IsIdentical( root.Right, subtree );
    }
}