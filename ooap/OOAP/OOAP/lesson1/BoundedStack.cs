using System.Collections.Generic;
using System.Drawing;

namespace OOAP.lesson1
{
    
    public abstract class BoundedStack<T>
    {
        public const int DefaultMaxElements = 32;
        
        /// предусловие maxElements >= 1
        /// постусловие: создан новый стек c размером = maxElements
        public BoundedStack(uint maxElements)
        {
            
        }
        
        /// постусловие: создан новый стек c размером = DefaultMaxElements
        protected BoundedStack()
        {
            
        }

        // команды 
        
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
        
        
        // запросы, в форме getter-ов удобнее вызывать - не смешивается с protected set, чтобы при необходимости добавить логику
        
        /// статус команды pop
        public abstract BoundedStackPopStatus PopStatus { get; }
        /// статус команды push
        public abstract BoundedStackPushStatus PushStatus { get; }
        /// статус команды peek
        public abstract BoundedStackPeekStatus PeekStatus { get; }
        
        /// текущее количество элементов стэка
        public abstract int Size { get; }
        
        /// максимально допустимое количество элементов в стеке
        public abstract int MaxElements { get; }
    }
    
    public enum BoundedStackPopStatus
    {
        None = 0, // Pop не вызывался
        Ok = 1, // Pop успешно удалил элемент из стэка
        FailEmpty = 2, // Pop неудачна, стэк пустой
    }
    
    public enum BoundedStackPushStatus
    {
        None = 0, // Push не вызывался
        Ok = 1, // Push успешно добавил элемент в стэк
        FailSizeExceeded = 2, // Push неудачна, стэк заполнен
    }

    public enum BoundedStackPeekStatus
    {
        None = 0, // Peek не вызывался
        Ok = 1, // Peek успешно удалил элемент из стэка
        FailEmpty = 2, // Peek неудачна, стэк пустой
    }
    
    public class BoundedStackImpl<T> : BoundedStack<T>
    {
        private BoundedStackPopStatus _popStatus;
        private BoundedStackPushStatus _pushStatus;
        private BoundedStackPeekStatus _peekStatus;
        private int _size;
        private int _maxElements;
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
            _store = new List<T>(_maxElements);
            _peekStatus = BoundedStackPeekStatus.None;
            _pushStatus = BoundedStackPushStatus.None;
            _popStatus = BoundedStackPopStatus.None;
            _size = 0;
        }

        public override BoundedStackPopStatus PopStatus => _popStatus;
        public override BoundedStackPushStatus PushStatus => _pushStatus;
        public override BoundedStackPeekStatus PeekStatus => _peekStatus;
        public override int Size => _size;
        public override int MaxElements => _maxElements;
    }
}