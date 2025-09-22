
namespace Tasks.LinkedList.Remove;

public class RemoveLinkedListTest
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
        var res = RemoveLinkedList.RunV2( node, 2 );

        // Assert
        Assert.NotNull( res );
        Assert.Equal( 1, res.Value );
        Assert.NotNull( res.Next );
        Assert.Equal( 3, res.Next.Value );
        Assert.Null( res.Next.Next );
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
        var res = RemoveLinkedList.RunV2(node, 1);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( 1, res.Value );
        Assert.Null( res.Next );
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
        var res = RemoveLinkedList.RunV2( node, 1 );

        // Assert
        Assert.Null( res );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
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
        var res = RemoveLinkedList.RunV2( node, 3 );

        // Assert
        Assert.NotNull( res );
        Assert.Equal( 2, res.Value );
        Assert.NotNull( res.Next );
        Assert.Equal( 3, res.Next.Value );
        Assert.Null( res.Next.Next );
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
                Value = 2,
                Next = new ListNode
                {
                    Value = 3
                }
            }
        };

        // Act
        var res = RemoveLinkedList.RunV2( node, 1 );

        // Assert
        Assert.NotNull( res );
        Assert.Equal( 1, res.Value );
        Assert.NotNull( res.Next );
        Assert.Equal( 2, res.Next.Value );
        Assert.Null( res.Next.Next );
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
                    Value = 3,
                    Next = new ListNode
                    {
                        Value = 4
                    }
                }
            }
        };

        // Act
        var res = RemoveLinkedList.RunV2( node, 1 );

        // Assert
        Assert.NotNull( res );
        Assert.Equal( 1, res.Value );
        Assert.NotNull( res.Next );
        Assert.Equal( 2, res.Next.Value );
        Assert.NotNull( res.Next.Next );
        Assert.Equal( 3, res.Next.Next.Value );
    }
    
    [Fact]
    public void Run_Case7_ShouldBeOk( )
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

        // Act
        var res = RemoveLinkedList.RunV2( node, 2 );

        // Assert
        Assert.NotNull( res );
        Assert.Equal( 1, res.Value );
        Assert.NotNull( res.Next );
        Assert.Equal( 2, res.Next.Value );
        Assert.NotNull( res.Next.Next );
        Assert.Equal( 4, res.Next.Next.Value );
        Assert.Null( res.Next.Next.Next );
    }
    
    [Fact]
    public void Run_Case8_ShouldBeOk( )
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
        var res = RemoveLinkedList.RunV2( node, 3 );

        // Assert
        Assert.NotNull( res );
        Assert.Equal( 1, res.Value );
        Assert.NotNull( res.Next );
        Assert.Equal( 3, res.Next.Value );
        Assert.NotNull( res.Next.Next );
        Assert.Equal( 4, res.Next.Next.Value );
        Assert.Null( res.Next.Next.Next );
    }
    
    [Fact]
    public void Run_Case9_ShouldBeOk( )
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
        var res = RemoveLinkedList.RunV2( node, 4 );

        // Assert
        Assert.NotNull( res );
        Assert.Equal( 2, res.Value );
        Assert.NotNull( res.Next );
        Assert.Equal( 3, res.Next.Value );
        Assert.NotNull( res.Next.Next );
        Assert.Equal( 4, res.Next.Next.Value );
        Assert.Null( res.Next.Next.Next );
    }
}