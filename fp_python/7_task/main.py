from dataclasses import dataclass
from typing import List, Set
from pymonad.list import ListMonad
from pymonad.state import State

Cell = tuple[int, int]

def iterate(f, x):
    while True:
        yield x
        x = f(x)

def stopWhen(pred, it):
    return next(x for x in it if pred(x))

@dataclass(frozen=True)
class VisitedCells():
    days: int
    visited: set[Cell]

    def next(self, visited):
        return VisitedCells(days=self.days + 1, visited = self.visited | set(visited))

def conquestCampaign(n: int, m: int, *cells: Cell):
    expand_capture_area = lambda x: ListMonad(
        (x[0] - 1, x[1]), 
        (x[0] + 1, x[1]),
        (x[0], x[1] - 1), 
        (x[0], x[1] + 1)
    )
    filter_valid_area = lambda x: ListMonad( (x[0], x[1]) ) if 1 <= x[0] <= n and 1 <= x[1] <= m else ListMonad()
    expand_to_valid_area = (lambda pos: ListMonad(pos).bind(expand_capture_area).bind(filter_valid_area))

    def step(cur: ListMonad):
        def with_list(visited: VisitedCells):
            next_area = cur.bind(expand_to_valid_area)
            return next_area, visited.next(next_area)
        return State(with_list)
    
    def step_run(pair):
        cur, visited = pair
        return step(cur).run(visited)
    
    done = lambda pair: (not list(pair[0])) or (len(pair[1].visited) >= n*m)

    visitedCells = VisitedCells(days=1, visited = set(cells))
    init = (ListMonad(*cells), visitedCells)
    _, visited = stopWhen(done, iterate(step_run, init))
    return visited.days


print(conquestCampaign(3, 4, (2,2), (3,4)))




