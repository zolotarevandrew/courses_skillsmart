import unittest

import unittest
from task5 import Queue
from task5_2 import rotate


class QueueTests(unittest.TestCase):
    def test_dequeue_empty_shouldReturnNone(self):
        # Arrange
        queue = Queue()

        # Act
        res = queue.dequeue()

        # Assert
        self.assertEqual(0, queue.size())
        self.assertIsNone(res)

    def test_dequeue_oneElement_shouldBeCorrect(self):
        # Arrange
        queue = Queue()
        queue.enqueue(1)

        # Act
        res = queue.dequeue()

        # Assert
        self.assertEqual(0, queue.size())
        self.assertEqual(1, res)
        self.assertIsNone(queue.dequeue())

    def test_dequeue_twoElements_shouldBeCorrect(self):
        # Arrange
        queue = Queue()
        queue.enqueue(1)
        queue.enqueue(2)

        # Act
        res = queue.dequeue()

        # Assert
        self.assertEqual(1, res)
        self.assertEqual(1, queue.size())
        self.assertEqual(2, queue.dequeue())
        self.assertIsNone(queue.dequeue())

    def test_dequeue_threeElements_shouldBeCorrect(self):
        # Arrange
        queue = Queue()
        queue.enqueue(1)
        queue.enqueue(2)
        queue.enqueue(3)

        # Act
        res = queue.dequeue()

        # Assert
        self.assertEqual(1, res)
        self.assertEqual(2, queue.size())
        self.assertEqual(2, queue.dequeue())
        self.assertEqual(3, queue.dequeue())
        self.assertIsNone(queue.dequeue())
    
    def test_enqueue_empty_shouldBeCorrect(self):
        # Arrange
        queue = Queue()

        # Act
        queue.enqueue(1)

        # Assert
        self.assertEqual(1, queue.size())

    def test_enqueue_oneElement_shouldBeCorrect(self):
        # Arrange
        queue = Queue()
        queue.enqueue(1)

        # Act
        queue.enqueue(2)

        # Assert
        self.assertEqual(2, queue.size())

    def test_enqueue_twoElements_shouldBeCorrect(self):
        # Arrange
        queue = Queue()
        queue.enqueue(1)
        queue.enqueue(2)

        # Act
        queue.enqueue(3)

        # Assert
        self.assertEqual(3, queue.size())

    def test_enqueue_threeElements_shouldBeCorrect(self):
        # Arrange
        queue = Queue()
        queue.enqueue(1)
        queue.enqueue(2)
        queue.enqueue(3)

        # Act
        queue.enqueue(5)

        # Assert
        self.assertEqual(4, queue.size())


class RotateTests(unittest.TestCase):
    def test_rotate_emptyInvalidPositiveK_shouldThrow(self):
        # Arrange
        queue = Queue()

        # Assert
        with self.assertRaises(ValueError):
            res = rotate(queue, 1)

    def test_rotate_oneElementInvalidPositiveK_shouldThrow(self):
        # Arrange
        queue = Queue()
        queue.enqueue(1)

        # Assert
        with self.assertRaises(ValueError):
            res = rotate(queue, 2)    

    def test_rotate_oneElementInvalidNegativeK_shouldThrow(self):
        # Arrange
        queue = Queue()
        queue.enqueue(1)

        # Assert
        with self.assertRaises(ValueError):
            res = rotate(queue, -1)

    def test_rotate_oneElementInvalidNegativeK_shouldThrow(self):
        # Arrange
        queue = Queue()
        queue.enqueue(1)

        # Assert
        with self.assertRaises(ValueError):
            res = rotate(queue, -1)  

    def test_rotate_oneElement_shouldReturnSameQueue(self):
        # Arrange
        queue = Queue()
        queue.enqueue(1)

        # Act
        res = rotate(queue, 1)  

        # Assert
        self.assertEqual(1, res.size())
        self.assertEqual(1, res.dequeue())

    def test_rotate_empty_shouldReturnSameQueue(self):
        # Arrange
        queue = Queue()

        # Act
        res = rotate(queue, 0)

        # Assert
        self.assertEqual(0, res.size())
        self.assertIsNone(res.dequeue())

    def test_rotate_twoElementsOneShift_shouldReturnShiftedQueue(self):
        # Arrange
        queue = Queue()
        queue.enqueue(1)
        queue.enqueue(2)

        # Act
        res = rotate(queue, 1)

        # Assert
        self.assertEqual(2, res.size())
        self.assertEqual(2, res.dequeue())
        self.assertEqual(1, res.dequeue())
        self.assertIsNone(res.dequeue())

    def test_rotate_twoElementsTwoShifts_shouldReturnShiftedQueue(self):
        # Arrange
        queue = Queue()
        queue.enqueue(1)
        queue.enqueue(2)

        # Act
        res = rotate(queue, 2)

        # Assert
        self.assertEqual(2, res.size())
        self.assertEqual(1, res.dequeue())
        self.assertEqual(2, res.dequeue())
        self.assertIsNone(res.dequeue())

    def test_rotate_threeElementsOneShift_shouldReturnShiftedQueue(self):
        # Arrange
        queue = Queue()
        queue.enqueue(1)
        queue.enqueue(2)
        queue.enqueue(3)

        # Act
        res = rotate(queue, 1)

        # Assert
        self.assertEqual(3, res.size())
        self.assertEqual(3, res.dequeue())
        self.assertEqual(1, res.dequeue())
        self.assertEqual(2, res.dequeue())
        self.assertIsNone(res.dequeue())

    def test_rotate_threeElementsTwoShifts_shouldReturnShiftedQueue(self):
        # Arrange
        queue = Queue()
        queue.enqueue(1)
        queue.enqueue(2)
        queue.enqueue(3)

        # Act
        res = rotate(queue, 2)

        # Assert
        self.assertEqual(3, res.size())
        self.assertEqual(2, res.dequeue())
        self.assertEqual(3, res.dequeue())
        self.assertEqual(1, res.dequeue())
        self.assertIsNone(res.dequeue())

    def test_rotate_threeElementsThreeShifts_shouldReturnShiftedQueue(self):
        # Arrange
        queue = Queue()
        queue.enqueue(1)
        queue.enqueue(2)
        queue.enqueue(3)

        # Act
        res = rotate(queue, 3)

        # Assert
        self.assertEqual(3, res.size())
        self.assertEqual(1, res.dequeue())
        self.assertEqual(2, res.dequeue())
        self.assertEqual(3, res.dequeue())
        self.assertIsNone(res.dequeue())
if __name__ == "__main__":
    unittest.main()