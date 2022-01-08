using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public static class BalancedBST
    {
        public struct BSTRange
        {
            private int _start;
            private int _end;
            private int _count;
            private int _middle;
            public BSTRange(int start, int end)
            {
                _start = start;
                _end = end;
                _count = (_end - _start) + 1;
                int middleByCount = _count / 2;
                _middle = _start + middleByCount;
            }

            bool IsInRange(int start, int end)
            {
                if (start > _end) return false;
                if (end < _start) return false;
                return true;
            }

            public int Middle => _middle;
            public int Count => _count;
            
            public BSTRange? Left
            {
                get
                {
                    var start = _start;
                    var end = _middle - 1;
                    if (!IsInRange(start, end)) return null;
                    return new BSTRange(start, end);
                }
            }
            
            public BSTRange? Right
            {
                get
                {
                    var start = _middle + 1;
                    var end = _end;
                    if (!IsInRange(start, end)) return null;
                    return new BSTRange(start, end);
                }
            }
        }

        public static int GetTreeSize(int depth)
        {
            return (int) (Math.Pow(2, depth + 1) - 1);
        }

        public static int[] GenerateBBSTArray(int[] a)
        {
            if (a.Length == 0) return Array.Empty<int>();

            Array.Sort(a);

            var res = new int[a.Length];
            Traverse(a, res ,new BSTRange(0, a.Length-1), 0);
            return res;
        }
        
        static void Traverse(int[] a, int[] res, BSTRange range, int toIndex)
        {
            res[toIndex] = a[range.Middle];
                
            if (range.Left != null) Traverse(a, res, range.Left.Value, toIndex * 2 + 1);
            if (range.Right != null) Traverse(a, res, range.Right.Value, toIndex * 2 + 2);
        }
    }
} 