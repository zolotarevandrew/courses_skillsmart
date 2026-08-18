namespace Tasks.Arrays.Sum;

public class ArrayRecursionTests
{
    [Fact]
    public void Sum( )
    {
        int[] arr = [1, 2, 3];
        Assert.Equal( 6, ArrayRecursion.Sum( arr ) );
    }
    
    [Fact]
    public void Count( )
    {
        int[] arr = [1, 2, 3];
        Assert.Equal( 3, ArrayRecursion.Count( arr ) );
    }
    
    [Fact]
    public void Max( )
    {
        int[] arr = [1, 2, 3];
        Assert.Equal( 3, ArrayRecursion.Max( arr ) );
    }
    
    [Fact]
    public void BinSearch( )
    {
        int[] arr = [1, 2, 3];
        Assert.Equal( 2, ArrayRecursion.BinSearch( arr, 3 ) );
    }
    
    [Fact]
    public void BinSearch_LongArray( )
    {
        int[] arr = [1, 2, 3, 4, 5, 6];
        Assert.Equal( 4, ArrayRecursion.BinSearch( arr, 5 ) );
    }
    
    [Fact]
    public void BinSearch_NotFound( )
    {
        int[] arr = [1, 2, 3, 4, 5, 6];
        Assert.Equal( -1, ArrayRecursion.BinSearch( arr, 10 ) );
    }
}