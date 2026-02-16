# порядковый номер самого задания на курсе - 7
#
# номер задачи из задания - 8
#
# краткое название -  Добавьте метод удаления всех дубликатов из упорядоченного списка.
#
# сложность решения (O-большое)
# временнАя - O(N) проходимся 1 раз по всему списку
# пространственная - O(1) не используем доп.память

# рефлексия по эталонному варианту решения:
# Первый вариант подумал про добавление set и проверку, если уже был удаляем. Но в таком случае приходится использовать доп. память.
# Так как список упорядоченный, можем просто проверять соседние пары и удалять лишние элементы последовательно без доп. памяти.

from task7 import OrderedList, Node

def removeDuplicates(list: OrderedList):
    cur = list.head
    while cur is not None and cur.next is not None:
        if list.compare(cur.value, cur.next.value) == 0:
            list._deleteNode(cur.next)
            list.count -= 1
            continue
        cur = cur.next
    return list

# порядковый номер самого задания на курсе - 7
#
# номер задачи из задания - 9
#
# краткое название -  Напишите алгоритм слияния двух упорядоченных списков в один, сохраняя порядок элементов
#
# сложность решения (O-большое)
# временнАя -
# O(N + M) проходимся 1 раз по обоим спискам
# и O(1) на вставку в хвост, итого O(N + M)
# пространственная - O(N + M) создаем новый список, не трогаем старые

# рефлексия по эталонному варианту решения:
# Здесь, как обычно merge sort, самое простое. Не трогаем старые списки создаем новый и вставляем в хвост за O(1)

def merge(list1: OrderedList, list2: OrderedList):
    if list1._OrderedList__ascending != list2._OrderedList__ascending:
        raise ValueError('List asc param should be equal')
    left = list1.head
    right = list2.head
    asc = list1._OrderedList__ascending
    res = OrderedList(asc)
    def append(node: Node):
        cur = node
        while cur is not None:
            res._insert(res.tail, Node(cur.value))
            cur = cur.next

    while left is not None and right is not None:
        compareRes = list1.compare(left.value, right.value)
        shouldAddLeft = compareRes <= 0 if asc else compareRes >= 0
        if shouldAddLeft:
            res._insert(res.tail, Node(left.value))
            left = left.next
        else:
            res._insert(res.tail, Node(right.value))
            right = right.next
    if left is not None: append(left)
    if right is not None:  append(right)
    return res

# порядковый номер самого задания на курсе - 7
#
# номер задачи из задания - 10
#
# краткое название - Напишите метод проверки наличия заданного упорядоченного под-списка (параметр метода) в текущем списке
#
# сложность решения (O-большое)
# временнАя - O(N * M) перебор
# пространственная - O(1) не используем доп.память

# рефлексия по эталонному варианту решения:
# Реализовал через полный перебор, так как могут быть ситуации с дубликатами. Без дубликатов было бы за O(N)
# Можно дополнительно улучшить - проверять, сколько в основном списке осталось элементов, если меньше чем в subList то сразу выходим
# А также, проверять заведомо большие или меньшие элементы.

def isSublistOf(list: OrderedList, sublist: OrderedList):
    if list._OrderedList__ascending != sublist._OrderedList__ascending:
        raise ValueError('List asc param should be equal')
    if sublist.len() > list.len(): return False
    if sublist.len() == 0: return True

    listHead = list.head
    sublistHead = sublist.head

    remaining = list.len()
    while listHead is not None and remaining >= sublist.len():
        cnt = 0
        cur = listHead
        subListCur = sublistHead
        while cur is not None and subListCur is not None:
            if list.compare(cur.value, subListCur.value) != 0:
                break
            cnt += 1
            cur = cur.next
            subListCur = subListCur.next

        if cnt == sublist.len(): return True

        listHead = listHead.next
        remaining -= 1
    return False


# порядковый номер самого задания на курсе - 7
#
# номер задачи из задания - 11
#
# краткое название - Добавьте метод, который находит наиболее часто встречающееся значение в списке.
#
# сложность решения (O-большое)
# временнАя - O(N)
# пространственная - O(1) не используем доп.память

# рефлексия по эталонному варианту решения:
# Здесь в целом все просто, двигаемся и считаем количество на основе текущего и предыдущего элемента, лучше не придумаешь.

def mostCommonValue(list: OrderedList):
    if list.len() == 0: return None
    if list.len() == 1: return list.head.value

    bestVal = list.head.value
    bestValCnt = 0
    curVal = list.head.value
    curValCnt = 0

    cur = list.head
    while cur is not None:
        if list.compare(cur.value, curVal) == 0:
            curValCnt += 1
        else:
            if curValCnt > bestValCnt:
                bestVal = curVal
                bestValCnt = curValCnt
            curValCnt = 1
            curVal = cur.value
        cur = cur.next

    if curValCnt > bestValCnt:
        bestVal = curVal

    return bestVal


# порядковый номер самого задания на курсе - 7
#
# номер задачи из задания - 12
#
# краткое название - Добавьте в упорядоченный список возможность найти индекс элемента (параметр) в списке, которая должна работать за o(log N)
#
# сложность решения (O-большое)
# временнАя - O(log N) бинарный поиск по массиву, как раз дает O(log N)
# увеличиваем сложность вставки и удаления всегда до O(N) - из-за вставок в дополнительный массив
# пространственная - O(N) храним дополнительно отсортированный массив для бинарного поиска

# рефлексия по эталонному варианту решения:
# Здесь первой пришла мысль дополнительно хранить отсортированный массив, поскольку по нему удобно искать за логарифмическое время бинарным поиском.
# Судя по всему, можно еще было использовать SkipList, но для этого нужно полностью переделывать саму структуру.

class SearchOrderedList:
    def __init__(self, asc):
        self.clean(asc)

    def compare(self, v1, v2):
        # -1 если v1 < v2
        # 0 если v1 == v2
        # +1 если v1 > v2
        if v1 < v2: return -1
        if v1 > v2: return 1
        return 0

    def add(self, value):
        _insertNode = Node(value)
        # -
        if self.head is None:
            self._insert(None, _insertNode)
            self.arr.insert(0, value)
            return

        # <- 1
        headCompare = self.compare(_insertNode.value, self.head.value)
        shouldAddInHead = (headCompare <= 0) if self.__ascending else (headCompare >= 0)
        if shouldAddInHead:
            self._insert(None, _insertNode)
            self.arr.insert(0, value)
            return

        # 1 ->
        tailCompare = self.compare(_insertNode.value, self.tail.value)
        shouldAddInTail = (tailCompare >= 0) if self.__ascending else (tailCompare <= 0)
        if shouldAddInTail:
            self._insert(self.tail, _insertNode)
            self.arr.append(value)
            return

        # 1 -> 2 -> 3
        node: Node = self.head
        idx = 0
        while node != None:
            nodeCompare = self.compare(_insertNode.value, node.value)
            shouldAddBeforeNode = (nodeCompare <= 0) if self.__ascending else (nodeCompare >= 0)
            if shouldAddBeforeNode:
                self._insert(node.prev, _insertNode)
                self.arr.insert(idx, value)
                break
            node = node.next
            idx += 1

    def find(self, val):
        left = 0
        right = len(self.arr) - 1
        while left <= right:
            mid = (left + right) // 2
            midVal = self.arr[mid]
            compare = self.compare(val, midVal)
            if compare == 0:
                return mid
            toLeft = compare < 0 if self.__ascending else compare > 0
            if toLeft:
                right = mid - 1
            else:
                left = mid + 1
        return -1

    def delete(self, val):
        node: Node = self.head
        idx = 0
        while node != None:
            if self.compare(val, node.value) == 0:
                self._deleteNode(node)
                self.arr.pop(idx)
                self.count -= 1
                break
            node = node.next
            idx += 1

    def clean(self, asc):
        self.head = None
        self.tail = None
        self.arr = []
        self.__ascending = asc
        self.count = 0

    def len(self):
        return self.count

    def _deleteNode(self, selectedNode: Node):
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

    def _insert(self, afterNode, newNode):
        def _insertLocal():
            if afterNode is None:
                self._add_in_head(newNode)
                return
            if afterNode == self.tail:
                self._add_in_tail(newNode)
                return

            # 1 -> [2] -> 3
            oldNext = afterNode.next
            afterNode.next = newNode
            newNode.prev = afterNode
            newNode.next = oldNext
            oldNext.prev = newNode
            self.count = self.count + 1

        _insertLocal()

    def _add_in_head(self, newNode):
        oldHead = self.head
        self.head = newNode
        self.head.next = oldHead
        self.head.prev = None
        if oldHead is None: self.tail = self.head
        else: oldHead.prev = newNode
        self.count = self.count + 1

    def _add_in_tail(self, item):
        if self.head is None:
            self.head = item
            item.prev = None
            item.next = None
        else:
            self.tail.next = item
            item.prev = self.tail
        self.tail = item
        self.count = self.count + 1

