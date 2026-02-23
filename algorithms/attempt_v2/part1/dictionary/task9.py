class NativeDictionary:
    def __init__(self, sz):
        self.size = sz
        self.slots = [None] * self.size
        self.values = [None] * self.size

    def hash_fun(self, key):
        h = hash(key)
        return h % self.size

    def is_key(self, key):
        slot = self.hash_fun(key)
        step = self._step(key)
        for i in range(self.size):
            idx = (slot + i * step) % self.size
            if self.slots[idx] is None: return False
            if self.slots[idx] == key: return True
        return False

    def put(self, key, value):
        slot = self.hash_fun(key)
        step = self._step(key)
        for i in range(self.size):
            idx = (slot + i * step) % self.size
            if self.slots[idx] is None or self.slots[idx] == key:
                self.slots[idx] = key
                self.values[idx] = value
                break

    def get(self, key):
        slot = self.hash_fun(key)
        step = self._step(key)
        for i in range(self.size):
            idx = (slot + i * step) % self.size
            if self.slots[idx] is None: return None
            if self.slots[idx] == key: return self.values[idx]
        return None

    def _step(self, key):
        if self.size < 2: return 1
        salt = 0x9E3779B97F4A7C15
        return 1 + (hash((key, salt)) % (self.size - 1))