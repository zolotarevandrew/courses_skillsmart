namespace Tasks.Hashtables.Pairsum;

public static class PairSum
{
    /*
     * Given an array of integer nums and a target integer
     * Return the two indices of the two numbers that add up to the target.
     * Each input has exactly one solution and you can not use the same element twice.
     *
     */
    public static (int Index1, int Index2) Run(int[] array, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < array.Length; i++)
        {
            int diff = target - array[i];
            if (map.TryGetValue(diff, out int index))
            {
                return (index, i);
            }

            if (!map.ContainsKey(array[i])) 
                map[array[i]] = i;
        }

        throw new InvalidOperationException("No valid pair found.");
    }
}