namespace Tasks.Hashtables;

public class ContainsDuplicatesTest
{
    [Fact]
    public void HasDuplicate_ShouldReturnTrue( )
    {
        // Arrange 
        var arr = new int[]
        {
            2,7,8,2
        };

        // Act
        bool exists = ContainsDuplicates.Run( arr );

        // Assert
        Assert.True( exists );
    }
    
    [Fact]
    public void HasMultipleDuplicate_ShouldReturnTrue( )
    {
        // Arrange 
        var arr = new int[]
        {
            1,1,1,2,2,3
        };

        // Act
        bool exists = ContainsDuplicates.Run( arr );

        // Assert
        Assert.True( exists );
    }
    
    [Fact]
    public void UniqueElements_ShouldReturnFalse( )
    {
        // Arrange 
        var arr = new int[]
        {
            10,20,30,40
        };

        // Act
        bool exists = ContainsDuplicates.Run( arr );

        // Assert
        Assert.False( exists );
    }
}