import unittest
from task11 import BloomFilter
from task11_2 import merge

def generate_random_strings():
    base = "0123456789"

    for i in range(10):
        yield f'"{base[i:] + base[:i]}"'

class BloomFilterTests(unittest.TestCase):
    def test_hash1_shouldBeCorrect(self):
        # Arrange
        filter = BloomFilter(10)
        for item in generate_random_strings():
            h = filter.hash1(item)
            self.assertTrue(0 <= h < filter._len)

    def test_hash2_shouldBeCorrect(self):
        # Arrange
        filter = BloomFilter(10)
        for item in generate_random_strings():
            h = filter.hash2(item)
            self.assertTrue(0 <= h < filter._len)

    def test_isValue_shouldBeFalse(self):
        # Arrange
        filter = BloomFilter(10)

        # Assert
        self.assertFalse(filter.is_value('12345'))
        self.assertFalse(filter.is_value('1'))
        self.assertFalse(filter.is_value('2'))
        self.assertFalse(filter.is_value('3'))

    def test_isValue_shouldBeTrueAndFalse(self):
        # Arrange
        filter = BloomFilter(10)
        filter.add('12345')
        filter.add('1')

        # Assert
        self.assertTrue(filter.is_value('12345'))
        self.assertTrue(filter.is_value('1'))
        self.assertFalse(filter.is_value('2'))

    def test_isValue_randomElements_shouldBeCorrect(self):
        # Arrange
        filter = BloomFilter(10)
        for item in generate_random_strings():
            filter.add(item)

        for item in generate_random_strings():
            self.assertTrue(filter.is_value(item))

class Merge_BloomFilterTests(unittest.TestCase):
    def test_merge_empty_shouldBeCorrect(self):
        # Arrange
        filter1 = BloomFilter(10)
        filter2 = BloomFilter(10)

        # Act
        res = merge(filter1, filter2)

        # Assert
        self.assertFalse(filter1.is_value('1'))
        self.assertFalse(filter2.is_value('1'))
        self.assertFalse(res.is_value('1'))

    def test_merge_secondEmpty_shouldBeCorrect(self):
        # Arrange
        filter1 = BloomFilter(10)
        filter1.add('1')
        filter2 = BloomFilter(10)

        # Act
        res = merge(filter1, filter2)

        # Assert
        self.assertTrue(filter1.is_value('1'))
        self.assertFalse(filter2.is_value('1'))
        self.assertTrue(res.is_value('1'))

    def test_merge_firstEmpty_shouldBeCorrect(self):
        # Arrange
        filter1 = BloomFilter(10)
        filter2 = BloomFilter(10)
        filter2.add('1')

        # Act
        res = merge(filter1, filter2)

        # Assert
        self.assertFalse(filter1.is_value('1'))
        self.assertTrue(filter2.is_value('1'))
        self.assertTrue(res.is_value('1'))

    def test_merge_notEmpty_shouldBeCorrect(self):
        # Arrange
        filter1 = BloomFilter(10)
        filter1.add('1')
        filter2 = BloomFilter(10)
        filter2.add('1')

        # Act
        res = merge(filter1, filter2)

        # Assert
        self.assertTrue(filter1.is_value('1'))
        self.assertTrue(filter2.is_value('1'))
        self.assertTrue(res.is_value('1'))

    def test_merge_notEmptyMultipleElements_shouldBeCorrect(self):
        # Arrange
        filter1 = BloomFilter(10)
        filter1.add('1')
        filter1.add('3')
        filter2 = BloomFilter(10)
        filter2.add('1')
        filter2.add('2')

        # Act
        res = merge(filter1, filter2)

        # Assert
        self.assertTrue(filter1.is_value('1'))
        self.assertFalse(filter1.is_value('2'))
        self.assertTrue(filter1.is_value('3'))

        self.assertTrue(filter2.is_value('1'))
        self.assertTrue(filter2.is_value('2'))
        self.assertFalse(filter2.is_value('3'))

        self.assertTrue(res.is_value('1'))
        self.assertTrue(res.is_value('2'))
        self.assertTrue(res.is_value('3'))

if __name__ == "__main__":
    unittest.main()