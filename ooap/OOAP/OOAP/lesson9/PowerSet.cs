namespace OOAP.lesson9
{
    public abstract class HashTable<T>
    {
        public const int NotCalled = 0;
        public const int Ok = 1;
        public const int FailNotFound = 2;
        public const int FailSizeExcedeed = 3;
        public const int FailCantRemove = 4;

        //конструктор
        public HashTable(int maxSize)
        {
            
        }
        
        //Команды
        
        //Предусловие таблица не заполнена
        //Предусловие элемент удалось добавить в таблицу
        //Постусловие элемент добавлен в таблицу
        public abstract void PutValue(T value);

        //Предусловие элемент найден
        //Постусловие элемент удален
        public abstract void RemoveValue(T value);
        
        //Запросы
        
        
        public abstract bool HasValue(T value);
        
        public abstract int Size { get; }
        public abstract int PutValueStatus { get; }
        public abstract int RemoveValueStatus { get; }
    }

    public abstract class PowerSet<T> : HashTable<T>
    {
        public PowerSet(int maxSize) : base(maxSize)
        {
        }

        //запросы
        public abstract PowerSet<T> Intersection(PowerSet<T> set2);
        public abstract PowerSet<T> Union(PowerSet<T> set2);
        public abstract PowerSet<T> Difference(PowerSet<T> set2);
        
        public abstract bool IsSubset(PowerSet<T> set2);
        
        //не вызвано/ок
        public abstract int IntersectionStatus { get; }
        //не вызвано/ок
        public abstract int UnionStatus { get; }
        //не вызвано/ок
        public abstract int DifferenceStatus { get; }
    }
}