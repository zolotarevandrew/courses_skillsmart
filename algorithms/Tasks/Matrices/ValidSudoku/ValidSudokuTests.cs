

namespace Tasks.Matrices.ValidSudoku;

public class ValidSudokuTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        var matrix = new int[,]
        {
            { 5,3,0, 0,7,0, 0,0,0 },
            { 6,0,0, 1,9,5, 0,0,0 },
            { 0,9,8, 0,0,0, 0,6,0 },
            
            { 8,0,0, 0,6,0, 0,0,3 },
            { 4,0,0, 8,0,3, 0,0,1 },
            { 7,0,0, 0,2,0, 0,0,6 },
            
            { 0,6,0, 0,0,0, 2,8,0 },
            { 0,0,0, 4,1,9, 0,0,5 },
            { 0,0,0, 0,8,0, 0,7,9 },
        };
        
        // Act
        var res = ValidSudoku.Run( matrix );
        
        // Assert
        Assert.True( res );
    }
}