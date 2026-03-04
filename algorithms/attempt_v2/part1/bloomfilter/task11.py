class BloomFilter:
    def __init__(self, f_len):
        self.filter_len = f_len
        self._len = 32
        self._value = 0


    def hash1(self, str1):
        res = 0
        rnd = 17
        for c in str1:
            code = ord(c)
            res = (res * rnd + code) % self._len
        return res

    def hash2(self, str1):
        res = 0
        rnd = 223
        for c in str1:
            code = ord(c)
            res = (res * rnd + code) % self._len
        return res

    def add(self, str1):
        hash1Idx = self.hash1(str1)
        self._set(hash1Idx)
        hash2Idx = self.hash2(str1)
        self._set(hash2Idx)

    def is_value(self, str1):
        hash1Idx = self.hash1(str1)
        if not self._get(hash1Idx):
            return False

        hash2Idx = self.hash2(str1)
        if not self._get(hash2Idx):
            return False

        return True

    def _set(self, idx):
        mask = 1 << idx
        self._value |= mask

    def _get(self, idx):
        mask = 1 << idx
        return (self._value & mask) != 0