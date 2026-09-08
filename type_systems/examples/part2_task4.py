from collections.abc import Callable
from dataclasses import dataclass
from enum import Enum
from itertools import combinations
from typing import Generic, TypeVar

from core.dependent_types import Pi
from core.universes import Level, Type, Universe

T = TypeVar("T")
U = TypeVar("U")


# Определяем сигма тип, совместимый с Type, для доказательств корректности типов на уровне компиляции
@dataclass
class SigmaType(Type, Generic[T, U]):
    domain: type[T]
    codomain: Callable[[T], type[U]]
    first: T
    second: U

    def __post_init__(self):
        expected_type = self.codomain(self.first)
        if not isinstance(self.second, expected_type):
            raise TypeError(f"Second element must be of type {expected_type}")


class Component(Type):
    def __init__(self, name: str, universe: Universe):
        if universe.level != Level(0):
            raise ValueError("Must be in level 0 universe")

        super().__init__(
            name=name,
            level=universe.level,
            universe=universe,
        )


class Cpu(Component):
    def __init__(
        self,
        name: str,
        universe: Universe,
        socket: str,
    ):
        super().__init__(name, universe)
        self.socket = socket


class Ram(Component):
    def __init__(
        self,
        name: str,
        universe: Universe,
        type: str,
    ):
        super().__init__(name, universe)
        self.type = type


class Gpu(Component):
    def __init__(
        self,
        name: str,
        universe: Universe,
        interface: str,
    ):
        super().__init__(name, universe)
        self.interface = interface


compatibility_rules = {
    (Cpu, Cpu): lambda с1, с2: с1.socket == с2.socket,
    (Ram, Ram): lambda r1, r2: r1.type == r2.type,
    (Gpu, Gpu): lambda g1, g2: g1.interface == g2.interface,
    (Cpu, Ram): lambda c, r: r.type == "DDR5" if c.socket == "LGA1700" else True,
    (Cpu, Gpu): lambda _, g: g.interface == "PCIe",
    (Ram, Gpu): lambda _, __: True,
}


def compatible(t1: Component, t2: Component) -> bool:
    if t1.level != t2.level:
        return False
    if t1.level != Level(0):
        return False

    rule = compatibility_rules.get((type(t1), type(t2)))
    if rule:
        return rule(t1, t2)

    rule = compatibility_rules.get((type(t2), type(t1)))
    if rule:
        return rule(t2, t1)

    return False


class Configuration(SigmaType):
    class Proof:
        def __init__(self, components: list[Component]):
            if not (
                any(isinstance(c, Cpu) for c in components)
                and any(isinstance(c, Ram) for c in components)
            ):
                raise ValueError("Ram and Cpu are required")
            if not all(compatible(c1, c2) for c1, c2 in combinations(components, 2)):
                raise ValueError("Incompatible components")

            self.components = components

    def __init__(
        self,
        name: str,
        universe: Universe,
        components: list[Component],
    ):
        if universe.level != Level(1):
            raise ValueError("Invalid universe")

        self.components = components
        super().__init__(
            name=name,
            level=universe.level,
            universe=universe,
            constructors={},
            domain=list[Component],
            codomain=lambda _: Configuration.Proof,
            first=components,
            second=Configuration.Proof(components),
        )


class Template(Type):
    def __init__(
        self,
        name: str,
        universe: Universe,
        func: Callable[[Configuration], bool],
    ):
        if universe.level != Level(2):
            raise ValueError("Invalid universe")

        super().__init__(
            name=name,
            level=universe.level,
            universe=universe,
        )
        self.config_rule = func

    def createConfiguration(
        self,
        name: str,
        universe: Universe,
        components: list[Component],
    ) -> Configuration | None:

        config = Configuration(
            name=name,
            universe=universe,
            components=components,
        )

        # ну или лучше Sum(Configuration, None)
        if not self.config_rule(config):
            return None

        return config


def configure_pc():
    universe0 = Universe(Level(0))  # Базовые компоненты
    universe1 = Universe(Level(1))  # Конкретные конфигурации
    universe2 = Universe(Level(2))  # Шаблоны конфигураций

    # Добавление компонентов и правил совместимости
    cpu_intel_i5 = Cpu(name="IntelI5", universe=universe0, socket="LGA1700")

    cpu_intel_i7 = Cpu(name="IntelI7", universe=universe0, socket="LGA1700")

    cpu_ryzen5 = Cpu(name="Ryzen5", universe=universe0, socket="AM4")

    cpu_ryzen7 = Cpu(
        name="Ryzen7",
        universe=universe0,
        socket="AM5",
    )

    ram_corsair = Ram(
        name="Corsair16GB",
        universe=universe0,
        type="DDR5",
    )

    ram_kingston = Ram(
        name="Kingston32GB",
        universe=universe0,
        type="DDR5",
    )

    ram_kingston_old = Ram(
        name="Kingston32GB_Old",
        universe=universe0,
        type="DDR4",
    )

    gpu_rtx = Gpu(
        name="NvidiaRTX4060",
        universe=universe0,
        interface="PCIe",
    )

    gpu_amd = Gpu(
        name="AmdRX7600",
        universe=universe0,
        interface="PCIe",
    )

    # тут так-то надо еще добавить базовый тип Component?

    universe0.add_type(cpu_intel_i5.name, cpu_intel_i5)
    universe0.add_type(cpu_intel_i7.name, cpu_intel_i7)
    universe0.add_type(cpu_ryzen5.name, cpu_ryzen5)
    universe0.add_type(cpu_ryzen7.name, cpu_ryzen7)
    universe0.add_type(ram_corsair.name, ram_corsair)
    universe0.add_type(ram_kingston.name, ram_kingston)
    universe0.add_type(ram_kingston_old.name, ram_kingston_old)
    universe0.add_type(gpu_rtx.name, gpu_rtx)
    universe0.add_type(gpu_amd.name, gpu_amd)

    # Создание конфигураций
    basic_conf = Configuration(
        name="Basic",
        universe=universe1,
        components=[
            cpu_intel_i5,
            ram_corsair,
            ram_corsair,
            gpu_rtx,
        ],
    )
    universe1.add_type(basic_conf.name, basic_conf)

    # Проверка корректности на уровне типов ?
    game_template = Template(
        name="Gaming",
        universe=universe2,
        func=lambda conf: any(
            isinstance(component, Gpu) for component in conf.components
        ),
    )
    universe2.add_type(game_template.name, game_template)
    gaming1_conf = game_template.createConfiguration(
        "gaming1", universe1, [cpu_intel_i5, ram_corsair, ram_corsair, gpu_amd]
    )
    universe1.add_type(gaming1_conf.name, gaming1_conf)


class Document(SigmaType):
    class Proof:
        def __init__(self, universe: Universe, level: Level):
            self.level = level
            if universe.level != Level(level.value):
                raise ValueError("Invalid universe")

    def __init__(
        self,
        name: str,
        level: Level,
        universe: Universe,
    ):
        super().__init__(
            name=name,
            level=level,
            universe=universe,
            constructors={},
            domain=Level,
            codomain=lambda level: Document.Proof,
            first=level,
            second=Document.Proof(universe, level),
        )


class User(Type):
    pass


class AccessibleDocument(SigmaType):
    class Proof:
        def __init__(self, user: User, document: Document):
            if document.level.value > user.level.value:
                raise ValueError("Use has no access to documents")
            self.user = user
            self.document = document

    def __init__(
        self,
        user: User,
        document: Document,
    ):
        super().__init__(
            name=document.name,
            level=document.level,
            universe=document.universe,
            constructors={},
            domain=Document,
            codomain=lambda _: AccessibleDocument.Proof,
            first=document,
            second=AccessibleDocument.Proof(user, document),
        )

        self.user = user
        self.document = document


def document_system():
    public_universe = Universe(Level(0))
    internal_universe = Universe(Level(1))
    secret_universe = Universe(Level(2))

    # Определение типов документов (не заводим для простоты отдельный DocumentLevel 0,1,2 - итак есть уровни юниверсума)
    public_doc = Document("Public", Level(0), public_universe)
    public_universe.add_type(public_doc.name, public_doc)

    internal_doc = Document("Internal", Level(1), internal_universe)
    internal_universe.add_type(internal_doc.name, internal_doc)

    secret_doc = Document("Secret", Level(2), secret_universe)
    secret_universe.add_type(secret_doc.name, secret_doc)

    secret_doc = Document("Secret", Level(2), secret_universe)

    uni = {
        public_universe.level.value: public_universe,
        internal_universe.level.value: internal_universe,
        secret_universe.level.value: secret_universe,
    }

    # Операции повышения/понижения уровня
    def promote(doc: Document) -> Document:
        nextLevel = doc.level.next()
        if nextLevel.value not in uni:
            raise ValueError("Universe was not found")
        # тут бы надо переносить еще тип из юниверсума в другой
        return Document(doc.name, nextLevel, uni[nextLevel.value])

    def demote(doc: Document) -> Document:
        prevLevel = doc.level.prev()
        if prevLevel.value not in uni:
            raise ValueError("Universe was not found")
        # тут бы надо переносить еще тип из юниверсума в другой
        return Document(doc.name, prevLevel, uni[prevLevel.value])

    # Проверка прав доступа через иерархию универсумов
    user0 = User("User0", public_universe.level, public_universe)
    accessible_public = AccessibleDocument(user=user0, document=public_doc)

    user1 = User("User1", internal_universe.level, internal_universe)
    accessible_internal = AccessibleDocument(user=user1, document=internal_doc)

    user2 = User("User2", secret_universe.level, secret_universe)
    accessible_secret = AccessibleDocument(
        user=user2,
        document=secret_doc,
    )

    # а такое упадет на этапе компиляции
    # accessible_secret = AccessibleDocument(user=user0, document=secret_doc)


class BasicType(Type):
    pass


class CompositeType(Type):
    def __init__(self, name, universe: Universe, types: list[BasicType]):
        self.types = types
        super().__init__(
            name=name,
            level=universe.level,
            universe=universe,
        )

    def extend(
        self,
        name: str,
        types: list[BasicType],
    ) -> "CompositeType":
        return CompositeType(
            name=name,
            universe=self.universe,
            types=[
                *self.types,
                *types,
            ],
        )


class FormType(Type):
    def __init__(
        self, name, universe: Universe, types: list[BasicType | CompositeType]
    ):
        self.types = types
        super().__init__(
            name=name,
            level=universe.level,
            universe=universe,
        )

    def extend(self, name: str, types: list[BasicType | CompositeType]) -> "FormType":
        return FormType(
            name=name,
            universe=self.universe,
            types=[
                *self.types,
                *types,
            ],
        )


def form_validator():
    basic_types = Universe(Level(0))
    composite_types = Universe(Level(1))
    forms = Universe(Level(2))

    # Определение базовых типов
    type_str = BasicType("String", basic_types.level, basic_types)
    basic_types.add_type(type_str.name, type_str)

    type_int = BasicType("Int", basic_types.level, basic_types)
    basic_types.add_type(type_int.name, type_int)

    # Создание составных типов
    address = CompositeType("Address", composite_types, [type_str, type_int])
    contact = CompositeType("Contact", composite_types, [type_str, type_str])
    composite_types.add_type(address.name, address)
    composite_types.add_type(contact.name, contact)

    extended_address = address.extend(
        "ExtendedAddress",
        [type_str],
    )
    composite_types.add_type(extended_address.name, extended_address)

    # Конструирование форм
    form = FormType("TestForm", forms, [address, contact, type_str, type_int])
    forms.add_type(form.name, form)
    extended_form = form.extend(
        "ExtendedTestForm",
        [
            extended_address,
            type_str,
        ],
    )
    forms.add_type(extended_form.name, extended_form)

    #
    # Валидация структуры данных
    def validate_type(type: Type):
        children = getattr(type, "types", [])
        # просто проверим, что можно использовать типы нижнего уровня, и тогда и циклы невозможны
        for item in children:
            if item.level.value >= type.level.value: return False
            if not validate_type(item): return False
        return True

    def validateUniverses(u0: Universe, u1: Universe, u2: Universe):
        return (
            all(t.level == Level(0) for t in u0.types.values())
            and all(t.level == Level(1) for t in u1.types.values())
            and all(t.level == Level(2) for t in u2.types.values())
            and all(validate_type(t) for t in u1.types.values())
            and all(validate_type(t) for t in u2.types.values())
        )

    assert validateUniverses(basic_types, composite_types, forms) == True


if __name__ == "__main__":
    configure_pc()
    document_system()
    form_validator()
    print("All tests passed")
