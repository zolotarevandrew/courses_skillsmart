using HiddenLogicMechanics.Task4;
using Xunit;

namespace HiddenLogicMechanics.Task5;

public class GradeCalculator
{
    public double CalculateAverage( List<int> grades )
    {
        if ( grades == null || grades.Count == 0 )
        {
            throw new InvalidOperationException( "No elements" );
        }
        
        double sum = 0;

        for ( int i = 0; i < grades.Count; i++ )
        {
            int grade = grades[i];
            if ( grade is < 1 or > 5 )
            {
                throw new InvalidOperationException( "Grades contains negative numbers" );
            }
            sum += grade;
        }

        return sum / (grades.Count * 1.0);
    }
}


public class GradeCalculatorTests
{
    [Fact]
    public void CalculateAverage_NoElements_ShouldThrow( )
    {
        // Arrange 
        
        // Act
        GradeCalculator calculator = new GradeCalculator();
        Assert.Throws<InvalidOperationException>( ( ) => calculator.CalculateAverage( [] ) );
    }
    
    [Fact]
    public void CalculateAverage_ContainsGradeBelowOne_ShouldThrow( )
    {
        // Arrange 
        
        // Act
        GradeCalculator calculator = new GradeCalculator();
        Assert.Throws<InvalidOperationException>( ( ) => calculator.CalculateAverage( [0] ) );
    }
    
    [Fact]
    public void CalculateAverage_ContainsGradeGreaterThanFive_ShouldThrow( )
    {
        // Arrange 
        
        // Act
        GradeCalculator calculator = new GradeCalculator();
        Assert.Throws<InvalidOperationException>( ( ) => calculator.CalculateAverage( [6] ) );
    }
    
    [Fact]
    public void CalculateAverage_OneElement_ShouldBeExactElement( )
    {
        // Arrange 
        
        // Act
        GradeCalculator calculator = new GradeCalculator();
        var res = calculator.CalculateAverage( [1] );
        
        // Assert
        Assert.Equal( 1, res );
    }
    
    [Fact]
    public void CalculateAverage_TwoElements_ShouldBeOk( )
    {
        // Arrange 
        
        // Act
        GradeCalculator calculator = new GradeCalculator();
        var res = calculator.CalculateAverage( [1, 5] );
        
        // Assert
        Assert.Equal( 3, res );
    }
    
    [Fact]
    public void CalculateAverage_ThreeElements_ShouldBeOk( )
    {
        // Arrange 
        
        // Act
        GradeCalculator calculator = new GradeCalculator();
        var res = calculator.CalculateAverage( [1, 2, 3] );
        
        // Assert
        Assert.Equal( 2, res );
    }
    
    [Fact]
    public void CalculateAverage_FourElements_ShouldBeOk( )
    {
        // Arrange 
        
        // Act
        GradeCalculator calculator = new GradeCalculator();
        var res = calculator.CalculateAverage( [1, 2, 3, 4] );
        
        // Assert
        Assert.Equal( 2.5, res );
    }
}

