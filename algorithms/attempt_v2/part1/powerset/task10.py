from typing import Any
from __future__ import annotations

class PowerSet:

    def __init__(self) -> None:
        self.set = {}

    def size(self) -> int:
        return len(self.set)

    def put(self, value: Any) -> None:
        self.set[value] = True

    def get(self, value: Any) -> bool:
        return value in self.set

    def remove(self, value: Any) -> bool:
        if value in self.set:
            del self.set[value]
            return True
        return False

    def intersection(self, set2: PowerSet) -> PowerSet:
        res = PowerSet()
        for key in self.set:
            if set2.get(key):
                res.put(key)
        return res

    def union(self, set2: PowerSet) -> PowerSet:
        res = PowerSet()
        for key in self.set:
            res.put(key)
        for key in set2.set:
            res.put(key)
        return res

    def difference(self, set2: PowerSet) -> PowerSet:
        # 1 2 3 4 5
        # 5 4 3
        res = PowerSet()
        for key in self.set:
            if not set2.get(key):
                res.put(key)
        return res

    def issubset(self, set2: PowerSet) -> bool:
        for key in set2.set:
            if not self.get(key): return False
        return True

    def equals(self, set2: PowerSet) -> bool:
        if self.size() != set2.size():
            return False

        return self.issubset(set2)