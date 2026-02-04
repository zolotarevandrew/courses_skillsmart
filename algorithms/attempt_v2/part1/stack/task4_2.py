# порядковый номер самого задания на курсе - 4
#
# номер задачи из задания - 2
#
# краткое название - Переделайте реализацию стека так, чтобы она работала не с хвостом списка как с верхушкой стека, а с его головой.
#
# сложность решения (O-большое) 
# временнАя - 
# Push - O(N), каждый раз сдвигаем, вставляя в начало массива
# Pop - O(N), каждый раз сдвигаем, удаляя из начала массива
# пространственная - O(1), во всех операциях, не требует доп.памяти
#
# рефлексия по эталонному варианту решения:
# Выбор вставки в начало на основе массива, ухудшает обе операции pop/push до O(N), что совсем не хочется видеть при работе такой структуры данных, как стэк.
# Проще было бы использовать deque или LinkedList - операции стали бы O(1) ну или вставлять в конец списка.

from task4 import Stack

class Stack2:
    def __init__(self):
        self.stack = []

    def size(self):
        return len(self.stack)

    def pop(self):
        if self.size() == 0:
            return None
        return self.stack.pop(0)

    def push(self, value):
        self.stack.insert(0, value)

    def peek(self):
        if self.size() == 0:
            return None
        return self.stack[0]
    
# порядковый номер самого задания на курсе - 4
#
# номер задачи из задания - 3
#
# Не запуская программу, скажите, как отработает такой цикл?
#  while stack.size() > 0:
#     print(stack.pop())
#     print(stack.pop())
# 0 элементов - не зайдет в цикл
# 1 элемент - на втором pop, в зависимости от реализации может упасть
# 2 элемента - выведет два элемента
# 3 элемента - может упасть на второй итерации цикла, в зависимости от реализации pop
# Соот-во, если берем стэк Python, который падает при вызове pop, когда 0 элементов в стэке
# То код логически ждет, чтобы было четное количество элементов в стэке.


# порядковый номер самого задания на курсе - 4
#
# номер задачи из задания - 4
#
# Оцените меру сложности для операций pop и push.
# Для стэка с верхушкой в конце массива - O(1) для push/pop.
# Для стэка с верхушкой в начале массива -  O(N) для push/pop.


# порядковый номер самого задания на курсе - 4
#
# номер задачи из задания - 5,6
#
# краткое название - Напишите функцию, которая получает на вход строку, состоящую из открывающих и закрывающих скобок
# и расширьте если скобки могут быть трех типов: (), {}, []
#
# сложность решения (O-большое) 
# временнАя - O(N) проходимся по всем элементам строки
# пространственная - O(N), используем стэк
#
# рефлексия по эталонному варианту решения:
# Для одного вида скобок можно было бы обойтись без стэка, просто считая баланс скобок.
# А для нескольких видов, все же приходится использовать стэк, но решение выглядит самым оптимальным, 
# поскольку нужно возвращаться назад для корректных проверок.

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


# порядковый номер самого задания на курсе - 4
#
# номер задачи из задания - 7
#
# краткое название - Добавьте в стек функцию, возвращающую текущий минимальный элемент в нём за O(1)
#
# сложность решения (O-большое) 
# временнАя - 
# push и pop, также O(1)
# пространственная - stack O(N) + minStack O(N) = O(N) храним доп.памяти в худшем случае
#
# рефлексия по эталонному варианту решения:
# В текущей реализации приходится хранить дополнительный стэк.
# Можно хранить пары, элемент + минимум на текущий момент, тогда избавимся от дополнительного стэка.
class Stack3:
    def __init__(self):
        self.stack = []
        self.minstack = []

    def size(self):
        return len(self.stack)

    def pop(self):
        if self.size() == 0:
            return None
        if self.stack[-1] == self.minstack[-1]:
            self.minstack.pop()
        return self.stack.pop()

    def push(self, value):
        if len(self.minstack) == 0 or value <= self.minstack[-1]:
            self.minstack.append(value)
        self.stack.append(value)

    def min(self):
        if len(self.minstack) == 0:
            return None
        return self.minstack[-1]

    def peek(self):
        if self.size() == 0:
            return None
        return self.stack[-1]
    

# порядковый номер самого задания на курсе - 4
#
# номер задачи из задания - 8
#
# краткое название - Добавьте в стек функцию, которая возвращает среднее значение всех элементов в стеке. Она должна выполняться за O(1)
#
# сложность решения (O-большое) 
# временнАя - O(1), обычные операции стэка
# пространственная - O(N) на хранение доп элемента внутри массива, но по факту это не сильная разница.
#
# рефлексия по эталонному варианту решения:
# За счет хранения пар решение максимально эффективное, конкретная верхушка стэка, хранит сумму всех элементов до верхушки включительно.
# Можно было бы хранить отдельно totalSum, тогда бы не пришлось хранить лишние n записей, но текущая версия чище и проще.
class Stack4:
    def __init__(self):
        self.stack = []

    def size(self):
        return len(self.stack)

    def pop(self):
        if self.size() == 0:
            return None
        res = self.stack.pop()
        return res[0]

    def push(self, value):
        cnt = self.size()
        total = value if cnt == 0 else self.stack[-1][1] + value
        vv = (value, total)
        self.stack.append(vv)

    def avg(self):
        if self.size() == 0:
            return None
        res = self.stack[-1]
        return res[1] / self.size()

    def peek(self):
        if self.size() == 0:
            return None
        return self.stack[-1][0]
    

# порядковый номер самого задания на курсе - 4
#
# номер задачи из задания - 9
#
# краткое название - Постфиксная запись выражения
#
# сложность решения (O-большое) 
# временнАя - O(N) проходимся два раза по всем элементам, один раз на split, второй для расчета
# пространственная - O(N) на стэк.
#
# рефлексия по эталонному варианту решения:
# Можно обойтись без лишнего первого стэка, просто проходясь по элементам.

ops = {
    '+': lambda a, b: a + b,
    '-': lambda a, b: a - b,
    '*': lambda a, b: a * b,
    '/': lambda a, b: a / b,
}

def postfixExpression(s: str):
    if s is None: return None
    s = s.strip()
    if s == "": return None
    parts = s.split()

    stack2 = Stack()
    for item in parts:
        num = parse_number(item)
        if num is not None:
            stack2.push(num)
            continue
        if item in ops:
            func = ops[item]
            op1 = stack2.pop()
            op2 = stack2.pop()
            if op1 is None or op2 is None:
                raise ValueError('Invalid input')
            res = func(op2, op1)
            stack2.push(res)
            continue

        raise ValueError('Unsupported char')

    if stack2.size() > 1:
        raise ValueError('Invalid input')

    return stack2.pop()

def parse_number(s: str):
    try:
        return int(s)
    except ValueError:
        return None
