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

    class TreeNodeWrapper<T>( TreeNode<T> node )
    {
        public TreeNode<T> Node { get; init; } = node;
        public State State { get; set; }
    }

    enum State
    {
        None = 0,
        LeftVisited = 1
    }
    
    public static List<T> RunStack<T>( TreeNode<T>? tree )
    {
        List<T> res = [];
        if ( tree == null ) return res;

        Stack<TreeNodeWrapper<T>> stack = new Stack<TreeNodeWrapper<T>>( );
        stack.Push( new TreeNodeWrapper<T>( tree ) );
        while ( stack.Count > 0 )
        {
            TreeNodeWrapper<T> curNode = stack.Peek( );
            if ( curNode.Node.Left != null && curNode.State != State.LeftVisited )
            {
                curNode.State = State.LeftVisited;
                stack.Push( new TreeNodeWrapper<T>( curNode.Node.Left ) );
                continue;
            }
            
            res.Add( curNode.Node.Value );
            stack.Pop( );
            
            if ( curNode.Node.Right != null )
            {
                stack.Push( new TreeNodeWrapper<T>( curNode.Node.Right ) );
            }
        }
        
        return res;
    }
}