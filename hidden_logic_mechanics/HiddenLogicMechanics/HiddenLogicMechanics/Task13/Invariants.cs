using System.Numerics;
using Xunit;

namespace HiddenLogicMechanics.Task13;

public class Invariants
{
    public static T Max<T>( T a, T b ) where T : INumber<T>
    {
        return a > b ? a : b;
    }

    public static T Abs<T>( T num ) where T : INumber<T>
    {
        return num < T.Zero ? -num : num;
    }

    public static T MaxMod<T>( T a, T b ) where T : INumber<T>
    {
        /*
         * Предусловие - здесь ничего не проверим.
         * Либо, если нам на вход сразу подаются modA, modB - то надо проверить, что оба числа >= 0.
         */
        
        // Команды
        T modA = Abs( a );
        T modB = Abs( b );
        T result = Max( modA, modB );

        /*
         * Постусловие
         * - результат тоже больше или равен нулю, поскольку оба числа будут по модулю.
         * - результат должен быть больше или равен чем modA И чем modB
         */
        Assert.True( result >= T.Zero );
        Assert.True( result >= modA && result >= modB );

        return result;
    }

    public static void Run( )
    {
        Console.WriteLine( MaxMod( 1, 1 ) );
        Console.WriteLine( MaxMod( 2, 1 ) );
        Console.WriteLine( MaxMod( 1, 100 ) );
        
        Console.WriteLine( MaxMod( -1, 1 ) );
        Console.WriteLine( MaxMod( 0, 1 ) );
        Console.WriteLine( MaxMod( 0, 0 ) );
        Console.WriteLine( MaxMod( -1, -1 ) );
        
        Console.WriteLine( MaxMod( 2, -1 ) );
        Console.WriteLine( MaxMod( -2, 1 ) );
        
        Console.WriteLine( MaxMod( 1, -100 ) );
        
        Console.WriteLine( MaxMod( -1, -100 ) );
        
    }
}