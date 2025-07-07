using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    // microsoft reference - https://github.com/dotnet/runtime/blob/main/src/libraries/System.Collections/src/System/Collections/Generic/Stack.cs
    // microsoft reference - https://github.com/microsoft/referencesource/blob/master/mscorlib/system/array.cs
    // почти все операции O(1) Pop просто затирает элемент на последнем месте.
    // Push с resize O(N) - поскольку надо копировать память.
    // вместо Array.Copy проще использовать готовую Array.Resize там внутри Array.Copy
    public class Stack<T>
    {
        private List<T> _store;
        public Stack()
        {
            _store = new List<T>();
        }

        public int Size()
        {
            return _store.Count;
        }

        public T Pop()
        {
            if (Size() == 0) return default(T);
            var index = _store.Count - 1;
            T result = _store[index];
            _store.RemoveAt(index);
            return result;
        }
	  
        public void Push(T val)
        {
            _store.Add(val);
        }

        public T Peek()
        {
            if (Size() == 0) return default(T);
            var index = _store.Count - 1;
            return _store[index];
        }
    }

}