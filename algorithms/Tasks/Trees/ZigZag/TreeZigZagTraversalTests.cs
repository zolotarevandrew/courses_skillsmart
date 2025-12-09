namespace Tasks.Trees.ZigZag;

public class TreeZigZagTraversalTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var node = new TreeZigZagTraversal.TreeNode<int>
        {
            Value = 1,
            Left = new TreeZigZagTraversal.TreeNode<int>
            {
                Value = 2,
            },
            Right = new TreeZigZagTraversal.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        List<int[]> res = TreeZigZagTraversal.Visit( node );
        
        // Assert
        Assert.Equal( 2, res.Count );
        Assert.Equal( [1], res[0] );
        Assert.Equal( [3, 2], res[1] );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var node = new TreeZigZagTraversal.TreeNode<int>
        {
            Value = 1
        };

        // Act
        List<int[]> res = TreeZigZagTraversal.Visit( node );
        
        // Assert
        Assert.Equal( 1, res.Count );
        Assert.Equal( [1], res[0] );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var node = new TreeZigZagTraversal.TreeNode<int>
        {
            Value = 1,
            Left = new TreeZigZagTraversal.TreeNode<int>
            {
                Value = 2,
                Left = new TreeZigZagTraversal.TreeNode<int>
                {
                    Value = 4,
                },
                Right = new TreeZigZagTraversal.TreeNode<int>
                {
                    Value = 5,
                }
            },
            Right = new TreeZigZagTraversal.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        List<int[]> res = TreeZigZagTraversal.Visit( node );
        
        // Assert
        Assert.Equal( 3, res.Count );
        Assert.Equal( [1], res[0] );
        Assert.Equal( [3, 2], res[1] );
        Assert.Equal( [4, 5], res[2] );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        // Arrange
        var node = new TreeZigZagTraversal.TreeNode<int>
        {
            Value = 1,
            Left = new TreeZigZagTraversal.TreeNode<int>
            {
                Value = 2,
                Left = new TreeZigZagTraversal.TreeNode<int>
                {
                    Value = 4,
                },
                Right = new TreeZigZagTraversal.TreeNode<int>
                {
                    Value = 5,
                }
            },
            Right = new TreeZigZagTraversal.TreeNode<int>
            {
                Value = 3,
                Left = new TreeZigZagTraversal.TreeNode<int>
                {
                    Value = 6,
                },
                Right = new TreeZigZagTraversal.TreeNode<int>
                {
                    Value = 7,
                }
            }
        };

        // Act
        List<int[]> res = TreeZigZagTraversal.Visit( node );
        
        // Assert
        Assert.Equal( 3, res.Count );
        
        Assert.Equal( [1], res[0] );
        Assert.Equal( [3, 2], res[1] );
        Assert.Equal( [4, 5, 6, 7], res[2] );
    }
    
    [Fact]
    public void Run_Case5_ShouldBeOk( )
    {
        // Arrange
        var node = new TreeZigZagTraversal.TreeNode<int>
        {
            Value = 1,
            Left = new TreeZigZagTraversal.TreeNode<int>
            {
                Value = 2,
                Left = new TreeZigZagTraversal.TreeNode<int>
                {
                    Value = 4,
                    Left = new TreeZigZagTraversal.TreeNode<int>
                    {
                        Value = 8,
                    },
                    Right = new TreeZigZagTraversal.TreeNode<int>
                    {
                        Value = 9,
                    }
                },
                Right = new TreeZigZagTraversal.TreeNode<int>
                {
                    Value = 5,
                    Left = new TreeZigZagTraversal.TreeNode<int>
                    {
                        Value = 10,
                    },
                }
            },
            Right = new TreeZigZagTraversal.TreeNode<int>
            {
                Value = 3,
                Left = new TreeZigZagTraversal.TreeNode<int>
                {
                    Value = 6,
                },
                Right = new TreeZigZagTraversal.TreeNode<int>
                {
                    Value = 7,
                }
            }
        };

        // Act
        List<int[]> res = TreeZigZagTraversal.Visit( node );
        
        // Assert
        Assert.Equal( 4, res.Count );
        
        Assert.Equal( [1], res[0] );
        Assert.Equal( [3, 2], res[1] );
        Assert.Equal( [4, 5, 6, 7], res[2] );
        Assert.Equal( [10, 9, 8], res[3] );
    }
}