namespace Tasks.Trees.Depth;

public class TreeDepthTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var node = new TreeDepth.TreeNode<int>
        {
            Value = 1,
            Left = new TreeDepth.TreeNode<int>
            {
                Value = 2,
            },
            Right = new TreeDepth.TreeNode<int>
            {
                Value = 3
            }
        };
        
        // Act
        var res = TreeDepth.Get( node );

        // Assert
        Assert.Equal( 2, res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var node = new TreeDepth.TreeNode<int>
        {
            Value = 1,
            Left = new TreeDepth.TreeNode<int>
            {
                Value = 2,
            }
        };
        
        // Act
        var res = TreeDepth.Get( node );

        // Assert
        Assert.Equal( 2, res );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var node = new TreeDepth.TreeNode<int>
        {
            Value = 1,
            Left = new TreeDepth.TreeNode<int>
            {
                Value = 2,
                Left = new TreeDepth.TreeNode<int>
                {
                    Value = 3,
                }
            }
        };
        
        // Act
        var res = TreeDepth.Get( node );

        // Assert
        Assert.Equal( 3, res );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        // Arrange
        var node = new TreeDepth.TreeNode<int>
        {
            Value = 1,
            Right = new TreeDepth.TreeNode<int>
            {
                Value = 2,
                Right = new TreeDepth.TreeNode<int>
                {
                    Value = 3,
                }
            }
        };
        
        // Act
        var res = TreeDepth.Get( node );

        // Assert
        Assert.Equal( 3, res );
    }
    
    [Fact]
    public void Run_Case5_ShouldBeOk( )
    {
        // Arrange
        var node = new TreeDepth.TreeNode<int>
        {
            Value = 1,
            Left = new TreeDepth.TreeNode<int>
            {
                Value = 2,
                Left = new TreeDepth.TreeNode<int>
                {
                    Value = 3,
                    Left = new TreeDepth.TreeNode<int>
                    {
                        Value = 5,
                    }
                },
                Right = new TreeDepth.TreeNode<int>
                {
                    Value = 4,
                }
            }
        };
        
        // Act
        var res = TreeDepth.Get( node );

        // Assert
        Assert.Equal( 4, res );
    }
}