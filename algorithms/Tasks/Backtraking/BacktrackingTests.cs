namespace Tasks.Backtraking;

public class BacktrackingTests
{
    [Fact]
    public void GenerateBinaryString_ShouldBeOk( )
    {
        // Act
        var res = Backtracking.GenerateBinaryString( 3 );

        // Assert
        Assert.NotEmpty( res );
    }
    
    [Fact]
    public void NQueen_ShouldBeOk( )
    {
        // Act
        var res = Backtracking.NQueen( 4 );

        // Assert
        Assert.NotEmpty( res );
        Assert.Equal( res.Length, 4 );
    }
    
    [Fact]
    public void Permutation_ThreeItems_ShouldBeOk( )
    {
        // Act
        List<List<int>> res = Backtracking.Permutation( [4, 5, 6] );

        // Assert
        Assert.NotEmpty( res );
        Assert.Equal( res.Count, 6 );
    }
    
    [Fact]
    public void Sets_ThreeItems_ShouldBeOk( )
    {
        // Act
        List<List<int>> res = Backtracking.Sets( [2, 4, 6] );

        // Assert
        Assert.NotEmpty( res );
        Assert.Equal( res.Count, 8 );
    }
    
    [Fact]
    public void Permutation_OneItem_ShouldBeOk( )
    {
        // Act
        List<List<int>> res = Backtracking.Permutation( [9] );

        // Assert
        Assert.NotEmpty( res );
        Assert.Equal( res.Count, 1 );
    }
    
    [Fact]
    public void WordSearch_TwoRows_ShouldBeOk( )
    {
        // Act
        char[,] grid =
        {
            { 'A', 'B' },
            { 'C', 'D' },
        };
        
        Assert.True( Backtracking.WordSearch( grid, "ABCD" ) );
    }
    
    [Fact]
    public void WordSearch_MultipleRows_ShouldBeOk( )
    {
        // Act
        char[,] grid =
        {
            { 'a', 'b', 'e', 'd', 'f', 'g', 'h' },
            { 'r', 'f', 'e', 'h', 'e', 'f', 'd' },
            { 'f', 'a', 'b', 'c', 'r', 'e', 't' },
            { 'w', 'e', 'q', 't', 'w', 'q', 'y' },
            { 'w', 'e', 'r', 'e', 't', 'h', 'e' },
            { 'f', 'o', 'l', 'l', 'o', 'w', 's' },
            { 't', 'h', 'e', 'd', 'e', 'e', 'r' },
        };
        
        Assert.True( Backtracking.WordSearch( grid, "abcteth" ) );
    }
}