import unittest
from task6 import Deque
from task6_2 import isPalindrome, MinDeque, CircularDeque

class DequeTests(unittest.TestCase):
    def test_removeTailAndHead_empty_shouldReturnNone(self):
        # Arrange
        deque = Deque()

        # Act

        # Assert
        self.assertEqual(0, deque.size())
        self.assertIsNone(deque.removeFront())
        self.assertIsNone(deque.removeTail())

    def test_addTail_empty_shouldBeOk(self):
        # Arrange
        deque = Deque()
        deque.addTail(1)

        # Act

        # Assert
        self.assertEqual(1, deque.size())
        self.assertEqual(1, deque.removeFront())
        self.assertIsNone(deque.removeTail())
        self.assertEqual(0, deque.size())

    def test_addFront_empty_shouldBeOk(self):
        # Arrange
        deque = Deque()
        deque.addFront(1)

        # Act

        # Assert
        self.assertEqual(1, deque.size())
        self.assertEqual(1, deque.removeFront())
        self.assertIsNone(deque.removeTail())
        self.assertEqual(0, deque.size())

    def test_addTail_oneElement_shouldBeOk(self):
        # Arrange
        deque = Deque()
        deque.addFront(2)
        

        # Act
        deque.addTail(1)

        # Assert
        self.assertEqual(2, deque.size())
        self.assertEqual(2, deque.removeFront())
        self.assertEqual(1, deque.size())
        self.assertEqual(1, deque.removeTail())
        self.assertEqual(0, deque.size())

    def test_addFront_empty_shouldBeOk(self):
        # Arrange
        deque = Deque()
        deque.addTail(2)
        

        # Act
        deque.addFront(1)

        # Assert
        self.assertEqual(2, deque.size())
        self.assertEqual(1, deque.removeFront())
        self.assertEqual(1, deque.size())
        self.assertEqual(2, deque.removeTail())
        self.assertEqual(0, deque.size())

    def test_addFront_twoElements_shouldBeOk(self):
        # Arrange
        deque = Deque()
        deque.addTail(2)
        deque.addTail(3)

        # Act
        deque.addFront(1)

        # Assert
        self.assertEqual(3, deque.size())
        self.assertEqual(1, deque.removeFront())
        self.assertEqual(2, deque.size())
        self.assertEqual(3, deque.removeTail())
        self.assertEqual(1, deque.size())
        self.assertEqual(2, deque.removeFront())
        self.assertEqual(0, deque.size())

    def test_addTail_twoElements_shouldBeOk(self):
        # Arrange
        deque = Deque()
        deque.addFront(2)
        deque.addTail(3)

        # Act
        deque.addFront(5)

        # Assert
        self.assertEqual(3, deque.size())
        self.assertEqual(5, deque.removeFront())
        self.assertEqual(2, deque.size())
        self.assertEqual(2, deque.removeFront())
        self.assertEqual(1, deque.size())
        self.assertEqual(3, deque.removeFront())
        self.assertEqual(0, deque.size())

    def test_removeTail_oneElement_shouldBeOk(self):
        # Arrange
        deque = Deque()
        deque.addFront(2)

        # Act
        

        # Assert
        self.assertEqual(1, deque.size())
        self.assertEqual(2, deque.removeTail())
        self.assertEqual(0, deque.size())
        self.assertIsNone(deque.removeFront())
        self.assertIsNone(deque.removeTail())

    def test_removeFront_oneElement_shouldBeOk(self):
        # Arrange
        deque = Deque()
        deque.addTail(2)

        # Act
        

        # Assert
        self.assertEqual(1, deque.size())
        self.assertEqual(2, deque.removeFront())
        self.assertEqual(0, deque.size())
        self.assertIsNone(deque.removeFront())
        self.assertIsNone(deque.removeTail())

    def test_removeTail_twoElements_shouldBeOk(self):
        # Arrange
        deque = Deque()
        deque.addFront(2)
        deque.addTail(1)

        # Act
        

        # Assert
        self.assertEqual(2, deque.size())
        self.assertEqual(1, deque.removeTail())
        self.assertEqual(1, deque.size())
        self.assertEqual(2, deque.removeFront())
        self.assertIsNone(deque.removeTail())

    def test_removeFront_twoElements_shouldBeOk(self):
        # Arrange
        deque = Deque()
        deque.addFront(2)
        deque.addTail(3)

        # Act
        

        # Assert
        self.assertEqual(2, deque.size())
        self.assertEqual(2, deque.removeFront())
        self.assertEqual(1, deque.size())
        self.assertEqual(3, deque.removeFront())
        self.assertIsNone(deque.removeTail())

    def test_removeTail_threeElements_shouldBeOk(self):
        # Arrange
        deque = Deque()
        deque.addFront(2)
        deque.addTail(1)
        deque.addTail(3)

        # Act
        

        # Assert
        self.assertEqual(3, deque.size())
        self.assertEqual(3, deque.removeTail())
        self.assertEqual(2, deque.size())
        self.assertEqual(2, deque.removeFront())
        self.assertEqual(1, deque.size())
        self.assertEqual(1, deque.removeTail())
        self.assertEqual(0, deque.size())

    def test_removeFront_threeElements_shouldBeOk(self):
        # Arrange
        deque = Deque()
        deque.addFront(2)
        deque.addFront(1)
        deque.addFront(3)

        # Act
        

        # Assert
        self.assertEqual(3, deque.size())
        self.assertEqual(3, deque.removeFront())
        self.assertEqual(2, deque.size())
        self.assertEqual(1, deque.removeFront())
        self.assertEqual(1, deque.size())
        self.assertEqual(2, deque.removeFront())
        self.assertEqual(0, deque.size())

class IsPalindromeTests(unittest.TestCase):
    def test_isPalindrome_none_shouldReturnFalse(self):
        # Assert
        self.assertFalse(isPalindrome(None))
    
    def test_isPalindrome_empty_shouldReturnFalse(self):
        # Assert
        self.assertFalse(isPalindrome(''))

    def test_isPalindrome_oneChar_shouldReturnTrue(self):
        # Assert
        self.assertTrue(isPalindrome('1'))

    def test_isPalindrome_twoNotEqualChars_shouldReturnFalse(self):
        # Assert
        self.assertFalse(isPalindrome('12'))

    def test_isPalindrome_twoEqualChars_shouldReturnTrue(self):
        # Assert
        self.assertTrue(isPalindrome('22'))

    def test_isPalindrome_threeDifferentChars_shouldReturnFalse(self):
        # Assert
        self.assertFalse(isPalindrome('123'))

    def test_isPalindrome_threeCharsPalindrome_shouldReturnTrue(self):
        # Assert
        self.assertTrue(isPalindrome('121'))

    def test_isPalindrome_fourDifferentChars_shouldReturnFalse(self):
        # Assert
        self.assertFalse(isPalindrome('1234'))

    def test_isPalindrome_fourChars_shouldReturnFalse(self):
        # Assert
        self.assertFalse(isPalindrome('1231'))

    def test_isPalindrome_fourCharsPalindrome_shouldReturnTrue(self):
        # Assert
        self.assertTrue(isPalindrome('1221'))

class MinDequeTests(unittest.TestCase):
    def test_allCases_shouldBeCorrect(self):
        # Arrange
        deque = MinDeque()

        #1
        self.assertIsNone(deque.min())

        #2
        deque.addFront(3)
        self.assertEqual(3, deque.min())

        #3
        deque.addFront(2)
        self.assertEqual(2, deque.min())

        #4
        deque.addTail(4)
        self.assertEqual(2, deque.min())

        #5
        deque.addTail(5)
        self.assertEqual(2, deque.min())

        #6
        deque.addFront(1)
        self.assertEqual(1, deque.min())

        deque.removeFront()
        self.assertEqual(2, deque.min())

        deque.removeTail()
        self.assertEqual(2, deque.min())

        deque.removeFront()
        self.assertEqual(3, deque.min())

        deque.removeFront()
        self.assertEqual(4, deque.min())

class CircularDequeTests(unittest.TestCase):
    def test_allCases_shouldBeCorrect(self):
        # Arrange
        cap = 3
        deque = CircularDeque(cap)

        #1
        self.assertIsNone(deque.removeFront())
        self.assertIsNone(deque.removeTail())
        self.assertEqual(deque.capacity, cap)

        #2
        deque.addFront(1)
        deque.addFront(2)
        deque.addFront(3)

        self.assertEqual(3, deque.removeFront())
        self.assertEqual(2, deque.removeFront())
        self.assertEqual(1, deque.removeFront())
        self.assertIsNone(deque.removeFront())
        self.assertEqual(deque.capacity, cap)

        #3
        deque.addTail(1)
        deque.addTail(2)
        deque.addTail(3)

        self.assertEqual(3, deque.removeTail())
        self.assertEqual(2, deque.removeTail())
        self.assertEqual(1, deque.removeTail())
        self.assertIsNone(deque.removeTail())
        self.assertEqual(deque.capacity, cap)

        #4
        deque.addTail(1)
        deque.addTail(2)
        deque.addFront(3)

        self.assertEqual(2, deque.removeTail())
        self.assertEqual(1, deque.removeTail())
        self.assertEqual(3, deque.removeTail())
        self.assertIsNone(deque.removeTail())
        self.assertEqual(deque.capacity, cap)

        #5
        deque.addTail(1)
        deque.addTail(2)
        deque.addFront(3)

        self.assertEqual(3, deque.removeFront())
        self.assertEqual(1, deque.removeFront())
        self.assertEqual(2, deque.removeFront())
        self.assertIsNone(deque.removeFront())
        self.assertEqual(deque.capacity, cap)

        #6
        deque.addFront(1)
        deque.addTail(2)
        deque.addFront(3)

        self.assertEqual(3, deque.removeFront())
        self.assertEqual(1, deque.removeFront())
        self.assertEqual(2, deque.removeFront())
        self.assertIsNone(deque.removeFront())
        self.assertEqual(deque.capacity, cap)

        #7
        deque.addFront(1)
        deque.addFront(2)

        self.assertEqual(1, deque.removeTail())
        self.assertEqual(2, deque.removeTail())
        self.assertIsNone(deque.removeTail())
        self.assertEqual(deque.capacity, cap)

        #8
        deque.addTail(1)
        deque.addTail(2)

        self.assertEqual(1, deque.removeFront())
        self.assertEqual(2, deque.removeFront())
        self.assertIsNone(deque.removeFront())
        self.assertEqual(deque.capacity, cap)

        #8
        deque.addTail(1)
        deque.addTail(2)
        deque.addTail(3)
        deque.addTail(4)

        self.assertEqual(1, deque.removeFront())
        self.assertEqual(2, deque.removeFront())
        self.assertEqual(3, deque.removeFront())
        self.assertEqual(4, deque.removeFront())
        self.assertIsNone(deque.removeFront())
        self.assertEqual(deque.capacity, cap * 2)

        #8
        deque.addTail(1)
        deque.addTail(2)
        deque.addFront(3)
        deque.addTail(4)

        self.assertEqual(3, deque.removeFront())
        self.assertEqual(1, deque.removeFront())
        self.assertEqual(2, deque.removeFront())
        self.assertEqual(4, deque.removeFront())
        self.assertIsNone(deque.removeFront())
        self.assertEqual(deque.capacity, cap * 2)

        #9
        deque.addTail(1)
        deque.addFront(2)
        deque.addFront(3)
        deque.addTail(4)

        self.assertEqual(3, deque.removeFront())
        self.assertEqual(2, deque.removeFront())
        self.assertEqual(1, deque.removeFront())
        self.assertEqual(4, deque.removeFront())
        self.assertIsNone(deque.removeFront())
        self.assertEqual(deque.capacity, cap * 2)

        #9
        deque.addFront(1)
        deque.addFront(2)
        deque.addTail(3)
        deque.addTail(4)

        self.assertEqual(2, deque.removeFront())
        self.assertEqual(1, deque.removeFront())
        self.assertEqual(3, deque.removeFront())
        self.assertEqual(4, deque.removeFront())
        self.assertIsNone(deque.removeFront())
        self.assertEqual(deque.capacity, cap * 2)

        #10
        deque.addFront(1)
        deque.addFront(2)
        deque.addFront(3)
        deque.addFront(4)

        self.assertEqual(4, deque.removeFront())
        self.assertEqual(3, deque.removeFront())
        self.assertEqual(2, deque.removeFront())
        self.assertEqual(1, deque.removeFront())
        self.assertIsNone(deque.removeFront())
        self.assertEqual(deque.capacity, cap * 2)
        

if __name__ == "__main__":
    unittest.main()