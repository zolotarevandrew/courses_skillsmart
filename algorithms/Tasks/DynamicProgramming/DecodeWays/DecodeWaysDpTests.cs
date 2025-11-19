namespace Tasks.DynamicProgramming.DecodeWays;

public partial class DecodeWaysDpTests
{
    [Fact]
    public void RunDp_Case1_ShouldBeOk( )
    {
        Assert.Equal( 4, DecodeWays.RunDp( "2615" ) );
    }
    
    [Fact]
    public void RunDp_Case2_ShouldBeOk( )
    {
        Assert.Equal( 2, DecodeWays.RunDp( "2715" ) );
    }
    
    [Fact]
    public void RunDp_Case3_ShouldBeOk( )
    {
        Assert.Equal( 0, DecodeWays.RunDp( "30" ) );
    }
    
    [Fact]
    public void RunDp_Case4_ShouldBeOk( )
    {
        Assert.Equal( 2, DecodeWays.RunDp( "23" ) );
    }
    
    [Fact]
    public void RunDp_Case5_ShouldBeOk( )
    {
        Assert.Equal( 1, DecodeWays.RunDp( "3855" ) );
    }
    
    [Fact]
    public void RunDp_Case6_ShouldBeOk( )
    {
        Assert.Equal( 3, DecodeWays.RunDp( "226" ) );
    }
}