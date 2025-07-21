
from dataclasses import dataclass
from typing import Optional

@dataclass
class Status:
    code: str
    is_ok: bool = True

@dataclass
class MoveResponse:
    status: Status
    new_x: Optional[float] = None
    new_y: Optional[float] = None

    @staticmethod
    def Ok(new_x: float, new_y: float) -> 'MoveResponse':
        return MoveResponse(status=Status("MOVE_OK", True), new_x=new_x, new_y=new_y)

    @staticmethod
    def HitBarrier() -> 'MoveResponse':
        return MoveResponse(status=Status("HIT_BARRIER", False))
    
@dataclass
class TurnResponse:
    status: Status
    new_angle: Optional[int] = None

    @staticmethod
    def Ok(new_angle: int) -> 'TurnResponse':
        return TurnResponse(status=Status("TURN_OK", True), new_angle=new_angle)
    
@dataclass
class SetStateResponse:
    status: Status
    new_state: Optional[str] = None

    @staticmethod
    def Ok(new_state: int) -> 'SetStateResponse':
        return SetStateResponse(status=Status("SET_STATE_OK", True), new_state=new_state)