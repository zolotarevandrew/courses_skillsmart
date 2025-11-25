namespace Tasks.Trees.Postorder;

public class PostorderTraversalTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var node = new PostorderTraversal.TreeNode<int>
        {
            Value = 1,
            Left = new PostorderTraversal.TreeNode<int>
            {
                Value = 2,
            },
            Right = new PostorderTraversal.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        List<int> res = PostorderTraversal.Run( node );
        
        // Assert
        Assert.Equal( res, [2, 3, 1] );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var node = new PostorderTraversal.TreeNode<int>
        {
            Value = 1,
            Left = new PostorderTraversal.TreeNode<int>
            {
                Value = 2,
                Left = new PostorderTraversal.TreeNode<int>
                {
                    Value = 4,
                },
                Right = new PostorderTraversal.TreeNode<int>
                {
                    Value = 5,
                },
            },
            Right = new PostorderTraversal.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        List<int> res = PostorderTraversal.Run( node );
        
        // Assert
        Assert.Equal( res, [4, 5, 2, 3, 1] );
    }
}