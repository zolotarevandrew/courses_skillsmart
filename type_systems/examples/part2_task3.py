from dataclasses import dataclass
from functools import reduce
from typing import Callable, Dict, List, TypeVar
from core.truncation import TruncationLevel

def sign(x):
    if x > 0: return 1
    elif x < 0: return -1
    return 0

dict = {
    TruncationLevel.MINUS_TWO: sign,
    TruncationLevel.MINUS_ONE: round,
    TruncationLevel.ZERO: lambda x: round(x,1),
    TruncationLevel.ONE: lambda x: round(x,2),
    TruncationLevel.TWO: lambda x: round(x,3),
}

class PrecisionCalculator():
    def __init__(self):
        pass

    def truncate(self, num: float, level: int) -> float :
        return dict[level](num)

def testPrecisionCalculator():
    calc = PrecisionCalculator()
    number = 3.14159
    assert calc.truncate(number, TruncationLevel.MINUS_TWO) == 1
    assert calc.truncate(number, TruncationLevel.MINUS_ONE) == 3
    assert calc.truncate(number, TruncationLevel.ZERO) == 3.1
    assert calc.truncate(number, TruncationLevel.ONE) == 3.14
    assert calc.truncate(number, TruncationLevel.TWO) == 3.142

T = TypeVar('T')

def quotient_set_element(element: T, relation: Callable[[T, T], bool], set: Dict[T, List[T]]):
    found = next(
        ( key for key in set if relation(element, key) ),
        None
    )

    if found is not None:
        set[found].append(element)
        return set

    set[element] = [element]
    return set

def create_quotient_set(elements: List[T], relation: Callable[[T, T], bool]) -> Dict[T, List[T]]:
    return reduce(
        lambda group, e: quotient_set_element(e, relation, group),
        elements,
        {}
    )

@dataclass(frozen=True)
class User:
    age: int

def first_digit(n):
    return int(str(n)[0])

def test_create_quotient_set():
    elements = [User(20), User(25), User(23), User(21), User(25), User(40), User(30)]
    dict = create_quotient_set(elements, lambda a,b: first_digit(a.age) == first_digit(b.age))
    assert len(dict) == 3
    assert dict[elements[0]] == [elements[0], elements[1], elements[2], elements[3], elements[4]]
    assert dict[elements[5]] == [elements[5]]
    assert dict[elements[6]] == [elements[6]]

def verify_equivalence_relation(relation: Callable[[T, T], bool], elements: List[T]) -> bool:
    for x in elements:
        if not relation(x,x): return False
        for y in elements:
            if relation(x, y) != relation(y, x):
                return False
            for z in elements:
                if relation(x, y) and relation(y, z) and not relation(x, z):
                    return False

    return True

def test_verify_equivalence_relation():
    assert verify_equivalence_relation(lambda x,y: x % 2 == y % 2, [1,2,3,4,5,6]) == True
    assert verify_equivalence_relation(lambda x,y: x >= y, [1,2,3,4,5,6]) == False

def find_representative(element: T, quotient_classes: Dict[T, List[T]]) -> T:
    for key, items in quotient_classes.items():
        if element in items: return key
    raise ValueError('reprsentative was not found')

def test_find_representative():
    st = create_quotient_set([1,2,3,4,5,6], lambda a,b: a % 2 == b % 2)
    assert find_representative(5, st) == 1
    assert find_representative(4, st) == 2
    try:
        find_representative(7, st)
        assert False
    except ValueError:
        pass


if __name__ == "__main__":
    testPrecisionCalculator()
    test_create_quotient_set()
    test_verify_equivalence_relation()
    test_find_representative()
    print("All tests passed")
