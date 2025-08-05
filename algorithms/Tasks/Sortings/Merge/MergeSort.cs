namespace Tasks.Sortings.Merge;

public static class MergeSort
{
    /*
      Divide the given array into two halves, Continues recursively until the each sub array contains only one element.
      If the array has multiple elements we find its middle index.
      The array then split into two halves.
      left - from start to mid;
      right - from mid + 1 to end;
      This splitting continues until each sub array contains only one element, at which point they are considered sorted.
      
      The merge phase works by comparing the elements from both sub arrays one by one.
      And placing the smallest element first. This continues until all elements from both sub arrays have been merged in sorted order.
      This step is repeated until the entire array is merged.
     */
    public static int[] Apply( int[] array )
    {
        if ( array.Length <= 1 ) return array;

        int mid = array.Length / 2;
        int[] left = Apply( array[..mid] );
        int[] right = Apply( array[mid..array.Length] );

        return Merge( left, right );
    }

    static int[] Merge( int[] left, int[] right )
    {
        List<int> res = new List<int>( left.Length + right.Length );
        
        int leftIdx = 0, rightIdx = 0;
        while ( leftIdx < left.Length && rightIdx < right.Length )
        {
            int leftVal = left[leftIdx];
            int rightVal = right[rightIdx];

            if ( leftVal <= rightVal )
            {
                res.Add( leftVal );
                leftIdx++;
                continue;
            }
            
            res.Add( rightVal );
            rightIdx++;
        }
        
        res.AddRange( left[leftIdx..] );
        res.AddRange( right[rightIdx..] );
        
        return res.ToArray(  );
    }
}