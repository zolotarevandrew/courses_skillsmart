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
        
        // 0 / 4 = 0 , 1 / 4 = 0 , 2 / 4 = 0, 3 / 4 = 0
        // 4 / 4 = 1, 5 / 4 = 1, 6 / 4 = 1, 7 / 4 = 1
            

        // Act
        for ( int idx = 0; idx < 8; idx++ )
        {
            int result = Search2DMatrix.GetByFlatIndex( matrix, idx );
            Assert.Equal( result, idx + 1 );
        }
    }
}