namespace Tasks.Trees.LevelOrder;

public class LevelTraversalTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var node = new LevelTraversal.TreeNode<int>
        {
            Value = 1,
            Left = new LevelTraversal.TreeNode<int>
            {
                Value = 2,
            },
            Right = new LevelTraversal.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        var res = LevelTraversal.Run( node );
        
        // Assert
        Assert.Equal( res.Count, 2 );
        Assert.Equal( res[0], [1] );
        Assert.Equal( res[1], [2, 3] );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var node = new LevelTraversal.TreeNode<int>
        {
            Value = 1,
            Left = new LevelTraversal.TreeNode<int>
            {
                Value = 2,
                Left = new LevelTraversal.TreeNode<int>
                {
                    Value = 4,
                },
                Right = new LevelTraversal.TreeNode<int>
                {
                    Value = 5,
                },
            },
            Right = new LevelTraversal.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        var res = LevelTraversal.Run( node );
        
        // Assert
        Assert.Equal( res.Count, 3 );
        Assert.Equal( res[0], [1] );
        Assert.Equal( res[1], [2, 3] );
        Assert.Equal( res[2], [4, 5] );
    }
}