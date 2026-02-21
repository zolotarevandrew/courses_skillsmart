import unittest
from task8 import HashTable
from task8_2 import OneHashTable, CollisionDetector, TwoHashTable
import random
import string
import time

def generateNumbers(cnt):
    for i in range(cnt):
        yield i

def generate_random_strings(cnt, min_len=1, max_len=32):
    alphabet = string.ascii_letters + string.digits

    for _ in range(cnt):
        n = random.randint(min_len, max_len)
        yield ''.join(random.choice(alphabet) for _ in range(n))

def fill_and_log_average_collisions(
    make_iter,
    log_title,
    load_factor: float = 0.65,
    size: int = 10_007,
    step: int = 7,
):
    detector = CollisionDetector()
    hash_table = OneHashTable(size, step, detector)

    t0 = time.perf_counter()
    n = int(hash_table.size * load_factor)
    for x in make_iter(n):
        hash_table.put(x)

    dt = time.perf_counter() - t0
    avg = detector.average()
    mx = detector.maximum()
    p50 = detector.percentile(50)
    p95 = detector.percentile(95)
    p99 = detector.percentile(99)
    print(f"h1 {log_title} : avg={avg:.6f}, p50={p50}, p95={p95}, p99={p99}, max={mx}, time={dt:.3f}s, n={n}, load={load_factor}")

    h2_fill_and_log_average_collisions(make_iter, 'h2 ' + log_title, load_factor, size)

def h2_fill_and_log_average_collisions(
    make_iter,
    log_title,
    load_factor: float = 0.65,
    size: int = 10_007,
) -> float:
    detector = CollisionDetector()
    hash_table = TwoHashTable(size, detector)

    t0 = time.perf_counter()
    n = int(hash_table.size * load_factor)
    for x in make_iter(n):
        hash_table.put(x)

    dt = time.perf_counter() - t0
    avg = detector.average()
    mx = detector.maximum()
    p50 = detector.percentile(50)
    p95 = detector.percentile(95)
    p99 = detector.percentile(99)
    print(f"{log_title} : avg={avg:.6f}, p50={p50}, p95={p95}, p99={p99}, max={mx}, time={dt:.3f}s, n={n}, load={load_factor}")
    return avg

class HashTableTests(unittest.TestCase):
    def test_hashFun_shouldFoundSlot(self):
        # Arrange
        sz = 3
        hash_table = HashTable(sz, 1)
        for item in ['1', '2', '3', '4', '5', '6', '222', '332321', '131313123131', 'asdasdbaw11']:
            h = hash_table.hash_fun(item)
            self.assertTrue(0 <= h < sz)

    def test_put_empty_shouldFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        slot = hash_table.put('1')
        self.assertIsNotNone(slot)
        self.assertEqual(hash_table.slots[slot], '1')

    def test_put_oneElement_shouldFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        slot = hash_table.put('1')
        self.assertIsNotNone(slot)
        self.assertEqual(hash_table.slots[slot], '1')

        slot = hash_table.put('2')
        self.assertIsNotNone(slot)
        self.assertEqual(hash_table.slots[slot], '2')

    def test_put_twoElements_shouldFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        slot = hash_table.put('1')
        self.assertIsNotNone(slot)
        self.assertEqual(hash_table.slots[slot], '1')

        slot = hash_table.put('2')
        self.assertIsNotNone(slot)
        self.assertEqual(hash_table.slots[slot], '2')

        slot = hash_table.put('3')
        self.assertIsNotNone(slot)
        self.assertEqual(hash_table.slots[slot], '3')

    def test_put_fourElements_shouldNotFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        slot = hash_table.put('1')
        self.assertIsNotNone(slot)
        self.assertEqual(hash_table.slots[slot], '1')

        slot = hash_table.put('2')
        self.assertIsNotNone(slot)
        self.assertEqual(hash_table.slots[slot], '2')

        slot = hash_table.put('3')
        self.assertIsNotNone(slot)
        self.assertEqual(hash_table.slots[slot], '3')

        slot = hash_table.put('4')
        self.assertIsNone(slot)

    def test_seek_empty_shouldFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        self.assertIsNotNone(hash_table.seek_slot('1'))

    def test_seek_oneElement_shouldFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        hash_table.put('1')
        self.assertIsNotNone(hash_table.seek_slot('2'))

    def test_seek_twoElements_shouldFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        hash_table.put('1')
        hash_table.put('2')
        self.assertIsNotNone(hash_table.seek_slot('3'))

    def test_seek_full_shouldNotFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        hash_table.put('1')
        hash_table.put('2')
        hash_table.put('3')
        self.assertIsNone(hash_table.seek_slot('4'))

    def test_find_empty_shouldNotFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        slot = hash_table.find('abc')
        self.assertIsNone(slot)

    def test_find_oneElement_shouldNotFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        hash_table.put('2')
        slot = hash_table.find('abc')
        self.assertIsNone(slot)

    def test_find_oneElement_shouldFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        hash_table.put('2')
        slot = hash_table.find('2')
        self.assertIsNotNone(slot)

    def test_find_twoElements_shouldNotFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        hash_table.put('1')
        hash_table.put('2')
        slot = hash_table.find('3')
        self.assertIsNone(slot)

    def test_find_twoElements_shouldFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        hash_table.put('1')
        hash_table.put('2')
        slot = hash_table.find('1')
        self.assertIsNotNone(slot)

    def test_find_threeElements_shouldNotFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        hash_table.put('1')
        hash_table.put('2')
        hash_table.put('3')
        slot = hash_table.find('4')
        self.assertIsNone(slot)

    def test_find_threeElements_shouldFoundSlot(self):
        # Arrange
        hash_table = HashTable(3, 1)
        hash_table.put('1')
        hash_table.put('2')
        hash_table.put('3')

        slot = hash_table.find('1')
        self.assertIsNotNone(slot)

        slot = hash_table.find('2')
        self.assertIsNotNone(slot)

        slot = hash_table.find('3')
        self.assertIsNotNone(slot)

    def test_putWithCollisions_shouldBeCorrect(self):
        # Arrange
        hash_table = HashTable(6, 2)
        hash_table.hash_fun = lambda _: 0

        self.assertEqual(0, hash_table.put('1'))
        self.assertEqual(2, hash_table.put('2'))
        self.assertEqual(4, hash_table.put('3'))
        self.assertIsNone(hash_table.put('4'))

    def test_numberCollisionsInOneHashTable_shouldBeCorrect(self):
        fill_and_log_average_collisions(generateNumbers, '0.65 Average collisions for one hash table numbers')

    def test_randomStringCollisionsInOneHashTable_shouldBeCorrect(self):
        fill_and_log_average_collisions(generate_random_strings, '0.65 Average collisions for one hash table random strings')

    def test_randomStringBCollisionsInOneHashTable_bigLoadFactor_shouldBeCorrect(self):
        fill_and_log_average_collisions(generate_random_strings, '0.8 Average collisions for one hash table random strings', 0.8)

    def test_equalLengthRandomStringCollisionsInOneHashTable_shouldBeCorrect(self):
        fill_and_log_average_collisions(lambda x : generate_random_strings(x, 32, 32), '0.65 Average collisions for one hash table equal length random strings')

    def test_equalLengthRandomStringCollisionsInOneHashTable_bigLoadFactor_shouldBeCorrect(self):
        fill_and_log_average_collisions(lambda x : generate_random_strings(x, 32, 32), '0.8 Average collisions for one hash table equal length random strings', 0.8)



if __name__ == "__main__":
    unittest.main()