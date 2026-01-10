namespace Tasks.BinaryTrees.KSmallest;

public class BinaryTreeKSmallest
{
    public class TreeNode<T>
    {
        public T Value { get; init; }
        public TreeNode<T>? Left { get; init; }
        public TreeNode<T>? Right { get; init; }
    }
    
    /*
     * Given the root of BST, return the K-smallest element in the tree (1-indexed).
     */
    public static int Get( TreeNode<int>? root, int k = 1 )
    {
        if ( k <= 0 ) return 0;
        
        int kStart = 0;
        int res = 0;

        void Run( TreeNode<int>? node )
        {
            if ( node == null ) return;

            Run( node.Left );

            kStart++;
            if ( kStart == k )
            {
                res = node.Value;
                return;
            }

            Run( node.Right );
        }

        Run( root );

        return res;
    }
}