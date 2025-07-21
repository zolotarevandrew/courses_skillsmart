from abc import ABC, abstractmethod
from typing import Callable, Generic, Optional, TypeVar
import math

from responses import MoveResponse, SetStateResponse, TurnResponse
from state import RobotState

TData = TypeVar("TData")
TResponse = TypeVar("TResponse")
TState = TypeVar("TState") 

class Command(ABC, Generic[TData, TResponse]):
    def __init__(
        self,
        data: Optional[TData] = None,
        next_func: Optional[Callable[[TResponse], 'Command']] = None
    ):
        self.data = data
        self.next: Optional[Callable[[TResponse], Command]] = next_func

    @abstractmethod
    def interpret(self, state: TState) -> TResponse:
        pass

WATER = 'WATER' # полив водой
SOAP  = 'SOAP' # полив мыльной пеной
BRUSH = 'BRUSH' # чистка щётками

class MoveCommand(Command[float, MoveResponse]):
    def interpret(self, state: RobotState) -> MoveResponse:
        angle_rads = state.angle * (math.pi/180.0)   
        new_x = state.x + self.data * math.cos(angle_rads)
        new_y = state.y + self.data * math.sin(angle_rads)
        return MoveResponse.Ok(new_x, new_y)
        
class TurnCommand(Command[int, TurnResponse]):
    def interpret(self, state: RobotState) -> TurnResponse:
        new_angle = state.angle + self.data
        return TurnResponse.Ok(new_angle)
    
class SetStateCommand(Command[str, SetStateResponse]):
    def interpret(self, state: RobotState) -> SetStateResponse:
        def calcState():
            if self.data == 'water':
                return WATER
            elif self.data == 'soap':
                return SOAP
            elif self.data == 'brush':
                return BRUSH
            else:
                return state  
        new_state = calcState()
        return SetStateResponse.Ok(new_state)
    
class StopCommand(Command[None, None]):
    def __init__(self):
        super().__init__(data=None, next_func=None)

    def interpret(self, state: TState) -> None:
        return None