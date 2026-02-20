import unittest
from task8 import HashTable

class HashTableTests(unittest.TestCase):
    def test_hashFun_shouldFoundSlot(self):
        # Arrange
        sz = 3
        hash_table = HashTable(sz, 1)
        for item in ['1', '2', '3', '4', '5', '6', '222', '332321', '131313123131', 'asdasdbaw11']:
            h = hash_table.hash_fun(item)
            self.assertTrue(0 <= h < sz)

    def test_put_empty_shouldFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        slot = hash_table.put('1')
        self.assertIsNotNone(slot)
        self.assertEqual(hash_table.slots[slot], '1')

    def test_put_oneElement_shouldFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        slot = hash_table.put('1')
        self.assertIsNotNone(slot)
        self.assertEqual(hash_table.slots[slot], '1')

        slot = hash_table.put('2')
        self.assertIsNotNone(slot)
        self.assertEqual(hash_table.slots[slot], '2')

    def test_put_twoElements_shouldFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        slot = hash_table.put('1')
        self.assertIsNotNone(slot)
        self.assertEqual(hash_table.slots[slot], '1')

        slot = hash_table.put('2')
        self.assertIsNotNone(slot)
        self.assertEqual(hash_table.slots[slot], '2')

        slot = hash_table.put('3')
        self.assertIsNotNone(slot)
        self.assertEqual(hash_table.slots[slot], '3')

    def test_put_fourElements_shouldNotFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        slot = hash_table.put('1')
        self.assertIsNotNone(slot)
        self.assertEqual(hash_table.slots[slot], '1')

        slot = hash_table.put('2')
        self.assertIsNotNone(slot)
        self.assertEqual(hash_table.slots[slot], '2')

        slot = hash_table.put('3')
        self.assertIsNotNone(slot)
        self.assertEqual(hash_table.slots[slot], '3')

        slot = hash_table.put('4')
        self.assertIsNone(slot)

    def test_seek_empty_shouldFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        self.assertIsNotNone(hash_table.seek_slot('1'))

    def test_seek_oneElement_shouldFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        hash_table.put('1')
        self.assertIsNotNone(hash_table.seek_slot('2'))

    def test_seek_twoElements_shouldFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        hash_table.put('1')
        hash_table.put('2')
        self.assertIsNotNone(hash_table.seek_slot('3'))

    def test_seek_full_shouldNotFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        hash_table.put('1')
        hash_table.put('2')
        hash_table.put('3')
        self.assertIsNone(hash_table.seek_slot('4'))

    def test_find_empty_shouldNotFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        slot = hash_table.find('abc')
        self.assertIsNone(slot)

    def test_find_oneElement_shouldNotFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        hash_table.put('2')
        slot = hash_table.find('abc')
        self.assertIsNone(slot)

    def test_find_oneElement_shouldFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        hash_table.put('2')
        slot = hash_table.find('2')
        self.assertIsNotNone(slot)

    def test_find_twoElements_shouldNotFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        hash_table.put('1')
        hash_table.put('2')
        slot = hash_table.find('3')
        self.assertIsNone(slot)

    def test_find_twoElements_shouldFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        hash_table.put('1')
        hash_table.put('2')
        slot = hash_table.find('1')
        self.assertIsNotNone(slot)

    def test_find_threeElements_shouldNotFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        hash_table.put('1')
        hash_table.put('2')
        hash_table.put('3')
        slot = hash_table.find('4')
        self.assertIsNone(slot)

    def test_find_threeElements_shouldFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        hash_table.put('1')
        hash_table.put('2')
        hash_table.put('3')

        slot = hash_table.find('1')
        self.assertIsNotNone(slot)

        slot = hash_table.find('2')
        self.assertIsNotNone(slot)

        slot = hash_table.find('3')
        self.assertIsNotNone(slot)

    def test_putWithCollisions_shouldBeCorrect(self):
        # Arrange
        hash_table = HashTable(6, 2)
        hash_table.hash_fun = lambda _: 0

        self.assertEqual(0, hash_table.put('1'))
        self.assertEqual(2, hash_table.put('2'))
        self.assertEqual(4, hash_table.put('3'))
        self.assertIsNone(hash_table.put('4'))


if __name__ == "__main__":
    unittest.main()