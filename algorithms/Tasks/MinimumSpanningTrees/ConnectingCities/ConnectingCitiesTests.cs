namespace Tasks.MinimumSpanningTrees.ConnectingCities;

public class ConnectingCitiesTests
{
    [Fact]
    public void Run_HasTree_ShouldBeOk( )
    {
        // Arrange
        int n = 3;
        (int from, int to, int weight)[] edges =
        [
            ( 1, 2, 5 ),
            ( 1, 3, 6 ),
            ( 2, 3, 1 ),
        ];

        // Assert
        Assert.Equal( 6, ConnectingCities.Run( n, edges ) );
    }
    
    [Fact]
    public void Run_HasCycles_ShouldBeMinusOne( )
    {
        // Arrange
        int n = 4;
        (int from, int to, int weight)[] edges =
        [
            ( 1, 2, 3 ),
            ( 3, 4, 4 )
        ];

        // Assert
        Assert.Equal( -1, ConnectingCities.Run( n, edges ) );
    }
}