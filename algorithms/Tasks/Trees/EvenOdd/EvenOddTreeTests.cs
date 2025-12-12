namespace Tasks.Trees.EvenOdd;

public class EvenOddTreeTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var node = new EvenOddTree.TreeNode<int>
        {
            Value = 1,
            Left = new EvenOddTree.TreeNode<int>
            {
                Value = 4,
                Left = new EvenOddTree.TreeNode<int>
                {
                    Value = 9,
                },
                Right = new EvenOddTree.TreeNode<int>
                {
                    Value = 7,
                }
            },
            Right = new EvenOddTree.TreeNode<int>
            {
                Value = 10,
                Left = new EvenOddTree.TreeNode<int>
                {
                    Value = 5,
                }
            }
        };

        // Act
        bool res = EvenOddTree.Run( node );
        
        // Assert
        Assert.True( res );
    }
}