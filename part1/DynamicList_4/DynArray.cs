using System;

namespace AlgorithmsDataStructures
{

    public static class DynArray
    {
        public const int MinArraySize = 16;
        public static int IncreasedCapacity(int capacity = MinArraySize) => Math.Max(MinArraySize, capacity * 2);
        public static int DecreasedCapacity(int capacity = MinArraySize) => Math.Max(MinArraySize, (int)(capacity / 1.5));
    }
    public class DynArray<T>
    {
        public T [] array;
        public int count;
        public int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }

        public void MakeArray(int new_capacity)
        {
            if (new_capacity == capacity) return;
            
            if (new_capacity <= 0)
                throw new InvalidOperationException("new capacity should be positive number");

            var newArray = new T[new_capacity];
            if (count > 0)
            {
                Array.Copy(array, newArray, count);
            }
            array = newArray;

            capacity = new_capacity;
        }

        public T GetItem(int index)
        {
            if (!IndexExists(index))
            {
                throw new IndexOutOfRangeException();
            }
            return array[index];
        }

        public void Append(T itm)
        {
            if (IsFullToAdd())
            {
                MakeArray(DynArray.IncreasedCapacity(capacity));
            }
            array[count] = itm;
            count++;
        }

        public void Insert(T itm, int index)
        {
            if (index > count || index < 0)
                throw new IndexOutOfRangeException();

            if (IsFullToAdd())
            {
                MakeArray(DynArray.IncreasedCapacity(capacity));
            }

            if (count > 0)
            {
                int startToShiftIndex = index;
                int endToShiftIndex = index + 1;
                int shiftLength = count - index;
                Array.Copy(array, startToShiftIndex, array, endToShiftIndex, shiftLength);    
            }

            array[index] = itm;

            count++;
        }

        public void Remove(int index)
        {
            if (!IndexExists(index))  throw new IndexOutOfRangeException();
            
            count--;
            
            if (count > 0)
            {
                int startToShiftIndex = index + 1;
                int endToShiftIndex = index;
                int shiftLength = count - index;
                Array.Copy(array, startToShiftIndex, array, endToShiftIndex, shiftLength);
            }

            array[count] = default(T)!;

            var percent = FillPercent;
            if (percent < 50)
            {
                MakeArray(DynArray.DecreasedCapacity(capacity));    
            }
        }

        float FillPercent
        {
            get
            {
                if (count == 0) return 0;
                return ((float)count / capacity) * 100;
            }
        }

        bool IndexExists(int index)
        {
            if (index < 0) return false;
            return index < count;
        }

        bool IsFullToAdd()
        {
            return count == array.Length;
        }
    }
}