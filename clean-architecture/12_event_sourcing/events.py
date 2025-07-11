from abc import ABC, abstractmethod
from typing import List, Dict
import math

class DomainEvent:
    pass

class RobotMoved(DomainEvent):
    def __init__(self, distance: float):
        self.distance = distance

class RobotTurned(DomainEvent):
    def __init__(self, turn_angle: int):
        self.turn_angle = turn_angle

class RobotStateChanged(DomainEvent):
    def __init__(self, new_mode: str):
        self.new_mode = new_mode

class RobotStarted(DomainEvent):
    pass

class RobotStopped(DomainEvent):
    pass