namespace Tasks.LinkedList.Sort;

public partial class SortLinkedListTest
{
    [Fact]
    public void Split_Case1_ShouldBeOk( )
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
        
        var expected1 = new int[]
        {
            1,2,3
        }.ToList();
        var expected2 = new int[]
        {
            4,5
        }.ToList();

        // Act
        (ListNode beforeMode, ListNode afterMid ) = SortLinkedList.Split(node);

        // Assert
        Assert.NotNull( beforeMode );
        Assert.NotNull( afterMid );
        Assert.Equal( expected1, beforeMode.AsArray() );
        Assert.Equal( expected2, afterMid.AsArray() );

    }
    
    [Fact]
    public void Split_Case2_ShouldBeOk( )
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
        
        var expected1 = new int[]
        {
            1,2
        }.ToList();
        var expected2 = new int[]
        {
            3,4
        }.ToList();

        // Act
        (ListNode beforeMode, ListNode afterMid ) = SortLinkedList.Split(node);

        // Assert
        Assert.NotNull( beforeMode );
        Assert.NotNull( afterMid );
        Assert.Equal( expected1, beforeMode.AsArray() );
        Assert.Equal( expected2, afterMid.AsArray() );

    }
    
    [Fact]
    public void Split_Case5_ShouldBeOk( )
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
        
        var expected1 = new int[]
        {
            1
        }.ToList();
        var expected2 = new int[]
        {
            2
        }.ToList();

        // Act
        (ListNode beforeMode, ListNode afterMid ) = SortLinkedList.Split(node);

        // Assert
        Assert.NotNull( beforeMode );
        Assert.NotNull( afterMid );
        Assert.Equal( expected1, beforeMode.AsArray() );
        Assert.Equal( expected2, afterMid.AsArray() );

    }
    
    [Fact]
    public void Split_Case6_ShouldBeOk( )
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
        
        var expected1 = new int[]
        {
            1,2
        }.ToList();
        var expected2 = new int[]
        {
            3
        }.ToList();

        // Act
        (ListNode beforeMode, ListNode afterMid ) = SortLinkedList.Split(node);

        // Assert
        Assert.NotNull( beforeMode );
        Assert.NotNull( afterMid );
        Assert.Equal( expected1, beforeMode.AsArray() );
        Assert.Equal( expected2, afterMid.AsArray() );

    }
}