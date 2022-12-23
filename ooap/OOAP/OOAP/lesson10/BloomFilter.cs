namespace OOAP.lesson10
{
    public abstract class BloomFilter<T>
    {
        //конструктор
        public BloomFilter()
        {
            
        }

        //команды
        
        //постусловие элемент добавлен
        public abstract void PutValue(T value);
        
        //запросы
        public abstract bool HasValue(T value);
        
    }
}