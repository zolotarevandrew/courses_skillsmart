# порядковый номер самого задания на курсе - 1
#
# номер задачи из задания - 1.8
#
# краткое название - Сумма элементов двух связанных списков
#
# сложность решения (O-большое) 
# временнАя - O(N) - проходимся 1 раз по всем элементам двух LinkedList
# пространственная - O(N) - создаем новый LinkedList на N элементов
#
# рефлексия по эталонному варианту решения:
# Здесь более эталонного решения не видится, самое простое - пройтись в цикле последовательно по двум спискам, двигая их указатели.
# При том, что моя реализация len не проходится по списку заново каждый раз, а хранится счетчик текущего количества.
# Хотя - это бы не повлияло на изменение сложности с математической точки зрения.

from task1 import LinkedList, Node

def sumLists(list1: LinkedList, list2: LinkedList):
    if list1.len() != list2.len(): return None

    node1Cur = list1.head
    node2Cur = list2.head

    res = LinkedList()
    while node1Cur is not None:
        res.add_in_tail(Node(node1Cur.value + node2Cur.value))
        node1Cur = node1Cur.next
        node2Cur = node2Cur.next
    return res


