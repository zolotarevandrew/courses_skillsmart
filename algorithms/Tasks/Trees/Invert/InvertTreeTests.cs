namespace Tasks.Trees.Invert;

public class InvertTreeTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var node = new InvertTree.TreeNode<int>
        {
            Value = 1,
            Left = new InvertTree.TreeNode<int>
            {
                Value = 2,
            },
            Right = new InvertTree.TreeNode<int>
            {
                Value = 3,
            }
        };

        // Act
        InvertTree.TreeNode<int>? res = InvertTree.Run( node );
        
        // Assert
        Assert.Equal( 1, res!.Value );
        Assert.Equal( 3, res.Left!.Value );
        Assert.Equal( 2, res.Right!.Value );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var node = new InvertTree.TreeNode<int>
        {
            Value = 1,
            Left = new InvertTree.TreeNode<int>
            {
                Value = 2,
                Right = new InvertTree.TreeNode<int>
                {
                    Value = 3,
                    Right = new InvertTree.TreeNode<int>
                    {
                        Value = 4,
                    }
                }
            },
            Right = new InvertTree.TreeNode<int>
            {
                Value = 5,
                Right = new InvertTree.TreeNode<int>
                {
                    Value = 6,
                }
            }
        };

        // Act
        InvertTree.TreeNode<int>? res = InvertTree.Run( node );
        
        // Assert
        Assert.Equal( 1, res!.Value );
        Assert.Equal( 5, res.Left!.Value );
        Assert.Equal( 6, res.Left!.Left!.Value );
        
        Assert.Equal( 2, res.Right!.Value );
        Assert.Equal( 3, res.Right!.Left!.Value );
        Assert.Equal( 4, res.Right!.Left!.Left!.Value );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var node = new InvertTree.TreeNode<int>
        {
            Value = 1,
            Left = new InvertTree.TreeNode<int>
            {
                Value = 2,
                Left = new InvertTree.TreeNode<int>
                {
                    Value = 4
                },
                Right = new InvertTree.TreeNode<int>
                {
                    Value = 5,
                }
            },
            Right = new InvertTree.TreeNode<int>
            {
                Value = 3
            }
        };

        // Act
        InvertTree.TreeNode<int>? res = InvertTree.Run( node );
        
        // Assert
        Assert.Equal( 1, res!.Value );
        Assert.Equal( 3, res.Left!.Value );
        
        Assert.Equal( 2, res.Right!.Value );
        Assert.Equal( 5, res.Right!.Left!.Value );
        Assert.Equal( 4, res.Right!.Right!.Value );
        
        
    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        // Arrange
        var node = new InvertTree.TreeNode<int>
        {
            Value = 1,
            Left = new InvertTree.TreeNode<int>
            {
                Value = 2,
                Left = new InvertTree.TreeNode<int>
                {
                    Value = 4
                },
                Right = new InvertTree.TreeNode<int>
                {
                    Value = 5,
                }
            },
            Right = new InvertTree.TreeNode<int>
            {
                Value = 3,
                Left = new InvertTree.TreeNode<int>
                {
                    Value = 6
                },
                Right = new InvertTree.TreeNode<int>
                {
                    Value = 7,
                }
            }
        };

        // Act
        InvertTree.TreeNode<int>? res = InvertTree.Run( node );
        
        // Assert
        Assert.Equal( 1, res!.Value );
        
        Assert.Equal( 3, res.Left!.Value );
        Assert.Equal( 7, res.Left!.Left!.Value );
        Assert.Equal( 6, res.Left!.Right!.Value );
        
        Assert.Equal( 2, res.Right!.Value );
        Assert.Equal( 5, res.Right!.Left!.Value );
        Assert.Equal( 4, res.Right!.Right!.Value );
    }
}