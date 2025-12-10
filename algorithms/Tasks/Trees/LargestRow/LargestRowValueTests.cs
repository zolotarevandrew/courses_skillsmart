namespace Tasks.Trees.LargestRow;

public class LargestRowValueTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var node = new LargestRowValue.TreeNode<int>
        {
            Value = 1,
            Left = new LargestRowValue.TreeNode<int>
            {
                Value = 2,
            },
            Right = new LargestRowValue.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        List<int> res = LargestRowValue.Visit( node );
        
        // Assert
        Assert.Equal( res, [1, 3] );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var node = new LargestRowValue.TreeNode<int>
        {
            Value = 1,
            Left = new LargestRowValue.TreeNode<int>
            {
                Value = 2,
                Left = new LargestRowValue.TreeNode<int>
                {
                    Value = 4,
                },
                Right = new LargestRowValue.TreeNode<int>
                {
                    Value = 5,
                }
            },
            Right = new LargestRowValue.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        List<int> res = LargestRowValue.Visit( node );
        
        // Assert
        Assert.Equal( res, [1, 3, 5] );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var node = new LargestRowValue.TreeNode<int>
        {
            Value = 1,
            Left = new LargestRowValue.TreeNode<int>
            {
                Value = 2,
                Left = new LargestRowValue.TreeNode<int>
                {
                    Value = 4,
                },
                Right = new LargestRowValue.TreeNode<int>
                {
                    Value = 5,
                }
            },
            Right = new LargestRowValue.TreeNode<int>
            {
                Value = 3,
                Left = new LargestRowValue.TreeNode<int>
                {
                    Value = 6,
                },
                Right = new LargestRowValue.TreeNode<int>
                {
                    Value = 7,
                }
            }
        };

        // Act
        List<int> res = LargestRowValue.Visit( node );
        
        // Assert
        Assert.Equal( res, [1, 3, 7] );
    }
}