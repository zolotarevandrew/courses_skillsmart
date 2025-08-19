namespace Tasks.Strings.GroupAnagrams;

public class GroupAnagramTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange 
        var input = new List<string>
        {
            "star",
            "rats",
            "car",
            "arc",
            "arts"
        };

        // Act
        var res = GroupAnagram.Run( input );

        // Assert
        Assert.Equal( 2, res.Count );
        Assert.Equal(3, res[0].Count);
        Assert.Equal("star", res[0][0]);
        Assert.Equal("rats", res[0][1]);
        Assert.Equal("arts", res[0][2]);
        
        Assert.Equal(2, res[1].Count);
        Assert.Equal("car", res[1][0]);
        Assert.Equal("arc", res[1][1]);
    }
}