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
    public void Permutation_OneItem_ShouldBeOk( )
    {
        // Act
        List<List<int>> res = Backtracking.Permutation( [9] );

        // Assert
        Assert.NotEmpty( res );
        Assert.Equal( res.Count, 1 );
    }
}