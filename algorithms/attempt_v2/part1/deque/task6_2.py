# порядковый номер самого задания на курсе - 6
#
# номер задачи из задания - 7.1
#
# Почему и как будет различаться мера сложности для addHead/removeHead и addTail/removeTail.
# Взял обычную реализацию list-а в python и здесь выбор будет зависеть от выбора head/tail.
# При таком выборе, в любом случае, одна сторона будет иметь сложность O(N).
# Для addTail - O(1) вставляем в конец массива, даже при расширении амортизационно будет O(1).
# Для addHead - O(N) вставляем в начало массива, сдвигаем элементы.
# Для removeTail - O(1) удаляем с конца массива.
# Для removeHead - O(N) удаляем с начала массива, сдвигаем элементы.


# порядковый номер самого задания на курсе - 6
#
# номер задачи из задания - 7.3
#
# краткое название -  Напишите функцию, которая с помощью deque проверяет, является ли некоторая строка палиндромом (читается одинаково слева направо и справа налево).
#
# сложность решения (O-большое) 
# временнАя - 
# O(N) проходимся 1 раз по всем элементам и добавляем в конец очереди за O(1)
# O(N/2) - раз достаем хвост за O(1)
# O(N/2 * N) - раз достаем голову за O(N)
# итого - O(N + N/2 + N/2 * N) ~ O(N^2)
# пространственная - O(N) на хранение элементов в deque
#
# рефлексия по эталонному варианту решения:
# Проще переделать на два указателя и будет O(N) временная и O(1) пространственная

from task6 import Deque

def isPalindrome(s: str):
    if s is None or s == '': return False
    deque = Deque()
    for ch in s:
        deque.addTail(ch)

    while deque.size() >= 2:
        front = deque.removeFront()
        tail = deque.removeTail()
        if front != tail: return False

    return True


# порядковый номер самого задания на курсе - 6
#
# номер задачи из задания - 7.4
#
# краткое название - Напишите метод, который возвращает минимальный элемент деки за O(1)
#
# сложность решения (O-большое) 
# временнАя - 
# addFront, addTail - O(1) добавляем в конкретный стэк
# removeFront, removeTail - амортизированно O(1), так как переливы случаются редко и также затрагивают несколько константых операций.
# min - O(1) просто смотрим минимум из двух стэков
# пространственная - O(N) на два стэка
#
# рефлексия по эталонному варианту решения:
# Попытался сначала хранить минимумы внутри элементов, понимая, что есть два направления и минимумы рассчитывались на основе начала или конца, но алгоритм оказался не рабочим.
# Далее перешел на два стэка, с такой же идеей по двум направлениям, только теперь все кейсы отрабатывали верно + добавились переливы.

class Stack:
    def __init__(self):
        self.stack = []

    def size(self):
        return len(self.stack)

    def pop(self):
        if self.size() == 0:
            return None
        return self.stack.pop()

    def push(self, value):
        self.stack.append(value)

    def peek(self):
        if self.size() == 0:
            return None
        return self.stack[-1]

class MinDeque:
    def __init__(self):
        self.front = Stack()
        self.tail = Stack()

    def addFront(self, item):
        curMin = item if self.front.size() == 0 else min(self.front.peek()[1], item)
        self.front.push((item, curMin))

    def addTail(self, item):
        curMin = item if self.tail.size() == 0 else min(self.tail.peek()[1], item)
        self.tail.push((item, curMin))

    def removeFront(self):
        if self.front.size() > 0:
            return self.front.pop()[0]

        while self.tail.size() > 0:
            self.addFront(self.tail.pop()[0])

        if self.front.size() > 0:
            return self.front.pop()[0]
        return None

    def removeTail(self):
        if self.tail.size() > 0:
            return self.tail.pop()[0]

        while self.front.size() > 0:
            self.addTail(self.front.pop()[0])

        if self.tail.size() > 0:
            return self.tail.pop()[0]
        return None
    
    def min(self):
        front = self.front.peek()
        tail = self.tail.peek()
        if front is None and tail is None:
            return None
        elif front is not None and tail is None:
            return front[1]
        elif front is None and tail is not None:
            return tail[1]
        else:
            return min(front[1], tail[1])

    def size(self):
        return self.front.size() + self.tail.size()
    

# порядковый номер самого задания на курсе - 6
#
# номер задачи из задания - 7.5
#
# краткое название - Реализуйте двустороннюю очередь с помощью динамического массива. Методы добавления и удаления элементов с обоих концов деки должны работать за амортизированное время o(1)
#
# сложность решения (O-большое) 
# временнАя - 
# removeTail, removeFront - O(1) двигаем указатели
# addFront, addTail - амортизированно O(1) из-за потенциального роста массива
# пространственная - O(N) на массив
#
# рефлексия по эталонному варианту решения:
# Очередь на основе кольцевого буфера, видел подобную реализацию еще давно у Microsoft.
# Здесь более оптимальных вариантов не видится.

MIN_CAPACITY = 4

class CircularDeque:
    def __init__(self, cap = MIN_CAPACITY):
        self.capacity = cap
        self.queue = [None] * cap
        self.count = 0
        self.head = 0
        self.tail = 0

    def addTail(self, item):
        self._tryGrow()
        self.queue[self.tail] = item
        self.tail += 1
        if self.tail == self.capacity: 
            self.tail = 0
        self.count += 1

    def removeTail(self):
        if self.count == 0: 
            return None
        self.tail -= 1
        if self.tail == -1:
            self.tail = self.capacity - 1

        item = self.queue[self.tail]
        self.queue[self.tail] = None
        self.count -= 1        
        return item

    def addFront(self, item):
        self._tryGrow()
        self.head = self.capacity - 1 if self.head == 0 else self.head - 1
        self.queue[self.head] = item
        self.count += 1

    def removeFront(self):        
        if self.count == 0: 
            return None
        item = self.queue[self.head]
        self.queue[self.head] = None

        self.head += 1
        if self.head == self.capacity:
            self.head = 0
        self.count -= 1
        return item

    def _tryGrow(self):
        if self.count != self.capacity:
            return
        newCapacity = self.capacity * 2
        new_queue = [None] * newCapacity
    
        if self.head < self.tail:
            merged = self.queue[self.head:self.tail]
        else:
            merged = self.queue[self.head:] + self.queue[:self.tail]

        new_queue[:self.count] = merged
        self.queue = new_queue
        self.head = 0
        self.capacity = newCapacity
        self.tail = self.count

    def size(self):
        return self.count
    

# порядковый номер самого задания на курсе - 6
#
# номер задачи из задания - 7.6
#
# краткое название - Напишите автономную функцию, которая проверяет правильность расстановки (баланс) скобок в символьном (например, арифметическом) выражении
#
# сложность решения (O-большое) 
# временнАя - O(N) проходимся по всем элементам строки
# пространственная - O(N), используем стэк

# рефлексия по эталонному варианту решения:
# Возможно я не до конца понял, что надо сделать, но это та же самая задача что и доп.задача по стэку с открывающими и закрывающими скобками - ее уже делал в task4_2..

openByClosed = {
    ')': '(',
    '}': '{',
    ']': '['
}
def checkBrackets(str):
    if str is None or str == '': return False

    stack = Stack()
    for ch in str:
        if ch == '{' or ch == '(' or ch == '[':
            stack.push(ch)
            continue
        if ch not in openByClosed:
            return False

        if stack.size() == 0:
            return False
        open = openByClosed[ch]
        popped = stack.pop()

        if popped != open: 
            return False
        
    return stack.size() == 0

