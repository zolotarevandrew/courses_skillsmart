using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Heap
    {
        public int[] HeapArray;
        private int _count;

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public Heap()
        {
            HeapArray = null;
            _count = 0;
        }
		
        public void MakeHeap(int[] a, int depth)
        {
            int heapSize = GetHeapSize(depth);
            HeapArray = new int[heapSize];
            
            foreach (var t in a)
            {
                var res = Add(t);
                if (!res) throw new InvalidOperationException("can't add item, change heap depth");
            }
        }
		
        public int GetMax()
        {
            if (_count == 0) return -1;

            var max = HeapArray[0];
            HeapArray[0] = HeapArray[_count - 1];
            HeapArray[_count - 1] = default;
            
            LiftDown(0);
            _count--;
            return max;
        }

        public bool Add(int key)
        {
            if (_count == HeapArray.Length) return false;

            int index = _count;
            HeapArray[index] = key;
            LiftUp(index);

            _count++;
            return true;
        }

        void LiftDown(int index)
        {
            int left = LeftChild(index);
            int right = RightChild(index);

            int largestIdx = index;
            if (IsInRange(left) && HeapArray[left] > HeapArray[largestIdx])
            {
                largestIdx = left;
            }
            if (IsInRange(right) && HeapArray[right] > HeapArray[largestIdx])
            {
                largestIdx = right;
            }

            if (largestIdx == index) return;

            Swap(index, largestIdx);
            LiftDown(largestIdx);
        }
        
        void LiftUp(int index)
        {
            int parentIdx = Parent(index);
            if (parentIdx == index || !IsInRange(parentIdx)) return;
            
            var parent = HeapArray[parentIdx];
            if (parent == default) return;

            var item = HeapArray[index];
            if (parent > item) return;
            
            Swap(index, parentIdx);
            LiftUp(parentIdx);
        }
        
        static int GetHeapSize(int depth)
        {
            return (int) (Math.Pow(2, depth + 1) - 1);
        }

        int LeftChild(int idx)
        {
            return 2 * idx + 1;
        }
        
        int Parent(int idx)
        {
            return (idx - 1) / 2;
        }

        bool IsInRange(int idx)
        {
            if (idx < 0) return false;
            return idx < HeapArray.Length;
        }

        void Swap(int fromIdx, int toIdx)
        {
            int swap = HeapArray[fromIdx];
            HeapArray[fromIdx] = HeapArray[toIdx];
            HeapArray[toIdx] = swap;
        }
        
        int RightChild(int idx)
        {
            return 2 * idx + 2;
        }
    }
}