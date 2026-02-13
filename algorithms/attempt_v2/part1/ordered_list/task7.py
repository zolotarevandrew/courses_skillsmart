class Node:
    def __init__(self, v):
        self.value = v
        self.prev = None
        self.next = None

class OrderedList:
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
            return
        
        # <- 1
        headCompare = self.compare(_insertNode.value, self.head.value)
        shouldAddInHead = (headCompare <= 0) if self.__ascending else (headCompare >= 0)
        if shouldAddInHead:
            self._insert(None, _insertNode)
            return
        
        # 1 ->
        tailCompare = self.compare(_insertNode.value, self.tail.value)
        shouldAddInTail = (tailCompare >= 0) if self.__ascending else (tailCompare <= 0)
        if shouldAddInTail:
            self._insert(self.tail, _insertNode)
            return

        # 1 -> 2 -> 3
        node: Node = self.head.next
        while node != None:
            nodeCompare = self.compare(_insertNode.value, node.value)
            shouldAddBeforeNode = (nodeCompare <= 0) if self.__ascending else (nodeCompare >= 0)
            if shouldAddBeforeNode:
                self._insert(node.prev, _insertNode)
                break
            node = node.next
        

    def find(self, val):
        node: Node = self.head
        while node != None:
            nodeCompare = self.compare(val, node.value)
            shouldSkip = (nodeCompare < 0) if self.__ascending else (nodeCompare > 0)
            if shouldSkip: return None
            if nodeCompare == 0: return node
            node = node.next
        return None

    def delete(self, val):
        node: Node = self.head
        while node != None:
            if self.compare(val, node.value) == 0:
                self._deleteNode(node)
                self.count -= 1
                break
            node = node.next

    def clean(self, asc):
        self.head = None
        self.tail = None
        self.__ascending = asc
        self.count = 0

    def len(self):
        return self.count

    def get_all(self):
        r = []
        node = self.head
        while node != None:
            r.append(node)
            node = node.next
        return r
    
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

class OrderedStringList(OrderedList):
    def __init__(self, asc):
        super(OrderedStringList, self).__init__(asc)

    def compare(self, v1, v2):
        s1 = ("" if v1 is None else str(v1)).strip()
        s2 = ("" if v2 is None else str(v2)).strip()
        if s1 < s2: return -1
        if s1 > s2: return 1
        return 0