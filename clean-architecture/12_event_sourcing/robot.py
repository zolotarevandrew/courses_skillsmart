from typing import List
from events import DomainEvent, RobotMoved, RobotStarted, RobotStateChanged, RobotStopped, RobotTurned
import math
from collections import namedtuple

RobotState = namedtuple("RobotState", "x y angle state")
RobotId = namedtuple("RobotId", "value")

# режимы работы устройства очистки
WATER = 1 # полив водой
SOAP  = 2 # полив мыльной пеной
BRUSH = 3 # чистка щётками

def createRobotId():
    return RobotId(1)

class RobotAggregate:
    def __init__(self, robot_id: RobotId):
        self.robot_id = robot_id
        self.state = RobotState(0.0, 0.0, 0, WATER)
        self._uncommitted_events: List[DomainEvent] = []

    @property
    def uncommitted_events(self) -> List[DomainEvent]:
        return list(self._uncommitted_events)
    
    def clear_events(self) -> None:
        self._uncommitted_events.clear()

    def apply(self, event: DomainEvent) -> None:
        if isinstance(event, RobotMoved):
            angle_rads = self.state.angle * (math.pi/180.0)
            oldState = self.state
            self.state = RobotState(
                oldState.x + event.distance * math.cos(angle_rads),
                oldState.y + event.distance * math.sin(angle_rads),
                oldState.angle,
                oldState.state ) 
        elif isinstance(event, RobotTurned):
             oldState = self.state
             self.state = RobotState(
                oldState.x,
                oldState.y,
                oldState.angle + event.turn_angle,
                oldState.state)
        elif isinstance(event, RobotStateChanged):
            oldState = self.state
            if event.new_mode=='water':
                self_state = WATER  
            elif event.new_mode=='soap':
                self_state = SOAP
            elif event.new_mode=='brush':
                self_state = BRUSH
            else:
                return  
            self.state = RobotState(
                oldState.x,
                oldState.y,
                oldState.angle,
                self_state)

    def _record(self, event: DomainEvent) -> None:
        self.apply(event)
        self._uncommitted_events.append(event)

    def move(self, distance: float) -> None:
        self._record(RobotMoved(distance))

    def turn(self, angle: int) -> None:
        self._record(RobotTurned(angle))

    def set_state(self, new_mode: str) -> None:
        self._record(RobotStateChanged(new_mode))

    def start(self) -> None:
        self._record(RobotStarted())

    def stop(self) -> None:
        self._record(RobotStopped())
