namespace Tasks.GraphAlgorithms.Tasks.NetworkDelayTime;

public class NetworkDelayTimeTests
{
    [Fact]
    public void Run_HasNoPath_ShouldReturnNone( )
    {
        // Arrange
        (int u, int v, int w)[] times =
        [
            ( 1, 2, 1 )
        ];
        int n = 2;
        int k = 2;
        
        
        // Act
        Assert.Equal( -1, NetworkDelayTime.Run( times, n, k ) );
    }
    
    [Fact]
    public void Run_HasPath_ShouldReturnTime( )
    {
        // Arrange
        (int u, int v, int w)[] times =
        [
            ( 1, 2, 1 )
        ];
        int n = 2;
        int k = 1;
        
        
        // Act
        Assert.Equal( 1, NetworkDelayTime.Run( times, n, k ) );
    }
    
    [Fact]
    public void Run_HasPathAndFourNodes_ShouldReturnTime( )
    {
        // Arrange
        (int u, int v, int w)[] times =
        [
            ( 2, 1, 1 ),
            ( 2, 3, 1 ),
            ( 3, 4, 1 ),
        ];
        int n = 4;
        int k = 2;
        
        
        // Act
        Assert.Equal( 2, NetworkDelayTime.Run( times, n, k ) );
    }
}