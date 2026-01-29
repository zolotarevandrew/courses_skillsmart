import unittest
from task3 import DynArray, MIN_ARRAY_SIZE


class Insert_DynArrayTests(unittest.TestCase):
    def test_insert_empty_shouldBeOk(self):
        # Arrange
        s_list = DynArray()
        old_capacity = s_list.capacity

        # Act
        s_list.insert(0, 1)

        # Assert
        self.assertEqual(1, s_list.count)
        self.assertEqual(1, s_list.array[0])
        self.assertEqual(old_capacity, s_list.capacity)

    def test_insert_invalidIndexPositive_shouldThrow(self):
        # Arrange
        s_list = DynArray()

        # Act

        # Assert
        with self.assertRaises(IndexError):
            s_list.insert(1, 1)

    def test_insert_invalidIndexNegative_shouldThrow(self):
        # Arrange
        s_list = DynArray()

        # Act

        # Assert
        with self.assertRaises(IndexError):
            s_list.insert(-1, 1)

    def test_insert_oneElement_idxIsCount_shouldAppend(self):
        # Arrange
        s_list = DynArray()
        old_capacity = s_list.capacity
        s_list.append(1)

        # Act
        s_list.insert(1, 2)

        # Assert
        self.assertEqual(2, s_list.count)
        self.assertEqual(1, s_list.array[0])
        self.assertEqual(2, s_list.array[1])
        self.assertEqual(old_capacity, s_list.capacity)

    def test_insert_twoElements_idxIsCount_shouldAppend(self):
        # Arrange
        s_list = DynArray()
        old_capacity = s_list.capacity
        s_list.append(1)
        s_list.append(2)

        # Act
        s_list.insert(2, 3)

        # Assert
        self.assertEqual(3, s_list.count)
        self.assertEqual(1, s_list.array[0])
        self.assertEqual(2, s_list.array[1])
        self.assertEqual(3, s_list.array[2])
        self.assertEqual(old_capacity, s_list.capacity)

    def test_insert_oneElement_idxZero_shouldInsert(self):
        # Arrange
        s_list = DynArray()
        old_capacity = s_list.capacity
        s_list.append(1)

        # Act
        s_list.insert(0, 3)

        # Assert
        self.assertEqual(2, s_list.count)
        self.assertEqual(3, s_list.array[0])
        self.assertEqual(1, s_list.array[1])
        self.assertEqual(old_capacity, s_list.capacity)

    def test_insert_twoElements_idxLastElement_shouldInsert(self):
        # Arrange
        s_list = DynArray()
        s_list.append(1)
        s_list.append(2)

        # Act
        s_list.insert(1, 3)

        # Assert
        self.assertEqual(3, s_list.count)
        self.assertEqual(1, s_list.array[0])
        self.assertEqual(3, s_list.array[1])
        self.assertEqual(2, s_list.array[2])

    def test_insert_threeElements_idxSecondElement_shouldInsert(self):
        # Arrange
        s_list = DynArray()
        old_capacity = s_list.capacity
        s_list.append(1)
        s_list.append(2)
        s_list.append(3)

        # Act
        s_list.insert(1, 4)

        # Assert
        self.assertEqual(4, s_list.count)
        self.assertEqual(1, s_list.array[0])
        self.assertEqual(4, s_list.array[1])
        self.assertEqual(2, s_list.array[2])
        self.assertEqual(3, s_list.array[3])
        self.assertEqual(old_capacity, s_list.capacity)

    def test_insert_fourElements_idxLastElement_shouldInsert(self):
        # Arrange
        s_list = DynArray()
        s_list.append(1)
        s_list.append(2)
        s_list.append(3)
        s_list.append(4)

        # Act
        s_list.insert(3, 5)

        # Assert
        self.assertEqual(5, s_list.count)
        self.assertEqual(1, s_list.array[0])
        self.assertEqual(2, s_list.array[1])
        self.assertEqual(3, s_list.array[2])
        self.assertEqual(5, s_list.array[3])
        self.assertEqual(4, s_list.array[4])

    def test_insert_16Elements_idxSecondElement_shouldIncreaseCapacity(self):
        # Arrange
        s_list = DynArray()
        oldCapacity = s_list.capacity
        cnt = 16
        for i in range(cnt):
            s_list.append(i)

        # Act
        s_list.insert(1, 145)

        # Assert
        self.assertEqual(cnt + 1, s_list.count)
        self.assertEqual(oldCapacity * 2, s_list.capacity)
        self.assertEqual(145, s_list.array[1])

class Delete_DynArrayTests(unittest.TestCase):

    def test_delete_invalidIndexPositive_shouldThrow(self):
        # Arrange
        s_list = DynArray()

        # Act

        # Assert
        with self.assertRaises(IndexError):
            s_list.delete(1)

    def test_delete_invalidIndexNegative_shouldThrow(self):
        # Arrange
        s_list = DynArray()

        # Act

        # Assert
        with self.assertRaises(IndexError):
            s_list.delete(-1)

    def test_delete_oneElement_idxIsCount_shouldDelete(self):
        # Arrange
        s_list = DynArray()
        old_capacity = s_list.capacity
        s_list.append(1)

        # Act
        s_list.delete(0)

        # Assert
        self.assertEqual(0, s_list.count)
        self.assertEqual(old_capacity, s_list.capacity)

    def test_delete_twoElements_first_shouldDelete(self):
        # Arrange
        s_list = DynArray()
        old_capacity = s_list.capacity
        s_list.append(1)
        s_list.append(2)

        # Act
        s_list.delete(0)

        # Assert
        self.assertEqual(1, s_list.count)
        self.assertEqual(2, s_list[0])
        self.assertEqual(old_capacity, s_list.capacity)

    def test_delete_twoElements_second_shouldDelete(self):
        # Arrange
        s_list = DynArray()
        s_list.append(1)
        s_list.append(2)

        # Act
        s_list.delete(1)

        # Assert
        self.assertEqual(1, s_list.count)
        self.assertEqual(1, s_list[0])
        self.assertEqual(MIN_ARRAY_SIZE, s_list.capacity)

    def test_delete_threeElements_mid_shouldDelete(self):
        # Arrange
        s_list = DynArray()
        s_list.append(1)
        s_list.append(2)
        s_list.append(3)

        # Act
        s_list.delete(1)

        # Assert
        self.assertEqual(2, s_list.count)
        self.assertEqual(1, s_list[0])
        self.assertEqual(3, s_list[1])
        self.assertEqual(MIN_ARRAY_SIZE, s_list.capacity)

    def test_delete_fourElements_beforeLast_shouldDelete(self):
        # Arrange
        s_list = DynArray()
        s_list.append(1)
        s_list.append(2)
        s_list.append(3)
        s_list.append(4)

        # Act
        s_list.delete(2)

        # Assert
        self.assertEqual(3, s_list.count)
        self.assertEqual(1, s_list[0])
        self.assertEqual(2, s_list[1])
        self.assertEqual(4, s_list[2])
        self.assertEqual(MIN_ARRAY_SIZE, s_list.capacity)

    def test_delete_fourElements_last_shouldDelete(self):
        # Arrange
        s_list = DynArray()
        s_list.append(1)
        s_list.append(2)
        s_list.append(3)
        s_list.append(4)

        # Act
        s_list.delete(3)

        # Assert
        self.assertEqual(3, s_list.count)
        self.assertEqual(1, s_list[0])
        self.assertEqual(2, s_list[1])
        self.assertEqual(3, s_list[2])
        self.assertEqual(MIN_ARRAY_SIZE, s_list.capacity)

    def test_delete_manyElements_shouldDeleteAndDecreaseCapacity(self):
        # Arrange
        s_list = DynArray()
        old_capacity = s_list.capacity
        for i in range(18):
            s_list.append(i)

        # Assert
        self.assertEqual(18, s_list.count)
        self.assertEqual(old_capacity * 2, s_list.capacity)

        prevCapacity = s_list.capacity

        s_list.delete(0)
        s_list.delete(1)
        s_list.delete(2)

        self.assertEqual(int(prevCapacity / 1.5), s_list.capacity)

if __name__ == "__main__":
    unittest.main()