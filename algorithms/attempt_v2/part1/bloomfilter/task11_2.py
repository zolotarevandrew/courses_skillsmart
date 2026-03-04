# порядковый номер самого задания на курсе - 11
#
# номер задачи из задания - 2
#
# краткое название - Напишите алгоритм слияния нескольких фильтров Блюма (одинакового размера и с одинаковым набором хэш-функций)
#
# сложность решения (O-большое)
# временнАя - O(1) побитовое или
# пространственная - O(1) выделили одно  число

# рефлексия по эталонному варианту решения:
# Вероятность ложного срабатывания для итогового фильтра увеличится, потому что элементов в нем станет примерно filter1.length + filter2.length

from task11 import BloomFilter

def merge(filter1: BloomFilter, filter2: BloomFilter) -> BloomFilter:
    res = BloomFilter(filter1.filter_len)
    val = filter1._value | filter2._value
    res._value = val
    return res


# порядковый номер самого задания на курсе - 11
#
# номер задачи из задания - 3
#
# краткое название - Реализуйте фильтр Блюма, предусматривающий удаление элементов (стандартный фильтр Блюма удаление не поддерживает). Учтите, что при удалении несуществующих элементов (с ложноположительным результатом проверки их наличия) структура фильтра нарушается и могут удаляться другие входные значения.
#
# сложность решения (O-большое)
# временнАя - O(1) все операции
# Конечно здесь нужно было бы учитывать и количество хэш функций и сложность конкретных хэш функций - но сокращаем до O(1) для упрощения
# пространственная - O(N) храним уже массив значений

# рефлексия по эталонному варианту решения:
#

class ExtendedBloomFilter:
    def __init__(self, f_len):
        self.filter_len = f_len
        self._len = 32
        self._values = [0] * self._len


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
        hash2Idx = self.hash2(str1)
        self._values[hash1Idx] += 1
        self._values[hash2Idx] += 1

    def remove(self, str1):
        hash1Idx = self.hash1(str1)
        hash2Idx = self.hash2(str1)
        if self._values[hash1Idx] > 0:
            self._values[hash1Idx] -= 1
        if self._values[hash2Idx] > 0:
            self._values[hash2Idx] -= 1


    def is_value(self, str1):
        hash1Idx = self.hash1(str1)
        hash2Idx = self.hash2(str1)
        return self._values[hash1Idx] > 0 and self._values[hash2Idx] > 0