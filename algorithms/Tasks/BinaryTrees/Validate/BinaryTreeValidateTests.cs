using System.Numerics;

namespace Tasks.BinaryTrees.Validate;

public class BinaryTreeValidateTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var node = new BinaryTreeValidate.TreeNode<int>
        {
            Value = 1
        };
        
        // Act
        var res = BinaryTreeValidate.Check( node );

        // Assert
        Assert.True( res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var node = new BinaryTreeValidate.TreeNode<int>
        {
            Value = 2,
            Left = new BinaryTreeValidate.TreeNode<int>
            {
                Value = 1
            }
        };
        
        // Act
        var res = BinaryTreeValidate.Check( node );

        // Assert
        Assert.True( res );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var node = new BinaryTreeValidate.TreeNode<int>
        {
            Value = 2,
            Left = new BinaryTreeValidate.TreeNode<int>
            {
                Value = 1
            },
            Right = new BinaryTreeValidate.TreeNode<int>
            {
                Value = 3
            }
        };
        
        // Act
        var res = BinaryTreeValidate.Check( node );

        // Assert
        Assert.True( res );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        // Arrange
        var node = new BinaryTreeValidate.TreeNode<int>
        {
            Value = 2,
            Left = new BinaryTreeValidate.TreeNode<int>
            {
                Value = 1,
                Left = new BinaryTreeValidate.TreeNode<int>
                {
                    Value = 5
                },
            },
            Right = new BinaryTreeValidate.TreeNode<int>
            {
                Value = 3
            }
        };
        
        // Act
        var res = BinaryTreeValidate.Check( node );

        // Assert
        Assert.False( res );
    }
    
    [Fact]
    public void Run_Case5_ShouldBeOk( )
    {
        // Arrange
        var node = new BinaryTreeValidate.TreeNode<int>
        {
            Value = 2,
            Left = new BinaryTreeValidate.TreeNode<int>
            {
                Value = 1,
                Left = new BinaryTreeValidate.TreeNode<int>
                {
                    Value = 0
                },
            },
            Right = new BinaryTreeValidate.TreeNode<int>
            {
                Value = 3,
                Right = new BinaryTreeValidate.TreeNode<int>
                {
                    Value = 2
                }
            }
        };
        
        // Act
        var res = BinaryTreeValidate.Check( node );

        // Assert
        Assert.False( res );
    }
    
    [Fact]
    public void Run_Case6_ShouldBeOk( )
    {
        // Arrange
        var node = new BinaryTreeValidate.TreeNode<int>
        {
            Value = 2,
            Left = new BinaryTreeValidate.TreeNode<int>
            {
                Value = 1,
                Left = new BinaryTreeValidate.TreeNode<int>
                {
                    Value = 0
                },
            },
            Right = new BinaryTreeValidate.TreeNode<int>
            {
                Value = 3
            }
        };
        
        // Act
        var res = BinaryTreeValidate.Check( node );

        // Assert
        Assert.True( res );
    }
    
    [Fact]
    public void Run_Case7_ShouldBeOk( )
    {
        // Arrange
        var node = new BinaryTreeValidate.TreeNode<int>
        {
            Value = 2,
            Left = new BinaryTreeValidate.TreeNode<int>
            {
                Value = 1,
                Left = new BinaryTreeValidate.TreeNode<int>
                {
                    Value = 0
                },
                Right = new BinaryTreeValidate.TreeNode<int>
                {
                    Value = 15
                },
            },
            Right = new BinaryTreeValidate.TreeNode<int>
            {
                Value = 3,
                Right = new BinaryTreeValidate.TreeNode<int>
                {
                    Value = 4
                }
            }
        };
        
        // Act
        var res = BinaryTreeValidate.Check( node );

        // Assert
        Assert.False( res );
    }
    
    [Fact]
    public void Run_Case8_ShouldBeOk( )
    {
        // Arrange
        var node = new BinaryTreeValidate.TreeNode<int>
        {
            Value = 6,
            Left = new BinaryTreeValidate.TreeNode<int>
            {
                Value = 4,
                Left = new BinaryTreeValidate.TreeNode<int>
                {
                    Value = 2,
                    Left = new BinaryTreeValidate.TreeNode<int>
                    {
                        Value = 1
                    },
                },
                Right = new BinaryTreeValidate.TreeNode<int>
                {
                    Value = 5
                },
            },
            Right = new BinaryTreeValidate.TreeNode<int>
            {
                Value = 7
            }
        };
        
        // Act
        var res = BinaryTreeValidate.Check( node );

        // Assert
        Assert.True( res );
    }
}