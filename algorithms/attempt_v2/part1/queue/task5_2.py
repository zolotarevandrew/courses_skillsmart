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
# пространственная - 
#
# рефлексия по эталонному варианту решения:
# 

from stack.task4 import Stack
class StackQueue:
    def __init__(self):
        self.stack1 = Stack()
        self.stack2 = Stack()

    def enqueue(self, item):
        self.stack1.push(item)

    def dequeue(self):
        while self.stack1.size() > 0:
            self.stack2.push(self.stack1.pop())

        if self.stack2.size() == 0: return None
        return self.stack2.pop()

    def size(self):
        return self.stack1.size() + self.stack2.size()