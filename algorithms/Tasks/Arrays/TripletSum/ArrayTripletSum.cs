namespace Tasks.Arrays.TripletSum;

public static class ArrayTripletSum
{
    /*
     * Given an integer array of nums, return all unique triplets in it
     * num[i] + num[j] + num[k] = 0 and i != j != k
     * The result should not contain duplicates
     * 0  1  2 3 4 5
        -3 -2 0 1 2 3


        0 = -3
        1 = -2

        0,1,2 = -3 -2 0
        0,1,3 = -3 -2 1
        0,1,4 = -3 -2 2
        0,1,5 = -3 -2 3

        0,2,3 = -3 0 1
        0,2,4 = -3 0 2
        0,2,5 = -3 0 4

        0,3,4 = -3 1 2
        0,3,5 = -3 1 3

        0,4,5 = -3 2 3

        1,2,3 = -2 0 1
        1,2,4 = -2 0 2
        1,2,5 = -2 0 3

        1,3,4 = -2 1 2
        1,3,5 = -2 1 3

        2,3,4 = 0 1 2
        2,3,5 = 0 1 3

        3,4,5 = 1 2 3
     */
    public static List<(int Item1, int Item2, int Item3)> Run( int[] array )
    {
        if ( array.Length < 3 ) return [];
        
        Array.Sort( array );

        List<(int Item1, int Item2, int Item3)> set = new ( );
        
        for ( int idx = 0; idx < array.Length - 2; idx++ )
        {
            // Пропускаем одинаковые "i", чтобы не было дубликатов
            if (idx > 0 && array[idx] == array[idx - 1])
                continue;
            
            int current = array[idx];
            int left = idx + 1, right = array.Length - 1;
            while ( left < right )
            {
                int sum = array[left] + array[right] + current;
                if ( sum == 0 )
                {
                    set.Add( ( current, array[left], array[right] ) );
                    left++;
                    right--;
                    
                    while (left < right && array[left] == array[left - 1]) left++;
                    while (left < right && array[right] == array[right + 1]) right--;
                }
                if (sum < 0)
                {
                    left++;
                    continue;
                }
                if (sum > 0)
                {
                    right--;
                    continue;
                }
            }
            
        } 
        
        return set;
    }
    
    public static List<(int Item1, int Item2, int Item3)> RunBruteforce( int[] array )
    {
        if ( array.Length < 3 ) return [];
        
        Array.Sort( array );

        HashSet<(int Item1, int Item2, int Item3)> res = new ( );
        for ( int i = 0; i < array.Length - 2; i++ )
        {
            for ( int j = i + 1; j < array.Length - 1; j++ )
            {
                for ( int k = j + 1; k < array.Length; k++ )
                {
                    if ( array[i] + array[j] + array[k] == 0 )
                        res.Add( ( array[i], array[j], array[k] ) );
                }
            }
        }
        
        return res.ToList(  );
    }
}