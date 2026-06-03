namespace Tasks.GraphAlgorithms.Tasks.PathMaximumProbability;

public class PathMaximumProbabilityTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        int n = 3;
        (int, int)[] edges = [
            ( 0, 1 ),
            ( 1, 2 ),
            ( 0, 2 )
        ];
        double[] probs = [0.5, 0.5, 0.2];
        int src = 0;
        int dst = 2;
        
        // Act
        
        Assert.Equal( 0.25, PathMaximumProbability.Run( n, edges, probs, src, dst ) );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        int n = 3;
        (int, int)[] edges = [
            ( 0, 1 ),
            ( 1, 2 ),
            ( 0, 2 )
        ];
        double[] probs = [0.5, 0.5, 0.3];
        int src = 0;
        int dst = 2;
        
        // Act
        
        Assert.Equal( 0.3, PathMaximumProbability.Run( n, edges, probs, src, dst ) );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        int n = 3;
        (int, int)[] edges = [
            ( 0, 1 )
        ];
        double[] probs = [0.5];
        int src = 0;
        int dst = 2;
        
        // Act
        
        Assert.Equal( 0, PathMaximumProbability.Run( n, edges, probs, src, dst ) );
    }
}