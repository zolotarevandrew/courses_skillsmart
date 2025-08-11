namespace Tasks.Hashtables;

public class ContainsDuplicates
{
    /*
     * Given an integer array of nums
     * determine if any value appears at least twice.
     * Return true if duplicate exists, and false if all elements are unique.
     */
    public static bool Run( int[] array )
    {
        HashSet<int> hashtable = [];
        return array.Any( t => !hashtable.Add( t ) );
    }
}