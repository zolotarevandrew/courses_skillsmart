namespace Tasks.LinkedList.Sort;

public partial class SortLinkedListTest
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var node1 = new ListNode
        {
            Value = 4,
            Next = new ListNode
            {
                Value = 2,
                Next = new ListNode
                {
                    Value = 1,
                    Next = new ListNode
                    {
                        Value = 3
                    }
                }
            }
        };
        
        var expected = new int[]
        {
           1,2,3,4
        }.ToList();

        // Act
        var res = SortLinkedList.Run(node1);

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
            Value = 4,
            Next = new ListNode
            {
                Value = 2
            }
        };
        
        var expected = new int[]
        {
            2,4
        }.ToList();

        // Act
        var res = SortLinkedList.Run(node1);

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
            Value = 4
        };
        
        var expected = new int[]
        {
            4
        }.ToList();

        // Act
        var res = SortLinkedList.Run(node1);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );

    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        // Arrange
        var node1 = new ListNode
        {
            Value = 4,
            Next = new ListNode
            {
                Value = 5,
                Next = new ListNode
                {
                    Value = -1
                }
            }
        };
        
        var expected = new int[]
        {
            -1,4,5
        }.ToList();

        // Act
        var res = SortLinkedList.Run(node1);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );

    }
    
    [Fact]
    public void Run_Case5_ShouldBeOk( )
    {
        // Arrange
        var node1 = new ListNode
        {
            Value = 4,
            Next = new ListNode
            {
                Value = 5,
                Next = new ListNode
                {
                    Value = -1,
                    Next = new ListNode
                    {
                        Value = 10,
                        Next = new ListNode
                        {
                            Value = 2
                        }
                    }
                }
            }
        };
        
        var expected = new int[]
        {
            -1,2,4,5,10
        }.ToList();

        // Act
        var res = SortLinkedList.Run(node1);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );

    }
    
    [Fact]
    public void Run_Case6_ShouldBeOk( )
    {
        // Arrange
        var node1 = new ListNode
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
            1,2,3,4,5
        }.ToList();

        // Act
        var res = SortLinkedList.Run(node1);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );

    }
}