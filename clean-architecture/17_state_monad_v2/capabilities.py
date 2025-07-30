from dataclasses import dataclass, replace
from typing import Callable, Optional

@dataclass(frozen=True)
class RobotAvailableCapabilities:
    canMove: bool
    canTurn: bool
    canSetState: bool

@dataclass(frozen=True)
class RobotCapabilities:
    move: Optional[Callable[[float], 'RobotCapabilities']]
    turn: Optional[Callable[[float], 'RobotCapabilities']]
    available: RobotAvailableCapabilities
    set_state: Optional[Callable[[int], 'RobotCapabilities']]
    get_log: Callable[[], list[str]]

    
