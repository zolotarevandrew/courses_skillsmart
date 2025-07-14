from typing import Dict, List, Type
from events import Event
from interfaces import EventStoreListener

class EventStore:
    def __init__(self):
        self._events: Dict[str, List[Event]] = {}
        self._listeners: Dict[Type[Event], List[EventStoreListener]] = {}

    def addListener(self, event_class: Type[Event], listener: EventStoreListener):
        if event_class not in self._listeners:
            self._listeners[event_class] = []
        self._listeners[event_class].append(listener)
    
    def append_events(self, robot_id: str, events: List[Event]) -> None:
        if robot_id not in self._events:
            self._events[robot_id] = []
        self._events[robot_id].extend(events)
        
        for event in events:
            ev_cls = type(event)
            for lst in self._listeners.get(ev_cls, []):
                lst.on_event(robot_id, event)

    
    def get_events(self, robot_id: str) -> List[Event]:
        return self._events.get(robot_id, [])
    
    def get_events_from_version(self, robot_id: str, from_version: int) -> List[Event]:
        events = self.get_events(robot_id)
        return events[from_version:] if from_version < len(events) else []