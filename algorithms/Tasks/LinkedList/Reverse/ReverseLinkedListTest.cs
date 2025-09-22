
namespace Tasks.LinkedList.Reverse;

public class ReverseLinkedListTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var node = new ListNode
        {
            Value = 1,
            Next = new ListNode
            {
                Value = 2,
                Next = new ListNode
                {
                    Value = 3
                }
            }
        };

        // Act
        var res = ReverseLinkedList.Run(node);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( 3, res.Value );
        Assert.Equal( 2, res.Next!.Value );
        Assert.Equal( 1, res.Next!.Next!.Value );
        Assert.Null( res.Next.Next.Next );
    }
}