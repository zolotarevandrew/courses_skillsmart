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
    
    class TreeNodeWrapper<T>( TreeNode<T> node )
    {
        public TreeNode<T> Node { get; init; } = node;
    }
    
    public static List<T> RunStack<T>( TreeNode<T>? tree )
    {
        List<T> res = [];
        if ( tree == null ) return res;

        Stack<TreeNodeWrapper<T>> stack = new Stack<TreeNodeWrapper<T>>( );
        stack.Push( new TreeNodeWrapper<T>( tree ) );
        while ( stack.Count > 0 )
        {
            TreeNodeWrapper<T> curNode = stack.Pop( );

            res.Add( curNode.Node.Value );
            
            if ( curNode.Node.Right != null )
            {
                stack.Push( new TreeNodeWrapper<T>( curNode.Node.Right ) );
            }
            
            if ( curNode.Node.Left != null )
            {
                stack.Push( new TreeNodeWrapper<T>( curNode.Node.Left ) );
            }
        }
        
        return res;
    }
}