namespace Tasks.Trees.Diameter;

public class TreeDiameterTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var node = new TreeDiameter.TreeNode<int>
        {
            Value = 1,
            Left = new TreeDiameter.TreeNode<int>
            {
                Value = 2
            },
            Right = new TreeDiameter.TreeNode<int>
            {
                Value = 3,
            }
        };
        
        // Act
        var res = TreeDiameter.Run( node );

        // Assert
        Assert.Equal( 2, res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var node = new TreeDiameter.TreeNode<int>
        {
            Value = 1,
            Left = new TreeDiameter.TreeNode<int>
            {
                Value = 2,
                Left = new TreeDiameter.TreeNode<int>
                {
                    Value = 4
                },
            },
            Right = new TreeDiameter.TreeNode<int>
            {
                Value = 3,
            }
        };
        
        // Act
        var res = TreeDiameter.Run( node );

        // Assert
        Assert.Equal( 3, res );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var node = new TreeDiameter.TreeNode<int>
        {
            Value = 1,
            Left = new TreeDiameter.TreeNode<int>
            {
                Value = 2,
                Left = new TreeDiameter.TreeNode<int>
                {
                    Value = 4,
                    Left = new TreeDiameter.TreeNode<int>
                    {
                        Value = 8
                    },
                },
                Right = new TreeDiameter.TreeNode<int>
                {
                    Value = 5,
                }
            },
            Right = new TreeDiameter.TreeNode<int>
            {
                Value = 3,
                Left = new TreeDiameter.TreeNode<int>
                {
                    Value = 6,
                },
                Right = new TreeDiameter.TreeNode<int>
                {
                    Value = 7,
                }
            }
        };
        
        // Act
        var res = TreeDiameter.Run( node );

        // Assert
        Assert.Equal( 5, res );
    }
}