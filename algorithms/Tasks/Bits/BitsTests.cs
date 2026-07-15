namespace Tasks.Bits;

public class BitsTests
{
    [Fact]
    public void Convert( )
    {
        Assert.Equal( "1101", Bits.Convert( 13 ) );
    }
    
    [Theory]
    [InlineData( 0b11010, 3 )]
    [InlineData( 0b10000000, 1 )]
    public void NumberOfOneBits( int num, int bits )
    {
        Assert.Equal( bits, Bits.NumberOfOneBits( num ) );
    }
    
    [Theory]
    [InlineData( 0b00000000011010, 1476395008 )]
    public void ReverseBits( int num, int res )
    {
        Assert.Equal( res, Bits.ReverseBits( num ) );
        Assert.Equal( res, Bits.ReverseBitsV2( num ) );
    }
    
    [Theory]
    [InlineData( new[] { 0, 1, 3}, 2 )]
    [InlineData( new[] { 1, 2 }, 0 )]
    public void MissingNumber( int[] nums, int res )
    {
        Assert.Equal( res, Bits.MissingNumber( nums ) );
    }
    
    [Theory]
    [InlineData( new[] { 3, 2, 3}, 2 )]
    [InlineData( new[] { 7, 6, 6, 7, 8 }, 8 )]
    public void SingleNumber( int[] nums, int res )
    {
        Assert.Equal( res, Bits.SingleNumber( nums ) );
    }
    
    [Theory]
    [InlineData( 3, 5, 8 )]
    [InlineData( 7, 6, 13 )]
    public void Sum( int num1, int num2, int res )
    {
        Assert.Equal( res, Bits.Sum( num1, num2 ) );
    }
    
    [Theory]
    [InlineData( 5, new[] { 0, 1, 1, 2, 1, 2} )]
    public void CountingBits( int n, int[] bits )
    {
        Assert.Equal( bits, Bits.CountingBits( n ) );
        Assert.Equal( bits, Bits.CountingBitsV2( n ) );
    }
}