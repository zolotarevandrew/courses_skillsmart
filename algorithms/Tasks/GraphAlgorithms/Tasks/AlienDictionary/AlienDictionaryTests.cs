namespace Tasks.GraphAlgorithms.Tasks.AlienDictionary;

public class AlienDictionaryTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        int k = 3;
        string[] dict = [
            "hrn",
            "hrf",
            "er",
            "enn",
            "rfnn",
        ];
        
        // Act

        Assert.Equal( ['h', 'e', 'r', 'n', 'f'], AlienDictionary.Run( dict, k ) );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        int k = 3;
        string[] dict = [
            "hrne",
            "hrf",
            "er",
            "enn",
            "rfnn",
        ];
        
        // Act
        var res = AlienDictionary.Run( dict, k );
        Assert.Equal( ['h', 'e', 'r', 'n', 'f'], res );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeEmpty( )
    {
        // Arrange
        int k = 3;
        string[] dict = [
            "hrne",
            "hrn",
            "hrf",
            "er",
            "enn",
            "rfnn",
        ];
        
        // Act
        var res = AlienDictionary.Run( dict, k );
        Assert.Equal( [], res );
    }
}