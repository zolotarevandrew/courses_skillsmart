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

import math


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


# порядковый номер самого задания на курсе - 8
#
# номер задачи из задания - 4
#
# краткое название - Реализуйте хэш-таблицу, которая использует несколько хэш-функций для каждой операции вставки, чтобы уменьшить вероятность коллизий
#
# сложность решения (O-большое)
# временнАя - как в основной реализации
# пространственная - как в основной реализации

# рефлексия по эталонному варианту решения:
# Сделал простые тесты по количеству коллизий и времени обработки.
# Выводы следующие - double hashing при линейном пробировании в сравнении с обычным линейным пробированием:
# - не уступает в скорости
# - сильно уменьшает количество коллизий (среднее, максимальное, и перцентели 95/99) даже при высоком load factor, что очень важно.
# И базовый вывод важно выбирать ту реализацию хэш таблиц, которая лучше подходит под конкретный тип нагрузки (цепочки/открытая адресация или другие методы).

class CollisionDetector:
    def __init__(self):
        self.clear()

    def add(self, numberOfTries):
        self.list.append(numberOfTries)
        self.max = max(self.max, numberOfTries)

    def clear(self):
        self.list = []
        self.max = 0

    def average(self):
        return sum(self.list) / len(self.list) if self.list else 0.0

    def percentile(self, p):
        if not self.list:
            return 0
        xs = sorted(self.list)
        if p <= 0: return xs[0]
        if p >= 100: return xs[-1]
        k = math.ceil((p / 100) * len(xs)) - 1
        return xs[k]

    def maximum(self):
        return max(self.list) if self.list else 0

class OneHashTable:
    def __init__(self, sz, stp, collisionDetector: CollisionDetector):
        self.size = sz
        self.step = stp
        self.collisionDetector = collisionDetector
        self.slots = [None] * self.size

    def hash_fun(self, value):
        h = hash(value)
        return abs(h % self.size)

    def seek_slot(self, value):
        slot = self.hash_fun(value)

        for i in range(self.size):
            cur = (slot + i * self.step) % self.size
            if self.slots[cur] is None:
                self.collisionDetector.add(i)
                return cur

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

class TwoHashTable:
    def __init__(self, sz, collisionDetector: CollisionDetector, salt = 123456789):
        self.size = sz
        self.collisionDetector = collisionDetector
        self.slots = [None] * self.size
        self.salt = salt

    def hash1(self, value) -> int:
        return hash(value) % self.size

    def hash2(self, value) -> int:
        return 1 + (hash((value, self.salt)) % (self.size - 1))

    def seek_slot(self, value):
        slot = self.hash1(value)
        step = self.hash2(value)

        for i in range(self.size):
            cur = (slot + i * step) % self.size
            if self.slots[cur] is None:
                self.collisionDetector.add(i)
                return cur

        return None

    def put(self, value):
        slot = self.seek_slot(value)
        if slot is None: return None
        self.slots[slot] = value
        return slot

    def find(self, value):
        slot = self.hash1(value)
        step = self.hash2(value)

        for i in range(self.size):
            cur = (slot + i * step) % self.size
            if self.slots[cur] == value: return cur

        return None


# порядковый номер самого задания на курсе - 8
#
# номер задачи из задания - 5
#
# краткое название - Организуйте ddos-атаку на вашу исходную хэш-таблицу -- с помощью специально сгенерированных ключей, вызывающих большое число коллизий
#
# сложность решения (O-большое)
# временнАя - как в основной реализации
# пространственная - как в основной реализации

# рефлексия по эталонному варианту решения:
# Написал функцию ddosHashTable которая генерирует 10 миллионов рандомных строк размера 32 и пытается перебрать хэш.
# Для OneHashTable смогло найти 1000-1200 возможных значений для одного хэша.
# Далее запустил CollisionDetector для OneHashTable и получил следующий результат
# DDOS collisions for one hash table : avg=572.000000, p50=572, p95=1087, p99=1133, max=1144, time=0.041s, n=8000, load=0.8
# огромное количество коллизий, как и ожидалось за счет ранее подобранных значений.
# Далее сделал новую реализацию SaltHashTable на основе OneHashTable, просто добавив соли к хэшу h ^= self.salt
# Само значение соли взял как "The Golden Ratio constant for hashing"
# DDOS collisions for SALT hash table : avg=0.923144, p50=1, p95=3, p99=4, max=7, time=0.001s, n=8000, load=0.8
# Видно, что количество коллизий снизилось до абсолютного минимума, как и ожидалось.
# В python и .net, стандартный хэш работает по разному при перезапуске процесса, поскольку в него уже вшит соль/seed.
# Кажется, что перебрать будет достаточно тяжело, хоть и возможно.
# Эксперимент был интересным.

import random
import string
import time

def _generate_random_strings(cnt, min_len=1, max_len=32):
    alphabet = string.ascii_letters + string.digits

    for _ in range(cnt):
        n = random.randint(min_len, max_len)
        yield ''.join(random.choice(alphabet) for _ in range(n))

def ddosHashTable(hash_table):
    buckets = {}

    for item in _generate_random_strings(10_000_000, 32, 32):
        h = hash_table.hash_fun(item)
        buckets.setdefault(h, []).append(item)

    mx = []
    for key in buckets:
        lst = buckets[key]
        if len(lst) > len(mx):
            mx = lst
    return mx

class SaltHashTable:
    def __init__(self, sz, stp, collisionDetector: CollisionDetector, salt = 0x9E3779B97F4A7C15):
        self.size = sz
        self.step = stp
        self.salt = salt
        self.collisionDetector = collisionDetector
        self.slots = [None] * self.size

    def hash_fun(self, value):
        h = hash(value)
        h ^= self.salt
        return h % self.size

    def seek_slot(self, value):
        slot = self.hash_fun(value)

        for i in range(self.size):
            cur = (slot + i * self.step) % self.size
            if self.slots[cur] is None:
                self.collisionDetector.add(i)
                return cur

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