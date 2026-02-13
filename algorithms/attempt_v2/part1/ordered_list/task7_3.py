import unittest
from task7 import OrderedList, OrderedStringList

class AddAsc_OrderedListTests(unittest.TestCase):
    def test_add_asc_empty_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)

        # Act
        s_list.add(1)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head, s_list.tail)
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(1, s_list.len())

    def test_add_asc_oneElementInTail_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(1)

        # Act
        s_list.add(2)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next, s_list.tail)
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(2, s_list.head.next.value)
        self.assertEqual(2, s_list.len())

    def test_add_asc_sameOneElementInHead_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(1)

        # Act
        s_list.add(1)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next, s_list.tail)
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(1, s_list.head.next.value)
        self.assertEqual(2, s_list.len())

    def test_add_asc_oneElementInHead_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(2)

        # Act
        s_list.add(1)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next, s_list.tail)
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(2, s_list.head.next.value)
        self.assertEqual(2, s_list.len())

    def test_add_asc_twoElementsInHead_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(2)
        s_list.add(3)

        # Act
        s_list.add(1)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next.next, s_list.tail)
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(2, s_list.head.next.value)
        self.assertEqual(3, s_list.head.next.next.value)
        self.assertEqual(3, s_list.len())

    def test_add_asc_twoElementsInTail_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(2)
        s_list.add(3)

        # Act
        s_list.add(4)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next.next, s_list.tail)
        self.assertEqual(2, s_list.head.value)
        self.assertEqual(3, s_list.head.next.value)
        self.assertEqual(4, s_list.head.next.next.value)
        self.assertEqual(3, s_list.len())

    def test_add_asc_twoElementsInMiddle_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(2)
        s_list.add(4)

        # Act
        s_list.add(3)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next.next, s_list.tail)
        self.assertEqual(2, s_list.head.value)
        self.assertEqual(3, s_list.head.next.value)
        self.assertEqual(4, s_list.head.next.next.value)
        self.assertEqual(3, s_list.len())

    def test_add_asc_fourElementsInMiddle_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(1)
        s_list.add(4)
        s_list.add(5)

        # Act
        s_list.add(3)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next.next.next, s_list.tail)
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(3, s_list.head.next.value)
        self.assertEqual(4, s_list.head.next.next.value)
        self.assertEqual(5, s_list.head.next.next.next.value)
        self.assertEqual(4, s_list.len())


class AddDesc_OrderedListTests(unittest.TestCase):
    def test_add_desc_empty_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)

        # Act
        s_list.add(1)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head, s_list.tail)
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(1, s_list.len())

    def test_add_desc_oneElementInTail_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(2)

        # Act
        s_list.add(1)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next, s_list.tail)
        self.assertEqual(2, s_list.head.value)
        self.assertEqual(1, s_list.head.next.value)
        self.assertEqual(2, s_list.len())

    def test_add_desc_sameOneElementInHead_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(1)

        # Act
        s_list.add(1)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next, s_list.tail)
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(1, s_list.head.next.value)
        self.assertEqual(2, s_list.len())

    def test_add_desc_oneElementInHead_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(2)

        # Act
        s_list.add(3)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next, s_list.tail)
        self.assertEqual(3, s_list.head.value)
        self.assertEqual(2, s_list.head.next.value)
        self.assertEqual(2, s_list.len())

    def test_add_desc_twoElementsInHead_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(2)
        s_list.add(3)

        # Act
        s_list.add(4)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next.next, s_list.tail)
        self.assertEqual(4, s_list.head.value)
        self.assertEqual(3, s_list.head.next.value)
        self.assertEqual(2, s_list.head.next.next.value)
        self.assertEqual(3, s_list.len())

    def test_add_desc_twoElementsInTail_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(2)
        s_list.add(3)

        # Act
        s_list.add(1)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next.next, s_list.tail)
        self.assertEqual(3, s_list.head.value)
        self.assertEqual(2, s_list.head.next.value)
        self.assertEqual(1, s_list.head.next.next.value)
        self.assertEqual(3, s_list.len())

    def test_add_desc_twoElementsInMiddle_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(2)
        s_list.add(4)

        # Act
        s_list.add(3)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next.next, s_list.tail)
        self.assertEqual(4, s_list.head.value)
        self.assertEqual(3, s_list.head.next.value)
        self.assertEqual(2, s_list.head.next.next.value)
        self.assertEqual(3, s_list.len())

    def test_add_desc_fourElementsInMiddle_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(1)
        s_list.add(4)
        s_list.add(5)

        # Act
        s_list.add(3)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next.next.next, s_list.tail)
        self.assertEqual(5, s_list.head.value)
        self.assertEqual(4, s_list.head.next.value)
        self.assertEqual(3, s_list.head.next.next.value)
        self.assertEqual(1, s_list.head.next.next.next.value)
        self.assertEqual(4, s_list.len())


class DeleteAsc_OrderedListTests(unittest.TestCase):
    def test_delete_asc_empty_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)

        # Act
        s_list.delete(1)

        # Assert
        self.assertIsNone(s_list.head)
        self.assertIsNone(s_list.tail)
        self.assertEqual(0, s_list.len())

    def test_delete_asc_oneElementNotExists_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(2)

        # Act
        s_list.delete(1)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head, s_list.tail)
        self.assertEqual(2, s_list.head.value)
        self.assertEqual(1, s_list.len())

    def test_delete_asc_oneElementExists_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(1)

        # Act
        s_list.delete(1)

        # Assert
        self.assertIsNone(s_list.head)
        self.assertIsNone(s_list.tail)
        self.assertEqual(0, s_list.len())

    def test_delete_asc_twoElementExists_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(1)
        s_list.add(2)

        # Act
        s_list.delete(1)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head, s_list.tail)
        self.assertEqual(2, s_list.head.value)
        self.assertEqual(1, s_list.len())

    def test_delete_asc_twoElementNotExists_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(1)
        s_list.add(2)

        # Act
        s_list.delete(3)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next, s_list.tail)
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(2, s_list.head.next.value)
        self.assertEqual(2, s_list.len())

    def test_delete_asc_twoDuplicateElementExists_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(1)
        s_list.add(1)

        # Act
        s_list.delete(1)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head, s_list.tail)
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(1, s_list.len())

    def test_delete_asc_threeElementExists_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(1)
        s_list.add(2)
        s_list.add(1)

        # Act
        s_list.delete(2)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next, s_list.tail)
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(1, s_list.head.next.value)
        self.assertEqual(2, s_list.len())

    def test_delete_asc_fourElementExists_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(1)
        s_list.add(2)
        s_list.add(3)
        s_list.add(4)

        # Act
        s_list.delete(4)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next.next, s_list.tail)
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(2, s_list.head.next.value)
        self.assertEqual(3, s_list.head.next.next.value)
        self.assertEqual(3, s_list.len())

class DeleteDesc_OrderedListTests(unittest.TestCase):
    def test_delete_desc_empty_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)

        # Act
        s_list.delete(1)

        # Assert
        self.assertIsNone(s_list.head)
        self.assertIsNone(s_list.tail)
        self.assertEqual(0, s_list.len())

    def test_delete_desc_oneElementNotExists_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(2)

        # Act
        s_list.delete(1)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head, s_list.tail)
        self.assertEqual(2, s_list.head.value)
        self.assertEqual(1, s_list.len())

    def test_delete_desc_oneElementExists_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(1)

        # Act
        s_list.delete(1)

        # Assert
        self.assertIsNone(s_list.head)
        self.assertIsNone(s_list.tail)
        self.assertEqual(0, s_list.len())

    def test_delete_desc_twoElementExists_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(1)
        s_list.add(2)

        # Act
        s_list.delete(1)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head, s_list.tail)
        self.assertEqual(2, s_list.head.value)
        self.assertEqual(1, s_list.len())

    def test_delete_asc_twoElementNotExists_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(1)
        s_list.add(2)

        # Act
        s_list.delete(3)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next, s_list.tail)
        self.assertEqual(2, s_list.head.value)
        self.assertEqual(1, s_list.head.next.value)
        self.assertEqual(2, s_list.len())

    def test_delete_desc_twoDuplicateElementExists_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(1)
        s_list.add(1)

        # Act
        s_list.delete(1)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head, s_list.tail)
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(1, s_list.len())

    def test_delete_desc_threeElementExists_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(1)
        s_list.add(2)
        s_list.add(1)

        # Act
        s_list.delete(2)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next, s_list.tail)
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(1, s_list.head.next.value)
        self.assertEqual(2, s_list.len())

    def test_delete_desc_fourElementExists_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(1)
        s_list.add(2)
        s_list.add(3)
        s_list.add(4)

        # Act
        s_list.delete(4)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next.next, s_list.tail)
        self.assertEqual(3, s_list.head.value)
        self.assertEqual(2, s_list.head.next.value)
        self.assertEqual(1, s_list.head.next.next.value)
        self.assertEqual(3, s_list.len())

class FindAsc_OrderedListTests(unittest.TestCase):
    def test_find_asc_empty_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)

        # Act
        res = s_list.find(1)

        # Assert
        self.assertIsNone(res)

    def test_find_asc_oneElementNotFound_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(3)

        # Act
        res = s_list.find(1)

        # Assert
        self.assertIsNone(res)

    def test_find_asc_oneElementFound_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(3)

        # Act
        res = s_list.find(3)

        # Assert
        self.assertIsNotNone(res)
        self.assertEqual(3, res.value)

    def test_find_asc_twoElementsNotFound_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(2)
        s_list.add(3)

        # Act
        res = s_list.find(4)

        # Assert
        self.assertIsNone(res)

    def test_find_asc_twoElementsFound_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(2)
        s_list.add(3)

        # Act
        res = s_list.find(3)

        # Assert
        self.assertIsNotNone(res)
        self.assertEqual(3, res.value)

    def test_find_asc_twoElementsDuplicatesFound_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(3)
        s_list.add(3)

        # Act
        res = s_list.find(3)

        # Assert
        self.assertIsNotNone(res)
        self.assertEqual(3, res.value)

    def test_find_asc_threeElementsNotFound_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(3)
        s_list.add(4)
        s_list.add(5)

        # Act
        res = s_list.find(2)

        # Assert
        self.assertIsNone(res)

    def test_find_asc_threeElementsFound_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(3)
        s_list.add(4)
        s_list.add(5)

        # Act
        res = s_list.find(5)

        # Assert
        self.assertIsNotNone(res)
        self.assertEqual(5, res.value)

    def test_find_asc_threeElementsFoundInTail_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(3)
        s_list.add(4)
        s_list.add(5)

        # Act
        res = s_list.find(5)

        # Assert
        self.assertIsNotNone(res)
        self.assertEqual(5, res.value)

    def test_find_asc_threeElementsFoundInHead_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(3)
        s_list.add(4)
        s_list.add(5)

        # Act
        res = s_list.find(3)

        # Assert
        self.assertIsNotNone(res)
        self.assertEqual(3, res.value)

    def test_find_asc_threeElementsFoundInMiddle_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(3)
        s_list.add(4)
        s_list.add(5)

        # Act
        res = s_list.find(4)

        # Assert
        self.assertIsNotNone(res)
        self.assertEqual(4, res.value)

    def test_find_asc_fourElements_shouldFoundAll(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(3)
        s_list.add(4)
        s_list.add(5)
        s_list.add(6)


        # Assert
        res = s_list.find(3)
        self.assertIsNotNone(res)
        self.assertEqual(3, res.value)

        res = s_list.find(4)
        self.assertIsNotNone(res)
        self.assertEqual(4, res.value)

        res = s_list.find(5)
        self.assertIsNotNone(res)
        self.assertEqual(5, res.value)

        res = s_list.find(6)
        self.assertIsNotNone(res)
        self.assertEqual(6, res.value)

        res = s_list.find(7)
        self.assertIsNone(res)

class FindDesc_OrderedListTests(unittest.TestCase):
    def test_find_desc_empty_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)

        # Act
        res = s_list.find(1)

        # Assert
        self.assertIsNone(res)

    def test_find_desc_oneElementNotFound_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(3)

        # Act
        res = s_list.find(1)

        # Assert
        self.assertIsNone(res)

    def test_find_desc_oneElementFound_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(3)

        # Act
        res = s_list.find(3)

        # Assert
        self.assertIsNotNone(res)
        self.assertEqual(3, res.value)

    def test_find_desc_twoElementsNotFound_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(2)
        s_list.add(3)

        # Act
        res = s_list.find(4)

        # Assert
        self.assertIsNone(res)

    def test_find_desc_twoElementsFound_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(2)
        s_list.add(3)

        # Act
        res = s_list.find(3)

        # Assert
        self.assertIsNotNone(res)
        self.assertEqual(3, res.value)

    def test_find_desc_twoElementsDuplicatesFound_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(3)
        s_list.add(3)

        # Act
        res = s_list.find(3)

        # Assert
        self.assertIsNotNone(res)
        self.assertEqual(3, res.value)

    def test_find_desc_threeElementsNotFound_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(3)
        s_list.add(4)
        s_list.add(5)

        # Act
        res = s_list.find(2)

        # Assert
        self.assertIsNone(res)

    def test_find_desc_threeElementsFoundInHead_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(3)
        s_list.add(4)
        s_list.add(5)

        # Act
        res = s_list.find(5)

        # Assert
        self.assertIsNotNone(res)
        self.assertEqual(5, res.value)

    def test_find_desc_threeElementsFoundInTail_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(3)
        s_list.add(4)
        s_list.add(5)

        # Act
        res = s_list.find(3)

        # Assert
        self.assertIsNotNone(res)
        self.assertEqual(3, res.value)

    def test_find_desc_threeElementsFoundInMiddle_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(3)
        s_list.add(4)
        s_list.add(5)

        # Act
        res = s_list.find(4)

        # Assert
        self.assertIsNotNone(res)
        self.assertEqual(4, res.value)

    def test_find_desc_fourElements_shouldFoundAll(self):
        # Arrange
        s_list = OrderedList(False)
        s_list.add(3)
        s_list.add(4)
        s_list.add(5)
        s_list.add(6)


        # Assert
        res = s_list.find(3)
        self.assertIsNotNone(res)
        self.assertEqual(3, res.value)

        res = s_list.find(4)
        self.assertIsNotNone(res)
        self.assertEqual(4, res.value)

        res = s_list.find(5)
        self.assertIsNotNone(res)
        self.assertEqual(5, res.value)

        res = s_list.find(6)
        self.assertIsNotNone(res)
        self.assertEqual(6, res.value)

        res = s_list.find(7)
        self.assertIsNone(res)
if __name__ == "__main__":
    unittest.main()