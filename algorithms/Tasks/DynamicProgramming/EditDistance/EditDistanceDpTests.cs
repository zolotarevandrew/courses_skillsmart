namespace Tasks.DynamicProgramming.EditDistance;

public partial class EditDistanceTests
{
    [Fact]
    public void RunDp_Case0_ShouldBeOk( )
    {
        Assert.Equal( 6, EditDistance.RunDp( "rotator", "rampage" ) );
    }
    
    [Fact]
    public void RunDp_Case1_ShouldBeOk( )
    {
        Assert.Equal( 3, EditDistance.RunDp( "cat", "dog" ) );
    }
    
    [Fact]
    public void RunDp_Case2_ShouldBeOk( )
    {
        Assert.Equal( 3, EditDistance.RunDp( "", "dog" ) );
    }
    
    [Fact]
    public void RunDp_Case3_ShouldBeOk( )
    {
        Assert.Equal( 5, EditDistance.RunDp( "opana", "" ) );
    }
    
    [Fact]
    public void RunDp_Case4_ShouldBeOk( )
    {
        Assert.Equal( 0, EditDistance.RunDp( "abc", "abc" ) );
    }
    
    [Fact]
    public void RunDp_Case5_ShouldBeOk( )
    {
        Assert.Equal( 1, EditDistance.RunDp( "abc", "yabc" ) );
    }
    
    [Fact]
    public void RunDp_Case6_ShouldBeOk( )
    {
        Assert.Equal( 1, EditDistance.RunDp( "axc", "ac" ) );
    }
}