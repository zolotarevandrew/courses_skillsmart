from collections.abc import Callable
from dataclasses import dataclass
from enum import Enum
from itertools import combinations
from typing import Generic, TypeVar

from core.dependent_types import Pi
from core.path import Path
from core.univalence import Equivalence, QInv, Univalence, create_type_equivalence
from core.universes import Level, Type, Universe


class Stack:
    def __init__(self):
        self._items = []
    def push(self, item):
        self._items.append(item)
    def pop(self):
        return self._items.pop()
    def to_list(self):
        return self._items.copy()

def stack_to_list(stack: Stack) -> "list":
    return stack.to_list()

def list_to_stack(lst: list) -> "Stack":
    stack = Stack()
    for item in lst:
        stack.push(item)
    return stack

def stack_task_1():
    eq = create_type_equivalence(Stack, list, stack_to_list, list_to_stack)
    st = Stack()
    st.push(1)
    st.push(2)
    st.push(3)

    def assert_equal(st: Stack, ls: list):
        assert eq.inverse.backward(eq.inverse.forward(st)).to_list() == st.to_list()
        assert eq.inverse.forward(eq.inverse.backward(ls)) == ls

    assert_equal(st, [1, 2, 3])
    assert_equal(Stack(), [])

class Celsius:
    def __init__(self, value: float):
        self.value = value

class Fahrenheit:
    def __init__(self, value: float):
        self.value = value

def c_to_f(c: Celsius) -> "Fahrenheit":
    return Fahrenheit(c.value * 9/5 + 32)

def f_to_c(f: Fahrenheit) -> "Celsius":
    return Celsius((f.value - 32) * 5/9)

def temperature_task2():
    eq = create_type_equivalence(Celsius, Fahrenheit, c_to_f, f_to_c)
    eq_inv = create_type_equivalence(Fahrenheit, Celsius, f_to_c, c_to_f)

    # Докажите коммутативность преобразований
    c = Celsius(10)
    f = Univalence.transport_uni_axi(Celsius, Fahrenheit, eq, c)
    c1 = Univalence.transport_uni_axi(Fahrenheit, Celsius, eq_inv, f)
    assert c.value == c1.value

    f = Fahrenheit(100)
    c = Univalence.transport_uni_axi(Fahrenheit, Celsius, eq_inv, f)
    f1 = Univalence.transport_uni_axi(Celsius, Fahrenheit, eq, c)
    assert f.value == f1.value


    # вода замерзает при 0°C = 32°F
    assert Univalence.transport_uni_axi(Celsius, Fahrenheit, eq, Celsius(0)).value == 32
    # вода кипит при 100°C = 212°F
    assert Univalence.transport_uni_axi(Celsius, Fahrenheit, eq, Celsius(100)).value == 212

class JSONData:
    def __init__(self, data: str):
        self.data = data

class XMLData:
    def __init__(self, data: str):
        self.data = data

class PythonDict:
    def __init__(self, data: dict):
        self.data = data

# берем кастомную библиотеку, xml_data = 'John30' - такой формат надежно не распарсить
import xmltodict
import json

def xml_to_p(data: XMLData) -> PythonDict:
    parsed = xmltodict.parse(data.data)
    return PythonDict(parsed["root"])

def p_to_xml(data: PythonDict) -> XMLData:
    return XMLData(xmltodict.unparse({"root": data.data}, full_document=True))

def json_to_p(data: JSONData) -> PythonDict:
    return PythonDict(json.loads(data.data))

def p_to_json(data: PythonDict) -> JSONData:
    return JSONData(json.dumps(data.data, ensure_ascii=False))

A = TypeVar('A')
B = TypeVar('B')
C = TypeVar('C')

# compose на уровне примера была a -> b -> a, а не a -> b --> b -> c
def compose(left: 'Equivalence[A, B]', right: 'Equivalence[B, C]') -> 'Equivalence[A, C]':
    def compose_fun(x: A) -> C:
        return right.function(left.function(x))

    composed_inv = QInv(
        forward=compose_fun,
        backward=lambda x: left.inverse.backward(right.inverse.backward(x)),
        forward_backward=lambda x: Path.refl(x),  # Simplified
        backward_forward=lambda x: Path.refl(x)   # Simplified
    )

    return Equivalence(compose_fun, composed_inv)

def formats_task3():
    json_python = create_type_equivalence(JSONData, PythonDict, json_to_p, p_to_json)
    python_xml = create_type_equivalence(PythonDict, XMLData, p_to_xml, xml_to_p)

    json = JSONData('{"name": "John", "age": 30}')
    python_dict = Univalence.transport_uni_axi(JSONData, PythonDict, json_python, json)
    assert len(python_dict.data) == 2
    assert python_dict.data["name"] == "John"
    assert python_dict.data["age"] == 30

    xml = Univalence.transport_uni_axi(PythonDict, XMLData, python_xml, python_dict)
    assert xml.data == '<?xml version="1.0" encoding="utf-8"?>\n<root><name>John</name><age>30</age></root>'

    json_xml = compose(json_python, python_xml)
    composed_xml = Univalence.transport_uni_axi(JSONData, XMLData, json_xml, json)
    assert composed_xml.data == '<?xml version="1.0" encoding="utf-8"?>\n<root><name>John</name><age>30</age></root>'

    p1 = Univalence.uni_axi(JSONData, PythonDict, json_python)
    p2 = Univalence.uni_axi(PythonDict, XMLData, python_xml)
    uni_path = Univalence.uni_axi(
        JSONData,
        XMLData,
        json_xml,
    )
    composed_path = p1.trans(p2)

    assert uni_path== composed_path



if __name__ == "__main__":
    stack_task_1()
    temperature_task2()
    formats_task3()
    print("All tests passed")
