namespace Tasks.Trees.Depth;

public class TreeDepth
{
    public class TreeNode<T>
    {
        public T Value { get; init; }
        public TreeNode<T>? Left { get; init; }
        public TreeNode<T>? Right { get; init; }
    }

    public static int Get<T>( TreeNode<T>? root )
    {
        if ( root == null ) return 0;
        
        int left = Get( root.Left );
        int right = Get( root.Right );

        return 1 + Math.Max( left, right );
    }
}