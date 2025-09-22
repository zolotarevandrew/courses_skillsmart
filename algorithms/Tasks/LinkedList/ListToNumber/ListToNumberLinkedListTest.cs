
namespace Tasks.LinkedList.ListToNumber;

public class ListToNumberLinkedListTest
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
        var res = ListToNumberLinkedList.Run(node);

        // Assert
        Assert.Equal( 321, res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var node = new ListNode
        {
            Value = 1,
            Next = new ListNode
            {
                Value = 2
            }
        };

        // Act
        var res = ListToNumberLinkedList.Run(node);

        // Assert
        Assert.Equal( 21, res );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var node = new ListNode
        {
            Value = 3
        };

        // Act
        var res = ListToNumberLinkedList.Run(node);

        // Assert
        Assert.Equal( 3, res );
    }
}