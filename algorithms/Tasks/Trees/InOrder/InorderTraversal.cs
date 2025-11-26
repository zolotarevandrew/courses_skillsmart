namespace Tasks.Trees.InOrder;

public class InorderTraversal
{
    public class TreeNode<T>
    {
        public T Value { get; init; }
        public TreeNode<T>? Left { get; init; }
        public TreeNode<T>? Right { get; init; }
    }
    /*
     * Return the inorder traversal (left, root, right) of a binary tree's node values
     */
    public static List<T> Run<T>( TreeNode<T> tree )
    {
        List<T> res = new List<T>( );
        RunInternal( tree );
        return res;
        
        void RunInternal( TreeNode<T>? curNode )
        {
            if ( curNode == null ) return;
            
            RunInternal( curNode.Left );
            res.Add( curNode.Value );
            RunInternal( curNode.Right );
        }
    }
    
    public static List<T> RunStack<T>( TreeNode<T>? tree )
    {
        List<T> res = [];
        if ( tree == null ) return res;

        Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>( );
        stack.Push( tree );
        while ( stack.Count > 0 )
        {
            TreeNode<T> curNode = stack.Peek( );
            if ( curNode.Left != null )
            {
                stack.Push( curNode.Left );
                continue;
            }
            
            res.Add( curNode.Value );
            stack.Pop( );
            
            if ( curNode.Right != null )
            {
                stack.Push( curNode.Right );
            }
        }
        
        return res;
        
        void RunInternal( TreeNode<T>? curNode )
        {
            if ( curNode == null ) return;
            
            RunInternal( curNode.Left );
            res.Add( curNode.Value );
            RunInternal( curNode.Right );
        }
    }
}