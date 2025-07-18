from dataclasses import dataclass
from functools import wraps
from collections import namedtuple
import math

RobotState = namedtuple("RobotState", "x y angle state")

WATER = 1  
SOAP = 2   
BRUSH = 3  

@dataclass
class Status:
    code: str
    is_ok: bool = True

class MoveResponse:
    OK = Status("MOVE_OK", True)
    BARRIER = Status("HIT_BARRIER", False)

class StateMonad:
    def __init__(self, state, log=None, status:Status=None):
        self.state = state
        self.log = log or []
        self.status = status
    
    def bind(self, func):
        if self.status is not None and not self.status.is_ok:
            return self
        new_state, new_log, new_status = func(self.state, self.log)
        return StateMonad(new_state, new_log, new_status)

def move(dist):
    def check_position(x: float, y: float) -> tuple[float, float, Status]:
        constrained_x = max(0, min(100, x))
        constrained_y = max(0, min(100, y))
        if x == constrained_x and y == constrained_y:
            return (x, y, MoveResponse.OK)
        return (constrained_x, constrained_y, MoveResponse.BARRIER)

    def inner(old_state, log):
        angle_rads = old_state.angle * (math.pi/180.0)
        new_x = old_state.x + dist * math.cos(angle_rads)
        new_y = old_state.y + dist * math.sin(angle_rads)
        constrained_x, constrained_y, status = check_position(new_x, new_y)
        new_state = RobotState(
            constrained_x,
            constrained_y,
            old_state.angle,
            old_state.state
        )
        return new_state, log + [f'POS({int(new_state.x)},{int(new_state.y)})'], status
    return inner

def turn(angle):
    def inner(old_state, log):
        new_state = RobotState(
            old_state.x,
            old_state.y,
            old_state.angle + angle,
            old_state.state
        )
        return new_state, log + [f'ANGLE {new_state.angle}'], None
    return inner

def set_state(new_mode):
    def inner(old_state, log):
        new_state = RobotState(
            old_state.x,
            old_state.y,
            old_state.angle,
            new_mode
        )
        return new_state, log + [f'STATE {new_mode}'], None
    return inner

def start(old_state, log):
    return old_state, log + ['START'], None

def stop(old_state, log):
    return old_state, log + ['STOP'], None


initial_state = StateMonad(RobotState(0.0, 0.0, 0, WATER))
result = (initial_state
    .bind(move(120))
    .bind(turn(-90))
    .bind(set_state(SOAP))
    .bind(start)
    .bind(move(50))
    .bind(stop))

print(f"Status: {result.status}")
print(f"Log: {result.log}")
print(f"Final state: {result.state}")

