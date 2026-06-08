namespace Tasks.GraphAlgorithms.Tasks.CourseSchedule;

public class CourseSchedule
{
    // You are given numCourses, the total number of courses labeled from o to numCourses - 1
    // and a list prerequisites.
    // Each element in prerequisite is a pair (a,b), indicating that course b must be completed before course a.
    // Determine whether it is possible to finish all courses by taking them in the correct order.
    // If it is possible, find a course order that would allow you to finish all courses
    public static bool Run( int numCourses, (int a, int b)[] pairs )
    {
        Dictionary<int, int> indegrees = [];
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        for ( int i = 0; i < numCourses; i++ )
        {
            indegrees[i] = 0;
            graph[i] = [];
        }

        foreach ( (int a, int b) item in pairs )
        {
            indegrees[item.a]++;
            graph[item.b].Add( item.a );
        }

        Queue<int> queue = new Queue<int>();
        for ( int i = 0; i < numCourses; i++ )
        {
            if ( indegrees[i] == 0 )
            {
                queue.Enqueue( i );
            }
        }

        var result = new List<int>();
        while ( queue.TryDequeue( out var curV ) )
        {
            result.Add( curV );
            foreach ( var neighbour in graph[curV] )
            {
                indegrees[neighbour]--;
                if ( indegrees[neighbour] == 0 )
                {
                    queue.Enqueue( neighbour );
                }
            }
        }

        return result.Count == numCourses;
    }
    
}