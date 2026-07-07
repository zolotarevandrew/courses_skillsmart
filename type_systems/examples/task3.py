from core.path import Path
from task2 import Record

from typing import Callable, Generic, TypeVar

T = TypeVar("T")

class Option(Generic[T]):
    def __init__(self, value: T | None):
        self.value = value

    @property
    def is_some(self) -> bool:
        return self.value is not None

    @property
    def is_none(self) -> bool:
        return self.value is None

# 1 собственные базовые типы, намеренно отказываемся от встроенных
class Type(Generic[T]):
    def __call__(self, value: T) -> Value[T]:
        return Value(self, value)

class IntType(Type[int]):
    pass

class StringType(Type[str]):
    pass

class TypeInfo(Generic[T]):
    def __init__(self, type_: Type[T], name: str):
        self.type = type_
        self.name = name

class Value(Generic[T]):
    def __init__(self, type_: Type[T], value: T):
        self.type = type_
        self.value = value

class ProofPath:
    def __init__(self, type, predicate: Callable[[object, object], bool]):
        self.type = type
        self.predicate = predicate

    def __call__(self, start: Record, end: Record) -> Option[Path]:
        if start.type is not self.type or end.type is not self.type:
            return Option(None)

        if not self.predicate(start, end):
            return Option(None)

        return Option(Path(start, end))


Int = IntType()
String = StringType()

# 3 Record как HoTT Product от указанных полей (то что сделал на предыдущем занятии)
# но нужно еще добавить реализацию __call__ чтобы создавать конкретную точку пространства (экземпляр) на основе сгенерированного внутри ProductType)
# Кастомный record Person и две точки пространства
Person = Record(
    name="Person",
    fields=[
        TypeInfo(Int, "id"),
        TypeInfo(String, "name")
    ]
)

andrey = Person(Int(1), String("Andrey"))
alex = Person(Int(2), String("Alex"))


# 4 имеем множество доказательств равенства (путей через ProofPath)
same_id = ProofPath(
    Person,
    lambda a, b: a.id == b.id
)
same_name = ProofPath(
    Person,
    lambda a, b: a.name == b.name
)
p1 = same_id(andrey, alex)
p2 = same_name(alex, andrey)
p3 = same_id(andrey, andrey)

# 5 пытаемся описать транспорт, для переноса значений между Person -> Builder (новый эквивалентный тип)
# используем sym для обратной трансформации?
Builder = Record(
    name="Builder",
    fields=[
        TypeInfo(Int, "id"),
        TypeInfo(String, "name")
    ]
)

same_record = ProofPath(
    Record,
    lambda a, b: False #тут надо описать что два record-а структурно равны
)

person_builder = same_record(Person, Builder)
andreyBuilder = person_builder.transport(andrey, Person)
andreyPerson = person_builder.sym().transport(andreyBuilder, Builder)

# 6 пытаемся описать группу без базовых классов
# identity - петля из базовой точки
identity = Path.refl(andrey)
# loop1 - andrey -> alex -> andrey  петля как часть группы
loop1 = p1.trans(p2)
identity.trans(loop1) == loop1
loop1.trans(identity) == loop1

# обратный элемент
inverse = loop1.sym()

loop2 = loop1.trans(inverse)