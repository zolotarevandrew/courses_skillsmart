
from core.circle import CubicalCircle
from core.cubical_path import CubicalPath
from core.interval import Interval
from core.sphere import CubicalSphere
from core.torus import CubicalTorus


def encode_circle_path(path: CubicalPath):
    # Нам тут нужно как-то считать число обходов..
    return path.start

def encode_torus_path(path: CubicalPath):
    # Нам тут нужно как-то считать число обходов..
    return (path.start, path.end)

def eq(path1: CubicalPath, path2: CubicalPath):
    return path1.start == path2.start and path1.end == path2.end

class TopologyCalculator:

    @staticmethod
    def interval_are_homotopic(path1: CubicalPath, path2: CubicalPath):
        # В интервале просто проверяем совпадения концов
        return eq(path1, path2)

    @staticmethod
    def circle_are_homotopic(path1: CubicalPath, path2: CubicalPath):
        # В сircle проверяем, что находимся в одной базовой точке + encode loop-ов совпадает
        return eq(path1, path2) and encode_circle_path(path1) == encode_circle_path(path2)

    @staticmethod
    def sphere_are_homotopic(path1: CubicalPath, path2: CubicalPath):
        # если тут одна сфера, тогда все меридианы будут совпадать..
        return eq(path1, path2)

    @staticmethod
    def torus_are_homotopic(path1: CubicalPath, path2: CubicalPath):
        # encode совпадает
        return encode_torus_path(path1) == encode_torus_path(path2)


def test() -> bool:
    try:
        # 1 - intervals
        i_p1 = CubicalPath(lambda t: t)
        i_p2 = CubicalPath(lambda t: t * t)
        i_p3 = CubicalPath(lambda t: 1 - t)
        assert TopologyCalculator.interval_are_homotopic(i_p1, i_p2), "Interval paths should be homotopic"
        assert not TopologyCalculator.interval_are_homotopic(i_p1, i_p3), "Interval paths should not be homotopic"

        # 2 - circles
        circle = CubicalCircle()

        c_p1 = CubicalPath(lambda t: circle.loop(t))
        c_p2 = CubicalPath(lambda t: circle.loop(t))
        c_p3 = CubicalPath(lambda t: circle.loop(1))

        assert TopologyCalculator.circle_are_homotopic(c_p1, c_p2), "Circle paths should be homotopic"
        assert not TopologyCalculator.circle_are_homotopic(c_p1, c_p3), "Circle paths should NOT be homotopic"

        # 3 - spheres
        sphere = CubicalSphere()
        s_p1 = sphere.merid(0)
        s_p2 = sphere.merid(0.5)
        s_p3 = sphere.merid(1)

        assert TopologyCalculator.sphere_are_homotopic(s_p1, s_p2), "Sphere paths should be homotopic"
        assert not TopologyCalculator.sphere_are_homotopic(s_p1, s_p3), "Sphere paths should always be homotopic"

        # 4 - torus
        torus = CubicalTorus()
        t_p1 = CubicalPath(lambda t: torus.surface(t, t))
        t_p2 = CubicalPath(lambda t: torus.surface(t, 1-t))
        t_p3 = CubicalPath(lambda t: torus.surface(0, 0))
        t_p4 = CubicalPath(lambda t: torus.surface(t, t))

        assert not TopologyCalculator.torus_are_homotopic(t_p1, t_p2), "Torus paths should not be homotopic"
        assert not TopologyCalculator.torus_are_homotopic(t_p1, t_p3), "Torus paths should not be homotopic"
        assert TopologyCalculator.torus_are_homotopic(t_p1, t_p4), "Torus paths should be homotopic"


        print("All tests passed successfully!")
        return True
    except Exception as e:
        print(f"test failed: {e!s}")
        return False


if __name__ == "__main__":
    test()
