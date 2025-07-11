from robot import RobotId

class Command:
    pass

class MoveCommand(Command):
    def __init__(self, robot_id: RobotId, distance: float):
        self.robot_id = robot_id
        self.distance = distance

class TurnCommand(Command):
    def __init__(self, robot_id: RobotId, turn_angle: int):
        self.robot_id = robot_id
        self.turn_angle = turn_angle

class SetStateCommand(Command):
    def __init__(self, robot_id: RobotId, new_state: str):
        self.robot_id = robot_id
        self.new_state = new_state

class StartCommand(Command):
    def __init__(self, robot_id: RobotId):
        self.robot_id = robot_id

class StopCommand(Command):
    def __init__(self, robot_id: RobotId):
        self.robot_id = robot_id