using System;

namespace OOAP.lesson4
{
    public abstract class DynArray<T>
    {
        //конструктор
        public DynArray()
        {
            
        }

        public const int NotCalled = 0;
        public const int Ok = 1;
        public const int FailIndexNotExists = 2;
        
        //команды
        
        //постусловие добавлен новый элемент
        public abstract void Append(T itm);
        
        //предусловие индекс существует
        //постусловие добавлен новый элемент
        public abstract void Insert(T itm, int index);
        
        //предусловие индекс существует
        //постусловие удален элемент по индексу
        public abstract void Remove(int index);
        
        public abstract int Size { get; }
        
        //предусловие индекс существует
        public abstract T GetItem(int index);
        
        public abstract int InsertStatus { get; }
        public abstract int RemoveStatus { get; }
        public abstract int GetItemStatus { get; }
    }
    
    public class DynArrayImpl<T> : DynArray<T>
    {
        private int _count;
        private int _insertStatus;
        private int _removeStatus;
        private int _getItemStatus;
        
        private T [] _array;
        private int _capacity;

        const int MinArraySize = 16;
        int IncreasedCapacity(int capacity = MinArraySize) => Math.Max(MinArraySize, capacity * 2);
        int DecreasedCapacity(int capacity = MinArraySize) => Math.Max(MinArraySize, (int)(capacity / 1.5));
        

        public DynArrayImpl()
        {
            _count = 0;
            _insertStatus = NotCalled;
            _removeStatus = NotCalled;
            _getItemStatus = NotCalled;
            MakeArray(MinArraySize);
        }
        
        public override void Append(T itm)
        {
            if (IsFullToAdd())
            {
                MakeArray(IncreasedCapacity(_capacity));
            }
            _array[_count] = itm;
            _count++;
        }

        public override void Insert(T itm, int index)
        {
            if (index > _count || index < 0)
            {
                _insertStatus = FailIndexNotExists;
                return;
            }

            if (IsFullToAdd())
            {
                MakeArray(IncreasedCapacity(_capacity));
            }

            if (_count > 0)
            {
                int startToShiftIndex = index;
                int endToShiftIndex = index + 1;
                int shiftLength = _count - index;
                Array.Copy(_array, startToShiftIndex, _array, endToShiftIndex, shiftLength);    
            }

            _array[index] = itm;

            _count++;

            _insertStatus = Ok;
        }

        public override void Remove(int index)
        {
            if (!IndexExists(index))
            {
                _removeStatus = FailIndexNotExists;
                return;
            }
            
            _count--;
            
            if (_count > 0)
            {
                int startToShiftIndex = index + 1;
                int endToShiftIndex = index;
                int shiftLength = _count - index;
                Array.Copy(_array, startToShiftIndex, _array, endToShiftIndex, shiftLength);
            }

            _array[_count] = default(T)!;

            var percent = FillPercent;
            if (percent < 50)
            {
                MakeArray(DecreasedCapacity(_capacity));    
            }

            _removeStatus = Ok;
        }

        
        public override T GetItem(int index)
        {
            if (!IndexExists(index))
            {
                _getItemStatus = FailIndexNotExists;
                return default;
            }
            
            var res=  _array[index];
            _getItemStatus = Ok;
            return res;
        }

        public override int Size => _count;
        public override int InsertStatus => _insertStatus;
        public override int RemoveStatus => _removeStatus;
        public override int GetItemStatus => _getItemStatus;
        
        void MakeArray(int new_capacity)
        {
            if (new_capacity == _capacity) return;
            
            if (new_capacity <= 0)
                throw new InvalidOperationException("new capacity should be positive number");

            var newArray = new T[new_capacity];
            if (_count > 0)
            {
                Array.Copy(_array, newArray, _count);
            }
            _array = newArray;

            _capacity = new_capacity;
        }
        
        float FillPercent
        {
            get
            {
                if (_count == 0) return 0;
                return ((float)_count / _capacity) * 100;
            }
        }

        bool IndexExists(int index)
        {
            if (index < 0) return false;
            return index < _count;
        }

        bool IsFullToAdd()
        {
            return _count == _array.Length;
        }
    }
}