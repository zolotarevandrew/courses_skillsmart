namespace Tasks.Stacks.Parenthesis;

public class StackParenthesisTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        string s = "()";
        
        // Assert
        Assert.True( StackParenthesis.Run( s ) );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeFalse( )
    {
        // Arrange
        string s = "(()";
        
        // Assert
        Assert.False( StackParenthesis.Run( s ) );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeTrue( )
    {
        // Arrange
        string s = "()(())";
        
        // Assert
        Assert.True( StackParenthesis.Run( s ) );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeTrue( )
    {
        // Arrange
        string s = "(){}[]";
        
        // Assert
        Assert.True( StackParenthesis.Run( s ) );
    }
    
    [Fact]
    public void Run_Case5_ShouldBeTrue( )
    {
        // Arrange
        string s = "(){[]";
        
        // Assert
        Assert.False( StackParenthesis.Run( s ) );
    }
    
    [Fact]
    public void Run_Case6_ShouldBeFalse( )
    {
        // Arrange
        string s = "()({})[[]]";
        
        // Assert
        Assert.True( StackParenthesis.Run( s ) );
    }
    
    [Fact]
    public void Run_Case7_ShouldBeFalse( )
    {
        // Arrange
        string s = "()({[]}[[]]";
        
        // Assert
        Assert.False( StackParenthesis.Run( s ) );
    }
}