namespace Sorting;

public static class BubbleSort
{
    public static void Sort(int[] array)
    {
        for (int outerLoopIdx = 0; outerLoopIdx < array.Length; outerLoopIdx++)
        {
            bool hasSwaps = false;
            
            for (int innerLoopIdx = 0; innerLoopIdx < array.Length - outerLoopIdx - 1; innerLoopIdx++)
            {
                if (array[innerLoopIdx] > array[innerLoopIdx + 1])
                {
                    (array[innerLoopIdx], array[innerLoopIdx + 1]) = (array[innerLoopIdx + 1], array[innerLoopIdx]);
                    hasSwaps = true;
                }
            }

            if (!hasSwaps) break;
        }
    }
}