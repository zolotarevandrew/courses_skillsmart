class Node:

    def __init__(self, v):
        self.value = v
        self.next = None

class LinkedList:

    def __init__(self):
        self.clean()

    def add_in_tail(self, item):
        if self.head is None:
            self.head = item
        else:
            self.tail.next = item
        self.tail = item
        self.count = self.count + 1

    def print_all_nodes(self):
        node = self.head
        while node != None:
            print(node.value)
            node = node.next

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

        def _deleteNode(selectedNode: Node, prevNode: Node):
            # [1]
            # [1] -> 2
            # [1] -> 2 -> 3
            if selectedNode == self.head:
                self.head = self.head.next
                if self.head is None: self.tail = None
                return
            # 1 -> [2]
            # 1 -> 2 -> [3]
            if selectedNode == self.tail:
                self.tail = prevNode
                self.tail.next = None
                return
            
            # 1 -> [2] -> 3
            prevNode.next = selectedNode.next
            selectedNode.next = None

        node = self.head
        prev = None

        while node is not None:
            next = node.next
            if node.value == val:
                _deleteNode(node, prev)
                self.count = self.count - 1
                if all == False: 
                    break
                if all == True:
                    node = next
                    continue
            prev = node
            node = next

    def clean(self):
        self.head = None
        self.tail = None
        self.count = 0

    def len(self):
        return self.count

    def insert(self, afterNode, newNode):

        def _insert():
            shouldAddAsFirst = afterNode is None
            if shouldAddAsFirst:
                curHead = self.head
                self.head = newNode
                self.head.next = curHead
                if curHead is None: 
                    self.tail = self.head
                self.count = self.count + 1
                return
            if afterNode == self.tail:
                self.add_in_tail(newNode)
                return
            # 1 -> [2] -> 3
            oldNext = afterNode.next
            afterNode.next = newNode
            newNode.next = oldNext
            self.count = self.count + 1
        
        _insert()

