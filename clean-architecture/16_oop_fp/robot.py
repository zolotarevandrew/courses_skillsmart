from dataclasses import dataclass
from enum import Enum
from logging import Logger
import math
from typing import Protocol


@dataclass(frozen=True)
class Angle:
    degrees: int

@dataclass(frozen=True)
class Distance:
    value: float

class CleaningDeviceType(Enum):
    WATER = 'water'
    SOAP = 'soap'
    BRUSH = 'brush'

    def __str__(self):
        return self.value

@dataclass(frozen=True)
class CleaningDevice:
    kind: CleaningDeviceType


class Cleaner(Protocol):
    def move(self, dist: Distance) -> 'Cleaner': 
        pass
    def turn(self, angle: Angle) -> 'Cleaner': 
        pass
    def start(self) -> 'Cleaner': 
        pass
    def stop(self) -> 'Cleaner': 
        pass
    def setDevice(self, device: CleaningDevice) -> 'Cleaner': 
        pass

@dataclass(frozen=True)
class CleanerState:
    x: float
    y: float
    angle: Angle
    device: CleaningDevice

class CleanerImpl(Cleaner):
    def __init__(self, logger: Logger, state: CleanerState = None):
        self.logger = logger
        self.state = state if state else CleanerState(
            x=0.0,
            y=0.0,
            angle=Angle(0),
            device=CleaningDevice(CleaningDeviceType.WATER)
        )

    def move(self, dist: Distance) -> 'CleanerImpl':
        angle_rads = self.state.angle.degrees * (math.pi / 180.0)
        new_x = self.state.x + dist.value * math.cos(angle_rads)
        new_y = self.state.y + dist.value * math.sin(angle_rads)

        new_state = CleanerState(
            x=new_x,
            y=new_y,
            angle=self.state.angle,
            device=self.state.device
        )

        self.logger.log(f'POS {new_x},{new_y}')
        return CleanerImpl(self.logger, new_state)

    def turn(self, angle: Angle) -> 'CleanerImpl':
        new_angle = Angle(self.state.angle.degrees + angle.degrees)
        new_state = CleanerState(
            x=self.state.x,
            y=self.state.y,
            angle=new_angle,
            device=self.state.device
        )

        self.logger.log(f'ANGLE {new_angle.degrees}')
        return CleanerImpl(self.logger, new_state)

    def setDevice(self, device: CleaningDevice) -> 'CleanerImpl':
        new_state = CleanerState(
            x=self.state.x,
            y=self.state.y,
            angle=self.state.angle,
            device=device
        )
        self.logger.log(f'SET {device.kind}')
        return CleanerImpl(self.logger, new_state)

    def start(self) -> 'CleanerImpl':
        self.logger.log(f'START {self.state.device.kind}')
        return self

    def stop(self) -> 'CleanerImpl':
        self.logger.log('STOP')
        return self