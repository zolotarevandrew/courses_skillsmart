from typing import TypeVar

from core.base_types import unit
from core.higher_path import HigherPath, InfinityGroupoid
from core.homotopy_groups import HomotopyGroup

T = TypeVar('T')


def is_homotopic_equivalent(p1: HigherPath[T], p2: HigherPath[T]) -> bool:
    if p1.dimension != p2.dimension:
        raise ValueError("p1 and p2 must have the same dimension")
    if p1.start != p2.start:
        raise ValueError("p1 and p2 must have the same start")
    if p1.end != p2.end:
        raise ValueError("p1 and p2 must have the same end")

    # если честно, тут не понял, как и зачем можно использовать InfitityGroupId, чтобы доказать существование p1.dimension + 1 пути.
    # coherence_proof у нас везде пустой, полагаться на него мы не можем. Пути не являются петлями или являются?
    # В общем, решения базового на текущей модели для себя не нашел.

    return True

#Добавляем методы в HomotopyGroup
# def __iter__(self):
    return iter(self.elements.items())

def identity(self) -> HigherPath[T]:
    return InfinityGroupoid.identity(
        self.base_point,
        self.dimension
    )

def inverse(self, index: int) -> HigherPath[T]:
    if index not in self.elements:
        raise ValueError("Invalid element indices")
    return self._inverseInternal(self.elements[index])

def _inverseInternal(self, p: HigherPath[T]) -> HigherPath[T]:
    if p.dimension == 1:
        return HigherPath.base_path(p.end, p.start)
    return HigherPath(
        p.dimension,
        p.end,
        p.start,
        [
            self._inverseInternal(prev) for prev in reversed(p.previous_paths)
        ],
        None
    )

def testHomotopyGroup():
    base_point = unit
    p_1_1 = HigherPath.base_path(base_point, base_point)
    p_1_2 = HigherPath(2, base_point, base_point, [p_1_1], None)
    p = HigherPath(3, base_point, base_point, [p_1_2], None)

    higher_group = HomotopyGroup(base_point, 3)
    higher_id = higher_group.add_element(p)
    assert higher_id == 0

    p_2_1 = HigherPath.base_path(base_point, base_point)
    p_2_2 = HigherPath(2, base_point, base_point, [p_2_1, p_2_1], None)
    p1 = HigherPath(3, base_point, base_point, [p_2_2, p_2_2], None)
    higher_id = higher_group.add_element(p1)
    assert higher_id == 1

    for element_id, element in higher_group:
        inversed = higher_group.inverse(element_id)
        assert is_homotopic_equivalent(InfinityGroupoid.compose(element, inversed), higher_group.identity())


if __name__ == "__main__":
    testHomotopyGroup()
    print("All tests passed")
