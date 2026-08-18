from typing import Optional, TypeVar
from core.higher_path import CoherenceConditions, HigherPath, InfinityGroupoid


T = TypeVar('T')

# здесь не стал оборачивать эту в еще одну функцию, ради проверки, что изначальные пути c dimension >= 2
def higher_compose(p: HigherPath[T], q: HigherPath[T]) -> Optional[HigherPath[T]]:
    is_valid = (
        p.dimension == q.dimension
        and p.dimension >= 1
        and p.end == q.start
        and len(p.previous_paths) == len(q.previous_paths)
    )
    if not is_valid: return None
    if p.dimension == 1: return InfinityGroupoid.compose(p, q)

    lst = []
    for prev_p, prev_q in zip(p.previous_paths, q.previous_paths):
        composed = higher_compose(prev_p, prev_q)
        if not composed:
            return None

        lst.append(composed)

    return HigherPath(p.dimension, p.start, q.end, lst, None)

def pentagon_identity(p: HigherPath[T], q: HigherPath[T], r: HigherPath[T], s: HigherPath[T]) -> HigherPath[T]:

    # ((p ∘ q) ∘ r) ∘ s = (p ∘ q) ∘ (r ∘ s)
    ac1 = CoherenceConditions.associativity(InfinityGroupoid.compose(p, q),r,s)

    # (p ∘ (q ∘ r)) ∘ s = p ∘ ((q ∘ r) ∘ s)
    ac2 = CoherenceConditions.associativity(p,InfinityGroupoid.compose(q, r),s)

    # (p ∘ q) ∘ (r ∘ s) = p ∘ ((q ∘ r) ∘ s)
    ac3 = CoherenceConditions.associativity(p,q,InfinityGroupoid.compose(r,s))

    return CoherenceConditions.associativity(ac1,ac2,ac3)


def higher_compose_tests():

    high_dim_path_1 = HigherPath(2, "A", "B", [HigherPath.base_path("A", "B"),  HigherPath.base_path("C", "D")])
    high_dim_path_2 = HigherPath(2, "B", "C", [HigherPath.base_path("B", "C"), HigherPath.base_path("D", "E")])
    composed = higher_compose(high_dim_path_1, high_dim_path_2)
    assert composed.dimension == high_dim_path_2.dimension
    assert composed.start == "A"
    assert composed.end == "C"

    assert len(composed.previous_paths) == 2

    assert composed.previous_paths[0].start == "A"
    assert composed.previous_paths[0].end == "C"
    assert composed.previous_paths[0].dimension == 1

    assert composed.previous_paths[1].start == "C"
    assert composed.previous_paths[1].end == "E"
    assert composed.previous_paths[1].dimension == 1

    high_dim_path_1 = HigherPath(2, "A", "B", [HigherPath.base_path("A", "B"),  HigherPath.base_path("C", "D")])
    high_dim_path_2 = HigherPath(2, "C", "E", [HigherPath.base_path("B", "C"), HigherPath.base_path("D", "E")])
    composed = higher_compose(high_dim_path_1, high_dim_path_2)
    assert composed is None

    high_dim_path_1 = HigherPath(2, "A", "B", [HigherPath.base_path("A", "B"),  HigherPath.base_path("C", "D")])
    high_dim_path_2 = HigherPath(2, "C", "E", [HigherPath.base_path("C", "E"), HigherPath.base_path("D", "E")])
    composed = higher_compose(high_dim_path_1, high_dim_path_2)
    assert composed is None

    high_dim_path_1 = HigherPath(2, "A", "B", [HigherPath.base_path("A", "B"),  HigherPath.base_path("C", "D")])
    high_dim_path_2 = HigherPath(2, "C", "E", [HigherPath.base_path("B", "C"), HigherPath.base_path("E", "F")])
    composed = higher_compose(high_dim_path_1, high_dim_path_2)
    assert composed is None

    high_dim_path_1 = HigherPath(2, "A", "B", [HigherPath.base_path("A", "B"),  HigherPath.base_path("C", "D")])
    high_dim_path_2 = HigherPath(2, "B", "C", [HigherPath.base_path("B", "C"), HigherPath.base_path("D", "E")])

    high_dim_path_3 = HigherPath(3, "D", "E", [high_dim_path_1])
    high_dim_path_4 = HigherPath(3, "E", "F", [high_dim_path_2])

    composed = higher_compose(high_dim_path_3, high_dim_path_4)
    assert composed.dimension == high_dim_path_3.dimension
    assert composed.start == "D"
    assert composed.end == "F"
    
    assert len(composed.previous_paths) == 1
    
    assert composed.previous_paths[0].start == "A"
    assert composed.previous_paths[0].end == "C"
    assert composed.previous_paths[0].dimension == high_dim_path_2.dimension

    p = composed.previous_paths[0].previous_paths
    assert len(p) == 2

    assert p[0].start == "A"
    assert p[0].end == "C"
    assert p[0].dimension == 1

    assert p[1].start == "C"
    assert p[1].end == "E"
    assert p[1].dimension == 1

def pentagon_identity_tests():    
    p = HigherPath.base_path("A", "B")
    q = HigherPath.base_path("B", "C")
    r = HigherPath.base_path("C", "D")
    s = HigherPath.base_path("D", "E")
    identity = pentagon_identity(p,q,r,s)
    assert identity.dimension == 4
    assert identity.start == "A"
    assert identity.end == "E"

if __name__ == "__main__":
    higher_compose_tests()
    print("All tests passed")
