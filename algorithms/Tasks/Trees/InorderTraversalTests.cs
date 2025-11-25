namespace Tasks.Trees;

public class InorderTraversalTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var node = new InorderTraversal.TreeNode<int>
        {
            Value = 1,
            Left = new InorderTraversal.TreeNode<int>
            {
                Value = 2,
            },
            Right = new InorderTraversal.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        List<int> res = InorderTraversal.Run( node );
        
        // Assert
        Assert.Equal( res, [2, 1, 3] );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var node = new InorderTraversal.TreeNode<int>
        {
            Value = 1,
            Left = new InorderTraversal.TreeNode<int>
            {
                Value = 2,
                Left = new InorderTraversal.TreeNode<int>
                {
                    Value = 4,
                },
                Right = new InorderTraversal.TreeNode<int>
                {
                    Value = 5,
                },
            },
            Right = new InorderTraversal.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        List<int> res = InorderTraversal.Run( node );
        
        // Assert
        Assert.Equal( res, [4, 2, 5, 1, 3] );
    }
}