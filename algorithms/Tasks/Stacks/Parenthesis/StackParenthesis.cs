namespace Tasks.Stacks.Parenthesis;

public class StackParenthesis
{
    private static Dictionary<char, char> OpenByClosed = new Dictionary<char, char>
    {
        { ')', '(' },
        { '}', '{' },
        { ']', '[' },
    };
    
    /*
     * Given a string containing just characters (, ), {, }, [, ]
     * Detetmine if the input string is valid.
     * Open brackets are closed by the same type of brackets
     * Open brackets are closed in the correct order.
     * Every closing bracket has corresponding opening bracket
     */
    public static bool Run( string s )
    {
        Stack<char> stack = new Stack<char>();
        foreach ( char ch in s )
        {
            if ( ch is '(' or '[' or '{' )
            {
                stack.Push( ch );
                continue;
            }

            if ( !OpenByClosed.TryGetValue( ch, out char open ) )
            {
                return false;
            }
            
            if ( !stack.TryPop( out char cur ) )
            {
                return false;
            }
            
            if ( cur != open ) return false;
        }
        
        return stack.Count == 0;
    }
}