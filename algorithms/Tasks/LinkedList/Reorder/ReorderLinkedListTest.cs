namespace Tasks.LinkedList.Reorder;

public class ReorderLinkedListTest
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
                    Value = 3,
                    Next = new ListNode
                    {
                        Value = 4
                    }
                }
            }
        };
        
        var expected = new int[]
        {
            1,4,2,3
        }.ToList();

        // Act
        var res = ReorderLinkedList.Run(node);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );

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
                Value = 2,
                Next = new ListNode
                {
                    Value = 3,
                    Next = new ListNode
                    {
                        Value = 4,
                        Next = new ListNode
                        {
                            Value = 5
                        }
                    }
                }
            }
        };
        
        var expected = new int[]
        {
            1,5,2,4,3
        }.ToList();

        // Act
        var res = ReorderLinkedList.Run(node);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );

    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var node = new ListNode
        {
            Value = 1
        };
        
        var expected = new int[]
        {
            1
        }.ToList();

        // Act
        var res = ReorderLinkedList.Run(node);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );

    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        // Arrange
        var node = new ListNode
        {
            Value = 1
        };
        
        var expected = new int[]
        {
            1
        }.ToList();

        // Act
        var res = ReorderLinkedList.Run(node);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );

    }
    
    [Fact]
    public void Run_Case5_ShouldBeOk( )
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
        
        var expected = new int[]
        {
            1,2
        }.ToList();

        // Act
        var res = ReorderLinkedList.Run(node);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );

    }
    
    [Fact]
    public void Run_Case6_ShouldBeOk( )
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
        
        var expected = new int[]
        {
            1,3,2
        }.ToList();

        // Act
        var res = ReorderLinkedList.Run(node);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );

    }
}