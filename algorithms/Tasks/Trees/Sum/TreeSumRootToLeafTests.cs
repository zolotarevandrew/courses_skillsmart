namespace Tasks.Trees.Sum;

public class TreeSumRootToLeafTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var tree = new TreeSumRootToLeaf.TreeNode<int>
        {
            Value = 1,
            Left = new TreeSumRootToLeaf.TreeNode<int>
            {
                Value = 2,
            },
            Right = new TreeSumRootToLeaf.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        int res = TreeSumRootToLeaf.Run( tree );

        // Assert
        Assert.Equal( 25, res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var tree = new TreeSumRootToLeaf.TreeNode<int>
        {
            Value = 1,
            Left = new TreeSumRootToLeaf.TreeNode<int>
            {
                Value = 2,
                Left = new TreeSumRootToLeaf.TreeNode<int>
                {
                    Value = 4,
                },
            },
            Right = new TreeSumRootToLeaf.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        int res = TreeSumRootToLeaf.Run( tree );

        // Assert
        Assert.Equal( 137, res );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var tree = new TreeSumRootToLeaf.TreeNode<int>
        {
            Value = 1,
            Left = new TreeSumRootToLeaf.TreeNode<int>
            {
                Value = 2,
                Left = new TreeSumRootToLeaf.TreeNode<int>
                {
                    Value = 4,
                },
                Right = new TreeSumRootToLeaf.TreeNode<int>
                {
                    Value = 5,
                }
            },
            Right = new TreeSumRootToLeaf.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        int res = TreeSumRootToLeaf.Run( tree );

        // Assert
        Assert.Equal( 262, res );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        // Arrange
        var tree = new TreeSumRootToLeaf.TreeNode<int>
        {
            Value = 1,
            Left = new TreeSumRootToLeaf.TreeNode<int>
            {
                Value = 2,
                Left = new TreeSumRootToLeaf.TreeNode<int>
                {
                    Value = 4,
                },
                Right = new TreeSumRootToLeaf.TreeNode<int>
                {
                    Value = 5,
                }
            },
            Right = new TreeSumRootToLeaf.TreeNode<int>
            {
                Value = 3,
                Left = new TreeSumRootToLeaf.TreeNode<int>
                {
                    Value = 6,
                },
            }
        };

        // Act
        int res = TreeSumRootToLeaf.Run( tree );

        // Assert
        Assert.Equal( 385, res );
    }
    
    [Fact]
    public void Run_Case5_ShouldBeOk( )
    {
        // Arrange
        var tree = new TreeSumRootToLeaf.TreeNode<int>
        {
            Value = 1,
            Left = new TreeSumRootToLeaf.TreeNode<int>
            {
                Value = 2,
                Left = new TreeSumRootToLeaf.TreeNode<int>
                {
                    Value = 4,
                },
                Right = new TreeSumRootToLeaf.TreeNode<int>
                {
                    Value = 5,
                }
            },
            Right = new TreeSumRootToLeaf.TreeNode<int>
            {
                Value = 3,
                Right = new TreeSumRootToLeaf.TreeNode<int>
                {
                    Value = 6,
                },
            }
        };

        // Act
        int res = TreeSumRootToLeaf.Run( tree );

        // Assert
        Assert.Equal( 385, res );
    }
}