namespace Tasks.DynamicProgramming.Climbing;

public class ClimbingStairsTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        Assert.Equal( 5, ClimbingStairs.Run( 4 ) );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        Assert.Equal( 8, ClimbingStairs.Run( 5 ) );
    }
    
    [Fact]
    public void RunMemo_Case1_ShouldBeOk( )
    {
        Assert.Equal( 5, ClimbingStairs.RunMemo( 4, new Dictionary<int, int>() ) );
    }
    
    [Fact]
    public void RunMemo_Case2_ShouldBeOk( )
    {
        Assert.Equal( 8, ClimbingStairs.RunMemo( 5, new Dictionary<int, int>() ) );
    }
    
    [Fact]
    public void RunTabulation_Case1_ShouldBeOk( )
    {
        Assert.Equal( 5, ClimbingStairs.RunTabulation( 4 ) );
    }
    
    [Fact]
    public void RunTabulation_Case2_ShouldBeOk( )
    {
        Assert.Equal( 8, ClimbingStairs.RunTabulation( 5 ) );
    }
}