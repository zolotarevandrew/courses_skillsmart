class Node:
    def __init__(self, v):
        self.value = v
        self.prev = None
        self.next = None

class LinkedList2:  
    def __init__(self):
        self.clean()

    def add_in_tail(self, item):
        if self.head is None:
            self.head = item
            item.prev = None
            item.next = None
        else:
            self.tail.next = item
            item.prev = self.tail
        self.tail = item
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

    def clean(self):
        self.head = None
        self.tail = None
        self.count = 0

    def len(self):
        return self.count

    def insert(self, afterNode, newNode):
        def _insert():
            # None и список пустой, добавьте новый элемент первым в списке
            if afterNode is None and self.len() == 0:
                self.add_in_head(newNode)
                return
            # None и список непустой, добавьте новый элемент последним в списке.
            if afterNode is None and self.len() > 0:
                self.add_in_tail(newNode)
                return
            if afterNode == self.tail:
                self.add_in_tail(newNode)
                return
            
            # 1 -> [2] -> 3
            oldNext = afterNode.next
            afterNode.next = newNode
            newNode.prev = afterNode
            newNode.next = oldNext
            oldNext.prev = newNode
            self.count = self.count + 1
        
        _insert()

    def add_in_head(self, newNode):
        oldHead = self.head
        self.head = newNode
        self.head.next = oldHead
        self.head.prev = None
        if oldHead is None: self.tail = self.head
        else: oldHead.prev = newNode
        self.count = self.count + 1