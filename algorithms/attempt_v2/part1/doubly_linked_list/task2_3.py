import unittest
from task2 import LinkedList2, Node
from task2_2 import reverse, hasCycle, split, merge, sort

class Delete_LinkedList2Tests(unittest.TestCase):
    def test_delete_allFalseEmpty_shouldBeEmpty(self):
        # Arrange
        s_list = LinkedList2()

        # Act
        s_list.delete(1, all = False)

        # Assert
        self.assertIsNone(s_list.head)
        self.assertIsNone(s_list.tail)
        self.assertEqual(0, s_list.len())

    def test_delete_allTrueEmpty_shouldBeEmpty(self):
        # Arrange
        s_list = LinkedList2()

        # Act
        s_list.delete(1, all = True)

        # Assert
        self.assertIsNone(s_list.head)
        self.assertIsNone(s_list.tail)
        self.assertEqual(0, s_list.len())

    def test_delete_allFalseInHead_shouldDeleteHead(self):
        # Arrange
        s_list = LinkedList2()
        node1 = Node(1)
        s_list.add_in_tail(node1)

        # Act
        s_list.delete(1, all = False)

        # Assert
        self.assertEqual(0, s_list.len())
        self.assertIsNone(s_list.head)
        self.assertIsNone(s_list.tail)

    def test_delete_allTrueInHead_shouldDeleteHead(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))

        # Act
        s_list.delete(1, all = True)

        # Assert
        self.assertEqual(0, s_list.len())
        self.assertIsNone(s_list.head)
        self.assertIsNone(s_list.tail)

    def test_delete_allFalseInTail_shouldDeleteTail(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))

        # Act
        s_list.delete(2, all = False)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertEqual(1, s_list.len())
        self.assertEqual(1, s_list.head.value)
        self.assertIsNone(s_list.head.next)
        self.assertIsNone(s_list.head.prev)
        self.assertEqual(s_list.head, s_list.tail)

    def test_delete_allFalseInTailThreeElements_shouldDeleteTail(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))

        # Act
        s_list.delete(3, all = False)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertEqual(2, s_list.len())
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(2, s_list.head.next.value)
        self.assertEqual(1, s_list.tail.prev.value)
        self.assertIsNone(s_list.tail.next)
        self.assertIsNone(s_list.head.prev)
        self.assertEqual(s_list.head.next, s_list.tail)

    def test_delete_allTrueInTail_shouldDeleteTail(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))

        # Act
        s_list.delete(2, all = True)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertEqual(1, s_list.len())
        self.assertEqual(1, s_list.head.value)
        self.assertIsNone(s_list.head.next)
        self.assertIsNone(s_list.head.prev)
        self.assertEqual(s_list.head, s_list.tail)

    def test_delete_allFalseInHeadTwoElements_shouldDeleteHead(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))

        # Act
        s_list.delete(1, all = False)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertEqual(1, s_list.len())
        self.assertEqual(2, s_list.head.value)
        self.assertIsNone(s_list.head.next)
        self.assertIsNone(s_list.head.prev)
        self.assertEqual(s_list.head, s_list.tail)

    def test_delete_allFalseInHeadThreeElements_shouldDeleteHead(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))

        # Act
        s_list.delete(1, all = False)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertEqual(2, s_list.len())
        self.assertEqual(2, s_list.head.value)
        self.assertEqual(3, s_list.head.next.value)
        self.assertEqual(2, s_list.tail.prev.value)
        self.assertIsNone(s_list.tail.next)
        self.assertIsNone(s_list.head.prev)
        self.assertEqual(s_list.head.next, s_list.tail)

    def test_delete_allTrueInHeadTwoElements_shouldDeleteHead(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))

        # Act
        s_list.delete(1, all = True)

        # Assert
        self.assertIsNotNone(s_list.head)
        self.assertEqual(1, s_list.len())
        self.assertEqual(2, s_list.head.value)
        self.assertIsNone(s_list.head.next)
        self.assertIsNone(s_list.head.prev)
        self.assertEqual(s_list.head, s_list.tail)

    def test_delete_allFalseInMid_shouldDeleteMid(self):
        # Arrange
        s_list = LinkedList2()
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
        self.assertEqual(1, s_list.tail.prev.value)
        self.assertEqual(s_list.tail, s_list.head.next)
        self.assertIsNone(s_list.tail.next)
        self.assertIsNone(s_list.head.prev)

    def test_delete_allTrueInMid_shouldDeleteMid(self):
        # Arrange
        s_list = LinkedList2()
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
        self.assertEqual(1, s_list.tail.prev.value)
        self.assertEqual(s_list.tail, s_list.head.next)
        self.assertIsNone(s_list.tail.next)
        self.assertIsNone(s_list.head.prev)

    def test_delete_allTrueTwoEqualElements_shouldDeleteAll(self):
        # Arrange
        s_list = LinkedList2()
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
        s_list = LinkedList2()
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
        self.assertIsNone(s_list.head.prev)
        self.assertEqual(s_list.head, s_list.tail)

    def test_delete_allTrueThreeElementsInEnd_shouldDeleteAll(self):
        # Arrange
        s_list = LinkedList2()
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
        self.assertIsNone(s_list.head.prev)
        self.assertEqual(s_list.head, s_list.tail)

    def test_delete_allTrueFourElementsInHead_shouldDeleteAll(self):
        # Arrange
        s_list = LinkedList2()
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
        self.assertEqual(3, s_list.tail.prev.value)
        self.assertEqual(2, s_list.tail.prev.prev.value)
        
        self.assertEqual(s_list.head.next.next, s_list.tail)
        self.assertIsNone(s_list.tail.next)
        self.assertIsNone(s_list.head.prev)
    
    def test_delete_allTrueTwoEqualElementsWithGap_shouldDeleteAll(self):
        # Arrange
        s_list = LinkedList2()
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
        self.assertEqual(3, s_list.tail.prev.value)
        self.assertEqual(1, s_list.tail.prev.prev.value)
        self.assertEqual(s_list.head.next.next, s_list.tail)
        self.assertIsNone(s_list.tail.next)
        self.assertIsNone(s_list.head.prev)

    def test_delete_allTrueTwoEqualElementsInDifferentPlaces_shouldDeleteAll(self):
        # Arrange
        s_list = LinkedList2()
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
        self.assertEqual(3, s_list.tail.prev.value)
        self.assertEqual(1, s_list.tail.prev.prev.value)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next.next, s_list.tail)
        self.assertIsNone(s_list.tail.next)
        self.assertIsNone(s_list.head.prev)
    
    def test_delete_allTrueThreeEqualElementsInDifferentPlaces_shouldDeleteAll(self):
        # Arrange
        s_list = LinkedList2()
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
        self.assertEqual(3, s_list.tail.prev.value)
        self.assertEqual(1, s_list.tail.prev.prev.value)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.head.next.next, s_list.tail)
        self.assertIsNone(s_list.tail.next)
        self.assertIsNone(s_list.head.prev)

class Clean_LinkedList2Tests(unittest.TestCase):
    def test_clean_empty_shouldBeEmpty(self):
        # Arrange
        s_list = LinkedList2()

        # Act
        s_list.clean()

        # Assert
        self.assertIsNone(s_list.head)
        self.assertIsNone(s_list.tail)
        self.assertEqual(0, s_list.len())

    def test_clean_oneElement_shouldBeEmpty(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))

        # Act
        s_list.clean()

        # Assert
        self.assertIsNone(s_list.head)
        self.assertIsNone(s_list.tail)
        self.assertEqual(0, s_list.len())

    def test_clean_twoElements_shouldBeEmpty(self):
        # Arrange
        s_list = LinkedList2()
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
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))

        # Act
        s_list.clean()

        # Assert
        self.assertIsNone(s_list.head)
        self.assertIsNone(s_list.tail)
        self.assertEqual(0, s_list.len())

class FindAll_LinkedList2Tests(unittest.TestCase):
    def test_findAll_empty_shouldBeEmpty(self):
        # Arrange
        s_list = LinkedList2()

        # Act
        res = s_list.find_all(1)

        # Assert
        self.assertEqual([], res)

    def test_findAll_oneElementValueNotFound_shouldBeEmpty(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))

        # Act
        res = s_list.find_all(2)

        # Assert
        self.assertEqual(0, len(res))
        self.assertEqual([], res)

    def test_findAll_oneElementValueFound_shouldBeOne(self):
        # Arrange
        s_list = LinkedList2()
        node = Node(1)
        s_list.add_in_tail(node)

        # Act
        res = s_list.find_all(1)

        # Assert
        self.assertEqual(1, len(res))
        self.assertEqual(node, res[0])

    def test_findAll_twoElementsOneValueFound_shouldBeOne(self):
        # Arrange
        s_list = LinkedList2()
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
        s_list = LinkedList2()
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
        s_list = LinkedList2()
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
        s_list = LinkedList2()
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
        s_list = LinkedList2()
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

class Find_LinkedList2Tests(unittest.TestCase):
    def test_find_empty_shouldBeEmpty(self):
        # Arrange
        s_list = LinkedList2()

        # Act
        res = s_list.find(1)

        # Assert
        self.assertIsNone(res)

    def test_find_oneElementValueNotFound_shouldBeEmpty(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))

        # Act
        res = s_list.find(2)

        # Assert
        self.assertIsNone(res)

    def test_find_oneElementValueFound_shouldBeOne(self):
        # Arrange
        s_list = LinkedList2()
        node = Node(1)
        s_list.add_in_tail(node)

        # Act
        res = s_list.find(1)

        # Assert
        self.assertEqual(node, res)

    def test_find_twoElementsOneValueFound_shouldBeOne(self):
        # Arrange
        s_list = LinkedList2()
        node1 = Node(1)
        node2 = Node(2)
        s_list.add_in_tail(node1)
        s_list.add_in_tail(node2)

        # Act
        res = s_list.find(1)

        # Assert
        self.assertEqual(node1, res)

    def test_findAll_twoElementsTwoValueFound_shouldBeOne(self):
        # Arrange
        s_list = LinkedList2()
        node1 = Node(1)
        node2 = Node(1)
        s_list.add_in_tail(node1)
        s_list.add_in_tail(node2)

        # Act
        res = s_list.find(1)

        # Assert
        self.assertEqual(node1, res)

    def test_find_threeElementsOneValueFound_shouldBeOne(self):
        # Arrange
        s_list = LinkedList2()
        node1 = Node(1)
        node2 = Node(2)
        node3 = Node(3)
        s_list.add_in_tail(node1)
        s_list.add_in_tail(node2)
        s_list.add_in_tail(node3)

        # Act
        res = s_list.find(2)

        # Assert
        self.assertEqual(node2, res)

    def test_find_threeElementsTwoValueFound_shouldBeOne(self):
        # Arrange
        s_list = LinkedList2()
        node1 = Node(1)
        node2 = Node(2)
        node3 = Node(1)
        s_list.add_in_tail(node1)
        s_list.add_in_tail(node2)
        s_list.add_in_tail(node3)

        # Act
        res = s_list.find(1)

        # Assert
        self.assertEqual(node1, res)

class Insert_LinkedListTests(unittest.TestCase):
    def test_insert_empty_afterNone_shouldBeAddedAsFirstElement(self):
        # Arrange
        s_list = LinkedList2()
        
        # Act
        s_list.insert(None, Node(1))

        # Assert
        self.assertEqual(1, s_list.len())
        self.assertEqual(1, s_list.head.value)
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertIsNone(s_list.head.next)
        self.assertIsNone(s_list.head.prev)
        self.assertEqual(s_list.head, s_list.tail)

    def test_insert_oneElement_afterNone_shouldBeAddedAtEnd(self):
        # Arrange
        s_list = LinkedList2()
        
        # Act
        s_list.add_in_tail(Node(2))
        s_list.insert(None, Node(1))

        # Assert
        self.assertEqual(2, s_list.len())

        self.assertEqual(2, s_list.head.value)
        self.assertEqual(1, s_list.head.next.value)
        self.assertEqual(2, s_list.tail.prev.value)
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.tail, s_list.head.next)
        self.assertIsNone(s_list.tail.next)
        self.assertIsNone(s_list.head.prev)

    def test_insert_twoElements_afterNone_shouldBeAddedAtEnd(self):
        # Arrange
        s_list = LinkedList2()
        
        # Act
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))
        s_list.insert(None, Node(1))

        # Assert
        self.assertEqual(3, s_list.len())
        self.assertEqual(2, s_list.head.value)
        self.assertEqual(3, s_list.head.next.value)
        self.assertEqual(1, s_list.head.next.next.value)
        self.assertEqual(3, s_list.tail.prev.value)
        self.assertEqual(2, s_list.tail.prev.prev.value)
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.tail, s_list.head.next.next)
        self.assertIsNone(s_list.tail.next)
        self.assertIsNone(s_list.head.prev)

    def test_insert_oneElement_afterHead_shouldBeTwoElements(self):
        # Arrange
        s_list = LinkedList2()
        
        # Act
        s_list.add_in_tail(Node(1))
        s_list.insert(s_list.head, Node(2))

        # Assert
        self.assertEqual(2, s_list.len())
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(2, s_list.head.next.value)
        self.assertEqual(1, s_list.tail.prev.value)
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.tail, s_list.head.next)
        self.assertIsNone(s_list.tail.next)
        self.assertIsNone(s_list.head.prev)

    def test_insert_twoElements_afterHead_shouldBeThreeElements(self):
        # Arrange
        s_list = LinkedList2()
        
        # Act
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.insert(s_list.head, Node(3))

        # Assert
        self.assertEqual(3, s_list.len())
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(3, s_list.head.next.value)
        self.assertEqual(2, s_list.head.next.next.value)
        self.assertEqual(3, s_list.tail.prev.value)
        self.assertEqual(1, s_list.tail.prev.prev.value)
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.tail, s_list.head.next.next)
        self.assertIsNone(s_list.tail.next)
        self.assertIsNone(s_list.head.prev)

    def test_insert_twoElements_afterTail_shouldBeThreeElements(self):
        # Arrange
        s_list = LinkedList2()
        
        # Act
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.insert(s_list.tail, Node(3))

        # Assert
        self.assertEqual(3, s_list.len())
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(2, s_list.head.next.value)
        self.assertEqual(3, s_list.head.next.next.value)
        self.assertEqual(2, s_list.tail.prev.value)
        self.assertEqual(1, s_list.tail.prev.prev.value)
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.tail, s_list.head.next.next)
        self.assertIsNone(s_list.tail.next)
        self.assertIsNone(s_list.head.prev)

    def test_insert_threeElements_oneElementBeforeTail_shouldBeFourElements(self):
        # Arrange
        s_list = LinkedList2()
        
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
        self.assertEqual(3, s_list.tail.prev.value)
        self.assertEqual(2, s_list.tail.prev.prev.value)
        self.assertEqual(1, s_list.tail.prev.prev.prev.value)
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.tail, s_list.head.next.next.next)
        self.assertIsNone(s_list.tail.next)
        self.assertIsNone(s_list.head.prev)

    def test_insertDelete_multipleTimes_shouldBeCorrect(self):
        # Arrange
        s_list = LinkedList2()
        
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
        self.assertEqual(6, s_list.tail.prev.value)
        self.assertEqual(4, s_list.tail.prev.prev.value)
        self.assertEqual(2, s_list.tail.prev.prev.prev.value)
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.tail, s_list.head.next.next.next)
        self.assertIsNone(s_list.tail.next)
        self.assertIsNone(s_list.head.prev)

class AddInHead_LinkedListTests(unittest.TestCase):
    def test_addInHead_empty_shouldBeOneElement(self):
        # Arrange
        s_list = LinkedList2()
        
        # Act
        s_list.add_in_head(Node(1))

        # Assert
        self.assertEqual(1, s_list.len())
        self.assertEqual(1, s_list.head.value)
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertIsNone(s_list.head.next)
        self.assertIsNone(s_list.head.prev)
        self.assertEqual(s_list.head, s_list.tail)

    def test_addInHead_oneElement_shouldBeTwoElements(self):
        # Arrange
        s_list = LinkedList2()
        
        # Act
        s_list.add_in_tail(Node(2))
        s_list.add_in_head(Node(1))

        # Assert
        self.assertEqual(2, s_list.len())

        self.assertEqual(1, s_list.head.value)
        self.assertEqual(2, s_list.head.next.value)
        self.assertEqual(1, s_list.tail.prev.value)
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.tail, s_list.head.next)
        self.assertIsNone(s_list.tail.next)
        self.assertIsNone(s_list.head.prev)

    def test_addInHead_twoElements_shouldBeThreeElements(self):
        # Arrange
        s_list = LinkedList2()
        
        # Act
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))
        s_list.add_in_head(Node(1))

        # Assert
        self.assertEqual(3, s_list.len())
        self.assertEqual(1, s_list.head.value)
        self.assertEqual(2, s_list.head.next.value)
        self.assertEqual(3, s_list.head.next.next.value)
        self.assertEqual(2, s_list.tail.prev.value)
        self.assertEqual(1, s_list.tail.prev.prev.value)
        self.assertIsNotNone(s_list.head)
        self.assertIsNotNone(s_list.tail)
        self.assertEqual(s_list.tail, s_list.head.next.next)
        self.assertIsNone(s_list.tail.next)
        self.assertIsNone(s_list.head.prev)

class Reverse_LinkedListTests(unittest.TestCase):
    def test_reverse_empty_shouldBeCorrect(self):
        # Arrange
        s_list = LinkedList2()
        
        # Act
        new_list = reverse(s_list)

        # Assert
        self.assertEqual(0, new_list.len())
        self.assertIsNone(new_list.head)
        self.assertIsNone(new_list.tail)

    def test_reverse_oneElement_shouldBeCorrect(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        
        # Act
        new_list = reverse(s_list)

        # Assert
        self.assertEqual(1, new_list.len())
        self.assertEqual(1, new_list.head.value)
        self.assertIsNotNone(new_list.head)
        self.assertIsNone(new_list.head.prev)
        self.assertIsNotNone(new_list.tail)
        self.assertIsNone(new_list.tail.next)
        self.assertEqual(new_list.head, new_list.tail)

    def test_reverse_twoElements_shouldBeCorrect(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        
        # Act
        new_list = reverse(s_list)

        # Assert
        self.assertEqual(2, new_list.len())
        self.assertEqual(2, new_list.head.value)
        self.assertEqual(1, new_list.head.next.value)
        self.assertEqual(2, new_list.tail.prev.value)
        self.assertIsNotNone(new_list.head)
        self.assertIsNotNone(new_list.tail)
        self.assertEqual(new_list.head.next, new_list.tail)
        self.assertIsNone(new_list.head.prev)
        self.assertIsNone(new_list.tail.next)

    def test_reverse_threeElements_shouldBeCorrect(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))
        
        # Act
        new_list = reverse(s_list)

        # Assert
        self.assertEqual(3, new_list.len())
        self.assertEqual(3, new_list.head.value)
        self.assertEqual(2, new_list.head.next.value)
        self.assertEqual(1, new_list.head.next.next.value)
        self.assertEqual(2, new_list.tail.prev.value)
        self.assertEqual(3, new_list.tail.prev.prev.value)
        self.assertIsNotNone(new_list.head)
        self.assertIsNotNone(new_list.tail)
        self.assertEqual(new_list.head.next.next, new_list.tail)
        self.assertIsNone(new_list.head.prev)
        self.assertIsNone(new_list.tail.next)

    def test_reverse_fourElements_shouldBeCorrect(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(5))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))
        
        # Act
        new_list = reverse(s_list)

        # Assert
        self.assertEqual(4, new_list.len())
        self.assertEqual(3, new_list.head.value)
        self.assertEqual(2, new_list.head.next.value)
        self.assertEqual(5, new_list.head.next.next.value)
        self.assertEqual(1, new_list.head.next.next.next.value)
        self.assertEqual(5, new_list.tail.prev.value)
        self.assertEqual(2, new_list.tail.prev.prev.value)
        self.assertEqual(3, new_list.tail.prev.prev.prev.value)
        self.assertIsNotNone(new_list.head)
        self.assertIsNotNone(new_list.tail)
        self.assertEqual(new_list.head.next.next.next, new_list.tail)
        self.assertIsNone(new_list.head.prev)
        self.assertIsNone(new_list.tail.next)

class HasCycle_LinkedListTests(unittest.TestCase):
    def test_hasCycle_empty_shouldBeCorrect(self):
        # Arrange
        s_list = LinkedList2()
        
        # Act

        # Assert
        self.assertFalse(hasCycle(s_list))

    def test_hasCycle_oneElement_shouldBeCorrect(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        
        # Act

        # Assert
        self.assertFalse(hasCycle(s_list))

    def test_hasCycle_twoElements_shouldBeCorrect(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        
        # Act

        # Assert
        self.assertFalse(hasCycle(s_list))

    def test_hasCycle_threeElements_shouldBeCorrect(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))
        
        # Act

        # Assert
        self.assertFalse(hasCycle(s_list))

    def test_hasCycle_oneElementWithNextCycle_shouldFoundCycle(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.head.next = s_list.head
        
        # Act

        # Assert
        self.assertTrue(hasCycle(s_list))

    def test_hasCycle_threeElementsWithNextCycle_shouldFoundCycle(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))
        s_list.head.next.next = s_list.head
        
        # Act

        # Assert
        self.assertTrue(hasCycle(s_list))

    def test_hasCycle_oneElementWithPrevSelfCycle_shouldFoundCycle(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.head.prev = s_list.head
        
        # Act

        # Assert
        self.assertTrue(hasCycle(s_list))

    def test_hasCycle_twoElementsWithPrevHeadSelfCycle_shouldFoundCycle(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.head.prev = s_list.head
        
        # Act

        # Assert
        self.assertTrue(hasCycle(s_list))

    def test_hasCycle_twoElementsWithNextTailCycle_shouldFoundCycle(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.tail.next = s_list.head
        
        # Act

        # Assert
        self.assertTrue(hasCycle(s_list))

    def test_hasCycle_threeElementsWithPrevSelfCycle_shouldFoundCycle(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))
        s_list.tail.prev = s_list.tail
        
        # Act

        # Assert
        self.assertTrue(hasCycle(s_list))

    def test_hasCycle_threeElementsWithPrevCycle_shouldFoundCycle(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))
        s_list.head.prev = s_list.tail
        
        # Act

        # Assert
        self.assertTrue(hasCycle(s_list))

    def test_hasCycle_threeElementsWithNextTailCycle_shouldFoundCycle(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))
        s_list.tail.next = s_list.head
        
        # Act

        # Assert
        self.assertTrue(hasCycle(s_list))

class Split_LinkedListTests(unittest.TestCase):
    def test_empty_shouldBeEmpty(self):
        # Arrange
        s_list = LinkedList2()
        
        # Act
        list1, list2 = split(s_list)

        # Assert
        self.assertIsNotNone(list1)
        self.assertIsNotNone(list2)
        self.assertEqual(0, list1.len())
        self.assertEqual(0, list2.len())

    def test_oneElement_shouldBeCorrect(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        
        # Act
        list1, list2 = split(s_list)

        # Assert
        self.assertIsNotNone(list1)
        self.assertIsNotNone(list2)
        self.assertEqual(1, list1.len())
        self.assertEqual(0, list2.len())
        self.assertEqual(1, list1.head.value)
        self.assertIsNone(list1.head.next)
        self.assertIsNone(list1.head.prev)
    
    def test_twoElement_shouldBeCorrect(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        
        # Act
        list1, list2 = split(s_list)

        # Assert
        self.assertIsNotNone(list1)
        self.assertIsNotNone(list2)
        self.assertEqual(1, list1.len())
        self.assertEqual(1, list2.len())

        self.assertEqual(1, list1.head.value)
        self.assertIsNone(list1.head.next)
        self.assertIsNone(list1.head.prev)

        self.assertEqual(2, list2.head.value)
        self.assertIsNone(list2.head.next)
        self.assertIsNone(list2.head.prev)
        

    def test_threeElement_shouldBeCorrect(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))
        
        # Act
        list1, list2 = split(s_list)

        # Assert
        self.assertIsNotNone(list1)
        self.assertIsNotNone(list2)
        self.assertEqual(1, list1.len())
        self.assertEqual(2, list2.len())

        self.assertEqual(1, list1.head.value)
        self.assertIsNone(list1.head.next)
        self.assertIsNone(list1.head.prev)
        
        self.assertEqual(2, list2.head.value)
        self.assertEqual(3, list2.head.next.value)
        self.assertEqual(2, list2.tail.prev.value)
        self.assertIsNone(list2.head.next.next)
        self.assertIsNone(list2.head.prev)

    def test_fourElement_shouldBeCorrect(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))
        s_list.add_in_tail(Node(4))
        
        # Act
        list1, list2 = split(s_list)

        # Assert
        self.assertIsNotNone(list1)
        self.assertIsNotNone(list2)
        self.assertEqual(2, list1.len())
        self.assertEqual(2, list2.len())

        self.assertEqual(1, list1.head.value)
        self.assertEqual(2, list1.head.next.value)
        self.assertEqual(1, list1.tail.prev.value)
        self.assertIsNone(list1.head.next.next)
        self.assertIsNone(list1.head.prev)
        
        self.assertEqual(3, list2.head.value)
        self.assertEqual(4, list2.head.next.value)
        self.assertEqual(3, list2.tail.prev.value)
        self.assertIsNone(list2.head.next.next)
        self.assertIsNone(list2.head.prev)

    def test_fiveElement_shouldBeCorrect(self):
        # Arrange
        s_list = LinkedList2()
        s_list.add_in_tail(Node(1))
        s_list.add_in_tail(Node(2))
        s_list.add_in_tail(Node(3))
        s_list.add_in_tail(Node(4))
        s_list.add_in_tail(Node(5))
        
        # Act
        list1, list2 = split(s_list)

        # Assert
        self.assertIsNotNone(list1)
        self.assertIsNotNone(list2)
        self.assertEqual(2, list1.len())
        self.assertEqual(3, list2.len())

        self.assertEqual(1, list1.head.value)
        self.assertEqual(2, list1.head.next.value)
        self.assertEqual(1, list1.tail.prev.value)
        self.assertIsNone(list1.head.next.next)
        self.assertIsNone(list1.head.prev)
        
        self.assertEqual(3, list2.head.value)
        self.assertEqual(4, list2.head.next.value)
        self.assertEqual(5, list2.head.next.next.value)
        self.assertEqual(4, list2.tail.prev.value)
        self.assertEqual(3, list2.tail.prev.prev.value)
        self.assertIsNone(list2.head.next.next.next)
        self.assertIsNone(list2.head.prev)

class Merge_LinkedListTests(unittest.TestCase):
    def test_rightListIsEmpty_shouldBeOk(self):
        # Arrange
        list1 = LinkedList2()
        list1.add_in_tail(Node(1))
        
        # Act
        res = merge(list1, LinkedList2())

        # Assert
        self.assertIsNotNone(res)
        self.assertEqual(1, res.len())
        self.assertEqual(1, list1.head.value)
        self.assertIsNone(list1.head.next)
        self.assertIsNone(list1.head.prev)

    def test_leftListIsEmpty_shouldBeOk(self):
        # Arrange
        list1 = LinkedList2()
        list1.add_in_tail(Node(1))
        
        # Act
        res = merge(LinkedList2(), list1)

        # Assert
        self.assertIsNotNone(res)
        self.assertEqual(1, res.len())
        self.assertEqual(1, list1.head.value)
        self.assertIsNone(list1.head.next)
        self.assertIsNone(list1.head.prev)

    def test_empty_shouldBeOk(self):
        # Arrange
        
        # Act
        res = merge(LinkedList2(), LinkedList2())

        # Assert
        self.assertIsNotNone(res)
        self.assertEqual(0, res.len())

    def test_oneElementInEach_shouldBeOk(self):
        # Arrange
        left = LinkedList2()
        left.add_in_tail(Node(2))
        right = LinkedList2()
        right.add_in_tail(Node(1))
        
        # Act
        res = merge(left, right)

        # Assert
        self.assertEqual(2, res.len())
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertIsNone(res.head.next.next)
        self.assertIsNone(res.head.prev)

    def test_twoInLeftOneInRight_shouldBeOk(self):
        # Arrange
        left = LinkedList2()
        left.add_in_tail(Node(2))
        left.add_in_tail(Node(3))
        right = LinkedList2()
        right.add_in_tail(Node(1))
        
        # Act
        res = merge(left, right)

        # Assert
        self.assertEqual(3, res.len())
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(3, res.head.next.next.value)
        self.assertEqual(2, res.tail.prev.value)
        self.assertEqual(1, res.tail.prev.prev.value)
        self.assertIsNone(res.head.next.next.next)
        self.assertIsNone(res.head.prev)

    def test_oneInLeftTwoInRight_shouldBeOk(self):
        # Arrange
        left = LinkedList2()
        left.add_in_tail(Node(3))
        right = LinkedList2()
        right.add_in_tail(Node(1))
        right.add_in_tail(Node(2))
        
        # Act
        res = merge(left, right)

        # Assert
        self.assertEqual(3, res.len())
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(3, res.head.next.next.value)
        self.assertEqual(2, res.tail.prev.value)
        self.assertEqual(1, res.tail.prev.prev.value)
        self.assertIsNone(res.head.next.next.next)
        self.assertIsNone(res.head.prev)

    def test_twoInLeftTwoInRight_shouldBeOk(self):
        # Arrange
        left = LinkedList2()
        left.add_in_tail(Node(3))
        left.add_in_tail(Node(4))
        right = LinkedList2()
        right.add_in_tail(Node(1))
        right.add_in_tail(Node(2))
        
        # Act
        res = merge(left, right)

        # Assert
        self.assertEqual(4, res.len())
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(3, res.head.next.next.value)
        self.assertEqual(4, res.head.next.next.next.value)
        self.assertEqual(3, res.tail.prev.value)
        self.assertEqual(2, res.tail.prev.prev.value)
        self.assertEqual(1, res.tail.prev.prev.prev.value)
        self.assertIsNone(res.head.next.next.next.next)
        self.assertIsNone(res.head.prev)

    def test_threeInLeftTwoInRight_shouldBeOk(self):
        # Arrange
        left = LinkedList2()
        left.add_in_tail(Node(3))
        left.add_in_tail(Node(4))
        left.add_in_tail(Node(5))
        right = LinkedList2()
        right.add_in_tail(Node(1))
        right.add_in_tail(Node(2))
        
        # Act
        res = merge(left, right)

        # Assert
        self.assertEqual(5, res.len())
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(3, res.head.next.next.value)
        self.assertEqual(4, res.head.next.next.next.value)
        self.assertEqual(5, res.head.next.next.next.next.value)
        self.assertEqual(4, res.tail.prev.value)
        self.assertEqual(3, res.tail.prev.prev.value)
        self.assertEqual(2, res.tail.prev.prev.prev.value)
        self.assertEqual(1, res.tail.prev.prev.prev.prev.value)
        self.assertIsNone(res.head.next.next.next.next.next)
        self.assertIsNone(res.head.prev)
    
    def test_twoInLeftThreeInRight_shouldBeOk(self):
        # Arrange
        left = LinkedList2()
        left.add_in_tail(Node(2))
        left.add_in_tail(Node(4))
        right = LinkedList2()
        right.add_in_tail(Node(1))
        right.add_in_tail(Node(2))
        right.add_in_tail(Node(3))
        
        # Act
        res = merge(left, right)

        # Assert
        self.assertEqual(5, res.len())
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(2, res.head.next.next.value)
        self.assertEqual(3, res.head.next.next.next.value)
        self.assertEqual(4, res.head.next.next.next.next.value)
        self.assertEqual(3, res.tail.prev.value)
        self.assertEqual(2, res.tail.prev.prev.value)
        self.assertEqual(2, res.tail.prev.prev.prev.value)
        self.assertEqual(1, res.tail.prev.prev.prev.prev.value)
        self.assertIsNone(res.head.next.next.next.next.next)
        self.assertIsNone(res.head.prev)

class Sort_LinkedListTests(unittest.TestCase):
    def test_sort_empty_shouldBeOk(self):
        # Arrange

        
        # Act
        res = sort(LinkedList2())

        # Assert
        self.assertIsNotNone(res)
        self.assertEqual(0, res.len())

    def test_srt_oneNode_shouldBeOk(self):
        # Arrange
        list1 = LinkedList2()
        list1.add_in_tail(Node(1))
        
        # Act
        res = sort(list1)

        # Assert
        self.assertIsNotNone(res)
        self.assertEqual(1, res.len())
        self.assertEqual(1, list1.head.value)
        self.assertIsNone(list1.head.next)
        self.assertIsNone(list1.head.prev)

    def test_sort_twoElements_shouldBeOk(self):
        # Arrange
        lst = LinkedList2()
        lst.add_in_tail(Node(2))
        lst.add_in_tail(Node(1))
        
        # Act
        res = sort(lst)

        # Assert
        self.assertEqual(2, res.len())
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertIsNone(res.head.next.next)
        self.assertIsNone(res.head.prev)

    def test_sort_threeElements_shouldBeOk(self):
        # Arrange
        lst = LinkedList2()
        lst.add_in_tail(Node(2))
        lst.add_in_tail(Node(3))
        lst.add_in_tail(Node(1))
        
        # Act
        res = sort(lst)

        # Assert
        self.assertEqual(3, res.len())
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(3, res.head.next.next.value)
        self.assertEqual(2, res.tail.prev.value)
        self.assertEqual(1, res.tail.prev.prev.value)
        self.assertIsNone(res.head.next.next.next)
        self.assertIsNone(res.head.prev)

    def test_threeElementsTwoEqual_shouldBeOk(self):
        # Arrange
        lst = LinkedList2()
        lst.add_in_tail(Node(3))
        lst.add_in_tail(Node(2))
        lst.add_in_tail(Node(3))
        
        # Act
        res = sort(lst)

        # Assert
        self.assertEqual(3, res.len())
        self.assertEqual(2, res.head.value)
        self.assertEqual(3, res.head.next.value)
        self.assertEqual(3, res.head.next.next.value)
        self.assertEqual(3, res.tail.prev.value)
        self.assertEqual(2, res.tail.prev.prev.value)
        self.assertIsNone(res.head.next.next.next)
        self.assertIsNone(res.head.prev)

    def test_sort_fourElements_shouldBeOk(self):
        # Arrange
        lst = LinkedList2()
        lst.add_in_tail(Node(3))
        lst.add_in_tail(Node(4))
        lst.add_in_tail(Node(1))
        lst.add_in_tail(Node(2))
        
        # Act
        res = sort(lst)

        # Assert
        self.assertEqual(4, res.len())
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(3, res.head.next.next.value)
        self.assertEqual(4, res.head.next.next.next.value)
        self.assertEqual(3, res.tail.prev.value)
        self.assertEqual(2, res.tail.prev.prev.value)
        self.assertEqual(1, res.tail.prev.prev.prev.value)
        self.assertIsNone(res.head.next.next.next.next)
        self.assertIsNone(res.head.prev)

    def test_sort_fiveElements_shouldBeOk(self):
        # Arrange
        lst = LinkedList2()
        lst.add_in_tail(Node(3))
        lst.add_in_tail(Node(4))
        lst.add_in_tail(Node(5))
        lst.add_in_tail(Node(1))
        lst.add_in_tail(Node(2))
        
        # Act
        res = sort(lst)

        # Assert
        self.assertEqual(5, res.len())
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(3, res.head.next.next.value)
        self.assertEqual(4, res.head.next.next.next.value)
        self.assertEqual(5, res.head.next.next.next.next.value)
        self.assertEqual(4, res.tail.prev.value)
        self.assertEqual(3, res.tail.prev.prev.value)
        self.assertEqual(2, res.tail.prev.prev.prev.value)
        self.assertEqual(1, res.tail.prev.prev.prev.prev.value)
        self.assertIsNone(res.head.next.next.next.next.next)
        self.assertIsNone(res.head.prev)
    
    def test_fiveElementsWithDuplicates_shouldBeOk(self):
        # Arrange
        lst = LinkedList2()
        lst.add_in_tail(Node(2))
        lst.add_in_tail(Node(4))
        lst.add_in_tail(Node(1))
        lst.add_in_tail(Node(2))
        lst.add_in_tail(Node(3))
        
        # Act
        res = sort(lst)

        # Assert
        self.assertEqual(5, res.len())
        self.assertEqual(1, res.head.value)
        self.assertEqual(2, res.head.next.value)
        self.assertEqual(2, res.head.next.next.value)
        self.assertEqual(3, res.head.next.next.next.value)
        self.assertEqual(4, res.head.next.next.next.next.value)
        self.assertEqual(3, res.tail.prev.value)
        self.assertEqual(2, res.tail.prev.prev.value)
        self.assertEqual(2, res.tail.prev.prev.prev.value)
        self.assertEqual(1, res.tail.prev.prev.prev.prev.value)
        self.assertIsNone(res.head.next.next.next.next.next)
        self.assertIsNone(res.head.prev)

if __name__ == "__main__":
    unittest.main()