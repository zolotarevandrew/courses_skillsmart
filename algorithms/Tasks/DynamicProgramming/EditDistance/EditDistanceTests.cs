namespace Tasks.DynamicProgramming.EditDistance;

public partial class EditDistanceTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        Assert.Equal( 3, EditDistance.Run( "cat", "dog" ) );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        Assert.Equal( 3, EditDistance.Run( "", "dog" ) );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        Assert.Equal( 5, EditDistance.Run( "opana", "" ) );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        Assert.Equal( 0, EditDistance.Run( "abc", "abc" ) );
    }
    
    [Fact]
    public void Run_Case5_ShouldBeOk( )
    {
        Assert.Equal( 1, EditDistance.Run( "abc", "yabc" ) );
    }
    
    [Fact]
    public void Run_Case6_ShouldBeOk( )
    {
        Assert.Equal( 1, EditDistance.Run( "axc", "ac" ) );
    }
}