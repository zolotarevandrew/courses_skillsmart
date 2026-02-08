import unittest

import unittest
from task5 import Queue
from task5_2 import rotate, reverse, StackQueue, CircularQueue


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

class StackQueueTests(unittest.TestCase):
    def test_dequeue_empty_shouldReturnNone(self):
        # Arrange
        queue = StackQueue()

        # Act
        res = queue.dequeue()

        # Assert
        self.assertEqual(0, queue.size())
        self.assertIsNone(res)

    def test_dequeue_oneElement_shouldBeCorrect(self):
        # Arrange
        queue = StackQueue()
        queue.enqueue(1)

        # Act
        res = queue.dequeue()

        # Assert
        self.assertEqual(0, queue.size())
        self.assertEqual(1, res)
        self.assertIsNone(queue.dequeue())

    def test_dequeue_twoElements_shouldBeCorrect(self):
        # Arrange
        queue = StackQueue()
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
        queue = StackQueue()
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
        queue = StackQueue()

        # Act
        queue.enqueue(1)

        # Assert
        self.assertEqual(1, queue.size())

    def test_enqueue_oneElement_shouldBeCorrect(self):
        # Arrange
        queue = StackQueue()
        queue.enqueue(1)

        # Act
        queue.enqueue(2)

        # Assert
        self.assertEqual(2, queue.size())

    def test_enqueue_twoElements_shouldBeCorrect(self):
        # Arrange
        queue = StackQueue()
        queue.enqueue(1)
        queue.enqueue(2)

        # Act
        queue.enqueue(3)

        # Assert
        self.assertEqual(3, queue.size())

    def test_enqueue_threeElements_shouldBeCorrect(self):
        # Arrange
        queue = StackQueue()
        queue.enqueue(1)
        queue.enqueue(2)
        queue.enqueue(3)

        # Act
        queue.enqueue(5)

        # Assert
        self.assertEqual(4, queue.size())

    def test_enqueue_multipleCases_shouldBeCorrect(self):
        # Arrange
        queue = StackQueue()

        # Assert 1 - simple dequeue
        queue.enqueue(25)
        self.assertEqual(1, queue.size())
        res = queue.dequeue()
        self.assertEqual(res, 25)
        self.assertEqual(0, queue.size())
        
        # Assert 2 - two enqueue, sequential dequeue
        queue.enqueue(25)
        queue.enqueue(6)
        self.assertEqual(2, queue.size())
        res = queue.dequeue()
        self.assertEqual(res, 25)
        self.assertEqual(1, queue.size())
        res = queue.dequeue()
        self.assertEqual(res, 6)
        self.assertEqual(0, queue.size())

        # Assert 3 - three sequential enqueue, dequeue
        queue.enqueue(25)
        self.assertEqual(1, queue.size())
        res = queue.dequeue()
        self.assertEqual(res, 25)
        self.assertEqual(0, queue.size())

        queue.enqueue(26)
        self.assertEqual(1, queue.size())
        res = queue.dequeue()
        self.assertEqual(res, 26)
        self.assertEqual(0, queue.size())

        queue.enqueue(27)
        self.assertEqual(1, queue.size())
        res = queue.dequeue()
        self.assertEqual(res, 27)
        self.assertEqual(0, queue.size())

class ReverseQueueTests(unittest.TestCase):
    def test_reverse_oneElement_shouldReturnSameQueue(self):
        # Arrange
        queue = Queue()
        queue.enqueue(1)

        # Act
        res = reverse(queue)  

        # Assert
        self.assertEqual(1, res.size())
        self.assertEqual(1, res.dequeue())

    def test_reverse_empty_shouldReturnSameQueue(self):
        # Arrange
        queue = Queue()

        # Act
        res = reverse(queue)  

        # Assert
        self.assertEqual(0, res.size())
        self.assertIsNone(res.dequeue())

    def test_reverse_twoElements_shouldReturnReversedQueue(self):
        # Arrange
        queue = Queue()
        queue.enqueue(1)
        queue.enqueue(2)

        # Act
        res = reverse(queue)  

        # Assert
        self.assertEqual(2, res.size())
        self.assertEqual(2, res.dequeue())
        self.assertEqual(1, res.dequeue())
        self.assertIsNone(res.dequeue())

    def test_reverse_threeElements_shouldReturnReversedQueue(self):
        # Arrange
        queue = Queue()
        queue.enqueue(1)
        queue.enqueue(2)
        queue.enqueue(3)

        # Act
        res = reverse(queue)  

        # Assert
        self.assertEqual(3, res.size())
        self.assertEqual(3, res.dequeue())
        self.assertEqual(2, res.dequeue())
        self.assertEqual(1, res.dequeue())
        self.assertIsNone(res.dequeue())

class QueueTests(unittest.TestCase):
    def test_multiCases_shouldBeOk(self):
        # Arrange
        queue = CircularQueue(3)
        
        self.assertEqual(0, queue.size())

        #1
        self.assertTrue(queue.enqueue(1))
        self.assertTrue(queue.enqueue(2))
        self.assertTrue(queue.enqueue(3))
        self.assertEqual(3, queue.size())
        self.assertTrue(queue.isFull())
        self.assertEqual(0, queue.head)
        self.assertEqual(0, queue.tail)

        #2
        self.assertEqual(1, queue.dequeue())
        self.assertEqual(2, queue.size())
        self.assertFalse(queue.isFull())
        self.assertEqual(1, queue.head)

        #3
        self.assertEqual(2, queue.dequeue())
        self.assertEqual(1, queue.size())
        self.assertFalse(queue.isFull())
        self.assertEqual(2, queue.head)

        #4
        queue.enqueue(1)
        self.assertEqual(2, queue.size())
        self.assertFalse(queue.isFull())
        self.assertEqual(2, queue.head)
        self.assertEqual(1, queue.tail)

        #5
        queue.enqueue(2)
        self.assertEqual(3, queue.size())
        self.assertTrue(queue.isFull())
        self.assertEqual(2, queue.head)
        self.assertEqual(2, queue.tail)

        #6
        self.assertEqual(3, queue.dequeue())
        self.assertEqual(2, queue.size())
        self.assertFalse(queue.isFull())
        self.assertEqual(0, queue.head)
        self.assertEqual(2, queue.tail)

        #7
        queue.enqueue(3)
        self.assertEqual(3, queue.size())
        self.assertTrue(queue.isFull())
        self.assertEqual(0, queue.head)
        self.assertEqual(0, queue.tail)

        #8 
        self.assertEqual(1,queue.dequeue())
        self.assertEqual(2,queue.size())
        self.assertFalse(queue.isFull())
        self.assertEqual(1, queue.head)
        self.assertEqual(0, queue.tail)

        

if __name__ == "__main__":
    unittest.main()