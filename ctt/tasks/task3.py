# Дано:
# Нижний отрезок: путь bottom от (0,0) до (1,0)
# Верхний отрезок: путь top от (0,1) до (1,1)

# Требуется:
# Построить непрерывную трансформацию
#  из нижнего отрезка в верхний через композицию Кана:
# - создать два куба
# - заполнить промежуточный путь middle
# - соединить кубы по общей грани middle

# Проверить что:
#- начальная грань осталась bottom
#-  конечная грань осталась top
# - трансформация непрерывна

# Реализуйте задачу, используя паттерн композиции Кана.

from core.cube import Cube
from core.cubical_path import CubicalPath, fill
from core.direction import Direction
from core.face import Face


def test() -> bool:
    try:
        bottom: CubicalPath[tuple[float, float]] = CubicalPath(lambda t: (t, 0))
        top: CubicalPath[tuple[float, float]] = CubicalPath(lambda t: (t, 1))

        filled = fill({'bottom': bottom, 'top': top})
        assert filled(0) == (0, 0), "Fill should respect boundary conditions at 0"
        assert filled(1) == (1, 1), "Fill should respect boundary conditions at 1"

        d0 = Direction(0)
        d1 = Direction(1)
        cube1 = Cube([d0, d1])
        cube2 = Cube([d0, d1])

        f10 = Face(d1, 0)
        f11 = Face(d1, 1)
        cube1.set_face(f10, bottom)
        cube1.set_face(f11, filled)

        cube2.set_face(f10, filled)
        cube2.set_face(f11, top)

        composed = cube1.compose(cube2, d1, 1)
        assert composed.get_face(f10) == bottom, "Composition should preserve bottom face"
        assert composed.get_face(f11) == top, "Composition should preserve top face"

        print("All tests passed successfully!")
        return True
    except Exception as e:
        print(f"test failed: {str(e)}")
        return False


if __name__ == "__main__":
    test()
