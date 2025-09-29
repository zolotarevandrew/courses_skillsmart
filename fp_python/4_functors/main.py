from pymonad.maybe import Maybe, Just, Nothing
from pymonad.tools import curry
from pymonad.list import ListMonad, List

@curry(2)
def add(x, y):
    return x + y

def add10(m):
    return m.apply(add).to_arguments(m.insert(10), m)

res1 = add10(Just(10))
res2 = add10(ListMonad(1,3,10))
res3 = add10(Nothing)
print(res1)
print(res2)
print(res3)