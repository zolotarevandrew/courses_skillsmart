using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    // microsoft reference - https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/Collections/Generic/Queue.cs
    // microsoft reference - https://github.com/microsoft/referencesource/blob/master/mscorlib/system/array.cs
    // содержит два индекса head,tail сделано как circular buffer
    // enqueue записывает в tail
    public class Queue<T>
    {
        private List<T> _store;
        public Queue()
        {
            _store = new List<T>();
        }

        public void Enqueue(T item)
        {
            _store.Add(item);
        }

        public T Dequeue()
        {
            if (Size() == 0) return default(T);
            var index = 0;
            var item = _store[index];
            _store.RemoveAt(index);
            return item;
        }

        public int Size()
        {
            return _store.Count;
        }

    }
}