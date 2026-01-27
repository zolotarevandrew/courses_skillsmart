

from task2 import LinkedList2, Node


# порядковый номер самого задания на курсе - 2
#
# номер задачи из задания - 2.10
#
# краткое название - Переворачивание связного списка
#
# сложность решения (O-большое) 
# временнАя - O(N) - проходимся 1 раз по всем элементам LinkedList
# пространственная - O(1) - не используем лишнюю память
#
# рефлексия по эталонному варианту решения:
# Самым простым решением оказалась смена направления указателей и соответствующая смена head,tail в конце.
# С двумя указателями делать такие операции гораздо проще, в отличии от варианта с одним указателем.
# Можно "слегка улучшить", не делая никаких манипуляций при размере списка 0 и 1.
def reverse(src: LinkedList2):
    cur = src.head
    while cur is not None:
        next = cur.next
        cur.next = cur.prev
        cur.prev = next
        cur = next

    oldHead = src.head
    src.head = src.tail
    src.tail = oldHead

    return src


# порядковый номер самого задания на курсе - 2
#
# номер задачи из задания - 2.11
#
# краткое название - Имеются ли циклы (замкнутые на себя по кругу)
#
# сложность решения (O-большое)
# временнАя - O(N) - проходимся 2 раза по всем элементам LinkedList
# пространственная - O(N) - используем 2 раза лишнюю память для visited
#
# рефлексия по эталонному варианту решения:
# Первым вариантом пришло в голову пройтись в обе стороны от head по next и от tail по prev с set visited - для обнаружения цикла.
# Если какой-то узел уже встретился, значит цикл обнаружен. В таком случае используем лишнюю память O(N).
# Была еще мысль просто проверять инвариант что cur.next != cur and cur.next.prev = cur
# но в таком случае не все кейсы покрываются, особенно в случае зацикленности в начале или конце - совсем не то, больше про валидность структуры.
# Постфактум поискал дополнительные варианты решения (своих идей не пришло более) - алгоритм флойда черепаха заяц с двумя указателями более эффективен, не использует доп. память.
def hasCycle(src: LinkedList2):
    cur = src.head
    visited = set()
    while cur is not None:
        if cur in visited:    
            return True

        visited.add(cur)
        cur = cur.next

    cur = src.tail
    visited = set()
    while cur is not None:
        if cur in visited:    
            return True

        visited.add(cur)
        cur = cur.prev

    return False

# порядковый номер самого задания на курсе - 2
#
# номер задачи из задания - 2.12
#
# краткое название - Добавьте метод, сортирующий список.
#
# сложность решения (O-большое)
# временнАя - O(N Log N)
# Каждый merge - O(N) * log N операций (делим пополам)

# пространственная - O(N log n) - 
# O(Log N) - памяти под стэк
# O(N) - под каждый merge и split, создаем новые ноды. Сделал так, ради удобства реализации (в том числе для следующей задачи)
# итого O (Log n) под стэк + O(N log n) под создание новых нод - примерно O(N log n)

# рефлексия по эталонному варианту решения:
# В целом merge sort - самый подходящий вариант для сортировки LinkedList, его легко разделить пополам и смерджить, просто двигаясь по указателям без индексного доступа.
# Можно улучшить решение, отказавшись от копирования Нод, тогда по памяти будет O(1) + O(log n) на стэк = O(log n). 
def sort(src: LinkedList2):
    if src.head is None or src.head.next is None: 
        return src
    left, right = split(src)

    sortedLeft = sort(left)
    sortedRight = sort(right)

    return merge(sortedLeft, sortedRight)

def split(src: LinkedList2):
    def splitToNodes(lst: LinkedList2):
        cur: Node = lst.head
        n = lst.len()
        if n == 0: return (None, None)
        if n == 1: return (lst.head, None)

        mid = n // 2
        start = 0
        while start != mid and cur is not None:
            cur = cur.next
            start = start + 1

        cur.prev.next = None
        cur.prev = None

        return (lst.head, cur)
    
    def addRemaining(newList: LinkedList2, cur: Node):
        while cur is not None:
            newList.add_in_tail(Node(cur.value))
            cur = cur.next
    
    left, right = splitToNodes(src)
    leftList = LinkedList2()
    addRemaining(leftList, left)
    rightList = LinkedList2()
    addRemaining(rightList, right)
    return (leftList, rightList)


def merge(list1: LinkedList2, list2: LinkedList2):
    res = LinkedList2()
    def addRemaining(remaining: Node):
        while remaining is not None:
            res.add_in_tail(Node(remaining.value))
            remaining = remaining.next

    left = list1.head
    right = list2.head
    while left is not None and right is not None:
        if left.value < right.value:
            res.add_in_tail(Node(left.value))
            left = left.next
        else:
            res.add_in_tail(Node(right.value))
            right = right.next

    if left is not None: addRemaining(left)
    if right is not None: addRemaining(right)

    return res

# порядковый номер самого задания на курсе - 2
#
# номер задачи из задания - 2.13
#
# краткое название - Добавьте метод, объединяющий два списка в третий.
#
# сложность решения (O-большое)
# временнАя - O(N Log N) + O(M Log M)
# на сортировки - O(N Log N) + O(M Log M), где N - list1, M - list2
# на merge - O(N + M)

# пространственная - O(N log n) +  O(M Log M) 
# так как внутри каждого sort выделяются новые элементы

# рефлексия по эталонному варианту решения:
# Здесь более идеального алгоритма придумать, кажется, нельзя.
# Единственное, можно также отказаться от копирования Нод и уменьшить количество выделяемой памяти.

def mergeLists(list1: LinkedList2, list2: LinkedList2):
    sortedList1 = sort(list1)
    sortedList2 = sort(list2)
    return merge(sortedList1, sortedList2)

# порядковый номер самого задания на курсе - 2
#
# номер задачи из задания - 2.14
#
# краткое название - фиктивный/пустой (dummy) узел.
#
# сложность решения (O-большое)
# временнАя - такая же как в LinkedList2
# пространственная - такая же как в LinkedList2

# рефлексия по эталонному варианту решения:
# DummyNodes сильно упрощают реализацию, 

class Node3:
    def __init__(self, v):
        self.value = v
        self._prev = None
        self._next = None

    @property
    def prev(self):
        node = self._prev
        if isinstance(node, DummyNode): return None
        return node
    
    @property
    def next(self):
        node = self._next
        if isinstance(node, DummyNode): return None
        return node

class DummyNode(Node3):
    def __init__(self, v):
        super().__init__(v)

class LinkedList3:  
    def __init__(self):
        self.clean()

    def add_in_tail(self, item: Node3):
        # dh -> [] -> dt
        # dh -> 1 -> dt
        # dh -> 1 -> 2 -> dt
        oldPrev = self.dummyTail._prev
        self.dummyTail._prev = item
        item._prev = oldPrev
        item._next = self.dummyTail
        oldPrev._next = item
        
        self.count = self.count + 1

    def find(self, val):
        node = self.head
        while node is not None:
            if node.value == val:
                return node
            node = node.next
        return None

    def find_all(self, val):
        res = []
        node = self.head
        while node is not None:
            if node.value == val:
                res.append(node)
            node = node.next
        return res

    def delete(self, val, all=False):
        def _deleteNode(selectedNode: Node):
            # [1]
            # [1] -> 2
            # [1] -> 2 -> 3
            if selectedNode == self.head:
                self.head = self.head.next
                if self.head is None:
                    self.tail = None
                else:
                    self.head.prev = None
                return
            # 1 -> [2]
            # 1 -> 2 -> [3]
            if selectedNode == self.tail:
                self.tail = self.tail.prev
                self.tail.next = None
                return
            
            # 1 -> [2] -> 3
            selectedNode.prev.next = selectedNode.next
            selectedNode.next.prev = selectedNode.prev
            selectedNode.next = None

        node = self.head
        while node is not None:
            next = node.next
            if node.value == val:
                _deleteNode(node)
                self.count = self.count - 1
                if all == False: 
                    break
            node = next

    @property
    def head(self):
        return self.dummyHead.next
    
    @property
    def tail(self):
        return self.dummyTail.prev
    
    def clean(self):
        self.dummyHead = DummyNode()
        self.dummyTail = DummyNode()
        self.dummyHead.next = self.dummyTail
        self.dummyTail.prev = self.dummyHead
        self.count = 0

    def len(self):
        return self.count

    def insert(self, afterNode: Node3, newNode: Node3):
        curNode = None
        if afterNode is None and self.len() == 0:
            curNode = self.dummyHead
        elif afterNode is None and self.len() > 0:
            curNode = self.dummyHead if self.tail is None else self.tail
        else:
            curNode = self.dummyHead
       
        oldNext = curNode.next
        curNode.next = newNode
        newNode.prev = curNode
        newNode.next = oldNext
        oldNext.prev = newNode
        self.count = self.count + 1

    def add_in_head(self, newNode: Node3):
        self.insert(self.dummyHead, newNode)