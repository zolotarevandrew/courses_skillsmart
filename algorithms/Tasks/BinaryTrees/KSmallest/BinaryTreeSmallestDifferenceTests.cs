namespace Tasks.BinaryTrees.KSmallest;

public class BinaryTreeKSmallestTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var node = new BinaryTreeKSmallest.TreeNode<int>
        {
            Value = 6
        };
        
        // Act
        var res = BinaryTreeKSmallest.Get( node, 1 );

        // Assert
        Assert.Equal( 6, res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var node = new BinaryTreeKSmallest.TreeNode<int>
        {
            Value = 6,
            Left = new BinaryTreeKSmallest.TreeNode<int>
            {
                Value = 5
            }
        };
        
        // Act
        var res = BinaryTreeKSmallest.Get( node, 1 );

        // Assert
        Assert.Equal( 5, res );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var node = new BinaryTreeKSmallest.TreeNode<int>
        {
            Value = 6,
            Left = new BinaryTreeKSmallest.TreeNode<int>
            {
                Value = 5
            },
            Right = new BinaryTreeKSmallest.TreeNode<int>
            {
                Value = 7
            }
        };
        
        // Act
        var res = BinaryTreeKSmallest.Get( node, 1 );

        // Assert
        Assert.Equal( 5, res );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        // Arrange
        var node = new BinaryTreeKSmallest.TreeNode<int>
        {
            Value = 6,
            Left = new BinaryTreeKSmallest.TreeNode<int>
            {
                Value = 4,
                Left = new BinaryTreeKSmallest.TreeNode<int>
                {
                    Value = 2
                },
                Right = new BinaryTreeKSmallest.TreeNode<int>
                {
                    Value = 5
                }
            },
            Right = new BinaryTreeKSmallest.TreeNode<int>
            {
                Value = 7
            }
        };
        
        // Act
        var res = BinaryTreeKSmallest.Get( node, 2 );

        // Assert
        Assert.Equal( 4, res );
    }
    
    [Fact]
    public void Run_Case5_ShouldBeOk( )
    {
        // Arrange
        var node = new BinaryTreeKSmallest.TreeNode<int>
        {
            Value = 6,
            Left = new BinaryTreeKSmallest.TreeNode<int>
            {
                Value = 4,
                Left = new BinaryTreeKSmallest.TreeNode<int>
                {
                    Value = 2
                },
                Right = new BinaryTreeKSmallest.TreeNode<int>
                {
                    Value = 5
                }
            },
            Right = new BinaryTreeKSmallest.TreeNode<int>
            {
                Value = 7
            }
        };
        
        // Act
        var res = BinaryTreeKSmallest.Get( node, 3 );

        // Assert
        Assert.Equal( 5, res );
    }
    
    [Fact]
    public void Run_Case6_ShouldBeOk( )
    {
        // Arrange
        var node = new BinaryTreeKSmallest.TreeNode<int>
        {
            Value = 6,
            Left = new BinaryTreeKSmallest.TreeNode<int>
            {
                Value = 4,
                Left = new BinaryTreeKSmallest.TreeNode<int>
                {
                    Value = 2
                },
                Right = new BinaryTreeKSmallest.TreeNode<int>
                {
                    Value = 5
                }
            },
            Right = new BinaryTreeKSmallest.TreeNode<int>
            {
                Value = 7
            }
        };
        
        // Act
        var res = BinaryTreeKSmallest.Get( node, 1 );

        // Assert
        Assert.Equal( 2, res );
    }
    
    [Fact]
    public void Run_Case7_ShouldBeOk( )
    {
        // Arrange
        var node = new BinaryTreeKSmallest.TreeNode<int>
        {
            Value = 6,
            Left = new BinaryTreeKSmallest.TreeNode<int>
            {
                Value = 4,
                Left = new BinaryTreeKSmallest.TreeNode<int>
                {
                    Value = 2
                },
                Right = new BinaryTreeKSmallest.TreeNode<int>
                {
                    Value = 5
                }
            },
            Right = new BinaryTreeKSmallest.TreeNode<int>
            {
                Value = 7
            }
        };
        
        // Act
        var res = BinaryTreeKSmallest.Get( node, 4 );

        // Assert
        Assert.Equal( 6, res );
    }
}