from typing import List
from events import Event
from robot import RobotState

class StateProjector:
    def __init__(self, initial_state: RobotState):
        self._initial_state = initial_state
    
    def project_state(self, events: List[Event]) -> RobotState:
        current_state = self._initial_state
        for event in events:
            current_state = event.apply(current_state)
        return current_state