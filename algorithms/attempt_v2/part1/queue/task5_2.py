# порядковый номер самого задания на курсе - 5
#
# номер задачи из задания - 2
#
# Оцените меру сложности для операций enqueue() и dequeue().
# Для enqueue - O(1) вставляем в конец массива, даже при расширении амортизационно будет O(1)
# Для dequeue - O(N) удаляем элемент из начала массива, сдвигаем элементы.


# порядковый номер самого задания на курсе - 5
#
# номер задачи из задания - 3
#
# краткое название -  Напишите функцию, которая "вращает" очередь по кругу на N элементов
#
# сложность решения (O-большое) 
# временнАя - 
# N - длина очереди
# r - ротация
# k - сдвиг = N - r
# заполнение временной очереди - O(k) элементов и для каждого dequeue O(N) = O(N * k)
# наполнение старой очереди - O(k) элементов и для каждого dequeue O(k) = O(k ^ 2)
# Итого - O(N * k + k^2) ~ O(N* k)
# пространственная - O(1) памяти не используем
#
# рефлексия по эталонному варианту решения:
# Здесь если бы очередь была как кольцевой буфер, можно было бы легко сдвинуть за O(1)
# При реализации через LinkedList было бы просто O(k)

from task5 import Queue

def rotate(queue: Queue, r):
    l = queue.size()
    if r > l or r < 0:
        raise ValueError('Should be in range of queue size')
    if l == 0 or l == 1 or l == r: return queue
    if r == 0: return queue
    
    k = l - r
    for i in range(k):
        item = queue.dequeue()
        queue.enqueue(item)


    return queue

# порядковый номер самого задания на курсе - 5
#
# номер задачи из задания - 4
#
# краткое название -  Реализуйте очередь с помощью двух стэков
#
# сложность решения (O-большое) 
# временнАя - 
# enqueue - O(1) пушим в stack1
# dequeue - 
# O(N) в худшем случае
# Но амортизированно O(1) - поскольку для прохода элемента через enqueue а потом dequeue, нужно всего 4 операции:
# - push stack1, pop stack1, push stack2, pop stack2
# пространственная - O(N) храним все элементы, но в двух стэках
#
# рефлексия по эталонному варианту решения:
# Здесь важным моментом является снижение количества "переливов" между стэками, поэтому в dequeue сначала пытаемся взять из стэка, в который уже перелили.

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
class StackQueue:
    def __init__(self):
        self.stack1 = Stack()
        self.stack2 = Stack()

    def enqueue(self, item):
        self.stack1.push(item)

    def dequeue(self):
        if self.stack2.size() != 0: return self.stack2.pop()

        while self.stack1.size() > 0:
            self.stack2.push(self.stack1.pop())

        # здесь не будет падать, при size = 0, так как кастомная реализация стэка
        return self.stack2.pop()

    def size(self):
        return self.stack1.size() + self.stack2.size()
    

# порядковый номер самого задания на курсе - 5
#
# номер задачи из задания - 5
#
# краткое название - Добавьте функцию, которая обращает все элементы в очереди в обратном порядке.
#
# сложность решения (O-большое) 
# временнАя - O(N) кладем в стэк, а затем обратно в очередь
# пространственная - O(N) храним доп элементы в стэке
#
# рефлексия по эталонному варианту решения:
# Здесь более простого решения не видится, поскольку стэк натурально позволяет положить элементы в обратном порядке.
# Если бы очередь была реализована на LinkedList, можно было бы поменять указатели, тогда бы доп.память не требовалась.

def reverse(queue: Queue):
    stack = Stack()
    while queue.size() > 0:
        stack.push(queue.dequeue())

    while stack.size() > 0:
        queue.enqueue(stack.pop())
    return queue

# порядковый номер самого задания на курсе - 5
#
# номер задачи из задания - 6
#
# краткое название - Реализуйте круговую (циклическую буферную) очередь статическим массивом фиксированного размера.
#
# сложность решения (O-большое) 
# временнАя - O(1) на все операции, сдвиги указателей
# пространственная - O(1) на все операции, сдвиги указателей, 
# ну и дополнительно всегда храним фиксированный массив O(capacity)
#
# рефлексия по эталонному варианту решения:
# Достаточно простая математика по сдвигу указателей позволяет эффективно обрабатывать основные операции над очередью. Лучше чем O(1) и не придумаешь.
# Здесь можно было бы избавиться от указателя на tail, но тогда бы всеравно пришлось его пересчитывать.

class CircularQueue:
    def __init__(self, n):
        if n <= 0:
            raise ValueError('Invalid capacity provided')
        self.capacity = n
        self.queue = [None] * n
        self.count = 0
        self.head = 0
        self.tail = 0

    def enqueue(self, item):
        if self.isFull(): 
            return False
        self.queue[self.tail] = item
        self.tail += 1
        self.tail = self.tail % self.capacity

        self.count += 1
        return True

    def dequeue(self):
        if self.count == 0: 
            return None
        item = self.queue[self.head]
        self.queue[self.head] = None
        self.head += 1 
        self.head = self.head % self.capacity
        self.count -= 1
        return item

    def isFull(self) -> bool:
        return self.count == self.capacity

    def size(self):
        return self.count