from abc import ABC, abstractmethod
from typing import List, Dict

from events import DomainEvent

class DomainEventStore(ABC):
    @abstractmethod
    def load_events(self, entity_id: int) -> List[DomainEvent]:
        pass

    @abstractmethod
    def append_event(self, entity_id: int, event: DomainEvent) -> None:
        pass

class InMemoryEventStore(DomainEventStore):
    def __init__(self):
        self._store: Dict[int, List[DomainEvent]] = {}

    def load_events(self, entity_id: int) -> List[DomainEvent]:
        return list(self._store.get(entity_id, []))

    def append_event(self, entity_id: int, event: DomainEvent) -> None:
        self._store.setdefault(entity_id, []).append(event)
