from command_robot import Command, RobotState
import command_robot
from functools import reduce

def transfer_to_cleaner(message):
    print(message)

def createDefaultState():
    return command_robot.createDefaultState()

def activate_cleaner(commands: list[Command], transfer, state: RobotState) -> RobotState:
    return reduce(
        lambda st, cmd: cmd.execute(transfer, st), 
        commands, 
        state
    )