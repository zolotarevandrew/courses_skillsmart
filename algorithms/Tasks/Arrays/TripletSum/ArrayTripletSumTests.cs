namespace Tasks.Arrays.TripletSum;

public class ArrayTripletSumTests
{
    [Fact]
    public void RunBruteforce_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { -3, -2, 0, 1, 2, 3 };
        
        // Act
        var res = ArrayTripletSum.RunBruteforce( array );
        
        // Assert
        Assert.Equal( 3, res.Count );
        
        var item = res[0];
        Assert.Equal( ( -3, 0, 3 ), item );

        item = res[1];
        Assert.Equal( ( -3, 1, 2 ), item );
        
        item = res[2];
        Assert.Equal( ( -2, 0, 2 ), item );
    }
    
    [Fact]
    public void RunBruteforce_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 0, 0, 0, 0 };
        
        // Act
        var res = ArrayTripletSum.RunBruteforce( array );
        
        // Assert
        Assert.Equal( 1, res.Count );
        
        var item = res[0];
        Assert.Equal( ( 0, 0, 0 ), item );
    }
    
    [Fact]
    public void RunBruteforce_Case3_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 2, -2, -1 };
        
        // Act
        var res = ArrayTripletSum.RunBruteforce( array );
        
        // Assert
        Assert.Equal( 0, res.Count );
    }
    
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { -3, -2, 0, 1, 2, 3 };
        
        // Act
        var res = ArrayTripletSum.Run( array );
        
        // Assert
        Assert.Equal( 3, res.Count );
        
        var item = res[0];
        Assert.Equal( ( -3, 0, 3 ), item );

        item = res[1];
        Assert.Equal( ( -3, 1, 2 ), item );
        
        item = res[2];
        Assert.Equal( ( -2, 0, 2 ), item );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 0, 0, 0, 0 };
        
        // Act
        var res = ArrayTripletSum.Run( array );
        
        // Assert
        Assert.Equal( 1, res.Count );
        
        var item = res[0];
        Assert.Equal( ( 0, 0, 0 ), item );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange
        var array = new int[] { 1, 2, -2, -1 };
        
        // Act
        var res = ArrayTripletSum.Run( array );
        
        // Assert
        Assert.Equal( 0, res.Count );
    }
}