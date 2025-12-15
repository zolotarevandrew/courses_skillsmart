namespace Tasks.Trees.Subtree;

public class SubTreeTests
{
    [Fact]
    public void Run_IdenticalTrees_ShouldBeOk( )
    {
        // Arrange
        var tree1 = new SubTree.TreeNode<int>
        {
            Value = 1,
            Left = new SubTree.TreeNode<int>
            {
                Value = 2,
            },
            Right = new SubTree.TreeNode<int>
            {
                Value = 3,
            }
        };
        var tree2 = new SubTree.TreeNode<int>
        {
            Value = 1,
            Left = new SubTree.TreeNode<int>
            {
                Value = 2,
            },
            Right = new SubTree.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        
        // Assert
        Assert.Equal( true, SubTree.Check( tree1, tree2 ) );
    }
    
    [Fact]
    public void Run_IdenticalTreesInRight_ShouldBeOk( )
    {
        // Arrange
        var tree1 = new SubTree.TreeNode<int>
        {
            Value = 2,
            Right = new SubTree.TreeNode<int>
            {
                Value = 3,
                Right = new SubTree.TreeNode<int>
                {
                    Value = 4,
                }
            }
        };
        var tree2 = new SubTree.TreeNode<int>
        {
            Value = 2,
            Right = new SubTree.TreeNode<int>
            {
                Value = 3,
                Right = new SubTree.TreeNode<int>
                {
                    Value = 4,
                }
            }
        };

        // Act
        
        // Assert
        Assert.Equal( true, SubTree.Check( tree1, tree2 ) );
    }
    
    [Fact]
    public void Run_SubTreeRight_ShouldBeOk( )
    {
        // Arrange
        var tree1 = new SubTree.TreeNode<int>
        {
            Value = 1,
            Left = new SubTree.TreeNode<int>
            {
                Value = 2,
                Right = new SubTree.TreeNode<int>
                {
                    Value = 3,
                    Right = new SubTree.TreeNode<int>
                    {
                        Value = 4,
                    }
                }
            }
        };
        var tree2 = new SubTree.TreeNode<int>
        {
            Value = 2,
            Right = new SubTree.TreeNode<int>
            {
                Value = 3,
                Right = new SubTree.TreeNode<int>
                {
                    Value = 4,
                }
            }
        };

        // Act
        
        // Assert
        Assert.Equal( true, SubTree.Check( tree1, tree2 ) );
    }
    
    [Fact]
    public void Run_PartialSubTree_ShouldBeFalse( )
    {
        // Arrange
        var tree1 = new SubTree.TreeNode<int>
        {
            Value = 1,
            Left = new SubTree.TreeNode<int>
            {
                Value = 2,
                Left = new SubTree.TreeNode<int>
                {
                    Value = 3,
                    Left = new SubTree.TreeNode<int>
                    {
                        Value = 4,
                    }
                }
            },
            
            Right = new SubTree.TreeNode<int>
            {
                Value = 5,
                Right = new SubTree.TreeNode<int>
                {
                    Value = 6,
                }
            }
        };
        var tree2 = new SubTree.TreeNode<int>
        {
            Value = 5,
            Right = new SubTree.TreeNode<int>
            {
                Value = 6,
                Right = new SubTree.TreeNode<int>
                {
                    Value = 8,
                }
            }
        };

        // Act
        
        // Assert
        Assert.Equal( false, SubTree.Check( tree1, tree2 ) );
    }
    
    [Fact]
    public void Run_FullSubTree_ShouldBeTrue( )
    {
        // Arrange
        var tree1 = new SubTree.TreeNode<int>
        {
            Value = 1,
            Left = new SubTree.TreeNode<int>
            {
                Value = 2,
                Left = new SubTree.TreeNode<int>
                {
                    Value = 3,
                    Left = new SubTree.TreeNode<int>
                    {
                        Value = 4,
                    }
                }
            },
            
            Right = new SubTree.TreeNode<int>
            {
                Value = 5,
                Right = new SubTree.TreeNode<int>
                {
                    Value = 6,
                }
            }
        };
        var tree2 = new SubTree.TreeNode<int>
        {
            Value = 5,
            Right = new SubTree.TreeNode<int>
            {
                Value = 6
            }
        };

        // Act
        
        // Assert
        Assert.Equal( true, SubTree.Check( tree1, tree2 ) );
    }
}