# порядковый номер самого задания на курсе - 4
#
# номер задачи из задания - 2
#
# краткое название - Переделайте реализацию стека так, чтобы она работала не с хвостом списка как с верхушкой стека, а с его головой..
#
# сложность решения (O-большое) 
# временнАя - 
# пространственная - 
#
# рефлексия по эталонному варианту решения:
# 

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