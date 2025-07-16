namespace Tasks.Arrays.SortedPairSum;

public static class ArraySortedPairSum
{
    /*
     * 1 indexes array of integers, sorted in non decreasing order
     * find two numbers such that their sum is equal to target
     * let these two numbers be at indices index1 and index2
     * ( 1 <= index1 < index2 <= n )
     * return the indices as a tuple or list
     * each input has exactly one solution and you can not use the same element twice
     * use only constant extra space
     */

    public static (int Index1, int Index2) Run( int[] sortedArray, int target )
    {
        int left = 0, right = sortedArray.Length - 1;
        while ( left < right )
        {
            int leftItem = sortedArray[left];
            int rightItem = sortedArray[right];

            int sum = leftItem + rightItem;
            if ( sum == target )
            {
                return ( left + 1, right + 1 );
            }

            if ( sum > target )
            {
                right--;
            }

            if ( sum < target )
            {
                left++;
            }
        }
        return ( left + 1, right + 1 );
    } 
}