namespace Tasks.Hashtables.LongestConsecutiveSequence;

public class LongestConsecutiveSequenceTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange 
        var color = new int[] { -2, 1, -3, 4, -1, 2, 1, 4, 3, 8, 5 };
        
        // Act
        var result = LongestConsecutiveSequence.Run(color);
        
        // Assert
        Assert.Equal( 5, result );
    }
    
    [Fact]
    public void Run2_Case1_ShouldBeOk( )
    {
        // Arrange 
        var color = new int[] { -2, 1, -3, 4, -1, 2, 1, 4, 3, 8, 5 };
        
        // Act
        var result = LongestConsecutiveSequence.Run2(color);
        
        // Assert
        Assert.Equal( 5, result );
    }
}