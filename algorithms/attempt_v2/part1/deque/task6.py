class Deque:
    def __init__(self):
        self.queue = []

    def addFront(self, item):
        self.queue.insert(0, item)

    def addTail(self, item):
        self.queue.append(item)

    def removeFront(self):
        if self.size() == 0:
            return None
        return self.queue.pop(0)

    def removeTail(self):
        if self.size() == 0:
            return None
        return self.queue.pop()

    def size(self):
        return len(self.queue)