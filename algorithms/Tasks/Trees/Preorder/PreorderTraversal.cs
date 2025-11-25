namespace Tasks.Trees.Preorder;

public class PreorderTraversal
{
    public class TreeNode<T>
    {
        public T Value { get; init; }
        public TreeNode<T>? Left { get; init; }
        public TreeNode<T>? Right { get; init; }
    }
    /*
     * Return the preorder traversal (root, left, right) of a binary tree's node values
     */
    public static List<T> Run<T>( TreeNode<T> tree )
    {
        List<T> res = new List<T>( );
        RunInternal( tree );
        return res;
        
        void RunInternal( TreeNode<T>? curNode )
        {
            if ( curNode == null ) return;
            
            res.Add( curNode.Value );
            RunInternal( curNode.Left );
            RunInternal( curNode.Right );
        }
    }
}