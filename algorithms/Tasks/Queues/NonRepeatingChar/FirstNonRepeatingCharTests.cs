namespace Tasks.Queues.NonRepeatingChar;

public class FirstNonRepeatingCharTests
{
    [Fact]
    public void RunBruteforce_Case1_ShouldBeOk( )
    {
        // Arrange
        var s = "hellothere";

        // Act
        var res = FirstNonRepeatingChar.RunBruteforce( s );

        // Assert
        Assert.NotNull( res );
        Assert.Equal( 'o', res );
    }
    
    [Fact]
    public void RunBruteforce_Case2_ShouldBeOk( )
    {
        // Arrange
        var s = "civicservant";

        // Act
        var res = FirstNonRepeatingChar.RunBruteforce( s );

        // Assert
        Assert.NotNull( res );
        Assert.Equal( 's', res );
    }
    
    [Fact]
    public void RunQueue_Case1_ShouldBeOk( )
    {
        // Arrange
        var s = "hellothere";

        // Act
        var res = FirstNonRepeatingChar.RunQueue( s );

        // Assert
        Assert.NotNull( res );
        Assert.Equal( 'o', res );
    }
    
    [Fact]
    public void RunQueue_Case2_ShouldBeOk( )
    {
        // Arrange
        var s = "civicservant";

        // Act
        var res = FirstNonRepeatingChar.RunQueue( s );

        // Assert
        Assert.NotNull( res );
        Assert.Equal( 's', res );
    }
}