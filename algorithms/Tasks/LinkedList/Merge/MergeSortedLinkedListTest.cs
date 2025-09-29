using Tasks.LinkedList.Palindrome;

namespace Tasks.LinkedList.Merge;

public class MergeSortedLinkedListTest
{
    [Fact]
    public void Run_Case1_ShouldBeFalse( )
    {
        // Arrange
        var node = new ListNode
        {
            Value = 3,
            Next = new ListNode
            {
                Value = 5
            }
        };
        
        var node2 = new ListNode
        {
            Value = 1,
            Next = new ListNode
            {
                Value = 2
            }
        };
        var expected = new int[]
        {
            1,2,3,5
        }.ToList();

        // Act
        var res = MergeSortedLinkedList.Run(node, node2);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );

    }
    
    [Fact]
    public void Run_Case2_ShouldBeFalse( )
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
        
        var node2 = new ListNode
        {
            Value = 4,
            Next = new ListNode
            {
                Value = 5
            }
        };
        var expected = new int[]
       {
            1,2,3,4,5
       }.ToList();

        // Act
        var res = MergeSortedLinkedList.Run(node, node2);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeFalse( )
    {
        // Arrange
        var node = new ListNode
        {
            Value = 1,
            Next = new ListNode
            {
                Value = 3,
                Next = new ListNode
                {
                    Value = 5
                }
            }
        };
        
        var node2 = new ListNode
        {
            Value = 4,
            Next = new ListNode
            {
                Value = 7
            }
        };
        var expected = new int[]
       {
            1,3,4,5,7
       }.ToList();

        // Act
        var res = MergeSortedLinkedList.Run(node, node2);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeFalse( )
    {
        // Arrange
        var node = new ListNode
        {
            Value = 5,
        };
        
        var node2 = new ListNode
        {
            Value = 1,
            Next = new ListNode
            {
                Value = 2
            }
        };

        var expected = new int[]
        {
                1,2,5
        }.ToList();
        // Act
        var res = MergeSortedLinkedList.Run(node, node2);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );
    }

    [Fact]
    public void Run_Case5_ShouldBeFalse()
    {
        // Arrange
        ListNode? node = null;

        var node2 = new ListNode
        {
            Value = 1,
            Next = new ListNode
            {
                Value = 2,
                Next = new ListNode { Value = 3 }
            }
        };

        var expected = new int[]
        {
           1,2,3
        }.ToList();
        // Act
        var res = MergeSortedLinkedList.Run( node, node2 );

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );
    }
}