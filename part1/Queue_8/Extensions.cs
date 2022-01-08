using System;

namespace AlgorithmsDataStructures
{
    public static class Extensions
    {
        public static void Rotate<T>(this Queue<T> queue, int count)
        {
            var size = queue.Size();
            if (count > size || count <= 0)
                throw new InvalidOperationException("invalid count. should be greater than zero and less than queue count");
            
            if (size == 0 || size == 1) return;

            var copyQueue = new Queue<T>();
            var shiftCount = size - count;
            for (int i = 0; i < shiftCount; i++)
            {
                var element = queue.Dequeue();
                copyQueue.Enqueue(element);
            }

            while(copyQueue.Size() > 0)
            {
                queue.Enqueue(copyQueue.Dequeue());
            }
        }
    }
}