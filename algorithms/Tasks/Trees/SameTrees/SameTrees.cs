namespace Tasks.Trees.SameTrees;

public class SameTrees
{
    public class TreeNode<T>
    {
        public T Value { get; init; }
        public TreeNode<T>? Left { get; init; }
        public TreeNode<T>? Right { get; init; }
    }
    /*
     * Check if two binary trees are structurally identical and have the same values for corresponding nodes
     */
    public static bool IsEqual<T>( TreeNode<T>? first, TreeNode<T>? second )
    {
        if ( first == null && second == null ) return true;
        if ( first == null || second == null ) return false;
        if ( !first.Value.Equals( second.Value ) ) return false;

        bool left = IsEqual( first.Left, second.Left );
        bool right = IsEqual( first.Right, second.Right );

        return left && right;
    }
}