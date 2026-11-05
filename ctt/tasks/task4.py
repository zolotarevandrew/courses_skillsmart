from dataclasses import dataclass
from math import atan2, cos, hypot, isclose, sin

from core.cubical_path import CubicalPath
from core.direction import Direction
from core.inv import CubicalEquivalence, CubicalQInv, cubical_uni_axi
from core.transport import CubicalTransport


@dataclass
class CartesianPoint:
    x: float
    y: float

@dataclass
class PolarPoint:
    r: float  # радиус
    theta: float  # угол в радианах

def is_equal(c1: CartesianPoint, c2: CartesianPoint):
    return isclose(c1.x, c2.x, abs_tol=1e-12) and isclose(c1.y, c2.y, abs_tol=1e-12)

def to_polar(point: CartesianPoint) -> PolarPoint:
    return PolarPoint(
        r=hypot(point.x, point.y),
        theta=atan2(point.y, point.x),
    )


def to_cartesian(point: PolarPoint) -> CartesianPoint:
    return CartesianPoint(
        x=point.r * cos(point.theta),
        y=point.r * sin(point.theta),
    )

def test() -> bool:
    try:
        equiv = CubicalEquivalence(
            function=to_polar,
            inverse=CubicalQInv(
                forward=to_polar,
                backward=to_cartesian,
                forward_backward=lambda y: CubicalPath(lambda t: y),
                backward_forward=lambda x: CubicalPath(lambda t: x)
            )
        )

        cp = CartesianPoint(-2, 0)
        pp = to_polar(cp)
        assert equiv.function(cp) == pp, "should be correct polar point"

        type_path = cubical_uni_axi(CartesianPoint, PolarPoint, equiv)
        transport = CubicalTransport(type_path)

        forward = transport.transport(cp, Direction(1))
        backward = transport.transport(forward, Direction(0))

        assert forward == pp, "should be correct forward"
        assert is_equal(backward, cp), "should be correct backward"

        print("All tests passed successfully!")
        return True
    except Exception as e:
        print(f"test failed: {str(e)}")
        return False


if __name__ == "__main__":
    test()
