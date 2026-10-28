## Создание и взаимодействие всех трёх структур (Interval, Direction, Face)
## Корректность путей между гранями
## Соответствие противоположных граней
## Работа с путями для каждого направления
## Корректность вырожденных путей
## Согласованность значений на гранях и в путях
## Правильность сопоставления направлений и граней

from core.direction import Direction
from core.face import Face
from core.interval import Interval


def test_1() -> bool:
    try:

        ## Создание и взаимодействие всех трёх структур (Interval, Direction, Face)
        d0 = Direction(0)
        d1 = Direction(1)

        interval = Interval()

        f00 = Face(d0, 0)
        f01 = Face(d0, 1)
        f10 = Face(d1, 0)
        f11 = Face(d1, 1)

        p1 = interval.path(1,10)
        p2 = interval.path(2,15)
        p3 = interval.path(1,2)
        p4 = interval.path(10,15)

        bb = {
            f00: p1,
            f01: p2,
            f10: p3,
            f11: p4
        }

        ## Корректность путей между гранями
        l = bb[f00]
        r = bb[f01]
        b = bb[f10]
        t = bb[f11]

        assert l(0) == b(0), "left bottom"
        assert l(1) == t(0), "left top"
        assert t(1) == r(1), "top right"
        assert b(1) == r(0), "bottom right"

        ## Соответствие противоположных граней
        assert f00.opposite() == f01, "Opposite of (d0,0) should be (d0,1)"
        assert f01.opposite() == f00, "Opposite of (d0,1) should be (d0,0)"
        assert f10.opposite() == f11, "Opposite of (d1,0) should be (d1,1)"
        assert f11.opposite() == f10, "Opposite of (d1,1) should be (d1,0)"

        ## Работа с путями для каждого направления
        assert l(0) == 1 and l(1) == 10, "left path"
        assert r(0) == 2 and r(1) == 15, "right path"
        assert b(0) == 1 and b(1) == 2, "bottom path"
        assert t(0) == 10 and t(1) == 15, "top path"

        ## Корректность вырожденных путей
        constant_path = interval.degeneracy(42)
        assert constant_path(0) == 42, "Constant path should always return 42 at t=0"
        assert constant_path(1) == 42, "Constant path should always return 42 at t=1"

        ## Согласованность значений на гранях и в путях
        # у face.value либо 0 или 1, а в путях значения конкретные точки, непонятно как тут можно проверить согласованность
        # без дополнительных структур данных, которые наверно появятся далее
        # да и вроде как, это дубль проверки границ

        ## Правильность сопоставления направлений и граней
        assert f00.direction == d0, "Face00 should store the correct direction"
        assert f01.direction == d0, "Face01 should store the correct direction"
        assert f10.direction == d1, "Face10 should store the correct direction"
        assert f11.direction == d1, "Face11 should store the correct direction"


        print("All tests passed successfully!")
        return True
    except Exception as e:
        print(f"Test failed: {str(e)}")
        return False


if __name__ == "__main__":
    test_1()
