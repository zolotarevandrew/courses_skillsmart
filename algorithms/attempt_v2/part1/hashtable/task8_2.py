# порядковый номер самого задания на курсе - 8
#
# номер задачи из задания - 3
#
# краткое название -  Реализуйте динамическую хэш-таблицу, которая автоматически удваивает свой размер, если уровень заполненности превышает заданный порог (например, 75%).
#Реализация должна корректно перераспределять все элементы в новую, более крупную хэш-таблицу с минимальными затратами по времени.
#
# сложность решения (O-большое)
# временнАя - grow - O(N) проходимся по всем слотам, чтобы сделать rehash
# НО важно заметить, что это если мы считаем саму хэш функцию за O(1). Но это далеко не всегда так.
# Дополнительная оптимизация, храним хэш вместе с самим элементом, чтобы при GROW рехешинг был всегда O(1)
# пространственная - grow - O(N) в самом методе аллоцируем новый массив.

# рефлексия по эталонному варианту решения:
# Подумал над двумя базовыми вариантами
# 1) не рехешировать все сразу, а делать по требованию (put/find) - но это более сложная реализация.
# 2) рехешировать всю таблицу за O(N). Посмотрел, microsoft делает также для своего Hashset, Hashtable.
# И они как раз сохраняют изначальный хэш вместе с элементом, что бы при grow его еще раз не пересчитывать.

GROW_PERCENT = 75

class HashTable:
    def __init__(self, sz, stp):
        self.size = sz
        self.step = stp
        self.slots = [None] * self.size
        self.count = 0

    def hash_fun(self, value):
        h = hash(value)
        return h % self.size

    def seek_slot(self, value):
        res = self._seek_slot(value)
        if res is None: return None
        return res[0]

    def _seek_slot(self, value):
        h = hash(value)
        slot = h % self.size

        for i in range(self.size):
            cur = (slot + i * self.step) % self.size
            if self.slots[cur] is None: return (cur, h)

        return None

    def put(self, value):
        fillCapacity =  (self.count / self.size) * 100
        if fillCapacity >= GROW_PERCENT:
            self._grow()

        slot = self._seek_slot(value)
        if slot is None: return None
        self.slots[slot[0]] = (value, slot[1])
        self.count += 1
        return slot[0]

    def find(self, value):
        h = hash(value)
        slot = h % self.size

        for i in range(self.size):
            cur = (slot + i * self.step) % self.size
            if self.slots[cur] is None: return None
            if self.slots[cur][0] == value: return cur

        return None

    def _grow(self):
        new_size = self.size * 2
        new_slots = [None] * new_size

        for i in range(self.size):
            val = self.slots[i]
            if val is None: continue

            slot = self._seek_new_slot(val, new_size, new_slots)
            if slot is None:
                raise ValueError('invalid slot in rehash')
            new_slots[slot] = val


        self.size = new_size
        self.slots = new_slots

    def _seek_new_slot(self, value, newSize, newSlots):
        slot = value[1] % newSize

        for i in range(newSize):
            cur = (slot + i * self.step) % newSize
            if newSlots[cur] is None: return cur

        return None

