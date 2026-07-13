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
}