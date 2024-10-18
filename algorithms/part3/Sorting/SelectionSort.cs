namespace Sorting;

public static class SelectionSort
{
    public static void Sort(int[] array)
    {
        for (int outerLoopIdx = 0; outerLoopIdx < array.Length; outerLoopIdx++)
        {
            int minElementIdx = outerLoopIdx;
            
            for (int innerLoopIdx = outerLoopIdx + 1; innerLoopIdx < array.Length; innerLoopIdx++)
            {
                if (array[innerLoopIdx] < array[minElementIdx])
                {
                    minElementIdx = innerLoopIdx;
                }
            }

            if (minElementIdx != outerLoopIdx)
            {
                (array[outerLoopIdx], array[minElementIdx]) = (array[minElementIdx], array[outerLoopIdx]);
            }
        }
    }
}