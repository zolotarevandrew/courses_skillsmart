using Xunit;

namespace HiddenLogicMechanics.Task4;

public class AverageCalculator
{
    public double CalculateAverage( int[] numbers )
    {
        if ( numbers.Length == 0 )
        {
            throw new InvalidOperationException( "No elements" );
        }
        
        long sum = 0;

        for ( int i = 0; i < numbers.Length; i++ )
        {
            sum += numbers[i];
        }

        return sum / (numbers.Length * 1.0);
    }
}

public class AverageCalculatorTests
{
    [Fact]
    public void CalculateAverage_NoElements_ShouldThrow( )
    {
        // Arrange 
        
        // Act
        AverageCalculator calculator = new AverageCalculator();
        Assert.Throws<InvalidOperationException>( ( ) => calculator.CalculateAverage( [] ) );
    }
    
    [Fact]
    public void CalculateAverage_OneElement_ShouldBeExactElement( )
    {
        // Arrange 
        
        // Act
        AverageCalculator calculator = new AverageCalculator();
        var res = calculator.CalculateAverage( [1] );
        
        // Assert
        Assert.Equal( 1, res );
    }
    
    [Fact]
    public void CalculateAverage_TwoElements_ShouldBeOk( )
    {
        // Arrange 
        
        // Act
        AverageCalculator calculator = new AverageCalculator();
        var res = calculator.CalculateAverage( [1, 5] );
        
        // Assert
        Assert.Equal( 3, res );
    }
    
    [Fact]
    public void CalculateAverage_ThreeElements_ShouldBeOk( )
    {
        // Arrange 
        
        // Act
        AverageCalculator calculator = new AverageCalculator();
        var res = calculator.CalculateAverage( [1, 2, 3] );
        
        // Assert
        Assert.Equal( 2, res );
    }
    
    [Fact]
    public void CalculateAverage_FourElements_ShouldBeOk( )
    {
        // Arrange 
        
        // Act
        AverageCalculator calculator = new AverageCalculator();
        var res = calculator.CalculateAverage( [1, 2, 3, 4] );
        
        // Assert
        Assert.Equal( 2.5, res );
    }
}

