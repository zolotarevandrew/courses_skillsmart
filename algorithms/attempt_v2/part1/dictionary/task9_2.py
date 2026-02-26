# порядковый номер самого задания на курсе - 9
#
# номер задачи из задания - 5
#
# краткое название -  Реализуйте словарь с использованием упорядоченного списка по ключу для оптимизации производительности поиска
#
# сложность решения (O-большое)
# временнАя -
# put - хоть и с бинарным поиском, но из-за insert O(N)
# delete - O(log n) за счет бинарного поиска
# get - O(log n) за счет бинарного поиска
# пространственная - O(N) храним в массиве пары

# рефлексия по эталонному варианту решения:
# В данной реализации большинство операций выполняются за O(log n) за счет бинарного поиска индекса для вставки в отсортированном порядке.
# Оптимизаций в таком контексте больше не придумал.



from typing import Generic, TypeVar
from dataclasses import dataclass

V = TypeVar("V")

@dataclass(slots=True)
class Entry(Generic[V]):
    key: str
    value: V

class OrderedListDict:
    def __init__(self):
        self.list: list[Entry[V]] = []

    def contains_key(self, key: str):
        idx = self._searchIndex(key)
        if idx < len(self.list) and self.list[idx].key == key:
            return True
        return False

    def put(self, key: str, value: V):
        entry = Entry(key, value)
        idx = self._searchIndex(key)
        # когда попали на уже существующий ключ
        if idx < len(self.list) and self.list[idx].key == key:
            self.list[idx] = entry
            return
        # вставляем в конец или по нужному индексу
        self.list.insert(idx, entry)

    def get(self, key: str) -> V | None:
        idx = self._searchIndex(key)
        if idx < len(self.list) and self.list[idx].key == key:
            return self.list[idx].value
        return None

    def delete(self, key: str):
        idx = self._searchIndex(key)
        if idx < len(self.list) and self.list[idx].key == key:
            self.list.pop(idx)
            return True
        return False

    def _compare(self, v1: str, v2: str) -> int :
        s1 = ("" if v1 is None else str(v1)).strip()
        s2 = ("" if v2 is None else str(v2)).strip()
        if s1 < s2: return -1
        if s1 > s2: return 1
        return 0

    def _searchIndex(self, key):
        # cnt 0 - 0
        # cnt 1 - 1 [2], idx = 1
        # cnt 4 - 1,2,4,5 [3] idx = 2
        # cnt 4 - 1,2,4,5 [0] idx = 0
        # cnt 4 - 1,2,4,5 [6] idx = 4
        # cnt 4 - 1,2,4,5 [5] idx = 3
        left = 0
        right = len(self.list)
        while left < right:
            mid = (left + right) // 2
            midKey = self.list[mid].key
            compare = self._compare(key, midKey)

            if compare <= 0:
                right = mid
            else:
                left = mid + 1
        return left

# порядковый номер самого задания на курсе - 9
#
# номер задачи из задания - 6
#
# краткое название - Создайте словарь, в котором ключи представлены битовыми строками фиксированной длины. Реализуйте методы добавления, удаления и поиска элементов, используя битовые операции для ускорения работы
#
# сложность решения (O-большое)
# временнАя - O(1) на все операции
# пространственная - O(2^16) ячеек создаем потенциально для индексации в худшем случае

# рефлексия по эталонному варианту решения:
# Сделал какой-то глупенький page table, с двойной индексацией по первым 8 и последним 8 битам.
# На практике такое будет наврядли использовано, а также будет занимать очень много места при более 16 бит.
# В текущей реализации коллизии сведены к минимуму, но жертвуем аллокацией большого количества памяти.

MAX_KEY = (1 << 16) - 1

class BitKeyDict:
    def __init__(self):
        self.list = [None] * 256

    def _checkKey(self, key: int):
        if key < 0 or key > MAX_KEY:
            raise ValueError('Key should be 16 bit')

    def put(self, key: int, value: V):
        self._checkKey(key)
        idx1 = key >> 8
        idx2 = key & 0b11111111

        if self.list[idx1] is None:
            self.list[idx1] = [None] * 256

        self.list[idx1][idx2] = value

    def get(self, key: int) -> V | None:
        self._checkKey(key)
        idx1 = key >> 8
        idx2 = key & 0b11111111
        if self.list[idx1] is None:
            return None
        return self.list[idx1][idx2]

    def delete(self, key: int):
        self._checkKey(key)
        idx1 = key >> 8
        idx2 = key & 0b11111111
        if self.list[idx1] is None:
            return False
        if self.list[idx1][idx2] is None:
            return False
        self.list[idx1][idx2] = None
        return True