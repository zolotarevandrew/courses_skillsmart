# порядковый номер самого задания на курсе - 3
#
# номер задачи из задания - 5
#
# краткое название - Реализуйте динамический массив на основе банковского метода.
#
# сложность решения (O-большое) 
# временнАя - 
# append - O(1) амортизационно
# insert - O(N) из-за сдвигов
# пространственная - O(N) количество элементов массива
#
# рефлексия по эталонному варианту решения:
# Не совсем понял назначение банковского метода, с точки зрения реализации динамического массива.
# Видно, что он показывает - за счет большого количества небольших операций, дорогие операции по resize реально дешевле, чем говорит "агрегированный метод".
# И тогда операция Append - реально не будет O(N), а амортизированно O(1).
# Можно пытаться аллоцировать заранее, за счет анализа списаний и текущего баланса - но эффективность такого решения сомнительна, ее нужно доказать и
# и она может быть эффективна только в специфичных узких кейсах.
# в .net реализации используется обычное удвоение размера массива. 
# Иногда проще будет использовать и переиспользовать заранее аллоцированный массив - пулы массивов. 
# Или разработать специфичное работающее решение.
MIN_ARRAY_SIZE = 16

import ctypes

class BankDynArray:
    
    def __init__(self):
        self.count = 0
        self.capacity = MIN_ARRAY_SIZE
        self.bank = 0
        self.array = self.make_array(self.capacity)

    def __len__(self):
        return self.count

    def make_array(self, new_capacity):
        return (new_capacity * ctypes.py_object)()

    def __getitem__(self,i):
        if i < 0 or i >= self.count:
            raise IndexError('Index is out of bounds')
        return self.array[i]

    def resize(self, new_capacity):
        new_array = self.make_array(new_capacity)
        for i in range(self.count):
            new_array[i] = self.array[i]
        self.array = new_array
        self.capacity = new_capacity

    def append(self, itm):
        self.bank += 3
        if self.count == self.capacity:
            self.bank -= self.capacity
            self.resize(2*self.capacity)
        self.array[self.count] = itm
        self.bank -= 1
        self.count += 1
        assert self.bank >= 0

    def insert(self, i, itm):
        if i < 0 or i > self.count:
            raise IndexError('Index is out of bounds')
        if i == self.count:
            self.append(itm)
            return
        
        self.bank += 3
        if self.count == self.capacity:
            self.bank -= self.capacity
            self.resize(2*self.capacity)

        for idx in range(self.count, i, -1):
            self.array[idx] = self.array[idx-1]

        moved = self.count - i
        self.bank -= moved
        self.array[i] = itm
        self.bank -= 1
        self.count += 1
        assert self.bank >= 0


# порядковый номер самого задания на курсе - 3
#
# номер задачи из задания - 6
#
# краткое название - Реализуйте многомерный динамический массив.
#
# сложность решения (O-большое) 
# временнАя - 
# удаление - O(d) - проходимся вглубь на размер dimension.
# вставка - O(d + (i - проходы для вставок)) - проходимся вглубь на размер dimension + O(d) памяти на стэк.
# пространственная - O( sizes[0] * sizes[1] * sizes[n])
#
# рефлексия по эталонному варианту решения:
# 1) Получился какой-то странный массив. Поскольку не совсем понятен контекст использования, и как должны расширяться измерения.
# Апи упрощенное - вставка всегда добавляет подмассивы, даже если их не было, то есть расширяет на нужный размер.
# А удаление, просто очищает сам элемент, не сдвигая структуру, не удаляя лишние пустые подмассивы.
# В продакшене такое использовать не буду :) 
# 2) Была идея использовать обычный 1d массив, и получать индексы математически по сдвигам. Но это сильно плохая затея - будут сильно большие массивы.
# в .net такие массивы могут уйти в LOH - и висеть там бесконечно.
# 3) Еще была идея представить в виде дерева - где измерение 0 = уровень дерева + 1, корень пустой.
# Ноды на одном уровне связаны друг с другом как LinkedList и хранятся у родителя, также быстрого доступа по индексам. 
# Минусы здесь тоже очевидны - количество элементов в каждой Ноде дерева, должно быть примерно одного размера.
# А если юзер захочет вставлять в конкретную ноду, то может быть "hot" Нода, с кучей элементов - что опять приведет к разбуханию одного конкретного массива.
# Тогда нужно обдумывать стратегию переноса/"балансировки", в том числе для удаления.
# Вопросов много, ответов мало - здесь нужно исходить от требований и конкретных кейсов использования.

class DimensionalDynArray:
    
    def __init__(self, sizes: list[int]):
        self.sizes = sizes
        self._validateSizes()
        self.dimensions = len(sizes)
        self.count = 0
        self.array = self._makeArray()

    def _validateSizes(self):
        if len(self.sizes) == 0:
            raise ValueError("There can't be empty dimensional array")
        for s in self.sizes:
            if s < 0:
                raise ValueError("Dimension must be >= 0")
        # Здесь еще может оказаться так, что если предыдущее значение 0, а следующее не 0, то всеравно в итоге создастся 0, но это и нормально.
            
    def _makeArray(self):
        def run(sizeIdx):
            if sizeIdx == len(self.sizes):
                return None
            curArr = [None] * self.sizes[sizeIdx]
            for i in range(len(curArr)):
                curArr[i] = run(sizeIdx+1)
            return curArr

        return run(0)
    
    def delete(self, path):
        if len(path) != self.dimensions:
            raise ValueError(f"path length must be = {self.dimensions}")
        for s in path:
            if s < 0:
                raise ValueError("Dimension must be >= 0")
            
        cur = self.array
        for idx in path[:-1]:
            if not isinstance(cur, list) or idx < 0 or idx >= len(cur):
                return False
            cur = cur[idx]

        idx = path[-1]
        if not isinstance(cur, list) or idx < 0 or idx >= len(cur):
            return False
        
        cur[idx] = None
        return True
    
    def insert(self, path, item):
        if len(path) != self.dimensions:
            raise ValueError(f"path length must be = {self.dimensions}")
        for s in path:
            if s < 0:
                raise ValueError("Dimension must be >= 0")
        self._set(path, item)

    def _set(self, path, item):
        def run(pathIdx, curArr):
            idx = path[pathIdx]
            isLast = pathIdx == len(path) - 1

            while len(curArr) <= idx:
                curArr.append(None if isLast else [])

            if isLast:
                curArr[idx] = item
                return

            run(pathIdx+1, curArr[idx])

        run(0, self.array)
        


    


