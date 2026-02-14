import unittest
from task7 import OrderedList, OrderedStringList
from task7_2 import removeDuplicates, merge

class Compare_OrderedStringListTests(unittest.TestCase):
    def test_asc_compare_allCases_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedStringList(True)

        # Act
        self.assertEqual(0, s_list.compare(None, None))
        self.assertEqual(0, s_list.compare(None, ''))
        self.assertEqual(0, s_list.compare('', None))
        self.assertEqual(0, s_list.compare(None, ' '))
        self.assertEqual(0, s_list.compare(' ', None))
        self.assertEqual(0, s_list.compare(' ', ''))
        self.assertEqual(0, s_list.compare(' ', ' '))
        self.assertEqual(1,  s_list.compare('b', ' a '))
        self.assertEqual(-1, s_list.compare(' a ', 'b'))
        self.assertEqual(0, s_list.compare(' abc ', 'abc   '))
        self.assertEqual(-1, s_list.compare(' abcd', 'abce   '))
        self.assertEqual(-1, s_list.compare('a b', 'ab'))
        self.assertEqual(1,  s_list.compare('ab', 'a b'))

        # Assert

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
        s_list.add(7)


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

        res = s_list.find(7)
        self.assertIsNotNone(res)
        self.assertEqual(7, res.value)

        res = s_list.find(6)
        self.assertIsNone(res)

        res = s_list.find(2)
        self.assertIsNone(res)

class RemoveDuplicates_OrderedListTests(unittest.TestCase):
    def test_removeDuplicates_empty_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(False)

        # Act
        res = removeDuplicates(s_list)

        # Assert
        self.assertIsNone(res.head)
        self.assertIsNone(res.tail)
        self.assertEqual(0, s_list.len())

    def test_removeDuplicates_oneElement_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(1)

        # Act
        res = removeDuplicates(s_list)

        # Assert
        self.assertIsNotNone(res.head)
        self.assertIsNotNone(res.tail)
        self.assertEqual(1, res.head.value)
        self.assertEqual(1, s_list.len())

    def test_removeDuplicates_twoElements_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(1)
        s_list.add(2)

        # Act
        res = removeDuplicates(s_list)

        # Assert
        self.assertIsNotNone(res.head)
        self.assertIsNotNone(res.tail)
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(2, s_list.len())

    def test_removeDuplicates_threeElements_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(1)
        s_list.add(2)
        s_list.add(3)

        # Act
        res = removeDuplicates(s_list)

        # Assert
        self.assertIsNotNone(res.head)
        self.assertIsNotNone(res.tail)
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(3, res.head.next.next.value)
        self.assertEqual(3, s_list.len())

    def test_removeDuplicates_twoElementsDuplicates_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(2)
        s_list.add(2)

        # Act
        res = removeDuplicates(s_list)

        # Assert
        self.assertIsNotNone(res.head)
        self.assertIsNotNone(res.tail)
        self.assertEqual(2, res.head.value)
        self.assertEqual(1, s_list.len())

    def test_removeDuplicates_threeElementsDuplicates_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(2)
        s_list.add(1)
        s_list.add(2)

        # Act
        res = removeDuplicates(s_list)

        # Assert
        self.assertIsNotNone(res.head)
        self.assertIsNotNone(res.tail)
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(2, s_list.len())

    def test_removeDuplicates_fourElementsDuplicates_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(2)
        s_list.add(1)
        s_list.add(2)
        s_list.add(3)

        # Act
        res = removeDuplicates(s_list)

        # Assert
        self.assertIsNotNone(res.head)
        self.assertIsNotNone(res.tail)
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(3, res.head.next.next.value)
        self.assertEqual(3, s_list.len())

    def test_removeDuplicates_fiveElementsDuplicates_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(2)
        s_list.add(1)
        s_list.add(2)
        s_list.add(3)
        s_list.add(3)

        # Act
        res = removeDuplicates(s_list)

        # Assert
        self.assertIsNotNone(res.head)
        self.assertIsNotNone(res.tail)
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(3, res.head.next.next.value)
        self.assertEqual(3, s_list.len())

    def test_removeDuplicates_sixElementsDuplicates_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(2)
        s_list.add(1)
        s_list.add(2)
        s_list.add(3)
        s_list.add(3)
        s_list.add(5)

        # Act
        res = removeDuplicates(s_list)

        # Assert
        self.assertIsNotNone(res.head)
        self.assertIsNotNone(res.tail)
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(3, res.head.next.next.value)
        self.assertEqual(5, res.head.next.next.next.value)
        self.assertEqual(4, s_list.len())

    def test_removeDuplicates_threeDuplicates_shouldBeCorrect(self):
        # Arrange
        s_list = OrderedList(True)
        s_list.add(1)
        s_list.add(1)
        s_list.add(1)
        s_list.add(2)

        # Act
        res = removeDuplicates(s_list)

        # Assert
        self.assertIsNotNone(res.head)
        self.assertIsNotNone(res.tail)
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(2, s_list.len())

class Merge_OrderedListTests(unittest.TestCase):
    def test_merge_empty_shouldBeCorrect(self):
        # Arrange
        list1 = OrderedList(True)
        list2 = OrderedList(True)

        # Act
        res = merge(list1, list2)

        # Assert
        self.assertIsNone(res.head)
        self.assertIsNone(res.tail)
        self.assertEqual(0, res.len())

    def test_merge_rightEmpty_shouldBeCorrect(self):
        # Arrange
        list1 = OrderedList(True)
        list1.add(1)
        list2 = OrderedList(True)

        # Act
        res = merge(list1, list2)

        # Assert
        self.assertIsNotNone(res.head)
        self.assertIsNotNone(res.tail)
        self.assertEqual(1, res.head.value)
        self.assertEqual(1, res.len())

    def test_merge_leftEmpty_shouldBeCorrect(self):
        # Arrange
        list1 = OrderedList(True)
        list2 = OrderedList(True)
        list2.add(2)

        # Act
        res = merge(list1, list2)

        # Assert
        self.assertIsNotNone(res.head)
        self.assertIsNotNone(res.tail)
        self.assertEqual(2, res.head.value)
        self.assertEqual(1, res.len())

    def test_merge_oneElementInEachLeft_shouldBeCorrect(self):
        # Arrange
        list1 = OrderedList(True)
        list1.add(1)
        list2 = OrderedList(True)
        list2.add(2)

        # Act
        res = merge(list1, list2)

        # Assert
        self.assertIsNotNone(res.head)
        self.assertIsNotNone(res.tail)
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(2, res.len())

    def test_merge_oneElementInEachRight_shouldBeCorrect(self):
        # Arrange
        list1 = OrderedList(True)
        list1.add(2)
        list2 = OrderedList(True)
        list2.add(1)

        # Act
        res = merge(list1, list2)

        # Assert
        self.assertIsNotNone(res.head)
        self.assertIsNotNone(res.tail)
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(2, res.len())

    def test_merge_twoInLeftOneInRight_shouldBeCorrect(self):
        # Arrange
        list1 = OrderedList(True)
        list1.add(2)
        list1.add(3)
        list2 = OrderedList(True)
        list2.add(1)

        # Act
        res = merge(list1, list2)

        # Assert
        self.assertIsNotNone(res.head)
        self.assertIsNotNone(res.tail)
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(3, res.head.next.next.value)
        self.assertEqual(3, res.len())

    def test_merge_twoInRightOneInLeft_shouldBeCorrect(self):
        # Arrange
        list1 = OrderedList(True)
        list1.add(2)
        list2 = OrderedList(True)
        list2.add(1)
        list2.add(2)

        # Act
        res = merge(list1, list2)

        # Assert
        self.assertIsNotNone(res.head)
        self.assertIsNotNone(res.tail)
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(2, res.head.next.next.value)
        self.assertEqual(3, res.len())

    def test_merge_twoInRightTwoInLeft_shouldBeCorrect(self):
        # Arrange
        list1 = OrderedList(True)
        list1.add(2)
        list1.add(3)
        list2 = OrderedList(True)
        list2.add(1)
        list2.add(2)

        # Act
        res = merge(list1, list2)

        # Assert
        self.assertIsNotNone(res.head)
        self.assertIsNotNone(res.tail)
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(2, res.head.next.next.value)
        self.assertEqual(3, res.head.next.next.next.value)
        self.assertEqual(4, res.len())

    def test_merge_threeInRightTwoInLeft_shouldBeCorrect(self):
        # Arrange
        list1 = OrderedList(True)
        list1.add(4)
        list1.add(5)
        list2 = OrderedList(True)
        list2.add(1)
        list2.add(2)
        list2.add(3)

        # Act
        res = merge(list1, list2)

        # Assert
        self.assertIsNotNone(res.head)
        self.assertIsNotNone(res.tail)
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(3, res.head.next.next.value)
        self.assertEqual(4, res.head.next.next.next.value)
        self.assertEqual(5, res.head.next.next.next.next.value)
        self.assertEqual(5, res.len())

    def test_merge_threeInLeftTwoInRight_shouldBeCorrect(self):
        # Arrange
        list1 = OrderedList(True)
        list1.add(4)
        list1.add(5)
        list1.add(6)
        list2 = OrderedList(True)
        list2.add(1)
        list2.add(2)

        # Act
        res = merge(list1, list2)

        # Assert
        self.assertIsNotNone(res.head)
        self.assertIsNotNone(res.tail)
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(4, res.head.next.next.value)
        self.assertEqual(5, res.head.next.next.next.value)
        self.assertEqual(6, res.head.next.next.next.next.value)
        self.assertEqual(5, res.len())

    def test_merge_desc_threeInLeftTwoInRight_shouldBeCorrect(self):
        # Arrange
        list1 = OrderedList(False)
        list1.add(6)
        list1.add(5)
        list1.add(4)
        list2 = OrderedList(False)
        list2.add(5)
        list2.add(1)

        # Act
        res = merge(list1, list2)

        # Assert
        self.assertIsNotNone(res.head)
        self.assertIsNotNone(res.tail)
        self.assertEqual(6, res.head.value)
        self.assertEqual(5, res.head.next.value)
        self.assertEqual(5, res.head.next.next.value)
        self.assertEqual(4, res.head.next.next.next.value)
        self.assertEqual(1, res.head.next.next.next.next.value)
        self.assertEqual(5, res.len())

if __name__ == "__main__":
    unittest.main()