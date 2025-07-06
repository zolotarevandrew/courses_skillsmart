from abc import ABC, abstractmethod
import math
from collections import namedtuple

RobotState = namedtuple("RobotState", "x y angle state")

def createDefaultState():
    return RobotState(0.0, 0.0, 0, WATER)

# режимы работы устройства очистки
WATER = 1 # полив водой
SOAP  = 2 # полив мыльной пеной
BRUSH = 3 # чистка щётками

class Command(ABC):
    @abstractmethod
    def execute(self, transfer, state: RobotState) -> RobotState:
        pass

class MoveCommand(Command):
    def __init__(self, distance: float):
        self.distance = distance

    def execute(self, transfer, state: RobotState) -> RobotState:
        angle_rads = state.angle * (math.pi/180.0)   
        new_state = RobotState(
            state.x + self.distance * math.cos(angle_rads),
            state.y + self.distance * math.sin(angle_rads),
            state.angle,
            state.state)  
        transfer(f'POS({new_state.x},{new_state.y})')
        return new_state
    
class TurnCommand(Command):
    def __init__(self, turn_angle: int):
        self.turn_angle = turn_angle

    def execute(self, transfer, state: RobotState) -> RobotState:
        new_state = RobotState(
            state.x,
            state.y,
            state.angle + self.turn_angle,
            state.state)
        transfer(f'ANGLE {new_state.angle}')
        return new_state
    
class SetStateCommand(Command):
    def __init__(self, new_internal_state: str):
        self.new_internal_state = new_internal_state

    def execute(self, transfer, state: RobotState) -> RobotState:
        if self.new_internal_state=='water':
            self_state = WATER  
        elif self.new_internal_state=='soap':
            self_state = SOAP
        elif self.new_internal_state=='brush':
            self_state = BRUSH
        else:
            return state  
        new_state = RobotState(
            state.x,
            state.y,
            state.angle,
            self_state)
        transfer(f'STATE {new_state.state}')
        return new_state
    
class StartCommand(Command):
    def execute(self, transfer, state: RobotState) -> RobotState:
        transfer(f'START WITH {state.state}')
        return state

class StopCommand(Command):
    def execute(self, transfer, state: RobotState) -> RobotState:
        transfer(f'STOP WITH {state.state}')
        return state