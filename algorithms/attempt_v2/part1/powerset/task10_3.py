import unittest
from task10 import PowerSet
from task10_2 import cartesianProduct, multiIntersection

class Put_PowerSetTests(unittest.TestCase):
    def test_put_empty_shouldBeCorrect(self):
        # Arrange
        ps = PowerSet()

        # Act
        ps.put('1')

        # Assert
        self.assertEqual(1, ps.size())
        self.assertTrue(ps.get('1'))
        self.assertFalse(ps.get('2'))

    def test_put_oneElement_shouldBeCorrect(self):
        # Arrange
        ps = PowerSet()

        # Act
        ps.put('1')
        ps.put('2')

        # Assert
        self.assertEqual(2, ps.size())
        self.assertTrue(ps.get('1'))
        self.assertTrue(ps.get('2'))
        self.assertFalse(ps.get('3'))

    def test_put_threeElements_shouldBeCorrect(self):
        # Arrange
        ps = PowerSet()

        # Act
        ps.put('1')
        ps.put('2')
        ps.put('3')

        # Assert
        self.assertEqual(3, ps.size())
        self.assertTrue(ps.get('1'))
        self.assertTrue(ps.get('2'))
        self.assertTrue(ps.get('3'))
        self.assertFalse(ps.get('4'))

    def test_put_threeElementsWithDuplicates_shouldBeCorrect(self):
        # Arrange
        ps = PowerSet()

        # Act
        ps.put('1')
        ps.put('2')
        ps.put('3')

        ps.put('1')
        ps.put('2')
        ps.put('3')

        # Assert
        self.assertEqual(3, ps.size())
        self.assertTrue(ps.get('1'))
        self.assertTrue(ps.get('2'))
        self.assertTrue(ps.get('3'))
        self.assertFalse(ps.get('4'))

    def test_put_30ThousandsElements_shouldBeCorrect(self):
        # Arrange
        ps = PowerSet()
        sz = 30000

        # Act
        for i in range(sz):
            ps.put(str(i))

        for i in range(sz):
            self.assertTrue(ps.get(str(i)))

        # Assert
        self.assertEqual(sz, ps.size())

    def test_put_30ThousandsElementsWithDuplicates_shouldBeCorrect(self):
        # Arrange
        ps = PowerSet()
        sz = 30000

        # Act
        for i in range(sz):
            ps.put(str(i))
            ps.put(str(i))

        for i in range(sz):
            self.assertTrue(ps.get(str(i)))

        # Assert
        self.assertEqual(sz, ps.size())

class Remove_PowerSetTests(unittest.TestCase):
    def test_remove_empty_shouldBeFalse(self):
        # Arrange
        ps = PowerSet()

        # Act

        # Assert
        self.assertFalse(ps.remove('2'))
        self.assertEqual(0, ps.size())

    def test_remove_oneElementNotExisting_shouldBeFalse(self):
        # Arrange
        ps = PowerSet()

        # Act
        ps.put('1')

        # Assert
        self.assertFalse(ps.remove('2'))
        self.assertEqual(1, ps.size())

    def test_remove_oneElementExisting_shouldBeTrue(self):
        # Arrange
        ps = PowerSet()

        # Act
        ps.put('2')

        # Assert
        self.assertTrue(ps.remove('2'))
        self.assertEqual(0, ps.size())

    def test_remove_twoElementsExisting_shouldBeTrue(self):
        # Arrange
        ps = PowerSet()

        # Act
        ps.put('1')
        ps.put('2')

        # Assert
        self.assertEqual(2, ps.size())
        self.assertTrue(ps.remove('2'))
        self.assertEqual(1, ps.size())
        self.assertTrue(ps.get('1'))

    def test_remove_30ThousandsElements_shouldBeCorrect(self):
        # Arrange
        ps = PowerSet()
        sz = 30000

        # Act
        for i in range(sz):
            ps.put(str(i))

        for i in range(sz):
            self.assertTrue(ps.remove(str(i)))

        # Assert
        self.assertEqual(0, ps.size())

class Intersection_PowerSetTests(unittest.TestCase):
    def test_intersection_empty_shouldBeEmpty(self):
        # Arrange
        ps1 = PowerSet()
        ps2 = PowerSet()

        # Act
        res = ps1.intersection(ps2)

        # Assert
        self.assertEqual(0, res.size())

    def test_intersection_firstNotEmpty_shouldBeEmpty(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps2 = PowerSet()

        # Act
        res = ps1.intersection(ps2)

        # Assert
        self.assertEqual(0, res.size())

    def test_intersection_secondNotEmpty_shouldBeEmpty(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps2 = PowerSet()

        # Act
        res = ps1.intersection(ps2)

        # Assert
        self.assertEqual(0, res.size())

    def test_intersection_oneEqualElement_shouldNotBeEmpty(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps2 = PowerSet()
        ps2.put('1')

        # Act
        res = ps1.intersection(ps2)

        # Assert
        self.assertEqual(1, res.size())
        self.assertTrue(res.get('1'))

    def test_intersection_oneAndTwo_shouldNotBeEmpty(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps2 = PowerSet()
        ps2.put('1')
        ps2.put('2')

        # Act
        res = ps1.intersection(ps2)

        # Assert
        self.assertEqual(1, res.size())
        self.assertTrue(res.get('1'))

    def test_intersection_twoAndOne_shouldNotBeEmpty(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps1.put('2')
        ps2 = PowerSet()
        ps2.put('1')

        # Act
        res = ps1.intersection(ps2)

        # Assert
        self.assertEqual(1, res.size())
        self.assertTrue(res.get('1'))

    def test_intersection_twoAndTwoDiffers_shouldBeEmpty(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps1.put('2')
        ps2 = PowerSet()
        ps2.put('3')
        ps2.put('4')

        # Act
        res = ps1.intersection(ps2)

        # Assert
        self.assertEqual(0, res.size())

    def test_intersection_twoAndTwo_shouldBeTwoElements(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps1.put('2')
        ps2 = PowerSet()
        ps2.put('1')
        ps2.put('2')

        # Act
        res = ps1.intersection(ps2)

        # Assert
        self.assertEqual(2, res.size())
        self.assertTrue(res.get('1'))
        self.assertTrue(res.get('2'))

    def test_intersection_fiveAndThree_shouldBeThree(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps1.put('2')
        ps1.put('3')
        ps1.put('4')
        ps1.put('5')
        ps2 = PowerSet()
        ps2.put('1')
        ps2.put('2')
        ps2.put('3')

        # Act
        res = ps1.intersection(ps2)

        # Assert
        self.assertEqual(3, res.size())
        self.assertTrue(res.get('1'))
        self.assertTrue(res.get('2'))
        self.assertTrue(res.get('3'))

    def test_intersection_fiveAndThree_shouldBeTwo(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps1.put('2')
        ps1.put('4')
        ps2 = PowerSet()
        ps2.put('1')
        ps2.put('2')
        ps2.put('3')
        ps2.put('4')
        ps2.put('5')

        # Act
        res = ps1.intersection(ps2)

        # Assert
        self.assertEqual(3, res.size())
        self.assertTrue(res.get('1'))
        self.assertTrue(res.get('2'))
        self.assertTrue(res.get('4'))

    def test_intersection_15And15Thousands_shouldBe15Thousands(self):
        # Arrange
        sz = 15000
        ps1 = PowerSet()
        for i in range(sz):
            ps1.put(str(i))

        ps2 = PowerSet()
        for i in range(sz * 2):
            ps2.put(str(i))

        # Act
        res = ps1.intersection(ps2)

        # Assert
        self.assertEqual(sz, res.size())
        for i in range(sz):
            self.assertTrue(res.get(str(i)))

class Union_PowerSetTests(unittest.TestCase):
    def test_union_empty_shouldBeEmpty(self):
        # Arrange
        ps1 = PowerSet()
        ps2 = PowerSet()

        # Act
        res = ps1.union(ps2)

        # Assert
        self.assertEqual(0, res.size())

    def test_union_firstEmpty_shouldNotBeEmpty(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps2 = PowerSet()

        # Act
        res = ps1.union(ps2)

        # Assert
        self.assertEqual(1, res.size())
        self.assertTrue(res.get('1'))

    def test_union_secondEmpty_shouldNotBeEmpty(self):
        # Arrange
        ps1 = PowerSet()
        ps2 = PowerSet()
        ps2.put('1')

        # Act
        res = ps1.union(ps2)

        # Assert
        self.assertEqual(1, res.size())
        self.assertTrue(res.get('1'))

    def test_union_notEmpty_shouldNotBeEmpty(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps2 = PowerSet()
        ps2.put('2')

        # Act
        res = ps1.union(ps2)

        # Assert
        self.assertEqual(2, res.size())
        self.assertTrue(res.get('1'))
        self.assertTrue(res.get('2'))

    def test_union_notEmpty_shouldBeThreeElements(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps2 = PowerSet()
        ps2.put('2')
        ps2.put('3')

        # Act
        res = ps1.union(ps2)

        # Assert
        self.assertEqual(3, res.size())
        self.assertTrue(res.get('1'))
        self.assertTrue(res.get('2'))
        self.assertTrue(res.get('3'))

    def test_union_notEmpty_shouldBeFourElements(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps1.put('1')
        ps1.put('1')
        ps1.put('5')
        ps2 = PowerSet()
        ps2.put('2')
        ps2.put('3')
        ps2.put('3')
        ps2.put('3')

        # Act
        res = ps1.union(ps2)

        # Assert
        self.assertEqual(4, res.size())
        self.assertTrue(res.get('1'))
        self.assertTrue(res.get('2'))
        self.assertTrue(res.get('3'))
        self.assertTrue(res.get('5'))

    def test_union_notEmpty_shouldBe30ThousandsElements(self):
        # Arrange
        sz = 15000
        ps1 = PowerSet()
        for i in range(sz):
            ps1.put(str(i))

        ps2 = PowerSet()
        for i in range(sz * 2):
            ps2.put(str(i))

        # Act
        res = ps1.union(ps2)

        # Assert
        self.assertEqual(sz *2, res.size())

        for i in range(sz * 2):
            self.assertTrue(res.get(str(i)))

class Difference_PowerSetTests(unittest.TestCase):
    def test_difference_empty_shouldBeEmpty(self):
        # Arrange
        ps1 = PowerSet()
        ps2 = PowerSet()

        # Act
        res = ps1.difference(ps2)

        # Assert
        self.assertEqual(0, res.size())

    def test_difference_firstEmpty_shouldBeEmpty(self):
        # Arrange
        ps1 = PowerSet()
        ps2 = PowerSet()
        ps2.put('2')

        # Act
        res = ps1.difference(ps2)

        # Assert
        self.assertEqual(0, res.size())

    def test_difference_secondEmpty_shouldBeOnElement(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('2')
        ps2 = PowerSet()

        # Act
        res = ps1.difference(ps2)

        # Assert
        self.assertEqual(1, res.size())
        self.assertTrue(res.get('2'))

    def test_difference_oneElementInEach_shouldBeFirstOneElement(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps2 = PowerSet()
        ps2.put('2')

        # Act
        res = ps1.difference(ps2)

        # Assert
        self.assertEqual(1, res.size())
        self.assertTrue(res.get('1'))

    def test_difference_oneElementInEach_shouldBeSecondOneElement(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps2 = PowerSet()
        ps2.put('2')

        # Act
        res = ps2.difference(ps1)

        # Assert
        self.assertEqual(1, res.size())
        self.assertTrue(res.get('2'))

    def test_difference_equal_shouldBeEmpty(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps1.put('2')
        ps2 = PowerSet()
        ps2.put('1')
        ps2.put('2')

        # Act
        res = ps2.difference(ps1)

        # Assert
        self.assertEqual(0, res.size())

    def test_difference_threeAndFive_shouldBeEmpty(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps1.put('2')
        ps1.put('3')
        ps2 = PowerSet()
        ps2.put('1')
        ps2.put('2')
        ps2.put('3')
        ps2.put('4')
        ps2.put('5')

        # Act
        res = ps1.difference(ps2)

        # Assert
        self.assertEqual(0, res.size())

    def test_difference_fiveAndThree_shouldBeTwoElements(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps1.put('2')
        ps1.put('3')
        ps2 = PowerSet()
        ps2.put('1')
        ps2.put('2')
        ps2.put('3')
        ps2.put('4')
        ps2.put('5')

        # Act
        res = ps2.difference(ps1)

        # Assert
        self.assertEqual(2, res.size())
        self.assertTrue(res.get('4'))
        self.assertTrue(res.get('5'))
        self.assertFalse(res.get('1'))

    def test_difference_15ThousandsElements_shouldBe15ThousandsElements(self):
        # Arrange
        sz = 15000
        ps1 = PowerSet()
        for i in range(sz):
            ps1.put(str(i))
        ps2 = PowerSet()
        for i in range(sz * 2):
            ps2.put(str(i))

        # Act
        res = ps2.difference(ps1)

        # Assert
        self.assertEqual(sz, res.size())
        for i in range(sz):
            res.get(str(i))

class IsSubset_PowerSetTests(unittest.TestCase):
    def test_issubset_empty_shouldBeTrue(self):
        # Arrange
        ps1 = PowerSet()
        ps2 = PowerSet()

        # Assert
        self.assertTrue(ps1.issubset(ps2))

    def test_issubset_firstNotEmpty_shouldBeTrue(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps2 = PowerSet()

        # Assert
        self.assertTrue(ps1.issubset(ps2))

    def test_issubset_secondNotEmpty_shouldBeFalse(self):
        # Arrange
        ps1 = PowerSet()
        ps2 = PowerSet()
        ps2.put('1')

        # Assert
        self.assertFalse(ps1.issubset(ps2))

    def test_issubset_equalSets_shouldBeTrue(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps1.put('2')
        ps2 = PowerSet()
        ps2.put('1')
        ps2.put('2')

        # Assert
        self.assertTrue(ps1.issubset(ps2))

    def test_issubset_partiallyEqualSets_shouldBeTrue(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps1.put('2')
        ps2 = PowerSet()
        ps2.put('1')

        # Assert
        self.assertTrue(ps1.issubset(ps2))

    def test_issubset_notEqualSets_shouldBeFalse(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps1.put('2')
        ps2 = PowerSet()
        ps2.put('3')

        # Assert
        self.assertFalse(ps1.issubset(ps2))

    def test_issubset_fiveAndThree_shouldBeTrue(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps1.put('2')
        ps1.put('3')
        ps1.put('4')
        ps1.put('5')
        ps2 = PowerSet()
        ps2.put('1')
        ps2.put('2')
        ps2.put('3')

        # Assert
        self.assertTrue(ps1.issubset(ps2))

    def test_issubset_fiveAndFour_shouldBeFalse(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps1.put('2')
        ps1.put('3')
        ps1.put('4')
        ps1.put('5')
        ps2 = PowerSet()
        ps2.put('1')
        ps2.put('2')
        ps2.put('3')
        ps2.put('6')

        # Assert
        self.assertFalse(ps1.issubset(ps2))

class Equals_PowerSetTests(unittest.TestCase):
    def test_equals_empty_shouldBeTrue(self):
        # Arrange
        ps1 = PowerSet()
        ps2 = PowerSet()

        # Assert
        self.assertTrue(ps1.equals(ps2))

    def test_equals_differentSize_shouldBeFalse(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps2 = PowerSet()
        ps2.put('2')
        ps2.put('3')

        # Assert
        self.assertFalse(ps1.equals(ps2))

    def test_equals_equalSize_shouldBeFalse(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps1.put('4')
        ps2 = PowerSet()
        ps2.put('2')
        ps2.put('3')

        # Assert
        self.assertFalse(ps1.equals(ps2))

    def test_equals_equalSize_shouldBeTrue(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps1.put('4')
        ps2 = PowerSet()
        ps2.put('1')
        ps2.put('4')

        # Assert
        self.assertTrue(ps1.equals(ps2))

    def test_equals_equalSizeFour_shouldBeTrue(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps1.put('4')
        ps1.put('2')
        ps1.put('3')
        ps2 = PowerSet()
        ps2.put('1')
        ps2.put('2')
        ps2.put('3')
        ps2.put('4')

        # Assert
        self.assertTrue(ps1.equals(ps2))


class CartesianProduct_PowerSetTests(unittest.TestCase):
    def test_cartesianProduct_empty_shouldBeEmpty(self):
        # Arrange
        ps1 = PowerSet()
        ps2 = PowerSet()
        res = list(cartesianProduct(ps1, ps2))

        # Assert
        self.assertEqual(0, len(res))

    def test_cartesianProduct_secondEmpty_shouldBeEmpty(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps1.put('2')
        ps2 = PowerSet()
        res = list(cartesianProduct(ps1, ps2))

        # Assert
        self.assertEqual(0, len(res))

    def test_cartesianProduct_secondOneElement_shouldBeCorrect(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps1.put('2')
        ps2 = PowerSet()
        ps2.put('3')
        res = list(cartesianProduct(ps1, ps2))

        # Assert
        self.assertEqual(2, len(res))
        self.assertEqual(('1', '3'), res[0])
        self.assertEqual(('2', '3'), res[1])

    def test_cartesianProduct_secondTwoElements_shouldBeCorrect(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps1.put('2')
        ps2 = PowerSet()
        ps2.put('3')
        ps2.put('4')
        res = list(cartesianProduct(ps1, ps2))

        # Assert
        self.assertEqual(4, len(res))
        self.assertEqual(('1', '3'), res[0])
        self.assertEqual(('1', '4'), res[1])
        self.assertEqual(('2', '3'), res[2])
        self.assertEqual(('2', '4'), res[3])

class MultiIntersection_PowerSetTests(unittest.TestCase):
    def test_multiIntersection_empty_shouldBeEmpty(self):
        # Arrange
        ps1 = PowerSet()
        ps2 = PowerSet()
        ps3 = PowerSet()
        res = multiIntersection([ps1, ps2, ps3])

        # Assert
        self.assertEqual(0, res.size())

    def test_multiIntersection_oneElementInEachDistinct_shouldBeEmpty(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps2 = PowerSet()
        ps2.put('2')
        ps3 = PowerSet()
        ps3.put('3')
        res = multiIntersection([ps1, ps2, ps3])

        # Assert
        self.assertEqual(0, res.size())

    def test_multiIntersection_oneElementInTwoOfThree_shouldBeEmpty(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps2 = PowerSet()
        ps2.put('1')
        ps3 = PowerSet()
        res = multiIntersection([ps1, ps2, ps3])

        # Assert
        self.assertEqual(0, res.size())

    def test_multiIntersection_oneElementInEachEqual_shouldBeOneElement(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps2 = PowerSet()
        ps2.put('1')
        ps3 = PowerSet()
        ps3.put('1')
        res = multiIntersection([ps1, ps2, ps3])

        # Assert
        self.assertEqual(1, res.size())
        self.assertTrue(res.get('1'))

    def test_multiIntersection_threeSets_shouldBeCorrect(self):
        # Arrange
        ps1 = PowerSet()
        ps1.put('1')
        ps1.put('2')
        ps1.put('3')
        ps1.put('4')
        ps2 = PowerSet()
        ps2.put('1')
        ps2.put('6')
        ps2.put('3')
        ps2.put('8')
        ps3 = PowerSet()
        ps3.put('1')
        ps3.put('3')
        ps3.put('9')
        res = multiIntersection([ps1, ps2, ps3])

        # Assert
        self.assertEqual(2, res.size())
        self.assertTrue(res.get('1'))
        self.assertTrue(res.get('3'))
        self.assertFalse(res.get('9'))

if __name__ == "__main__":
    unittest.main()