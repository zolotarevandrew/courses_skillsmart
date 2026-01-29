import ctypes

MIN_ARRAY_SIZE = 16

class DynArray:
    
    def __init__(self):
        self.count = 0
        self.capacity = MIN_ARRAY_SIZE
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
        if self.count == self.capacity:
            self.resize(2*self.capacity)
        self.array[self.count] = itm
        self.count += 1

    # временная сложность - O(N), в худшем случае из-за resize и/или сдвига
    def insert(self, i, itm):
        if i < 0 or i > self.count:
            raise IndexError('Index is out of bounds')
        if i == self.count:
            self.append(itm)
            return
        if self.count == self.capacity:
            self.resize(2*self.capacity)

        for idx in range(self.count, i, -1):
            self.array[idx] = self.array[idx-1]

        self.array[i] = itm
        self.count += 1

    # временная сложность - O(N), в худшем случае из-за resize и/или сдвига
    def delete(self, i):
        if i < 0 or i >= self.count:
            raise IndexError('Index is out of bounds')

        for idx in range(i, self.count - 1):
            self.array[idx] = self.array[idx+1]
        
        self.array[self.count-1] = None
        self.count -= 1

        fillCapacity = (self.count / self.capacity) * 100
        if fillCapacity < 50:
            decreased_capacity = max(MIN_ARRAY_SIZE, int(self.capacity / 1.5))
            self.resize(decreased_capacity)