namespace Tasks.Trees.Symmetric;

public class SymmetricTree
{
    public class TreeNode<T>
    {
        public T Value { get; init; }
        public TreeNode<T>? Left { get; init; }
        public TreeNode<T>? Right { get; init; }
    }
    /*
     * Determine if a binary tree is symmetric around its center (mirror itself)
     */
    public static bool IsSymmetric<T>( TreeNode<T>? tree )
    {
        return IsSymmetricSubtree( tree, tree );
    }
    
    static bool IsSymmetricSubtree<T>( TreeNode<T>? left, TreeNode<T>? right )
    {
        // если оба пустые, значит да?
        if ( left == null && right == null ) return true;
        
        // если только один, значит нет
        if ( left == null || right == null ) return false;
        
        // если оба идем проверять левое и правое поддерево
        return left.Value.Equals( right.Value ) 
               && IsSymmetricSubtree( left.Left, right.Right ) 
               && IsSymmetricSubtree( left.Right, right.Left );
    }
}