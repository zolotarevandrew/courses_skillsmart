namespace Tasks.Search;

public class BinarySearch
{
    public static int Search(int[] arr, int search)
    {
        int low = 0;
        int high = arr.Length - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            int item = arr[mid];
            if (item == search) return mid;
            if (item > search)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return -1;
    }
}
