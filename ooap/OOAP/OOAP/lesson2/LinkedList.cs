namespace OOAP.lesson2
{
    public enum LinkedListMoveCursorStatus
    {
        None = 0,
        Ok = 1,
        FailListEmpty = 2,
        FailNoRightElement = 3
    }
    
    public enum LinkedListCurrentValueStatus
    {
        None = 0,
        Ok = 1,
        FailListEmpty = 2
    }
    
    public enum LinkedListAddValueStatus
    {
        None = 0,
        Ok = 1
    }
    
    public enum LinkedListFindStatus
    {
        None = 0,
        Ok = 1,
        FailListEmpty = 2,
        FailNotFound = 3
    }
    
    public enum LinkedListRemoveAllStatus
    {
        None = 0,
        Ok = 1,
        FailListEmpty = 2,
        FailNotFound = 3
    }
    
    public enum LinkedListRemoveStatus 
    {
        None = 0,
        Ok = 1,
        FailListEmpty = 2
    }
    
    public enum LinkedListReplaceStatus
    {
        None = 0,
        Ok = 1,
        FailListEmpty = 2
    }
    
    //2.1
    public abstract class LinkedList<T>
    {

        //конструктор
        public LinkedList()
        {
            
        }
        
        //команды
        
        /// предусловие, есть текущий элемент
        /// постусловие, текущий элемент указывает на начало списка
        /// устанавливает LinkedListMoveCursorStatus
        public abstract void Head();
        
        /// предусловие, есть текущий элемент
        /// постусловие, текущий элемент указывает на конец списка
        /// устанавливает LinkedListMoveCursorStatus
        public abstract void Tail();
        
        /// предусловие, есть текущий элемент
        /// предусловие, есть следующий элемент
        /// постусловие, текущий элемент сдвинут на один вправо
        /// устанавливает LinkedListMoveCursorStatus 
        public abstract void Right();
        
        /// постусловие, новый элемент добавлен после текущего (отработает даже если нет элементов)
        /// устанавливает LinkedListAddValueStatus
        public abstract void PutRight(T value);
        
        /// постусловие, новый элемент добавлен перед текущим (отработает даже если нет элементов)
        /// устанавливает LinkedListAddValueStatus
        public abstract void PutLeft(T value);
        
        /// постусловие, новый элемент добавлен в конец списка (отработает даже если нет элементов)
        /// устанавливает LinkedListAddValueStatus
        public abstract void AddInTail(T value);
        
        
        /// предусловие, есть текущий элемент
        /// постусловие, текущий элемент заменен на value
        public abstract void ReplaceCurrent(T value);
        
        /// предусловие, есть текущий элемент
        /// постусловие, удален текущий элемент (курсор смещается к правому соседу, если он есть, в противном случае курсор смещается к левому соседу, если он есть)
        public abstract void RemoveCurrent();
        
        /// предусловие, есть текущий элемент
        /// предусловие, найден хотя бы один элемент после текущего со значением value
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
        public abstract T CurrentValue();
        
        /// установлен ли курсор на начало списка
        public abstract bool IsInHead { get; }
        
        /// установлен ли курсор на конец списка
        public abstract bool IsInTail { get; }
        
        /// установлен ли курсор на какой-либо узел в списке
        public abstract bool IsInValue { get; }
        
        /// текущее количество элементов
        public abstract int Size { get; }
        
        
        /// статус после запроса текущего элемента
        public abstract LinkedListCurrentValueStatus CurrentValueStatus { get; }
        
        /// статус изменения курсора, чтобы не плодить для трех методов отдельные статусы
        public abstract LinkedListMoveCursorStatus MoveCursorStatus { get; }
        
        /// статус после команд добавления
        public abstract LinkedListAddValueStatus AddValueStatus { get; }
        
        /// статус после команд AddinTail, PutLeft, PutRight
        public abstract LinkedListFindStatus FindStatus { get; }
        
        /// статус после команды RemoveAll
        public abstract LinkedListRemoveAllStatus RemoveAllStatus { get; }
        
        /// статус после команды RemoveCurrent
        public abstract LinkedListRemoveStatus RemoveStatus { get; }
        
        /// статус после команды Replace
        public abstract LinkedListReplaceStatus ReplaceStatus { get; }
    }
    
    //2.2 Почему операция tail не сводима к другим операциям (если исходить из эффективной реализации)?
    
    /* в эффективной реализации все также придется хранить указатели на начало и конец списка,
     * значит чтобы курсор указывал на конец списка, нужно либо установить его в начало head, и вызывать right, что явно неэффективно
     * или все таки напрямую установить курсор на указатель конца списка.
     */ 
    
    //2.3 Операция поиска всех узлов с заданным значением, выдающая список таких узлов, уже не нужна. Почему?
    
    /* во-первых АТД уже не оперирует понятием узлы, можно получить только текущее значение с помощью запроса.
     * во-вторых можно с помощью метода find и head,tail, right двигаться по курсору и написать свою функцию поиска всех элементов с заданным значениям,
     * она явно не будет относиться к АТД и будет условно написаной пользователем этого АТД, что удобно с точки зрения
     * не добавления лишних не нужных методов в АТД
     * (в c# например можно сделать метод расширения или даже сделать свой кастомный итератор)
     */
}