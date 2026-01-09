namespace Tasks.BinaryTrees.SmallestDifference;

public class BinaryTreeSmallestDifferenceTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var node = new BinaryTreeSmallestDifference.TreeNode<int>
        {
            Value = 6,
            Left = new BinaryTreeSmallestDifference.TreeNode<int>
            {
                Value = 4,
                Left = new BinaryTreeSmallestDifference.TreeNode<int>
                {
                    Value = 2
                },
                Right = new BinaryTreeSmallestDifference.TreeNode<int>
                {
                    Value = 5
                }
            },
            Right = new BinaryTreeSmallestDifference.TreeNode<int>
            {
                Value = 8
            }
        };
        
        // Act
        var res = BinaryTreeSmallestDifference.Check( node );

        // Assert
        Assert.Equal( 1, res );
    }
}