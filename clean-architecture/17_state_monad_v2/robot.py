from functools import wraps
from collections import namedtuple
import math
from typing import Tuple, List, Optional

from capabilities import RobotAvailableCapabilities, RobotCapabilities

class MoveResponse:
    OK = "MOVE_OK"
    BARRIER = "HIT_BARRIER"

class SetStateResponse:
    OK = "STATE_OK"
    NO_WATER = "OUT_OF_WATER"
    NO_SOAP = "OUT_OF_SOAP"

WATER = 1  
SOAP = 2   
BRUSH = 3  

RobotState = namedtuple("RobotState", "x y angle state")

def _check_position(x: float, y: float) -> tuple[float, float, str]:
    constrained_x = max(0, min(100, x))
    constrained_y = max(0, min(100, y))
    
    if x == constrained_x and y == constrained_y:
        return (x, y, MoveResponse.OK)
    return (constrained_x, constrained_y, MoveResponse.BARRIER)

def _check_resources(new_mode: int) -> SetStateResponse:
    return SetStateResponse.OK

def _move(dist, old_state: RobotState, log):
    angle_rads = old_state.angle * (math.pi/180.0)
    new_x = old_state.x + dist * math.cos(angle_rads)
    new_y = old_state.y + dist * math.sin(angle_rads)
    
    constrained_x, constrained_y, move_result = _check_position(new_x, new_y)
    
    new_state = RobotState(
        constrained_x,
        constrained_y,
        old_state.angle,
        old_state.state
    )
    
    message = (f'POS({int(constrained_x)},{int(constrained_y)})' 
            if move_result == MoveResponse.OK 
            else f'HIT_BARRIER at ({int(constrained_x)},{int(constrained_y)})')
    
    return new_state, log + [message], move_result

def _turn(angle, old_state: RobotState, log):
    new_state = RobotState(
        old_state.x,
        old_state.y,
        old_state.angle + angle,
        old_state.state
    )
    return new_state, log + [f'ANGLE {new_state.angle}'], MoveResponse.OK

def _set_state(new_mode, old_state: RobotState, log):
    resource_check = _check_resources(new_mode)
    
    if resource_check != SetStateResponse.OK:
        message = f'RESOURCE ERROR: {resource_check} for mode {new_mode}'
        return old_state, log + [message], resource_check
    
    new_state = RobotState(
        old_state.x,
        old_state.y,
        old_state.angle,
        new_mode
    )
    return new_state, log + [f'STATE {new_mode}'], SetStateResponse.OK

def _compute_capabilities(state: RobotState) -> RobotAvailableCapabilities:
    canMove = _check_position(
        state.x + math.cos(state.angle * math.pi / 180),
        state.y + math.sin(state.angle * math.pi / 180)
    )[2] == MoveResponse.OK
    canTurn = True
    canSetState = _check_resources(state.state) == SetStateResponse.OK

    return RobotAvailableCapabilities(
        canMove=canMove,
        canTurn=canTurn,
        canSetState=canSetState
    )


def create_robot(initial_state: RobotState) -> RobotCapabilities:
    def create_capabilities(state: RobotState, log: list[str]) -> RobotCapabilities:
        available = _compute_capabilities(state)
        def move_fn(dist: float) -> RobotCapabilities:
            new_state, new_log, response = _move(dist, state, log)
            return create_capabilities(new_state, new_log)

        def turn_fn(angle: float) -> RobotCapabilities:
            new_state, new_log, _ = _turn(angle, state, log)
            return create_capabilities(new_state, new_log)

        def set_state_fn(mode: int) -> RobotCapabilities:
            new_state, new_log, response = _set_state(mode, state, log)
            return create_capabilities(new_state, new_log)

        def get_log() -> list[str]:
            return log

        return RobotCapabilities(
            move=move_fn if available.canMove else None,
            turn=turn_fn if available.canTurn else None,
            available = available,
            set_state=set_state_fn if available.canSetState else None,
            get_log=get_log
        )

    return create_capabilities(
        initial_state, 
        []
    )