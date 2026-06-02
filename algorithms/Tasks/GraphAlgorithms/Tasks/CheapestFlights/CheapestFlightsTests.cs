namespace Tasks.GraphAlgorithms.Tasks.CheapestFlights;

public class CheapestFlightsTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        int n = 4;
        (int, int, int)[] flights = [
            ( 0, 1, 100 ),
            ( 1, 2, 100 ),
            ( 2, 0, 100 ),
            ( 1, 3, 600 ),
            ( 2, 3, 200 ),
        ];
        int src = 0;
        int dst = 3;
        int k = 1;
        
        // Act
        
        Assert.Equal( 700, CheapestFlights.Run( n, flights, src, dst, k ) );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        int n = 3;
        (int, int, int)[] flights = [
            ( 0, 1, 100 ),
            ( 1, 2, 100 ),
            ( 0, 2, 500 ),
        ];
        int src = 0;
        int dst = 2;
        int k = 1;
        
        // Act
        
        Assert.Equal( 200, CheapestFlights.Run( n, flights, src, dst, k ) );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        int n = 3;
        (int, int, int)[] flights = [
            ( 0, 1, 100 ),
            ( 1, 2, 100 ),
            ( 0, 2, 500 ),
        ];
        int src = 0;
        int dst = 2;
        int k = 0;
        
        // Act
        
        Assert.Equal( 500, CheapestFlights.Run( n, flights, src, dst, k ) );
    }
}