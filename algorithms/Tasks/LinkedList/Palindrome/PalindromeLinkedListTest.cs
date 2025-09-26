
using Tasks.LinkedList.ListToNumber;

namespace Tasks.LinkedList.Palindrome;

public class PalindromeLinkedListTest
{
    [Fact]
    public void Run_Case1_ShouldBeFalse( )
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
                    Value = 3,
                    Next = new ListNode
                    {
                        Value = 4
                    }
                }
            }
        };

        // Act
        var res = PalindromeLinkedList.Run(node);

        // Assert
        Assert.False( res );
    }
    
    [Fact]
    public void Run_Case1_ShouldBeTrue( )
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
                    Value = 1
                }
            }
        };

        // Act
        var res = PalindromeLinkedList.Run(node);

        // Assert
        Assert.True( res );
    }
}