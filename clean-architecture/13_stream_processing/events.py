from abc import ABC, abstractmethod
from dataclasses import dataclass
import math
from robot import CleaningMode, RobotState

class Event(ABC):
    @abstractmethod
    def apply(self, state: RobotState) -> RobotState:
        pass
    
    @abstractmethod
    def get_event_type(self) -> str:
        pass

@dataclass
class MoveRequestedEvent(Event):
    distance: float
    
    def apply(self, state: RobotState) -> RobotState:
        return state
    
    def get_event_type(self) -> str:
        return f'MOVE_REQUESTED'

@dataclass
class TurnRequestedEvent(Event):
    angle: float
    
    def apply(self, state: RobotState) -> RobotState:
        return state
    
    def get_event_type(self) -> str:
        return f'TURN_REQUESTED'
    
@dataclass
class StateChangedRequestedEvent(Event):
    new_state: CleaningMode
    
    def apply(self, state: RobotState) -> RobotState:
        return state
    
    def get_event_type(self) -> str:
        return f'STATE_CHANGE_REQUESTED'
    
@dataclass
class StopRequestedEvent(Event):
    
    def apply(self, state: RobotState) -> RobotState:
        return state
    
    def get_event_type(self) -> str:
        return f'STOP_REQUESTED'
    
@dataclass  
class StartRequestedEvent(Event):
    
    def apply(self, state: RobotState) -> RobotState:
        return state
    
    def get_event_type(self) -> str:
        return f'START_REQUESTED'

@dataclass
class RobotMovedEvent(Event):
    distance: float
    
    def apply(self, state: RobotState) -> RobotState:
        angle_rads = state.angle * (math.pi/180.0)
        return RobotState(
            x=state.x + self.distance * math.cos(angle_rads),
            y=state.y + self.distance * math.sin(angle_rads),
            angle=state.angle,
            state=state.state
        )
    
    def get_event_type(self) -> str:
        return f'ROBOT_MOVED {self.distance}'

@dataclass
class RobotTurnedEvent(Event):
    angle: float
    
    def apply(self, state: RobotState) -> RobotState:
        return RobotState(
            x=state.x,
            y=state.y,
            angle=state.angle + self.angle,
            state=state.state
        )
    
    def get_event_type(self) -> str:
        return f'ROBOT_TURNED {self.angle}'

@dataclass
class RobotStateChangedEvent(Event):
    new_state: CleaningMode
    
    def apply(self, state: RobotState) -> RobotState:
        print(self.new_state)
        return RobotState(
            x=state.x,
            y=state.y,
            angle=state.angle,
            state=self.new_state
        )
    
    def get_event_type(self) -> str:
        return f'ROBOT_STATE_CHANGED {self.new_state.name}'

@dataclass
class RobotStartedEvent(Event):

    def apply(self, state: RobotState) -> RobotState:
        return state
    
    def get_event_type(self) -> str:
        return 'ROBOT_STARTED'

@dataclass
class RobotStoppedEvent(Event):

    def apply(self, state: RobotState) -> RobotState:
        return state
    
    def get_event_type(self) -> str:
        return 'ROBOT_STOPPED'