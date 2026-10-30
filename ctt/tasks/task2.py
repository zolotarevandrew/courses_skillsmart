from core.cube import Cube
from core.direction import Direction
from core.face import Face
from core.system import System

# достанем правила где есть нужная face, но исключим ее из ключа
def get_face_rules(system: System, face: Face):
    rules = {}

    for faces, element in system._rules.items():
        if face not in faces:
            continue

        op = set(faces)
        op.remove(face)
        rules[frozenset(op)] = element

    return rules

# System.compose смотрит на ключи двух систем и если они пересекаются по общим граням, а значения равны то добавляет их в результат без общих граней
# Но у нас ведь на пересечение кубов две разные грани, и если мы их подсунем в common_face зачастую вообще ничего в результате не будет толкового
# Поэтому сделал тут склейку похожую на склейку куба - проверяем чтобы правила склеиваемых граней были согласованы (их в результат не добавляем - непонятно правильно это или нет)
# А все правила, что не входят в склеиваемые грани добавляем
def try_compose(system1: System, system2: System, connecting: Face, opposite: Face):
    result = System()
    if get_face_rules(system1, connecting) != get_face_rules(system2, opposite):
        return (False, result)

    for faces, element in system1._rules.items():
        if connecting not in faces:
            result.add_rule(faces, element)

    for faces, element in system2._rules.items():
        if opposite not in faces:
            result.add_rule(faces, element)
    return (True, result)

def compose_cubes_with_rules(cube1: Cube, system1: System,
                            cube2: Cube, system2: System,
                            direction: Direction, value: int) -> tuple[Cube, System]:
    connecting_face = Face(direction, value)
    opposite_face = connecting_face.opposite()
    # в целом можно было бы и не дублировать проверку здесь
    if cube1.get_face(connecting_face) != cube2.get_face(opposite_face):
        raise ValueError('There is no common face')
    system_compose = try_compose(system1, system2, connecting_face, opposite_face)
    if system_compose[0] == False:
        raise ValueError('Systems are not composable')
    return (
        cube1.compose(cube2, direction, value),
        system_compose[1]
    )


def test() -> bool:
    try:
        d0 = Direction(0)
        d1 = Direction(1)
        dimensions = [d0, d1]

        f00 = Face(d0, 0)
        f01 = Face(d0, 1)
        f10 = Face(d1, 0)
        f11 = Face(d1, 1)

        cube1 = Cube(dimensions)
        cube1.set_face(f00, "left")
        cube1.set_face(f01, "right")
        cube1.set_face(f10, "bottom")
        cube1.set_face(f11, "top")
        system1 = System()
        system1.add_rule([f00, f11], "B")
        system1.add_rule([f00, f10], "A")
        system1.add_rule([f01, f11], "100")
        system1.add_rule([f01, f10], "50")

        cube2 = Cube(dimensions)
        cube2.set_face(f00, "right")
        cube2.set_face(f01, "other-right")
        cube2.set_face(f10, "bottom")
        cube2.set_face(f11, "top")
        system2 = System()
        system2.add_rule([f00, f11], "100")
        system2.add_rule([f00, f10], "50")
        system2.add_rule([f01, f11], "D")
        system2.add_rule([f01, f10], "C")

        composed = compose_cubes_with_rules(cube1, system1, cube2, system2, d0, 1)


        print("All tests passed successfully!")
        return True
    except Exception as e:
        print(f"test failed: {str(e)}")
        return False


if __name__ == "__main__":
    test()
