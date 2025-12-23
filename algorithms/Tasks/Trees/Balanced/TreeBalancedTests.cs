namespace Tasks.Trees.Balanced;

public class TreeBalancedTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var node = new TreeBalanced.TreeNode<int>
        {
            Value = 1,
            Left = new TreeBalanced.TreeNode<int>
            {
                Value = 2,
            },
            Right = new TreeBalanced.TreeNode<int>
            {
                Value = 3
            }
        };
        
        // Act
        var res = TreeBalanced.Run( node );

        // Assert
        Assert.True( res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var node = new TreeBalanced.TreeNode<int>
        {
            Value = 1,
            Left = new TreeBalanced.TreeNode<int>
            {
                Value = 2,
                Left = new TreeBalanced.TreeNode<int>
                {
                    Value = 4,
                },
            },
            Right = new TreeBalanced.TreeNode<int>
            {
                Value = 3
            }
        };
        
        // Act
        var res = TreeBalanced.Run( node );

        // Assert
        Assert.True( res );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var node = new TreeBalanced.TreeNode<int>
        {
            Value = 1,
            Left = new TreeBalanced.TreeNode<int>
            {
                Value = 2,
                Left = new TreeBalanced.TreeNode<int>
                {
                    Value = 4,
                    Left = new TreeBalanced.TreeNode<int>
                    {
                        Value = 6,
                    },
                },
            },
            Right = new TreeBalanced.TreeNode<int>
            {
                Value = 3
            }
        };
        
        // Act
        bool res = TreeBalanced.Run( node );

        // Assert
        Assert.False( res );
    }
}