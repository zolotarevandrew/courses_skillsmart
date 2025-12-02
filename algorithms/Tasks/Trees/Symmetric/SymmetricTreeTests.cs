namespace Tasks.Trees.Symmetric;

public class SymmetricTreeTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var tree1 = new SymmetricTree.TreeNode<int>
        {
            Value = 1,
            Left = new SymmetricTree.TreeNode<int>
            {
                Value = 2,
            },
            Right = new SymmetricTree.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        
        // Assert
        Assert.False( SymmetricTree.IsSymmetric( tree1 ) );
    }
    
    [Fact]
    public void Run_EqualTrees_ShouldBeFalse( )
    {
        // Arrange
        var tree1 = new SymmetricTree.TreeNode<int>
        {
            Value = 1,
            Left = new SymmetricTree.TreeNode<int>
            {
                Value = 2,
                Left = new SymmetricTree.TreeNode<int>
                {
                    Value = 4,
                },
                Right = new SymmetricTree.TreeNode<int>
                {
                    Value = 6,
                }
            },
            Right = new SymmetricTree.TreeNode<int>
            {
                Value = 2,
                Left = new SymmetricTree.TreeNode<int>
                {
                    Value = 4,
                },
                Right = new SymmetricTree.TreeNode<int>
                {
                    Value = 6,
                }
            }
        };

        // Act
        
        // Assert
        Assert.False( SymmetricTree.IsSymmetric( tree1 ) );
    }
    
    [Fact]
    public void Run_SymmetricTrees_ShouldBeTrue( )
    {
        // Arrange
        var tree1 = new SymmetricTree.TreeNode<int>
        {
            Value = 1,
            Left = new SymmetricTree.TreeNode<int>
            {
                Value = 2,
                Left = new SymmetricTree.TreeNode<int>
                {
                    Value = 4,
                },
                Right = new SymmetricTree.TreeNode<int>
                {
                    Value = 6,
                }
            },
            Right = new SymmetricTree.TreeNode<int>
            {
                Value = 2,
                Left = new SymmetricTree.TreeNode<int>
                {
                    Value = 6,
                },
                Right = new SymmetricTree.TreeNode<int>
                {
                    Value = 4,
                }
            }
        };

        // Act
        
        // Assert
        Assert.True( SymmetricTree.IsSymmetric( tree1 ) );
    }

    
}