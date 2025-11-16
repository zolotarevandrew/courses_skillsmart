using System.Numerics;
using Xunit;

namespace HiddenLogicMechanics.Task14;

public class CycleInvariants
{
    // {P: arr.length > 0} findMax(arr) {Q: result = Max(arr)}
    
    /*
     * I: 1 <= i < n и res = Max(arr[0]..arr[i-1])
     * 
     * 1. До начала первой итерации цикла: i = 1 и res = arr[0]
        Проверка инварианта: 1 <= 1 <= n и res = Max(arr[0]..arr[0])
        Инвариант истинен в начале.
       2. Допустим, перед некоторой итерацией i = k, 1 <= k < n и res = Max(arr[0].. arr[k-1])
          В теле цикла выполняем res = Max(res, arr[k]), i_next = k + 1
          Значит res = Max(Max(arr[0]..arr[k-1]), arr[k])
                 res = Max(arr[0]..arr[k])
          Таким образом, инвариант по-прежнему истинен на следующих итерациях цикла: 1 <= i_next < n и 
            res = Max(arr[0]..arr[i_next-1])
      3. Цикл завершается, когда i = n
        res = Max(arr[0]..arr[n-1]) - истинно, постусловие выполняется
     */
    public static T FindMax<T>( T[] arr ) where T : INumber<T>
    {
        if ( arr.Length == 0 ) return T.Zero;
        if ( arr.Length == 1 ) return arr[0];

        T res = arr[0];
        for ( int i = 1; i < arr.Length; i++ )
        {
            res = T.Max( res, arr[i] );
        }

        return res;
    }

    public static void Run( )
    {
        Console.WriteLine( FindMax( [1, 2, 3, 4, 5, 6, 7] ) );
        Console.WriteLine( FindMax( [1, 2, 3] ) );
        Console.WriteLine( FindMax( [1] ) );
        Console.WriteLine( FindMax( Array.Empty<int>( ) ) );
        Console.WriteLine( FindMax( [5, 4, 6, 1, 2, 7] ) );
    }
}