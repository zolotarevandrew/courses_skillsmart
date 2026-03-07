TOMBSTONE = object()

class NativeCache:
    def __init__(self, sz):
        self.size = sz
        self.slots = [None] * self.size
        self.values = [None] * self.size
        self.hits = [0] * self.size
        self.count = 0

    def set(self, key, value):
        if self.count == self.size:
            self._clearMinElement()

        first_tombstone = None
        slot = self._hash_fun(key)
        step = self._step(key)
        for i in range(self.size):
            idx = (slot + i * step) % self.size

            if self.slots[idx] is None:
                insertIdx = first_tombstone if first_tombstone is not None else idx
                self._insert(insertIdx, key, value)
                return
            if self.slots[idx] is TOMBSTONE:
                if first_tombstone is None:
                    first_tombstone = idx
                continue
            if self.slots[idx] == key:
                self.slots[idx] = key
                self.values[idx] = value
                return
        if first_tombstone is not None:
            self._insert(first_tombstone, key, value)

    def get(self, key):
        slot = self._hash_fun(key)
        step = self._step(key)
        for i in range(self.size):
            idx = (slot + i * step) % self.size
            if self.slots[idx] is None: return None
            if self.slots[idx] is TOMBSTONE: continue
            if self.slots[idx] == key:
                self._addHit(idx)
                return self.values[idx]
        return None

    def _step(self, key):
        if self.size < 2: return 1
        salt = 0x9E3779B97F4A7C15
        return 1 + (hash((key, salt)) % (self.size - 1))

    def _hash_fun(self, key):
        h = hash(key)
        return h % self.size

    def _addHit(self, idx):
        self.hits[idx] += 1

    def _insert(self, idx, key, value):
        self.slots[idx] = key
        self.values[idx] = value
        self.count += 1

    def _clearMinElement(self):
        minHitIdx = 0
        minHitValue = None
        for i in range(self.size):
            if self.slots[i] is None or self.slots[i] is TOMBSTONE:
                continue
            hit = self.hits[i]
            if minHitValue is None or hit < minHitValue:
                minHitValue = hit
                minHitIdx = i

        self.slots[minHitIdx] = TOMBSTONE
        self.hits[minHitIdx] = 0
        self.values[minHitIdx] = None

        if self.count > 0:
            self.count -= 1
