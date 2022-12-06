using System;
using System.Collections.Generic;

namespace OOAP.lesson2
{
    
    public abstract class LinkedList<T>
    {
        
        //команды
        
        /// предусловие, есть текущий элемент
        /// постусловие, текущий элемент указывает на начало списка
        public abstract void Head();
        
        /// предусловие, есть текущий элемент
        /// постусловие, текущий элемент указывает на конец списка
        public abstract void Tail();
        
        /// предусловие, есть текущий элемент
        /// предусловие, есть следующий элемент
        /// постусловие, текущий элемент сдвинут на один вправо
        public abstract void Right();
        
        
        /// предусловие, есть текущий элемент
        /// постусловие, новый элемент добавлен после текущего
        public abstract void PutRight(T value);
        
        /// предусловие, есть текущий элемент
        /// постусловие, новый элемент добавлен перед текущим
        public abstract void PutLeft(T value);
        
        //постусловие, элемень добавлен в хвост списка
        public abstract void AddInTail(T value);
        
        
        /// предусловие, есть текущий элемент
        /// постусловие, текущий элемент заменен на value
        public abstract void ReplaceCurrent(T value);
        
        /// предусловие, есть текущий элемент
        /// постусловие, удален текущий элемент
        public abstract void RemoveCurrent();
        
        /// предусловие, есть текущий элемент
        /// предусловие, найден элемент после текущего со значением value
        /// постусловие, в списке удалены все элементы со значением value 
        public abstract void RemoveAll(T value);
        
        /// постусловие: удалятся все значения
        public abstract void Clear();
        
        /// предусловие, есть текущий элемент
        /// предусловие, найден элемент после текущего со значением value
        /// постусловие, текущий элемент указывает на элемент со значением value
        public abstract void Find(T value);

        //запросы
        
        /// предусловие, есть текущий элемент
        /// значение текущего узла
        public abstract T CurrentValue { get; }
        
        /// установлен ли курсор на начало списка
        public abstract bool IsInHead { get; }
        
        /// установлен ли курсор на конец списка
        public abstract bool IsInTail { get; }
        
        /// установлен ли курсор на какой-либо узел в списке
        public abstract bool IsInValue { get; }
        
        /// текущее количество элементов
        public abstract int Size { get; }
    }
}