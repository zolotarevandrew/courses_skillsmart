import unittest
from task1 import LinkedList, Node
from task1_2 import sumLists

class Delete_LinkedListTests(unittest.TestCase):
    def test_delete_allFalseEmpty_shouldBeEmpty(self):
        # Arrange
        s_list = LinkedList()

        # Act
        s_list.delete(1, all = False)

        # Assert
        self.assertIsNone(s_list.head)
        self.assertIsNone(s_list.tail)
        self.assertEqual(0, s_list.len())

    def test_delete_allTrueEmpty_shouldBeEmpty(self):
        # Arrange
        s_list = LinkedList()

        # Act
        s_list.delete(1, all = True)

        # Assert
        self.assertIsNone(s_list.head)
        self.assertIsNone(s_list.tail)
        self.assertEqual(0, s_list.len())

    def test_delete_allFalseInHead_shouldDeleteHead(self):
        # Arrange
        s_list = LinkedList()
        node1 = Node(1)
        s_list.add_in_tail(node1)

        # Act
        s_list.delete(1, all = False)

        # Assert
        self.assertIsNone(s_list.head)
        self.assertIsNone(s_list.tail)

    def test_delete_allTrueInHead_shouldDeleteHead(self):
        # Arrange
        s_list = LinkedList()
        s_list.add_in_tail(Node(1))

        # Act
        s_list.delete(1, all = True)

        # Assert
        self.assertIsNone(s_list.head)
        self.assertIsNone(s_list.tail)

    def test_delete_allFalseInTail_shouldDeleteTail(self):
        # Arrange
        s_list = LinkedList()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))

        # Act
        s_list.delete(2, all = False)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertEqual(1, s_list.len())
        self.assertEqual(1, s_list.head.value)
        self.assertIsNone(s_list.head.next)
        self.assertEqual(s_list.head, s_list.tail)

    def test_delete_allTrueInTail_shouldDeleteTail(self):
        # Arrange
        s_list = LinkedList()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))

        # Act
        s_list.delete(2, all = True)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertEqual(1, s_list.len())
        self.assertEqual(1, s_list.head.value)
        self.assertIsNone(s_list.head.next)
        self.assertEqual(s_list.head, s_list.tail)

    def test_delete_allFalseInHeadTwoElements_shouldDeleteHead(self):
        # Arrange
        s_list = LinkedList()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))

        # Act
        s_list.delete(1, all = False)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertEqual(1, s_list.len())
        self.assertEqual(2, s_list.head.value)
        self.assertIsNone(s_list.head.next)
        self.assertEqual(s_list.head, s_list.tail)

    def test_delete_allTrueInHeadTwoElements_shouldDeleteHead(self):
        # Arrange
        s_list = LinkedList()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))

        # Act
        s_list.delete(1, all = True)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertEqual(1, s_list.len())
        self.assertEqual(2, s_list.head.value)
        self.assertIsNone(s_list.head.next)
        self.assertEqual(s_list.head, s_list.tail)

    def test_delete_allFalseInMid_shouldDeleteMid(self):
        # Arrange
        s_list = LinkedList()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))

        # Act
        s_list.delete(2, all = False)

        # Assert
        self.assertEqual(2, s_list.len())
        self.assertIsNotNone(s_list.head)
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(3, s_list.head.next.value)
        self.assertEqual(s_list.tail, s_list.head.next)
        self.assertIsNone(s_list.tail.next)

    def test_delete_allTrueInMid_shouldDeleteMid(self):
        # Arrange
        s_list = LinkedList()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))

        # Act
        s_list.delete(2, all = True)

        # Assert
        self.assertEqual(2, s_list.len())
        self.assertIsNotNone(s_list.head)
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(3, s_list.head.next.value)
        self.assertEqual(s_list.tail, s_list.head.next)
        self.assertIsNone(s_list.tail.next)

    def test_delete_allTrueTwoEqualElements_shouldDeleteAll(self):
        # Arrange
        s_list = LinkedList()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(1))

        # Act
        s_list.delete(1, all = True)

        # Assert
        self.assertEqual(0, s_list.len())
        self.assertIsNone(s_list.head)
        self.assertIsNone(s_list.tail)

    def test_delete_allTrueThreeElementsInMiddle_shouldDeleteAll(self):
        # Arrange
        s_list = LinkedList()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(1))

        # Act
        s_list.delete(1, all = True)

        # Assert
        self.assertEqual(1, s_list.len())
        self.assertIsNotNone(s_list.head)
        self.assertEqual(2, s_list.head.value)
        self.assertIsNone(s_list.head.next)
        self.assertEqual(s_list.head, s_list.tail)

    def test_delete_allTrueThreeElementsInEnd_shouldDeleteAll(self):
        # Arrange
        s_list = LinkedList()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))

        # Act
        s_list.delete(1, all = True)

        # Assert
        self.assertEqual(1, s_list.len())
        self.assertIsNotNone(s_list.head)
        self.assertEqual(2, s_list.head.value)
        self.assertIsNone(s_list.head.next)
        self.assertEqual(s_list.head, s_list.tail)

    def test_delete_allTrueFourElementsInHead_shouldDeleteAll(self):
        # Arrange
        s_list = LinkedList()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))
        s_list.add_in_tail(Node(4))

        # Act
        s_list.delete(1, all = True)

        # Assert
        self.assertEqual(3, s_list.len())
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(2, s_list.head.value)
        self.assertEqual(3, s_list.head.next.value)
        self.assertEqual(4, s_list.head.next.next.value)
        self.assertEqual(s_list.head.next.next, s_list.tail)
        self.assertIsNone(s_list.tail.next)
    
    def test_delete_allTrueTwoEqualElementsWithGap_shouldDeleteAll(self):
        # Arrange
        s_list = LinkedList()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))
        s_list.add_in_tail(Node(4))

        # Act
        s_list.delete(2, all = True)

        # Assert
        self.assertEqual(3, s_list.len())
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(3, s_list.head.next.value)
        self.assertEqual(4, s_list.head.next.next.value)
        self.assertEqual(s_list.head.next.next, s_list.tail)
        self.assertIsNone(s_list.tail.next)

    def test_delete_allTrueTwoEqualElementsInDifferentPlaces_shouldDeleteAll(self):
        # Arrange
        s_list = LinkedList()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(4))

        # Act
        s_list.delete(2, all = True)

        # Assert
        self.assertEqual(3, s_list.len())
        self.assertIsNotNone(s_list.head)
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(3, s_list.head.next.value)
        self.assertEqual(4, s_list.head.next.next.value)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next.next, s_list.tail)
        self.assertIsNone(s_list.tail.next)
    
    def test_delete_allTrueThreeEqualElementsInDifferentPlaces_shouldDeleteAll(self):
        # Arrange
        s_list = LinkedList()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(4))

        # Act
        s_list.delete(2, all = True)

        # Assert
        self.assertEqual(3, s_list.len())
        self.assertIsNotNone(s_list.head)
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(3, s_list.head.next.value)
        self.assertEqual(4, s_list.head.next.next.value)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next.next, s_list.tail)
        self.assertIsNone(s_list.tail.next)

class Clean_LinkedListTests(unittest.TestCase):
    def test_clean_empty_shouldBeEmpty(self):
        # Arrange
        s_list = LinkedList()

        # Act
        s_list.clean()

        # Assert
        self.assertIsNone(s_list.head)
        self.assertIsNone(s_list.tail)
        self.assertEqual(0, s_list.len())

    def test_clean_oneElement_shouldBeEmpty(self):
        # Arrange
        s_list = LinkedList()
        s_list.add_in_tail(Node(1))

        # Act
        s_list.clean()

        # Assert
        self.assertIsNone(s_list.head)
        self.assertIsNone(s_list.tail)
        self.assertEqual(0, s_list.len())

    def test_clean_twoElements_shouldBeEmpty(self):
        # Arrange
        s_list = LinkedList()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))

        # Act
        s_list.clean()

        # Assert
        self.assertIsNone(s_list.head)
        self.assertIsNone(s_list.tail)
        self.assertEqual(0, s_list.len())

    def test_clean_threeElements_shouldBeEmpty(self):
        # Arrange
        s_list = LinkedList()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))

        # Act
        s_list.clean()

        # Assert
        self.assertIsNone(s_list.head)
        self.assertIsNone(s_list.tail)
        self.assertEqual(0, s_list.len())

class FindAll_LinkedListTests(unittest.TestCase):
    def test_findAll_empty_shouldBeEmpty(self):
        # Arrange
        s_list = LinkedList()

        # Act
        res = s_list.find_all(1)

        # Assert
        self.assertEqual([], res)

    def test_findAll_oneElementValueNotFound_shouldBeEmpty(self):
        # Arrange
        s_list = LinkedList()
        s_list.add_in_tail(Node(1))

        # Act
        res = s_list.find_all(2)

        # Assert
        self.assertEqual(0, len(res))
        self.assertEqual([], res)

    def test_findAll_oneElementValueFound_shouldBeOne(self):
        # Arrange
        s_list = LinkedList()
        node = Node(1)
        s_list.add_in_tail(node)

        # Act
        res = s_list.find_all(1)

        # Assert
        self.assertEqual(1, len(res))
        self.assertEqual(node, res[0])

    def test_findAll_twoElementsOneValueFound_shouldBeOne(self):
        # Arrange
        s_list = LinkedList()
        node1 = Node(1)
        node2 = Node(2)
        s_list.add_in_tail(node1)
        s_list.add_in_tail(node2)

        # Act
        res = s_list.find_all(1)

        # Assert
        self.assertEqual(1, len(res))
        self.assertEqual(node1, res[0])

    def test_findAll_twoElementsTwoValueFound_shouldBeTwo(self):
        # Arrange
        s_list = LinkedList()
        node1 = Node(1)
        node2 = Node(1)
        s_list.add_in_tail(node1)
        s_list.add_in_tail(node2)

        # Act
        res = s_list.find_all(1)

        # Assert
        self.assertEqual(2, len(res))
        self.assertEqual(node1, res[0])
        self.assertEqual(node2, res[1])

    def test_findAll_threeElementsOneValueFound_shouldBeOne(self):
        # Arrange
        s_list = LinkedList()
        node1 = Node(1)
        node2 = Node(2)
        node3 = Node(3)
        s_list.add_in_tail(node1)
        s_list.add_in_tail(node2)
        s_list.add_in_tail(node3)

        # Act
        res = s_list.find_all(2)

        # Assert
        self.assertEqual(1, len(res))
        self.assertEqual(node2, res[0])

    def test_findAll_threeElementsTwoValueFound_shouldBeTwo(self):
        # Arrange
        s_list = LinkedList()
        node1 = Node(1)
        node2 = Node(2)
        node3 = Node(1)
        s_list.add_in_tail(node1)
        s_list.add_in_tail(node2)
        s_list.add_in_tail(node3)

        # Act
        res = s_list.find_all(1)

        # Assert
        self.assertEqual(2, len(res))
        self.assertEqual(node1, res[0])
        self.assertEqual(node3, res[1])

    def test_findAll_threeElementsAllFound_shouldBeThree(self):
        # Arrange
        s_list = LinkedList()
        node1 = Node(1)
        node2 = Node(1)
        node3 = Node(1)
        s_list.add_in_tail(node1)
        s_list.add_in_tail(node2)
        s_list.add_in_tail(node3)

        # Act
        res = s_list.find_all(1)

        # Assert
        self.assertEqual(3, len(res))
        self.assertEqual(node1, res[0])
        self.assertEqual(node2, res[1])
        self.assertEqual(node3, res[2])

class Insert_LinkedListTests(unittest.TestCase):
    def test_insert_empty_beforeHead_shouldBeOneElement(self):
        # Arrange
        s_list = LinkedList()
        
        # Act
        s_list.insert(None, Node(1))

        # Assert
        self.assertEqual(1, s_list.len())
        self.assertEqual(1, s_list.head.value)
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertIsNone(s_list.head.next)
        self.assertEqual(s_list.head, s_list.tail)

    def test_insert_oneElement_beforeHead_shouldBeTwoElements(self):
        # Arrange
        s_list = LinkedList()
        
        # Act
        s_list.add_in_tail(Node(2))
        s_list.insert(None, Node(1))

        # Assert
        self.assertEqual(2, s_list.len())
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(2, s_list.head.next.value)
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.tail, s_list.head.next)
        self.assertIsNone(s_list.tail.next)

    def test_insert_twoElements_beforeHead_shouldBeThreeElements(self):
        # Arrange
        s_list = LinkedList()
        
        # Act
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))
        s_list.insert(None, Node(1))

        # Assert
        self.assertEqual(3, s_list.len())
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(2, s_list.head.next.value)
        self.assertEqual(3, s_list.head.next.next.value)
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.tail, s_list.head.next.next)
        self.assertIsNone(s_list.tail.next)

    def test_insert_oneElement_afterHead_shouldBeTwoElements(self):
        # Arrange
        s_list = LinkedList()
        
        # Act
        s_list.add_in_tail(Node(1))
        s_list.insert(s_list.head, Node(2))

        # Assert
        self.assertEqual(2, s_list.len())
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(2, s_list.head.next.value)
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.tail, s_list.head.next)
        self.assertIsNone(s_list.tail.next)

    def test_insert_twoElements_afterHead_shouldBeThreeElements(self):
        # Arrange
        s_list = LinkedList()
        
        # Act
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.insert(s_list.head, Node(3))

        # Assert
        self.assertEqual(3, s_list.len())
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(3, s_list.head.next.value)
        self.assertEqual(2, s_list.head.next.next.value)
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.tail, s_list.head.next.next)
        self.assertIsNone(s_list.tail.next)

    def test_insert_twoElements_afterTail_shouldBeThreeElements(self):
        # Arrange
        s_list = LinkedList()
        
        # Act
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.insert(s_list.tail, Node(3))

        # Assert
        self.assertEqual(3, s_list.len())
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(2, s_list.head.next.value)
        self.assertEqual(3, s_list.head.next.next.value)
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.tail, s_list.head.next.next)
        self.assertIsNone(s_list.tail.next)

    def test_insert_threeElements_oneElementBeforeTail_shouldBeFourElements(self):
        # Arrange
        s_list = LinkedList()
        
        # Act
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(4))
        s_list.insert(s_list.head.next, Node(3))

        # Assert
        self.assertEqual(4, s_list.len())
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(2, s_list.head.next.value)
        self.assertEqual(3, s_list.head.next.next.value)
        self.assertEqual(4, s_list.head.next.next.next.value)
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.tail, s_list.head.next.next.next)
        self.assertIsNone(s_list.tail.next)

    def test_insertDelete_multipleTimes_shouldBeCorrect(self):
        # Arrange
        s_list = LinkedList()
        
        # Act
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(4))
        s_list.insert(s_list.head.next, Node(3))
        # 1 -> 2 -> 3 -> 4
        s_list.delete(1)
        s_list.delete(3)
        # 2 -> 4
        s_list.insert(s_list.head, Node(5))
        s_list.add_in_tail(Node(5))
        s_list.add_in_tail(Node(5))
        # 2 -> 5 -> 4 -> 5 -> 5 
        s_list.delete(5, True)
        # 2 -> 4 -> 6 -> 7
        s_list.add_in_tail(Node(6))
        s_list.add_in_tail(Node(7))

        # Assert
        self.assertEqual(4, s_list.len())
        self.assertEqual(2, s_list.head.value)
        self.assertEqual(4, s_list.head.next.value)
        self.assertEqual(6, s_list.head.next.next.value)
        self.assertEqual(7, s_list.head.next.next.next.value)
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.tail, s_list.head.next.next.next)
        self.assertIsNone(s_list.tail.next)

class SumLists_LinkedListTests(unittest.TestCase):
    def test_sumLists_emptyLists_shouldBeEmptyList(self):
        # Arrange
        s_list1 = LinkedList()
        s_list2 = LinkedList()
        
        # Act
        res = sumLists(s_list1, s_list2)

        # Assert
        self.assertEqual(0, res.len())
        self.assertIsNone(res.head)
        self.assertIsNone(res.tail)

    def test_sumLists_notEqualLength_shouldBeNone(self):
        # Arrange
        s_list1 = LinkedList()
        s_list1.add_in_tail(Node(1))
        s_list2 = LinkedList()
        
        # Act
        res = sumLists(s_list1, s_list2)

        # Assert
        self.assertIsNone(res)

    def test_sumLists_equalLengthOne_shouldBeCorrect(self):
        # Arrange
        s_list1 = LinkedList()
        s_list1.add_in_tail(Node(1))
        s_list2 = LinkedList()
        s_list2.add_in_tail(Node(1))
        
        # Act
        res = sumLists(s_list1, s_list2)

        # Assert
        self.assertEqual(1, res.len())
        self.assertEqual(2, res.head.value)
        self.assertIsNotNone(res.head)
        self.assertIsNotNone(res.tail)
        self.assertEqual(res.head, res.tail)

    def test_sumLists_equalLengthTwo_shouldBeCorrect(self):
        # Arrange
        s_list1 = LinkedList()
        s_list1.add_in_tail(Node(1))
        s_list1.add_in_tail(Node(2))

        s_list2 = LinkedList()
        s_list2.add_in_tail(Node(1))
        s_list2.add_in_tail(Node(3))
        
        # Act
        res = sumLists(s_list1, s_list2)

        # Assert
        self.assertEqual(2, res.len())
        self.assertEqual(2, res.head.value)
        self.assertEqual(5, res.head.next.value)
        self.assertIsNotNone(res.head)
        self.assertIsNotNone(res.tail)
        self.assertIsNone(res.tail.next)
        self.assertEqual(res.tail, res.head.next)
if __name__ == "__main__":
    unittest.main()