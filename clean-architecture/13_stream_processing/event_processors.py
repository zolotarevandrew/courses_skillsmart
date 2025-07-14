from event_store import EventStore
from events import Event, MoveRequestedEvent, RobotMovedEvent, RobotStartedEvent, RobotStateChangedEvent, RobotStoppedEvent, RobotTurnedEvent, StartRequestedEvent, StateChangedRequestedEvent, StopRequestedEvent, TurnRequestedEvent
from interfaces import EventStoreListener

class MovedRequestedEventListener(EventStoreListener):
    def __init__(self, event_store: EventStore):
        self.event_store = event_store

    def on_event(self, robot_id: str, event: MoveRequestedEvent) -> None:
        self.event_store.append_events(robot_id, [RobotMovedEvent(event.distance)])

class TurnRequestedEventListener(EventStoreListener):
    def __init__(self, event_store: EventStore):
        self.event_store = event_store
        
    def on_event(self, robot_id: str, event: TurnRequestedEvent) -> None:
        self.event_store.append_events(robot_id, [RobotTurnedEvent(event.angle)])

class StateChangedRequestedEventListener(EventStoreListener):
    def __init__(self, event_store: EventStore):
        self.event_store = event_store

    def on_event(self, robot_id: str, event: StateChangedRequestedEvent) -> None:
        self.event_store.append_events(robot_id, [RobotStateChangedEvent(event.new_state)])

class StopRequestedEventListener(EventStoreListener):
    def __init__(self, event_store: EventStore):
        self.event_store = event_store

    def on_event(self, robot_id: str, event: StopRequestedEvent) -> None:
        self.event_store.append_events(robot_id, [RobotStoppedEvent()])

class StartRequestedEventListener(EventStoreListener):
    def __init__(self, event_store: EventStore):
        self.event_store = event_store
    
    def on_event(self, robot_id: str, event: StartRequestedEvent) -> None:
        self.event_store.append_events(robot_id, [RobotStartedEvent()])