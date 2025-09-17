namespace Tasks.Matrices.DiagonalSorting;

public class DiagonalSortingTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange 
        var matrix = new int[,]
        {
            { 3, 3, 1, 1 },
            { 2, 2, 1, 2 },
            { 1, 1, 1, 2 }
        };
        
        var expected = new int[,]
        {
            { 1, 1, 1, 1 },
            { 1, 2, 2, 2 },
            { 1, 2, 3, 3 }
        };
        
        // Act
        DiagonalSorting.Run( matrix );
        
        // Assert
        Assert.Equal( expected, matrix );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange 
        var matrix = new int[,]
        {
            { 1 },
            { 2 }
        };
        
        var expected = new int[,]
        {
            { 1 },
            { 2 }
        };
        
        // Act
        DiagonalSorting.Run( matrix );
        
        // Assert
        Assert.Equal( expected, matrix );
    }
    
    [Fact]
    public void Run_Case3_ShouldBeOk( )
    {
        // Arrange 
        var matrix = new int[,]
        {
            { 2, 1 },
        };
        
        var expected = new int[,]
        {
            { 2, 1 },
        };
        
        // Act
        DiagonalSorting.Run( matrix );
        
        // Assert
        Assert.Equal( expected, matrix );
    }
    
    [Fact]
    public void Run_Case4_ShouldBeOk( )
    {
        // Arrange 
        var matrix = new int[,]
        {
            { 2, 1 },
            { 3, 1 },
        };
        
        var expected = new int[,]
        {
            { 1, 1 },
            { 3, 2 },
        };
        
        // Act
        DiagonalSorting.Run( matrix );
        
        // Assert
        Assert.Equal( expected, matrix );
    }
    
    [Fact]
    public void Run_Case5_ShouldBeOk( )
    {
        // Arrange 
        var matrix = new int[,]
        {
            { 2, 4, 3 },
            { 3, 1, 1 },
            { 2, 2, 2 },
        };
        
        var expected = new int[,]
        {
            { 1, 1, 3 },
            { 2, 2, 4 },
            { 2, 3, 2 },
        };
        
        // Act
        DiagonalSorting.Run( matrix );
        
        // Assert
        Assert.Equal( expected, matrix );
    }
    
    [Fact]
    public void Run_Case6_ShouldBeOk( )
    {
        // Arrange 
        var matrix = new int[,]
        {
            { 2, 4, 3 },
            { 3, 1, 1 },
            { 2, 2, 2 },
            { 1, 1, 1 },
        };
        
        var expected = new int[,]
        {
            { 1, 1, 3 },
            { 1, 2, 4 },
            { 1, 2, 2 },
            { 1, 2, 3 },
        };
        
        // Act
        DiagonalSorting.Run( matrix );
        
        // Assert
        Assert.Equal( expected, matrix );
    }
    
    [Fact]
    public void RunV2_Case1_ShouldBeOk( )
    {
        // Arrange 
        var matrix = new int[,]
        {
            { 3, 3, 1, 1 },
            { 2, 2, 1, 2 },
            { 1, 1, 1, 2 }
        };
        
        var expected = new int[,]
        {
            { 1, 1, 1, 1 },
            { 1, 2, 2, 2 },
            { 1, 2, 3, 3 }
        };
        
        // Act
        DiagonalSorting.RunV2( matrix );
        
        // Assert
        Assert.Equal( expected, matrix );
    }
}