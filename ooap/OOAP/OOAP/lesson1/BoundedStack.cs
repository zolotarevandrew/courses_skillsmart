using System;
using System.Collections.Generic;

namespace OOAP.lesson1
{
    
    public abstract class BoundedStack<T>
    {
        public const int DefaultMaxElements = 32;
        
        /// предусловие maxElements >= 1
        /// постусловие: создан новый стек c размером = maxElements
        public BoundedStack(uint maxElements)
        {
            if (maxElements < 1)
                throw new InvalidOperationException("max elements should be >= 1");
            
            MaxElements = maxElements;
        }
        
        /// постусловие: создан новый стек c размером = DefaultMaxElements
        public BoundedStack()
        {
            MaxElements = DefaultMaxElements;
        }

 
        /// предусловие, стэк не пустой
        public abstract T Peek();
        
        /// предусловие: стек не пустой
        /// постусловие: из стека удалён верхний элемент
        public abstract void Pop();
        
        /// предусловие: стэк не заполнен
        /// постусловие: в стек добавлено новое значение
        public abstract void Push(T value);
        
        /// постусловие: из стека удалятся все значения
        public abstract void Clear();
        
        
        /// статус команды pop
        public abstract BoundedStackPopStatus PopStatus { get; }
        
        /// статус команды push
        public abstract BoundedStackPushStatus PushStatus { get; }
        
        /// статус команды peek
        public abstract BoundedStackPeekStatus PeekStatus { get; }
        
        /// текущее количество элементов стэка
        public abstract int Size { get; }

        /// максимально допустимое количество элементов в стеке
        public uint MaxElements { get; }
    }
    
    public enum BoundedStackPopStatus
    {
        NotCalled = 0,
        Ok = 1,
        FailEmpty = 2,
    }
    
    public enum BoundedStackPushStatus
    {
        NotCalled = 0,
        Ok = 1,
        FailSizeExceeded = 2, 
    }

    public enum BoundedStackPeekStatus
    {
        NotCalled = 0,
        Ok = 1, 
        FailEmpty = 2, 
    }
    
    public class BoundedStackImpl<T> : BoundedStack<T>
    {
        private BoundedStackPopStatus _popStatus;
        private BoundedStackPushStatus _pushStatus;
        private BoundedStackPeekStatus _peekStatus;
        private int _size;
        private List<T> _store;
        
        public override T Peek()
        {
            if (Size == 0)
            {
                _peekStatus = BoundedStackPeekStatus.FailEmpty;
                return default;
            }
            
            var index = _store.Count - 1;
            var result =  _store[index];
            
            _peekStatus = BoundedStackPeekStatus.Ok;

            return result;
        }

        public override void Pop()
        {
            if (Size == 0)
            {
                _popStatus = BoundedStackPopStatus.FailEmpty;
                return;
            }
            
            var index = _store.Count - 1;
            _store.RemoveAt(index);
            
            _popStatus = BoundedStackPopStatus.Ok;
        }

        public override void Push(T value)
        {
            if (_size == MaxElements)
            {
                _pushStatus = BoundedStackPushStatus.FailSizeExceeded;
                return;
            }
            
            _store.Add(value);
            _pushStatus = BoundedStackPushStatus.Ok;
        }

        public override void Clear()
        {
            _store = new List<T>((int)MaxElements);
            _peekStatus = BoundedStackPeekStatus.NotCalled;
            _pushStatus = BoundedStackPushStatus.NotCalled;
            _popStatus = BoundedStackPopStatus.NotCalled;
            _size = 0;
        }

        public override BoundedStackPopStatus PopStatus => _popStatus;
        public override BoundedStackPushStatus PushStatus => _pushStatus;
        public override BoundedStackPeekStatus PeekStatus => _peekStatus;
        public override int Size => _size;
    }
}