from dataclasses import dataclass
from typing import Union

from responses import MoveResponse, SetStateResponse, TurnResponse

@dataclass(frozen=True)
class RobotState:
    x: float
    y: float
    angle: int
    state: int

    def apply(self, response: Union[MoveResponse, TurnResponse, SetStateResponse, None]) -> 'RobotState':
        if response is None or not response.status.is_ok:
            return self

        if isinstance(response, MoveResponse):
            return RobotState(
                x=response.new_x,
                y=response.new_y,
                angle=self.angle,
                state=self.state
            )

        if isinstance(response, TurnResponse):
            return RobotState(
                x=self.x,
                y=self.y,
                angle=response.new_angle,
                state=self.state
            )

        if isinstance(response, SetStateResponse):
            return RobotState(
                x=self.x,
                y=self.y,
                angle=self.angle,
                state=response.new_state
            )

        return self