namespace Tasks.Trees.InOrder;

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
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var node = new InorderTraversal.TreeNode<int>
        {
            Value = 1,
            Left = new InorderTraversal.TreeNode<int>
            {
                Value = 2,
                Right = new InorderTraversal.TreeNode<int>
                {
                    Value = 3,
                    Right = new InorderTraversal.TreeNode<int>
                    {
                        Value = 4
                    },
                },
            },
            Right = new InorderTraversal.TreeNode<int>
            {
                Value = 5,
                Right = new InorderTraversal.TreeNode<int>
                {
                    Value = 6
                },
            }
        };

        // Act
        List<int> res = InorderTraversal.Run( node );
        
        // Assert
        Assert.Equal( res, [2, 3, 4, 1, 5, 6] );
    }
    
    [Fact]
    public void RunStack_Case1_ShouldBeOk( )
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
        List<int> res = InorderTraversal.RunStack( node );
        
        // Assert
        Assert.Equal( res, [2, 1, 3] );
    }
    
    [Fact]
    public void RunStack_Case2_ShouldBeOk( )
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
        List<int> res = InorderTraversal.RunStack( node );
        
        // Assert
        Assert.Equal( res, [4, 2, 5, 1, 3] );
    }
    
    [Fact]
    public void RunStack_Case3_ShouldBeOk( )
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
                    Left = new InorderTraversal.TreeNode<int>
                    {
                        Value = 8,
                    },
                    Right = new InorderTraversal.TreeNode<int>
                    {
                        Value = 9,
                    },
                },
                Right = new InorderTraversal.TreeNode<int>
                {
                    Value = 5,
                },
            },
            Right = new InorderTraversal.TreeNode<int>
            {
                Value = 3,
                Left = new InorderTraversal.TreeNode<int>
                {
                    Value = 6,
                },
                Right = new InorderTraversal.TreeNode<int>
                {
                    Value = 7,
                },
            }
        };

        // Act
        List<int> res = InorderTraversal.RunStack( node );
        
        // Assert
        Assert.Equal( res, [8, 4, 9, 2, 5, 1, 6, 3, 7] );
    }
    
    [Fact]
    public void RunStack_Case4_ShouldBeOk( )
    {
        // Arrange
        var node = new InorderTraversal.TreeNode<int>
        {
            Value = 1,
            Left = new InorderTraversal.TreeNode<int>
            {
                Value = 2,
                Right = new InorderTraversal.TreeNode<int>
                {
                    Value = 3,
                    Right = new InorderTraversal.TreeNode<int>
                    {
                        Value = 4
                    },
                },
            },
            Right = new InorderTraversal.TreeNode<int>
            {
                Value = 5,
                Right = new InorderTraversal.TreeNode<int>
                {
                    Value = 6
                },
            }
        };

        // Act
        List<int> res = InorderTraversal.RunStack( node );
        
        // Assert
        Assert.Equal( res, [2, 3, 4, 1, 5, 6] );
    }
}