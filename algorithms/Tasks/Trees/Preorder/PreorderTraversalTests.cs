namespace Tasks.Trees.Preorder;

public class PreorderTraversalTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var node = new PreorderTraversal.TreeNode<int>
        {
            Value = 1,
            Left = new PreorderTraversal.TreeNode<int>
            {
                Value = 2,
            },
            Right = new PreorderTraversal.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        List<int> res = PreorderTraversal.Run( node );
        
        // Assert
        Assert.Equal( res, [1, 2, 3] );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var node = new PreorderTraversal.TreeNode<int>
        {
            Value = 1,
            Left = new PreorderTraversal.TreeNode<int>
            {
                Value = 2,
                Left = new PreorderTraversal.TreeNode<int>
                {
                    Value = 4,
                },
                Right = new PreorderTraversal.TreeNode<int>
                {
                    Value = 5,
                },
            },
            Right = new PreorderTraversal.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        List<int> res = PreorderTraversal.Run( node );
        
        // Assert
        Assert.Equal( res, [1, 2, 4, 5, 3] );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var node = new PreorderTraversal.TreeNode<int>
        {
            Value = 1,
            Left = new PreorderTraversal.TreeNode<int>
            {
                Value = 2,
                Right = new PreorderTraversal.TreeNode<int>
                {
                    Value = 3,
                    Right = new PreorderTraversal.TreeNode<int>
                    {
                        Value = 4
                    },
                },
            },
            Right = new PreorderTraversal.TreeNode<int>
            {
                Value = 5,
                Right = new PreorderTraversal.TreeNode<int>
                {
                    Value = 6
                },
            }
        };

        // Act
        List<int> res = PreorderTraversal.Run( node );
        
        // Assert
        Assert.Equal( res, [1, 2, 3, 4, 5, 6] );
    }
    
    [Fact]
    public void RunStack_Case1_ShouldBeOk( )
    {
        // Arrange
        var node = new PreorderTraversal.TreeNode<int>
        {
            Value = 1,
            Left = new PreorderTraversal.TreeNode<int>
            {
                Value = 2,
            },
            Right = new PreorderTraversal.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        List<int> res = PreorderTraversal.RunStack( node );
        
        // Assert
        Assert.Equal( res, [1, 2, 3] );
    }
    
    [Fact]
    public void RunStack_Case2_ShouldBeOk( )
    {
        // Arrange
        var node = new PreorderTraversal.TreeNode<int>
        {
            Value = 1,
            Left = new PreorderTraversal.TreeNode<int>
            {
                Value = 2,
                Left = new PreorderTraversal.TreeNode<int>
                {
                    Value = 4,
                },
                Right = new PreorderTraversal.TreeNode<int>
                {
                    Value = 5,
                },
            },
            Right = new PreorderTraversal.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        List<int> res = PreorderTraversal.RunStack( node );
        
        // Assert
        Assert.Equal( res, [1, 2, 4, 5, 3] );
    }
    
    [Fact]
    public void RunStack_Case3_ShouldBeOk( )
    {
        // Arrange
        var node = new PreorderTraversal.TreeNode<int>
        {
            Value = 1,
            Left = new PreorderTraversal.TreeNode<int>
            {
                Value = 2,
                Right = new PreorderTraversal.TreeNode<int>
                {
                    Value = 3,
                    Right = new PreorderTraversal.TreeNode<int>
                    {
                        Value = 4
                    },
                },
            },
            Right = new PreorderTraversal.TreeNode<int>
            {
                Value = 5,
                Right = new PreorderTraversal.TreeNode<int>
                {
                    Value = 6
                },
            }
        };

        // Act
        List<int> res = PreorderTraversal.RunStack( node );
        
        // Assert
        Assert.Equal( res, [1, 2, 3, 4, 5, 6] );
    }
}