using Tasks.LinkedList.Merge;

namespace Tasks.LinkedList.OddEven;

public class OddEvenLinkedListTest
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
            1,3,5,2,4
        }.ToList();

        // Act
        var res = OddEvenLinkedList.Run(node);

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
            Value = 2,
            Next = new ListNode
            {
                Value = 1,
                Next = new ListNode
                {
                    Value = 3,
                    Next = new ListNode
                    {
                        Value = 5,
                        Next = new ListNode
                        {
                            Value = 6,
                            Next = new ListNode
                            {
                                Value = 4,
                                Next = new ListNode
                                {
                                    Value = 7
                                }
                            }
                        }
                    }
                }
            }
        };
        
        var expected = new int[]
        {
            2,3,6,7,1,5,4
        }.ToList();

        // Act
        var res = OddEvenLinkedList.Run(node);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );

    }
    
    [Fact]
    public void RunV2_Case1_ShouldBeOk( )
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
            1,3,5,2,4
        }.ToList();

        // Act
        var res = OddEvenLinkedList.RunV2(node);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );

    }
    
    [Fact]
    public void RunV2_Case2_ShouldBeOk( )
    {
        // Arrange
        var node = new ListNode
        {
            Value = 2,
            Next = new ListNode
            {
                Value = 1,
                Next = new ListNode
                {
                    Value = 3,
                    Next = new ListNode
                    {
                        Value = 5,
                        Next = new ListNode
                        {
                            Value = 6,
                            Next = new ListNode
                            {
                                Value = 4,
                                Next = new ListNode
                                {
                                    Value = 7
                                }
                            }
                        }
                    }
                }
            }
        };
        
        var expected = new int[]
        {
            2,3,6,7,1,5,4
        }.ToList();

        // Act
        var res = OddEvenLinkedList.RunV2(node);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );
    }
    
    [Fact]
    public void RunV2_Case3_ShouldBeOk( )
    {
        // Arrange
        var node = new ListNode
        {
            Value = 2,
            Next = new ListNode
            {
                Value = 1,
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
            2,3,1,4
        }.ToList();

        // Act
        var res = OddEvenLinkedList.RunV2(node);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );
    }
    
    [Fact]
    public void RunV2_Case4_ShouldBeOk( )
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
        var res = OddEvenLinkedList.RunV2(node);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );
    }
    
    [Fact]
    public void RunV2_Case5_ShouldBeOk( )
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
        var res = OddEvenLinkedList.RunV2(node);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );
    }
    
    [Fact]
    public void RunV2_Case6_ShouldBeOk( )
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
        var res = OddEvenLinkedList.RunV2(node);

        // Assert
        Assert.NotNull( res );
        Assert.Equal( expected, res.AsArray() );
    }
}