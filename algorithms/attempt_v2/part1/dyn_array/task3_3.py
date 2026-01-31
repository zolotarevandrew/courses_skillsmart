import unittest
from task3 import DynArray, MIN_ARRAY_SIZE
from task3_2 import DimensionalDynArray


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

class DimensionalDynArray_Tests(unittest.TestCase):

    def test_create_invalidSizes_shouldThrow(self):
        # Arrange

        # Assert
        with self.assertRaises(ValueError):
            s_list = DimensionalDynArray([-1,2,3])

    def test_create_emptySizes_shouldThrow(self):
        # Arrange

        # Assert
        with self.assertRaises(ValueError):
            s_list = DimensionalDynArray([])

    def test_create_oneDimension_shouldBeOk(self):
        # Arrange
        sizes = [2]
        s_list = DimensionalDynArray(sizes)

        #Act
        self.assertEqual(2, len(s_list.array))

    def test_create_twoDimensions_shouldBeOk(self):
        # Arrange
        sizes = [2, 5]
        s_list = DimensionalDynArray(sizes)

        #Act
        self.assertEqual(2, len(s_list.array))
        self.assertEqual(5, len(s_list.array[0]))
        self.assertEqual(5, len(s_list.array[1]))

    def test_create_threeDimensions_shouldBeOk(self):
        # Arrange
        sizes = [2, 5, 4]
        s_list = DimensionalDynArray(sizes)

        #Act
        self.assertEqual(2, len(s_list.array))
        self.assertEqual(5, len(s_list.array[0]))
        self.assertEqual(5, len(s_list.array[1]))

        self.assertEqual(4, len(s_list.array[0][0]))
        self.assertIsNone(s_list.array[0][0][0])
        self.assertIsNone(s_list.array[0][0][1])
        self.assertIsNone(s_list.array[0][0][2])
        self.assertIsNone(s_list.array[0][0][3])

        self.assertEqual(4, len(s_list.array[0][1]))
        self.assertEqual(4, len(s_list.array[0][2]))
        self.assertEqual(4, len(s_list.array[0][3]))
        self.assertEqual(4, len(s_list.array[0][4]))
        

        self.assertEqual(4, len(s_list.array[1][0]))
        self.assertEqual(4, len(s_list.array[1][1]))
        self.assertEqual(4, len(s_list.array[1][2]))
        self.assertEqual(4, len(s_list.array[1][3]))
        self.assertEqual(4, len(s_list.array[1][4]))

    def test_insert_oneDimension_shouldBeOk(self):
        # Arrange
        sizes = [0]
        s_list = DimensionalDynArray(sizes)
        self.assertEqual(0, len(s_list.array))

        s_list.insert((0,), 2)
        self.assertEqual(1, len(s_list.array))
        self.assertEqual(2, len(s_list.array[0]))
    
    def test_insert_oneDimension_shouldNotAdd(self):
        # Arrange
        sizes = [1]
        s_list = DimensionalDynArray(sizes)
        self.assertEqual(1, len(s_list.array))

        s_list.insert((0,), 3)
        self.assertEqual(1, len(s_list.array))
        self.assertEqual(3, s_list.array[0])

    def test_insert_oneDimension_shouldBeOk(self):
        # Arrange
        sizes = [1]
        s_list = DimensionalDynArray(sizes)
        self.assertEqual(1, len(s_list.array))

        s_list.insert((1,),2)
        self.assertEqual(2, len(s_list.array))
        self.assertIsNone(s_list.array[0])
        self.assertEqual(2, s_list.array[1])

    def test_insert_oneDimension_shouldBeOk(self):
        # Arrange
        sizes = [1]
        s_list = DimensionalDynArray(sizes)
        self.assertEqual(1, len(s_list.array))

        s_list.insert((3,), 2)
        self.assertEqual(4, len(s_list.array))
        self.assertIsNone(s_list.array[0])
        self.assertIsNone(s_list.array[1])
        self.assertIsNone(s_list.array[2])
        self.assertEqual(2, s_list.array[3])

    def test_insert_twoDimensions_shouldBeOk(self):
        # Arrange
        sizes = [0, 0]
        s_list = DimensionalDynArray(sizes)
        self.assertEqual(0, len(s_list.array))

        s_list.insert((0,1), 1)
        self.assertEqual(1, len(s_list.array))
        self.assertEqual(2, len(s_list.array[0]))
        self.assertIsNone(s_list.array[0][0])
        self.assertEqual(1, s_list.array[0][1])

    def test_insert_twoDimensions_shouldBeOk(self):
        # Arrange
        sizes = [1, 2]
        s_list = DimensionalDynArray(sizes)
        self.assertEqual(1, len(s_list.array))
        self.assertEqual(2, len(s_list.array[0]))

        s_list.insert((0,1), 2)
        self.assertEqual(1, len(s_list.array))
        self.assertIsNone(s_list.array[0][0])
        self.assertEqual(2, s_list.array[0][1])

    def test_ensurePathExists_twoDimensions_shouldBeOk(self):
        # Arrange
        sizes = [1, 2]
        s_list = DimensionalDynArray(sizes)
        self.assertEqual(1, len(s_list.array))
        self.assertEqual(2, len(s_list.array[0]))

        s_list.insert((1,2), 5)
        self.assertEqual(2, len(s_list.array))
        self.assertEqual(2, len(s_list.array[0]))
        self.assertIsNone(s_list.array[0][0])
        self.assertIsNone(s_list.array[0][1])
        self.assertEqual(3, len(s_list.array[1]))
        self.assertIsNone(s_list.array[1][0])
        self.assertIsNone(s_list.array[1][1])
        self.assertEqual(5, s_list.array[1][2])

    def test_insert_threeDimensions_shouldBeOk(self):
        # Arrange
        sizes = [0, 0, 0]
        s_list = DimensionalDynArray(sizes)
        self.assertEqual(0, len(s_list.array))

        s_list.insert((0,0,0), 1)
        self.assertEqual(1, len(s_list.array))
        self.assertEqual(1, len(s_list.array[0]))
        self.assertEqual(1, len(s_list.array[0][0]))
        self.assertEqual(1, s_list.array[0][0][0])

    def test_insert_threeDimensions_shouldBeOk(self):
        # Arrange
        sizes = [1, 2, 0]
        s_list = DimensionalDynArray(sizes)
        self.assertEqual(1, len(s_list.array))
        self.assertEqual(2, len(s_list.array[0]))
        self.assertEqual(0, len(s_list.array[0][0]))
        self.assertEqual(0, len(s_list.array[0][1]))

        s_list._set((0,1,0), 5)
        self.assertEqual(1, len(s_list.array))
        self.assertEqual(2, len(s_list.array[0]))
        self.assertEqual(0, len(s_list.array[0][0]))
        self.assertEqual(1, len(s_list.array[0][1]))
        self.assertEqual(5, s_list.array[0][1][0])

    def test_insert_invalidPath_shouldThrow(self):
        # Arrange
        sizes = [1, 2, 0]
        s_list = DimensionalDynArray(sizes)

        # Assert
        with self.assertRaises(ValueError):
            s_list.insert((-1,2,3), 2)

    def test_insert_invalidPath_shouldThrow(self):
        # Arrange
        sizes = [1, 2, 0]
        s_list = DimensionalDynArray(sizes)

        # Assert
        with self.assertRaises(ValueError):
            s_list.insert((-1,2), 2)

    def test_delete_invalidPath_shouldThrow(self):
        # Arrange
        sizes = [1, 2, 0]
        s_list = DimensionalDynArray(sizes)

        # Assert
        with self.assertRaises(ValueError):
            s_list.delete((-1,2,3))

    def test_delete_invalidPath_shouldThrow(self):
        # Arrange
        sizes = [1, 2, 0]
        s_list = DimensionalDynArray(sizes)

        # Assert
        with self.assertRaises(ValueError):
            s_list.delete((-1,2))

    def test_delete_oneDimension_shouldNotDelete(self):
        # Arrange
        sizes = [0]
        s_list = DimensionalDynArray(sizes)
        self.assertEqual(0, len(s_list.array))

        self.assertFalse(s_list.delete((0,)))

    def test_delete_oneDimension_shouldDelete(self):
        # Arrange
        sizes = [0]
        s_list = DimensionalDynArray(sizes)
        s_list.insert((0,),1)
        self.assertEqual(1, len(s_list.array))

        self.assertTrue(s_list.delete((0,)))

    def test_delete_twoDimension_shouldNotDelete(self):
        # Arrange
        sizes = [0, 0]
        s_list = DimensionalDynArray(sizes)
        self.assertEqual(0, len(s_list.array))

        self.assertFalse(s_list.delete((0,0)))

    def test_delete_twoDimension_shouldDelete(self):
        # Arrange
        sizes = [1, 2]
        s_list = DimensionalDynArray(sizes)
        s_list.insert((0,1),1)
        self.assertEqual(1, len(s_list.array))

        self.assertTrue(s_list.delete((0,1)))

    def test_delete_twoDimensionEmpty_shouldDelete(self):
        # Arrange
        sizes = [1, 2]
        s_list = DimensionalDynArray(sizes)
        self.assertEqual(1, len(s_list.array))

        self.assertTrue(s_list.delete((0,1)))


if __name__ == "__main__":
    unittest.main()