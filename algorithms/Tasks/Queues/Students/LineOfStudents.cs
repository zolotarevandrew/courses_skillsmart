namespace Tasks.Queues.Students;

public static class LineOfStudents
{
    /*
     * A line of students is waiting for lunch.
     * Each student prefers either a circular (0) or square (1) sandwich.
     * Sandwiches are stacked in order, and students take turn:
     *  If the student at the front likes the top sandwich, they take it and leave.
     *  If not, they go back of the line. This continues until no student wants the top sandwich.
     *  Given two lists:
     *  1) students - student's preferences (0,1)
     *  2) sandwiches - sandwich types from top to bottom.
     *  Return the number of students who can't eat.
     */
    public static int Run( int[] students, int[] sandwiches )
    {
        Queue<int> studentQueue = new Queue<int>( students );
        Queue<int> sandwichesQueue = new Queue<int>( sandwiches );

        int iterations = 0;
        while ( studentQueue.Count > 0 && sandwichesQueue.Count > 0 )
        {
            if ( iterations == studentQueue.Count ) break;
            
            int curStudent = studentQueue.Dequeue( );
            int curSandwich = sandwichesQueue.Peek( );

            if ( curSandwich == curStudent )
            {
                sandwichesQueue.Dequeue( );
                iterations = 0;
                continue;
            }
            
            studentQueue.Enqueue( curStudent );
            iterations++;
        }
        return studentQueue.Count;
    }
}