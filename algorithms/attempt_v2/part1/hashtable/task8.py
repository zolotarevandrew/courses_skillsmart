class HashTable:
    def __init__(self, sz, stp):
        self.size = sz
        self.step = stp
        self.slots = [None] * self.size

    def hash_fun(self, value):
        h = hash(value)
        return abs(h % self.size)

    def seek_slot(self, value):
        slot = self.hash_fun(value)

        for i in range(self.size):
            cur = (slot + i * self.step) % self.size
            if self.slots[cur] is None: return cur

        return None

    def put(self, value):
        slot = self.seek_slot(value)
        if slot is None: return None
        self.slots[slot] = value
        return slot

    def find(self, value):
        slot = self.hash_fun(value)

        for i in range(self.size):
            cur = (slot + i * self.step) % self.size
            if self.slots[cur] == value: return cur

        return None