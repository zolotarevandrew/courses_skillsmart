import unittest
from task9 import NativeDictionary
from task9_2 import OrderedListDict

class DictionaryTableTests(unittest.TestCase):
    def test_hashFun_shouldFoundSlot(self):
        # Arrange
        sz = 3
        dct = NativeDictionary(sz)
        for item in ['1', '2', '3', '4', '5', '6', '222', '332321', '131313123131', 'asdasdbaw11']:
            h = dct.hash_fun(item)
            self.assertTrue(0 <= h < sz)

    def test_isKey_empty_shouldBeFalse(self):
        # Arrange
        sz = 3
        dct = NativeDictionary(sz)

        # Assert
        self.assertFalse(dct.is_key('2'))

    def test_isKey_oneElementNoKey_shouldBeFalse(self):
        # Arrange
        sz = 3
        dct = NativeDictionary(sz)
        dct.put('1', '2')

        # Assert
        self.assertFalse(dct.is_key('2'))

    def test_isKey_oneElementHasKey_shouldBeTrue(self):
        # Arrange
        sz = 3
        dct = NativeDictionary(sz)
        dct.put('1', '2')

        # Assert
        self.assertTrue(dct.is_key('1'))

    def test_isKey_twoElementNoKey_shouldBeFalse(self):
        # Arrange
        sz = 3
        dct = NativeDictionary(sz)
        dct.put('1', '2')
        dct.put('2', '3')

        # Assert
        self.assertFalse(dct.is_key('3'))

    def test_isKey_twoElementHasKeys_shouldBeTrue(self):
        # Arrange
        sz = 3
        dct = NativeDictionary(sz)
        dct.put('1', '2')
        dct.put('2', '3')

        # Assert
        self.assertTrue(dct.is_key('1'))
        self.assertTrue(dct.is_key('2'))
        self.assertFalse(dct.is_key('3'))

    def test_isKey_threeElementsNoKeys_shouldBeFalse(self):
        # Arrange
        sz = 3
        dct = NativeDictionary(sz)
        dct.put('1', '2')
        dct.put('2', '3')
        dct.put('3', '4')

        # Assert
        self.assertFalse(dct.is_key('4'))
        self.assertFalse(dct.is_key('5'))
        self.assertFalse(dct.is_key('6'))

    def test_get_empty_shouldBeNone(self):
        # Arrange
        sz = 3
        dct = NativeDictionary(sz)

        # Assert
        self.assertIsNone(dct.get('2'))

    def test_get_oneElementNoKey_shouldBeNone(self):
        # Arrange
        sz = 3
        dct = NativeDictionary(sz)
        dct.put('1', '2')

        # Assert
        self.assertIsNone(dct.get('2'))

    def test_get_oneElementHasKey_shouldFound(self):
        # Arrange
        sz = 3
        dct = NativeDictionary(sz)
        dct.put('1', '2')

        # Assert
        self.assertEqual('2', dct.get('1'))

    def test_get_twoElementNoKey_shouldBeNone(self):
        # Arrange
        sz = 3
        dct = NativeDictionary(sz)
        dct.put('1', '2')
        dct.put('2', '3')

        # Assert
        self.assertIsNone(dct.get('3'))

    def test_get_twoElementHasKeys_shouldBeCorrect(self):
        # Arrange
        sz = 3
        dct = NativeDictionary(sz)
        dct.put('1', '2')
        dct.put('2', '3')

        # Assert
        self.assertEqual('2',dct.get('1'))
        self.assertEqual('3', dct.get('2'))
        self.assertIsNone(dct.get('3'))

    def test_get_threeElementsNoKeys_shouldBeNone(self):
        # Arrange
        sz = 3
        dct = NativeDictionary(sz)
        dct.put('1', '2')
        dct.put('2', '3')
        dct.put('3', '4')

        # Assert
        self.assertIsNone(dct.get('4'))
        self.assertIsNone(dct.get('5'))
        self.assertIsNone(dct.get('6'))

    def test_put_empty_shouldBeOk(self):
        # Arrange
        sz = 3
        dct = NativeDictionary(sz)
        dct.put('1', '2')

        # Assert
        self.assertEqual('2', dct.get('1'))

    def test_put_twoElementsWithRewrite_shouldBeOk(self):
        # Arrange
        sz = 3
        dct = NativeDictionary(sz)
        dct.put('1', '2')
        dct.put('2', '3')

        # Assert
        self.assertEqual('2', dct.get('1'))
        self.assertEqual('3', dct.get('2'))

        dct.put('2', '5')
        self.assertEqual('5', dct.get('2'))

    def test_put_threeElementsWithRewrite_shouldBeOk(self):
        # Arrange
        sz = 3
        dct = NativeDictionary(sz)
        dct.put('1', '2')
        dct.put('2', '3')
        dct.put('3', '4')

        # Assert
        self.assertEqual('2', dct.get('1'))
        self.assertEqual('3', dct.get('2'))
        self.assertEqual('4', dct.get('3'))

        dct.put('1', '6')
        dct.put('2', '7')
        dct.put('3', '8')
        self.assertEqual('6', dct.get('1'))
        self.assertEqual('7', dct.get('2'))
        self.assertEqual('8', dct.get('3'))

    def test_put_sizeOne_shouldBeOk(self):
        # Arrange
        dct = NativeDictionary(1)
        dct.put('1', '2')

        # Assert
        self.assertEqual('2', dct.get('1'))
        self.assertIsNone(dct.get('2'))

    def test_put_sizeTwo_shouldBeOk(self):
        # Arrange
        dct = NativeDictionary(2)
        dct.put('1', '2')
        dct.put('2', '3')

        # Assert
        self.assertEqual('2', dct.get('1'))
        self.assertEqual('3', dct.get('2'))
        self.assertIsNone(dct.get('3'))

    def test_step_shouldBeOk(self):
        # Arrange
        dct = NativeDictionary(1)
        step = dct._step('1')
        self.assertTrue( step >= 0 )

        dct = NativeDictionary(2)
        step = dct._step('11')
        self.assertTrue( step >= 0)

        dct = NativeDictionary(3)
        step = dct._step('1232132132131')
        self.assertTrue( step >= 0 )

class OrderListDictTableTests(unittest.TestCase):
    def test_containsKey_empty_shouldBeFalse(self):
        # Arrange
        dct = OrderedListDict()

        # Assert
        self.assertFalse(dct.contains_key('2'))

    def test_contains_key_oneElementNoKey_shouldBeFalse(self):
        # Arrange
        dct = OrderedListDict()
        dct.put('1', '2')

        # Assert
        self.assertFalse(dct.contains_key('2'))

    def test_contains_key_oneElementHasKey_shouldBeTrue(self):
        # Arrange

        dct = OrderedListDict()
        dct.put('1', '2')

        # Assert
        self.assertTrue(dct.contains_key('1'))

    def test_contains_key_twoElementNoKey_shouldBeFalse(self):
        # Arrange
        dct = OrderedListDict()
        dct.put('1', '2')
        dct.put('2', '3')

        # Assert
        self.assertFalse(dct.contains_key('3'))

    def test_contains_key_twoElementHasKeys_shouldBeTrue(self):
        # Arrange
        dct = OrderedListDict()
        dct.put('1', '2')
        dct.put('2', '3')

        # Assert
        self.assertTrue(dct.contains_key('1'))
        self.assertTrue(dct.contains_key('2'))
        self.assertFalse(dct.contains_key('3'))

    def test_contains_key_threeElementsNoKeys_shouldBeFalse(self):
        # Arrange
        dct = OrderedListDict()
        dct.put('1', '2')
        dct.put('2', '3')
        dct.put('3', '4')

        # Assert
        self.assertFalse(dct.contains_key('4'))
        self.assertFalse(dct.contains_key('5'))
        self.assertFalse(dct.contains_key('6'))

    def test_get_empty_shouldBeNone(self):
        # Arrange
        dct = OrderedListDict()

        # Assert
        self.assertIsNone(dct.get('2'))

    def test_get_oneElementNoKey_shouldBeNone(self):
        # Arrange
        dct = OrderedListDict()
        dct.put('1', '2')

        # Assert
        self.assertIsNone(dct.get('2'))

    def test_get_oneElementHasKey_shouldFound(self):
        # Arrange
        dct = OrderedListDict()
        dct.put('1', '2')

        # Assert
        self.assertEqual('2', dct.get('1'))

    def test_get_twoElementNoKey_shouldBeNone(self):
        # Arrange
        dct = OrderedListDict()
        dct.put('1', '2')
        dct.put('2', '3')

        # Assert
        self.assertIsNone(dct.get('3'))

    def test_get_twoElementHasKeys_shouldBeCorrect(self):
        # Arrange
        dct = OrderedListDict()
        dct.put('1', '2')
        dct.put('2', '3')

        # Assert
        self.assertEqual('2',dct.get('1'))
        self.assertEqual('3', dct.get('2'))
        self.assertIsNone(dct.get('3'))

    def test_get_threeElementsNoKeys_shouldBeNone(self):
        # Arrange
        dct = OrderedListDict()
        dct.put('1', '2')
        dct.put('2', '3')
        dct.put('3', '4')

        # Assert
        self.assertIsNone(dct.get('4'))
        self.assertIsNone(dct.get('5'))
        self.assertIsNone(dct.get('6'))

    def test_put_empty_shouldBeOk(self):
        # Arrange
        dct = OrderedListDict()
        dct.put('1', '2')

        # Assert
        self.assertEqual('2', dct.get('1'))

    def test_put_twoElementsWithRewrite_shouldBeOk(self):
        # Arrange
        dct = OrderedListDict()
        dct.put('1', '2')
        dct.put('2', '3')

        # Assert
        self.assertEqual('2', dct.get('1'))
        self.assertEqual('3', dct.get('2'))

        dct.put('2', '5')
        self.assertEqual('5', dct.get('2'))

    def test_put_threeElementsWithRewrite_shouldBeOk(self):
        # Arrange
        dct = OrderedListDict()
        dct.put('1', '2')
        dct.put('2', '3')
        dct.put('3', '4')

        # Assert
        self.assertEqual('2', dct.get('1'))
        self.assertEqual('3', dct.get('2'))
        self.assertEqual('4', dct.get('3'))

        dct.put('1', '6')
        dct.put('2', '7')
        dct.put('3', '8')
        self.assertEqual('6', dct.get('1'))
        self.assertEqual('7', dct.get('2'))
        self.assertEqual('8', dct.get('3'))

    def test_put_fiveElementsWithRewrite_shouldBeOk(self):
        # Arrange
        dct = OrderedListDict()
        dct.put('1', '2')
        dct.put('2', '3')
        dct.put('3', '4')
        dct.put('44', '41')
        dct.put('55', '42')

        # Assert
        self.assertEqual('2', dct.get('1'))
        self.assertEqual('3', dct.get('2'))
        self.assertEqual('4', dct.get('3'))
        self.assertEqual('41', dct.get('44'))
        self.assertEqual('42', dct.get('55'))

        dct.put('1', '6')
        dct.put('2', '7')
        dct.put('3', '8')
        dct.put('44', '100')
        self.assertEqual('6', dct.get('1'))
        self.assertEqual('7', dct.get('2'))
        self.assertEqual('8', dct.get('3'))
        self.assertEqual('100', dct.get('44'))

if __name__ == "__main__":
    unittest.main()