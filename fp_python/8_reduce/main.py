from functools import reduce
from math import inf

def step(state, cur):
    x1, x2 = state
    if cur > x1:
        return (cur, x1)
    elif x1 > cur > x2:
        return (x1, cur)
    else:
        return state

def secondMax(lst):
    x, y = reduce(step, lst, (-inf,-inf))
    return x if y == -inf else y

lst = [1,2,3,4,5]
print(secondMax(lst))