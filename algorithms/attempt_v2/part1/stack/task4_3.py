import unittest

import unittest
from task4 import Stack
from task4_2 import checkBrackets,postfixExpression


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

    def test_push_twoElements_shouldBeCorrect(self):
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
        
class CheckBracketTests(unittest.TestCase):
    def test_check_none_shouldReturnFalse(self):
        # Arrange

        # Act

        # Assert
        self.assertFalse(checkBrackets(None))

    def test_check_empty_shouldReturnFalse(self):
        # Arrange

        # Act

        # Assert
        self.assertFalse(checkBrackets(''))

    def test_check_invalidChar_shouldReturnFalse(self):
        # Arrange

        # Act

        # Assert
        self.assertFalse(checkBrackets('1'))

    def test_check_invalidCharWithValidBrackets_shouldReturnFalse(self):
        # Arrange

        # Act

        # Assert
        self.assertFalse(checkBrackets('(1)'))

    def test_check_invalidCharWithValidBrackets_shouldReturnFalse(self):
        # Arrange

        # Act

        # Assert
        self.assertFalse(checkBrackets('(1)'))

    def test_check_validBracketsOne_shouldReturnTrue(self):
        # Arrange

        # Act

        # Assert
        self.assertTrue(checkBrackets('()'))
        self.assertTrue(checkBrackets('{}'))
        self.assertTrue(checkBrackets('[]'))

    def test_check_validBracketsNested_shouldReturnTrue(self):
        # Arrange

        # Act

        # Assert
        self.assertTrue(checkBrackets('(())'))
        self.assertTrue(checkBrackets('((()))'))
        self.assertTrue(checkBrackets('[([{}])]'))
        self.assertTrue(checkBrackets('({})'))

    def test_check_invalidBrackets_shouldReturnFalse(self):
        # Arrange

        # Act

        # Assert
        self.assertFalse(checkBrackets('(('))
        self.assertFalse(checkBrackets('(()'))
        self.assertFalse(checkBrackets('{{}'))
        self.assertFalse(checkBrackets('[[]'))
        self.assertFalse(checkBrackets('())'))
        self.assertFalse(checkBrackets('}}'))
        self.assertFalse(checkBrackets('}{'))
        self.assertFalse(checkBrackets(']]'))
        self.assertFalse(checkBrackets('[{([})}]'))

class PostfixExpressionTests(unittest.TestCase):
    def test_postfixExpression_none_shouldReturnNone(self):
        self.assertIsNone(postfixExpression(None))

    def test_postfixExpression_empty_shouldReturnNone(self):
        self.assertIsNone(postfixExpression(''))

    def test_postfixExpression_spaces_shouldReturnNone(self):
        self.assertIsNone(postfixExpression(' '))

    def test_postfixExpression_invalidOperatorOnly_shouldReturnNone(self):
        with self.assertRaises(ValueError):
            postfixExpression('+')

    def test_postfixExpression_invalidDigitsOnly_shouldReturnNone(self):
        with self.assertRaises(ValueError):
            postfixExpression('1 2')

    def test_postfixExpression_invalidExpression_shouldReturnNone(self):
        with self.assertRaises(ValueError):
            postfixExpression('8 10 + 9 / -')

    def test_postfixExpression_valid1_shouldReturnOk(self):
        self.assertEqual(59, postfixExpression('8 2 + 5 * 9 +'))

    def test_postfixExpression_valid2_shouldReturnOk(self):
        self.assertEqual(39, postfixExpression('8 2 - 5 * 9 +'))

    def test_postfixExpression_valid3_shouldReturnOk(self):
        self.assertEqual(2, postfixExpression('8 10 + 9 /'))

if __name__ == "__main__":
    unittest.main()