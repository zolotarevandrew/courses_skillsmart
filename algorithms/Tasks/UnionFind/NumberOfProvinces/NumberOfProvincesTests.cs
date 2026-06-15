namespace Tasks.UnionFind.NumberOfProvinces;

public class NumberOfProvincesTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        int[,] adj =
        {
            { 1, 1, 0 },
            { 1, 1, 0 },
            { 0, 0, 1 }
        };

        // Act
        var res = NumberOfProvinces.Run( adj );

        // Assert
        Assert.Equal( 2, res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        int[,] adj =
        {
            { 1, 0, 0 },
            { 0, 1, 0 },
            { 0, 0, 1 }
        };

        // Act
        var res = NumberOfProvinces.Run( adj );

        // Assert
        Assert.Equal( 3, res );
    }
}