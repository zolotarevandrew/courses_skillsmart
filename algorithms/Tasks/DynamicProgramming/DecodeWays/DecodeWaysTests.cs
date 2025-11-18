namespace Tasks.DynamicProgramming.DecodeWays;

public class DecodeWaysTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        Assert.Equal( 4, DecodeWays.Run( "2615" ) );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        Assert.Equal( 2, DecodeWays.Run( "2715" ) );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        Assert.Equal( 0, DecodeWays.Run( "30" ) );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        Assert.Equal( 2, DecodeWays.Run( "23" ) );
    }
    
    [Fact]
    public void Run_Case5_ShouldBeOk( )
    {
        Assert.Equal( 1, DecodeWays.Run( "3855" ) );
    }
    
    [Fact]
    public void Run_Case6_ShouldBeOk( )
    {
        Assert.Equal( 3, DecodeWays.Run( "226" ) );
    }
}