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
