namespace Tasks.GraphAlgorithms.Tasks.CourseSchedule;

public class CourseScheduleTests
{
    [Fact]
    public void Run_Case1_ShouldBeOk( )
    {
        // Arrange
        int n = 3;
        (int, int)[] pre = [
            ( 2, 1 ),
            ( 1, 0 )
        ];
        
        // Act

        Assert.True( CourseSchedule.Run( n, pre ) );
    }
    
    [Fact]
    public void Run_Case2_ShouldBeOk( )
    {
        // Arrange
        int n = 3;
        (int, int)[] pre = [
            ( 1, 0 ),
            ( 0, 2 ),
            ( 2, 1 )
        ];
        
        // Act

        Assert.False( CourseSchedule.Run( n, pre ) );
    }
}