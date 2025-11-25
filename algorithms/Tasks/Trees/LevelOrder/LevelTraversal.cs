namespace Tasks.Trees.LevelOrder;

public class LevelTraversal
{
    public class TreeNode<T>
    {
        public T Value { get; init; }
        public TreeNode<T>? Left { get; init; }
        public TreeNode<T>? Right { get; init; }
    }
    /*
     * Return the level order traversal of a binary tree's node values
     */
    public static List<List<T>> Run<T>( TreeNode<T> tree )
    {
        List<List<T>> res = [];

        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>( );
        queue.Enqueue( tree );
        while ( queue.Count > 0 )
        {
            List<T> curLevel = [];
            int cnt = queue.Count;
            for ( int i = 0; i < cnt; i++ )
            {
                TreeNode<T> node = queue.Dequeue( );
                curLevel.Add( node.Value );

                if ( node.Left != null )
                {
                    queue.Enqueue( node.Left );
                }
                
                if ( node.Right != null )
                {
                    queue.Enqueue( node.Right );
                }
            }
            
            
            res.Add( curLevel );
        }
        return res;
    }
}