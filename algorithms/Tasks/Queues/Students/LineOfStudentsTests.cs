namespace Tasks.Queues.Students;

public class LineOfStudentsTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange 
        var students = new int[] { 1, 1, 0, 0 };
        var sandwiches = new int[] { 0, 1, 0, 1 };
        
        // Act
        var res = LineOfStudents.Run( students, sandwiches );

        // Assert
        Assert.Equal( 0, res );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange 
        var students = new int[] { 1, 1, 1, 0, 0, 1 };
        var sandwiches = new int[] { 1, 0, 0, 0, 1, 1 };
        
        // Act
        var res = LineOfStudents.Run( students, sandwiches );

        // Assert
        Assert.Equal( 3, res );
    }
}