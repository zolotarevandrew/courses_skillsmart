namespace Tasks.Search.Search2DMatrix;

public class Search2DMatrixTests
{
    [Fact]
    public void RunBinarySearch_Case1_ShouldBeOk( )
    {
        // Arrange
        int[][] matrix = new int[][]
        {
            [1, 2, 3], [4, 5, 6], [7, 8, 9]
        };

        // Act
        var result = Search2DMatrix.RunBinarySearch( matrix, 5 );

        // Assert
        Assert.Equal( result, true );
    }
    
    [Fact]
    public void GetByFlatIndex_Case1_ShouldBeOk( )
    {
        // Arrange
        int[][] matrix = new int[][]
        {
            [1, 2, 3, 4], 
            [5, 6, 7, 8]
        };
        // Act
        for ( int idx = 0; idx < 8; idx++ )
        {
            int result = Search2DMatrix.GetByFlatIndex( matrix, idx );
            Assert.Equal( result, idx + 1 );
        }
    }
}