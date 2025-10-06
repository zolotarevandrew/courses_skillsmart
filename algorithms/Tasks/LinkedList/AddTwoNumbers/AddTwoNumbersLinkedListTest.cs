namespace Tasks.LinkedList.AddTwoNumbers;

public class AddTwoNumbersLinkedListTest
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var node1 = new ListNode
        {
            Value = 5,
            Next = new ListNode
            {
                Value = 4,
                Next = new ListNode
                {
                    Value = 3
                }
            }
        };
        var node2 = new ListNode
        {
            Value = 5,
            Next = new ListNode
            {
                Value = 6,
                Next = new ListNode
                {
                    Value = 4
                }
            }
        };
        
        var expected = new int[]
        {
           0,1,8
        }.ToList();

        // Act
        var res = AddTwoNumbersLinkedList.Run(node1, node2);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );

    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var node1 = new ListNode
        {
            Value = 2,
            Next = new ListNode
            {
                Value = 4,
                Next = new ListNode
                {
                    Value = 3
                }
            }
        };
        var node2 = new ListNode
        {
            Value = 5,
            Next = new ListNode
            {
                Value = 6
            }
        };
        
        var expected = new int[]
        {
            7,0,4
        }.ToList();

        // Act
        var res = AddTwoNumbersLinkedList.Run(node1, node2);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );

    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var node1 = new ListNode
        {
            Value = 2,
            Next = new ListNode
            {
                Value = 4,
                Next = new ListNode
                {
                    Value = 3
                }
            }
        };
        var node2 = new ListNode
        {
            Value = 5,
            Next = new ListNode
            {
                Value = 6,
                Next = new ListNode
                {
                    Value = 7
                }
            }
        };
        
        var expected = new int[]
        {
            7,0,1,1
        }.ToList();

        // Act
        var res = AddTwoNumbersLinkedList.Run(node1, node2);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );

    }
}