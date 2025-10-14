namespace Tasks.Stacks.Polish;

public class PolishNotation
{
    /*
     * Reverse polish notation, evaluate expression and return result as integer
     */
    public static int Run( string input )
    {
        string[] fixedInput = input
            .Split( " ", StringSplitOptions.RemoveEmptyEntries );
        Stack<int> stack = new Stack<int>();
        foreach ( string c in fixedInput )
        {
            if ( int.TryParse(c, out int num) )
            {
                stack.Push( num );
                continue;
            }

            int right = stack.Pop();
            int left  = stack.Pop();

            int res = c switch
            {
                "*" => left * right,
                "/" => left / right,   
                "+" => left + right,
                "-" => left - right,
                _   => throw new InvalidOperationException($"Unknown operator: '{c}'.")
            };

            stack.Push(res);
        }

        if ( stack.Count != 1 )
        {
            throw new Exception( "Invalid input" );
        }

        return stack.Pop( );
    }
}