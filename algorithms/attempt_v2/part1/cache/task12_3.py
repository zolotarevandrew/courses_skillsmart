import unittest
from task12 import NativeCache, TOMBSTONE


class ClearMinElement_NativeCacheTests(unittest.TestCase):
    def test_noElements_shouldBeCorrect(self):
        # Arrange
        cache = NativeCache(10)

        # Act
        cache._clearMinElement()

        # Assert
        self.assertEqual(0, cache.hits[0])
        self.assertEqual(TOMBSTONE, cache.slots[0])
        self.assertEqual(None, cache.values[0])

    def test_clearAll_shouldBeCorrect(self):
        # Arrange
        cache = NativeCache(3)
        cache.set('1', '2')
        cache.set('2', '3')
        cache.set('3', '4')

        # Act
        self.assertEqual(3, cache.count)
        cache._clearMinElement()
        cache._clearMinElement()
        cache._clearMinElement()
        idx1 = cache._hash_fun('1')
        idx2 = cache._hash_fun('2')
        idx3 = cache._hash_fun('3')

        cache._clearMinElement()
        cache._clearMinElement()

        # Assert
        self.assertEqual(0, cache.hits[idx1])
        self.assertEqual(TOMBSTONE, cache.slots[idx1])
        self.assertEqual(None, cache.values[idx1])

        self.assertEqual(0, cache.hits[idx2])
        self.assertEqual(TOMBSTONE, cache.slots[idx2])
        self.assertEqual(None, cache.values[idx2])

        self.assertEqual(0, cache.hits[idx3])
        self.assertEqual(TOMBSTONE, cache.slots[idx3])
        self.assertEqual(None, cache.values[idx3])

        self.assertEqual(0, cache.count)

    def test_hasThreeElements_shouldClearElementWithLeastHits(self):
        # Arrange
        cache = NativeCache(3)
        cache.set('1', '2')
        cache.get('1')
        cache.get('1')
        cache.get('1')

        cache.set('2', '3')
        cache.get('2')
        cache.get('2')

        cache.set('3', '4')
        cache.get('3')

        # Act
        self.assertEqual(3, cache.count)
        cache._clearMinElement()

        # Assert
        for i in range(cache.size):
            if cache.slots[i] is TOMBSTONE:
                self.assertEqual(TOMBSTONE, cache.slots[i])
                self.assertEqual(None, cache.values[i])
                self.assertEqual(0, cache.hits[i])
                self.assertIsNone(cache.get('3'))
            if cache.hits[i] == 2:
                self.assertEqual('3', cache.get('2'))

            if cache.hits[i] == 3:
                self.assertEqual('2', cache.get('1'))

        self.assertEqual(2, cache.count)

    def test_hasOneElement_shouldClear(self):
        # Arrange
        cache = NativeCache(3)
        cache.set('1', '2')

        # Act
        self.assertEqual(1, cache.count)
        cache._clearMinElement()

        # Assert
        for i in range(cache.size):
            if cache.slots[i] is TOMBSTONE:
                self.assertEqual(TOMBSTONE, cache.slots[i])
                self.assertEqual(None, cache.values[i])
                self.assertEqual(0, cache.hits[i])
                self.assertIsNone(cache.get('1'))

        self.assertEqual(0, cache.count)

    def test_hasFourElements_shouldClearElementWithLeastHits(self):
        # Arrange
        cache = NativeCache(10)
        cache.set('1', '2')
        cache.get('1')
        cache.get('1')
        cache.get('1')

        cache.set('2', '3')
        cache.get('2')
        cache.get('2')

        cache.set('3', '4')
        cache.get('3')

        cache.set('4', '5')
        cache.get('4')
        cache.get('4')
        cache.get('4')

        # Act
        self.assertEqual(4, cache.count)
        cache._clearMinElement()

        # Assert
        for i in range(cache.size):
            if cache.slots[i] is TOMBSTONE:
                self.assertEqual(TOMBSTONE, cache.slots[i])
                self.assertEqual(None, cache.values[i])
                self.assertEqual(0, cache.hits[i])
            if cache.hits[i] == 2:
                self.assertEqual('3', cache.get('2'))

            if cache.hits[i] == 3:
                self.assertEqual('2', cache.get('1'))
                self.assertEqual('5', cache.get('4'))

        self.assertEqual(3, cache.count)

class Get_NativeCacheTests(unittest.TestCase):
    def test_noElements_shouldBeCorrect(self):
        # Arrange
        cache = NativeCache(3)

        # Act
        cache.get('1')
        cache.get('2')
        cache.get('3')
        cache.get('4')

        # Assert
        for i in range(cache.size):
            self.assertEqual(0, cache.hits[i])
            self.assertEqual(None, cache.slots[i])
            self.assertEqual(None, cache.values[i])

    def test_oneElement_shouldBeCorrect(self):
        # Arrange
        cache = NativeCache(10)
        cache.set('1', '2')

        # Act
        cache.get('1')
        cache.get('2')
        cache.get('3')
        cache.get('4')

        # Assert
        for i in range(cache.size):
            if cache.hits[i] == 1:
                self.assertEqual('1', cache.slots[i])
                self.assertEqual('2', cache.values[i])
            else:
                self.assertEqual(0, cache.hits[i])
                self.assertEqual(None, cache.slots[i])
                self.assertEqual(None, cache.values[i])

    def test_twoElements_shouldBeCorrect(self):
        # Arrange
        cache = NativeCache(10)
        cache.set('1', '2')
        cache.set('2', '3')

        # Act
        cache.get('1')
        cache.get('2')
        cache.get('2')
        cache.get('3')
        cache.get('4')

        # Assert
        for i in range(cache.size):
            if cache.hits[i] == 1:
                self.assertEqual('1', cache.slots[i])
                self.assertEqual('2', cache.values[i])
            elif cache.hits[i] == 2:
                self.assertEqual('2', cache.slots[i])
                self.assertEqual('3', cache.values[i])
            else:
                self.assertEqual(0, cache.hits[i])
                self.assertEqual(None, cache.slots[i])
                self.assertEqual(None, cache.values[i])

    def test_twoElementsWithDeleted_shouldBeCorrect(self):
        # Arrange
        cache = NativeCache(10)
        cache.set('1', '2')
        cache.set('2', '3')
        cache.set('3', '4')
        cache.set('4', '5')

        # Act
        cache.get('1')
        cache.get('2')
        cache.get('2')

        cache._clearMinElement()
        cache._clearMinElement()


        # Assert
        self.assertIsNone(cache.get('3'))
        self.assertIsNone(cache.get('4'))
        for i in range(cache.size):
            if cache.hits[i] == 1:
                self.assertEqual('1', cache.slots[i])
                self.assertEqual('2', cache.values[i])
            elif cache.hits[i] == 2:
                self.assertEqual('2', cache.slots[i])
                self.assertEqual('3', cache.values[i])
            else:
                self.assertEqual(0, cache.hits[i])
                self.assertTrue(cache.slots[i] is TOMBSTONE or cache.slots[i] is None)
                self.assertEqual(None, cache.values[i])

        self.assertEqual('2', cache.get('1'))
        self.assertEqual('3', cache.get('2'))

class Set_NativeCacheTests(unittest.TestCase):
    def test_noElements_shouldBeCorrect(self):
        # Arrange
        cache = NativeCache(3)

        # Act
        self.assertEqual(0, cache.count)
        cache.set('1', '2')

        # Assert
        self.assertEqual(1, cache.count)
        self.assertEqual('2', cache.get('1'))
        self.assertIsNone(cache.get('4'))

    def test_oneElement_shouldBeCorrect(self):
        # Arrange
        cache = NativeCache(3)
        cache.set('1', '2')

        # Act
        cache.set('2', '3')

        # Assert
        self.assertEqual(2, cache.count)
        self.assertEqual('2', cache.get('1'))
        self.assertEqual('3', cache.get('2'))
        self.assertIsNone(cache.get('3'))

    def test_twoElements_shouldBeCorrect(self):
        # Arrange
        cache = NativeCache(3)
        cache.set('1', '2')
        cache.set('2', '3')

        # Act
        cache.set('3', '4')

        # Assert
        self.assertEqual(3, cache.count)
        self.assertEqual('2', cache.get('1'))
        self.assertEqual('3', cache.get('2'))
        self.assertEqual('4', cache.get('3'))

    def test_threeElements_shouldClear(self):
        # Arrange
        cache = NativeCache(3)
        cache.set('1', '2')
        cache.get('1')
        cache.set('2', '3')
        cache.get('2')
        cache.get('2')
        cache.set('3', '4')

        # Act
        cache.set('4', '5')
        self.assertEqual(3, cache.count)
        self.assertEqual('5', cache.get('4')) # 0
        self.assertEqual('2', cache.get('1')) # 1
        self.assertEqual('3', cache.get('2')) # 2

        cache.get('4')
        cache.get('4')
        cache.get('4')

        cache.set('5', '6')
        self.assertEqual(3, cache.count)
        self.assertEqual('6', cache.get('5')) # 0
        self.assertEqual('5', cache.get('4')) # 3
        self.assertEqual('3', cache.get('2')) # 2

        cache.get('5')
        cache.get('5')
        cache.get('5')
        cache.get('5')

        cache.set('6', '7')
        self.assertEqual(3, cache.count)
        self.assertEqual('7', cache.get('6'))
        self.assertEqual('5', cache.get('4'))
        self.assertEqual('6', cache.get('5'))

    def test_sizeTen_shouldAddAll(self):
        # Arrange
        cache = NativeCache(10)
        cache.set('1', '2')
        cache.get('1')
        cache.set('2', '3')
        cache.get('2')
        cache.get('2')
        cache.set('3', '4')

        # Act
        cache.set('4', '5')
        self.assertEqual(4, cache.count)


        cache.set('5', '6')
        self.assertEqual(5, cache.count)

        cache.get('5')
        cache.get('5')
        cache.get('5')
        cache.get('5')

        cache.set('6', '7')
        self.assertEqual(6, cache.count)

    def test_collisionsSizeSeven_shouldBeCorrect(self):
        # Arrange
        cache = NativeCache(7)
        hashes = {}
        hashes['1'] = 0
        hashes['2'] = 0
        hashes['3'] = 0

        hashes['4'] = 1
        hashes['5'] = 1

        hashes['6'] = 2
        hashes['7'] = 2

        cache._hash_fun = lambda x: hashes[x] if x in hashes else 4
        cache._step = lambda key: 1

        cache.set('1', '11')
        cache.set('2', '22')
        cache.set('3', '33')
        cache.set('4', '44')
        cache.set('5', '55')
        cache.set('6', '66')
        cache.set('7', '77')

        # Act
        self.assertEqual(7, cache.count)

        cache.get('3')
        cache.set('1114', '555')

        self.assertEqual(7, cache.count)

        self.assertEqual('555', cache.get('1114'))
        self.assertEqual('22', cache.get('2'))
        self.assertEqual('33', cache.get('3'))
        self.assertEqual('44', cache.get('4'))
        self.assertEqual('55', cache.get('5'))
        self.assertEqual('66', cache.get('6'))
        self.assertEqual('77', cache.get('7'))

        cache.get('1114')
        cache.get('2')
        cache.get('3')
        cache.get('4')
        cache.get('5')
        cache.get('6')

        cache.set('1115', '556')

        self.assertEqual(7, cache.count)

        self.assertEqual('555', cache.get('1114'))
        self.assertEqual('22', cache.get('2'))
        self.assertEqual('33', cache.get('3'))
        self.assertEqual('44', cache.get('4'))
        self.assertEqual('55', cache.get('5'))
        self.assertEqual('66', cache.get('6'))
        self.assertEqual('556', cache.get('1115'))

        cache._clearMinElement()
        cache._clearMinElement()

        self.assertEqual(5, cache.count)
        self.assertEqual('22', cache.get('2'))
        self.assertEqual('33', cache.get('3'))
        self.assertEqual('44', cache.get('4'))
        self.assertEqual('55', cache.get('5'))
        self.assertEqual('66', cache.get('6'))

        cache._clearMinElement()
        self.assertEqual(4, cache.count)
        self.assertEqual('33', cache.get('3'))
        self.assertEqual('44', cache.get('4'))
        self.assertEqual('55', cache.get('5'))
        self.assertEqual('66', cache.get('6'))

        cache.set('235', '532')
        cache.set('abc', 'def')
        self.assertEqual(6, cache.count)

        self.assertEqual('532', cache.get('235'))
        self.assertEqual('def', cache.get('abc'))
        self.assertEqual('33', cache.get('3'))
        self.assertEqual('33', cache.get('3'))
        self.assertEqual('44', cache.get('4'))
        self.assertEqual('55', cache.get('5'))
        self.assertEqual('66', cache.get('6'))

if __name__ == "__main__":
    unittest.main()