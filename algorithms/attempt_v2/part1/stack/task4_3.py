import unittest

import unittest
from task4 import Stack


class StackTests(unittest.TestCase):
    def test_pop_empty_shouldReturnNone(self):
        # Arrange
        stack = Stack()

        # Act
        res = stack.pop()

        # Assert
        self.assertEqual(0, stack.size())
        self.assertIsNone(res)

    def test_pop_oneElement_shouldBeCorrect(self):
        # Arrange
        stack = Stack()
        stack.push(1)

        # Act
        res = stack.pop()

        # Assert
        self.assertEqual(0, stack.size())
        self.assertEqual(1, res)
        self.assertIsNone(stack.pop())

    def test_pop_twoElements_shouldBeCorrect(self):
        # Arrange
        stack = Stack()
        stack.push(1)
        stack.push(2)

        # Act
        res = stack.pop()

        # Assert
        self.assertEqual(2, res)
        self.assertEqual(1, stack.size())
        self.assertEqual(1, stack.pop())

    def test_pop_threeElements_shouldBeCorrect(self):
        # Arrange
        stack = Stack()
        stack.push(1)
        stack.push(2)
        stack.push(3)

        # Act
        res = stack.pop()

        # Assert
        self.assertEqual(3, res)
        self.assertEqual(2, stack.size())
        self.assertEqual(2, stack.pop())
        self.assertEqual(1, stack.pop())

    def test_peek_empty_shouldReturnNone(self):
        # Arrange
        stack = Stack()

        # Act
        res = stack.peek()

        # Assert
        self.assertEqual(0, stack.size())
        self.assertIsNone(res)

    def test_peek_oneElement_shouldBeCorrect(self):
        # Arrange
        stack = Stack()
        stack.push(1)

        # Act
        res = stack.peek()

        # Assert
        self.assertEqual(1, stack.size())
        self.assertEqual(1, res)

    def test_peek_twoElements_shouldBeCorrect(self):
        # Arrange
        stack = Stack()
        stack.push(1)
        stack.push(12)

        # Act
        res = stack.peek()

        # Assert
        self.assertEqual(12, res)
        self.assertEqual(2, stack.size())

    def test_peek_threeElements_shouldBeCorrect(self):
        # Arrange
        stack = Stack()
        stack.push(1)
        stack.push(2)
        stack.push(23)

        # Act
        res = stack.peek()

        # Assert
        self.assertEqual(23, res)
        self.assertEqual(3, stack.size())

    
    def test_push_empty_shouldBeCorrect(self):
        # Arrange
        stack = Stack()

        # Act
        stack.push(1)

        # Assert
        self.assertEqual(1, stack.size())
        self.assertEqual(1, stack.peek())

    def test_push_oneElement_shouldBeCorrect(self):
        # Arrange
        stack = Stack()
        stack.push(1)

        # Act
        stack.push(2)

        # Assert
        self.assertEqual(2, stack.size())
        self.assertEqual(2, stack.peek())

    def test_pop_twoElements_shouldBeCorrect(self):
        # Arrange
        stack = Stack()
        stack.push(1)
        stack.push(2)

        # Act
        stack.push(3)

        # Assert
        self.assertEqual(3, stack.size())
        self.assertEqual(3, stack.peek())

    def test_push_threeElements_shouldBeCorrect(self):
        # Arrange
        stack = Stack()
        stack.push(1)
        stack.push(2)
        stack.push(3)

        # Act
        stack.push(5)

        # Assert
        self.assertEqual(4, stack.size())
        self.assertEqual(5, stack.peek())
        


if __name__ == "__main__":
    unittest.main()