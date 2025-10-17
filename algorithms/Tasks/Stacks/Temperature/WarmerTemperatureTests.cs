namespace Tasks.Stacks.Temperature;

public class WarmerTemperatureTests
{
    [Fact]
    public void RunBruteforce_Case1_ShouldBeOk( )
    {
        // Arrange
        int[] temperatures = [73,74,75,71,69,72,76,73];
        int[] expected = [1, 1, 4, 2, 1, 1, 0, 0];
        
        // Act
        int[] res = WarmerTemperature.RunBruteforce( temperatures );
        
        // Assert
        Assert.Equal( expected, res );
    }
    
    [Fact]
    public void RunBruteforce_Case2_ShouldBeOk( )
    {
        // Arrange
        int[] temperatures = [30,40,50,60];
        int[] expected = [1, 1, 1, 0];
        
        // Act
        int[] res = WarmerTemperature.RunBruteforce( temperatures );
        
        // Assert
        Assert.Equal( expected, res );
    }
    
    [Fact]
    public void RunMonotonicStack_Case1_ShouldBeOk( )
    {
        // Arrange
        int[] temperatures = [73,74,75,71,69,72,76,73];
        int[] expected = [1, 1, 4, 2, 1, 1, 0, 0];
        
        // Act
        int[] res = WarmerTemperature.RunMonotonicStack( temperatures );
        
        // Assert
        Assert.Equal( expected, res );
    }
    
    [Fact]
    public void RunMonotonicStack_Case2_ShouldBeOk( )
    {
        // Arrange
        int[] temperatures = [30,40,50,60];
        int[] expected = [1, 1, 1, 0];
        
        // Act
        int[] res = WarmerTemperature.RunBruteforce( temperatures );
        
        // Assert
        Assert.Equal( expected, res );
    }
}