namespace Tasks.Trees.SameTrees;

public class SameTreesTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var tree1 = new SameTrees.TreeNode<int>
        {
            Value = 1,
            Left = new SameTrees.TreeNode<int>
            {
                Value = 2,
            },
            Right = new SameTrees.TreeNode<int>
            {
                Value = 3,
            }
        };
        var tree2 = new SameTrees.TreeNode<int>
        {
            Value = 1,
            Left = new SameTrees.TreeNode<int>
            {
                Value = 2,
            },
            Right = new SameTrees.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        
        // Assert
        Assert.Equal( true, SameTrees.IsEqual( tree1, tree2 ) );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var tree1 = new SameTrees.TreeNode<int>
        {
            Value = 1,
            Left = new SameTrees.TreeNode<int>
            {
                Value = 2,
                Left = new SameTrees.TreeNode<int>
                {
                    Value = 4,
                },
                Right = new SameTrees.TreeNode<int>
                {
                    Value = 5,
                },
            },
            Right = new SameTrees.TreeNode<int>
            {
                Value = 3,
            }
        };
        var tree2 = new SameTrees.TreeNode<int>
        {
            Value = 1,
            Left = new SameTrees.TreeNode<int>
            {
                Value = 2,
            },
            Right = new SameTrees.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        
        // Assert
        Assert.Equal( false, SameTrees.IsEqual( tree1, tree2 ) );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var tree1 = new SameTrees.TreeNode<int>
        {
            Value = 1,
            Left = new SameTrees.TreeNode<int>
            {
                Value = 2,
                Left = new SameTrees.TreeNode<int>
                {
                    Value = 4,
                },
                Right = new SameTrees.TreeNode<int>
                {
                    Value = 5,
                },
            },
            Right = new SameTrees.TreeNode<int>
            {
                Value = 3,
            }
        };
        var tree2 = new SameTrees.TreeNode<int>
        {
            Value = 1,
            Left = new SameTrees.TreeNode<int>
            {
                Value = 2,
                Left = new SameTrees.TreeNode<int>
                {
                    Value = 4,
                },
                Right = new SameTrees.TreeNode<int>
                {
                    Value = 5,
                },
            },
            Right = new SameTrees.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        
        // Assert
        Assert.Equal( true, SameTrees.IsEqual( tree1, tree2 ) );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        // Arrange
        var tree1 = new SameTrees.TreeNode<int>
        {
            Value = 1,
            Left = new SameTrees.TreeNode<int>
            {
                Value = 2,
                Right = new SameTrees.TreeNode<int>
                {
                    Value = 3,
                    Right = new SameTrees.TreeNode<int>
                    {
                        Value = 4
                    },
                },
            },
            Right = new SameTrees.TreeNode<int>
            {
                Value = 5,
                Right = new SameTrees.TreeNode<int>
                {
                    Value = 6
                },
            }
        };
        var tree2 = new SameTrees.TreeNode<int>
        {
            Value = 1,
            Left = new SameTrees.TreeNode<int>
            {
                Value = 2,
                Left = new SameTrees.TreeNode<int>
                {
                    Value = 4,
                },
                Right = new SameTrees.TreeNode<int>
                {
                    Value = 5,
                },
            },
            Right = new SameTrees.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        
        // Assert
        Assert.Equal( false, SameTrees.IsEqual( tree1, tree2 ) );
    }
    
    [Fact]
    public void Run_Case5_ShouldBeOk( )
    {
        // Arrange
        var tree1 = new SameTrees.TreeNode<int>
        {
            Value = 1,
            Left = new SameTrees.TreeNode<int>
            {
                Value = 2,
                Right = new SameTrees.TreeNode<int>
                {
                    Value = 3,
                    Right = new SameTrees.TreeNode<int>
                    {
                        Value = 4
                    },
                },
            },
            Right = new SameTrees.TreeNode<int>
            {
                Value = 5,
                Right = new SameTrees.TreeNode<int>
                {
                    Value = 6
                },
            }
        };
        var tree2 = new SameTrees.TreeNode<int>
        {
            Value = 1,
            Left = new SameTrees.TreeNode<int>
            {
                Value = 2,
                Right = new SameTrees.TreeNode<int>
                {
                    Value = 3,
                    Right = new SameTrees.TreeNode<int>
                    {
                        Value = 4
                    },
                },
            },
            Right = new SameTrees.TreeNode<int>
            {
                Value = 5,
                Right = new SameTrees.TreeNode<int>
                {
                    Value = 6
                },
            }
        };

        // Act
        
        // Assert
        Assert.Equal( true, SameTrees.IsEqual( tree1, tree2 ) );
    }
}