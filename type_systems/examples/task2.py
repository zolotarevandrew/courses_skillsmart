from typing import Type
from core.product import Product
from core.sum import Sum
from core.base_types import Unit, Empty
from functools import reduce

# - условный тип на основе Product, на основе рекурсивного Product типа, без методов пока конечно же
class ProductType:
    def __init__(self, types: list[Type]):
        self._types = types
        self._product = self._buildProduct()

    def _buildProduct(self):
        return reduce(
            lambda acc, t: Product(t, acc),
            reversed(self._types),
            Unit
        )

# - аналог Record
class Record:
    def __init__(self, name: str, fields: list[type]):
        self.name = name
        self.payload = ProductType(fields)

# - кастомный ADT, на основе рекурсивного Sum типа, без методов пока конечно же
class AlgebraicDataType:
    def __init__(self, name: str, records: list[Record]):
        if not records:
            raise ValueError("AlgebraicDataType must contain at least one Record")
        self.name = name
        self._records = records
        self._sum = self._buildSum()

    def _buildSum(self):
        return reduce(
            lambda acc, t: Sum(t, acc),
            reversed(self._records),
            Empty
        )

# язык фильтров Sum = || Product = &&, тут надо докручивать, пилить предикаты в виде объектов не хочется, а для разбора lambda нужен expression tree, чтобы получить примерно как в Linq

from dataclasses import dataclass
from typing import Callable, Generic, TypeVar

T = TypeVar("T")

Predicate = Callable[[T], bool]

class And(Generic[T]):
    def __init__(self, left: Predicate[T], right: Predicate[T]):
        self._product = Product(left, right)

    def __call__(self, value: T) -> bool:
        return self._product.first_value(value) and self._product.second_value(value)

class Or(Generic[T]):
    def __init__(self, left: Predicate[T], right: Predicate[T]):
        self._sum = Sum(left, right)
        self.right = right

    def __call__(self, value: T) -> bool:
        return self._sum.left_value(value) or self._sum.right_value(value)