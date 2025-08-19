namespace Tasks.Strings;

public class ValidPalindromeTests
{
    [Fact]
    public void RunTwoPointer_Case1_ShouldBeOk( )
    {
        // Arrange 
        
        // Act
        
        // Assert
        Assert.True( ValidPalindrome.RunTwoPointer( "borrow or rob" ) );
    }
    
    [Fact]
    public void RunReverse_Case1_ShouldBeOk( )
    {
        // Arrange 
        
        // Act
        
        // Assert
        Assert.True( ValidPalindrome.RunReverse( "borrow or rob" ) );
    }
}