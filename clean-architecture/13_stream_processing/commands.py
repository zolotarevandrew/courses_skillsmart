from dataclasses import dataclass
from typing import List, Protocol
from event_store import EventStore
from events import Event, MoveRequestedEvent, StartRequestedEvent, StateChangedRequestedEvent, StopRequestedEvent, TurnRequestedEvent
from robot import CleaningMode, RobotState

class Command(Protocol):
    def handle(self) -> List[Event]:
        pass

@dataclass
class MoveCommand:
    distance: float
    
    def handle(self) -> List[Event]:
        return [MoveRequestedEvent(self.distance)]

@dataclass
class TurnCommand:
    angle: float
    
    def handle(self) -> List[Event]:
        return [TurnRequestedEvent(self.angle)]

@dataclass
class SetStateCommand:
    new_state: CleaningMode
    
    def handle(self) -> List[Event]:
        return [StateChangedRequestedEvent(self.new_state)]

@dataclass
class StartCommand:
    def handle(self) -> List[Event]:
        return [StartRequestedEvent()]

@dataclass
class StopCommand:
    def handle(self) -> List[Event]:
        return [StopRequestedEvent()]
    

class CommandHandler:
    def __init__(self, event_store: EventStore):
        self._event_store = event_store
    
    def handle_command(self, robot_id: str, command: Command) -> RobotState:
        new_events = command.handle()
        if new_events:
            self._event_store.append_events(robot_id, new_events)