namespace Tasks.Trees.PathSum;

public class TreePathSumTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        
        // Act
        var res = TreePathSum.Run( null, 0 );

        // Assert
        Assert.False( res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var node = new TreePathSum.TreeNode<int>
        {
            Value = 1
        };
        
        // Act
        var res = TreePathSum.Run( node, 1 );

        // Assert
        Assert.True( res );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var node = new TreePathSum.TreeNode<int>
        {
            Value = 1,
            Left = new TreePathSum.TreeNode<int>
            {
                Value = 3
            }
        };
        
        // Act
        var res = TreePathSum.Run( node, 4 );

        // Assert
        Assert.True( res );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        // Arrange
        var node = new TreePathSum.TreeNode<int>
        {
            Value = 1,
            Left = new TreePathSum.TreeNode<int>
            {
                Value = 2
            }
        };
        
        // Act
        var res = TreePathSum.Run( node, 4 );

        // Assert
        Assert.False( res );
    }
    
    [Fact]
    public void Run_Case5_ShouldBeOk( )
    {
        // Arrange
        var node = new TreePathSum.TreeNode<int>
        {
            Value = 1,
            Left = new TreePathSum.TreeNode<int>
            {
                Value = 2
            },
            Right = new TreePathSum.TreeNode<int>
            {
                Value = 3
            }
        };
        
        // Act
        var res = TreePathSum.Run( node, 4 );

        // Assert
        Assert.True( res );
    }
    
    [Fact]
    public void Run_Case6_ShouldBeOk( )
    {
        // Arrange
        var node = new TreePathSum.TreeNode<int>
        {
            Value = 1,
            Left = new TreePathSum.TreeNode<int>
            {
                Value = 2
            },
            Right = new TreePathSum.TreeNode<int>
            {
                Value = 3
            }
        };
        
        // Act
        var res = TreePathSum.Run( node, 5 );

        // Assert
        Assert.False( res );
    }
}