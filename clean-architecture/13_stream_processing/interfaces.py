from typing import Protocol
from events import Event

class EventStoreListener(Protocol):
    def on_event(self, robot_id: str, event: Event) -> None:
        pass