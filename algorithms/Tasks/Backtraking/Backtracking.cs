namespace Tasks.Backtraking;

public class Backtracking
{
    public static List<string> GenerateBinaryString( int n )
    {
        List<string> generated = [];
        GenerateBinaryStringInternal( [], n, generated );
        return generated;
    }

    private static void GenerateBinaryStringInternal( 
        List<char> current, 
        int maxLength, 
        List<string> generated )
    {
        // check if valid solution
        if ( current.Count == maxLength )
        {
            // process solution
            generated.Add( string.Join( "", current ) );
            return;
        }
        
        current.Add( '0' );
        GenerateBinaryStringInternal( current, maxLength, generated );
        current.RemoveAt( current.Count - 1 );

        current.Add( '1' );
        GenerateBinaryStringInternal( current, maxLength, generated );
        current.RemoveAt( current.Count - 1 );
    }
}