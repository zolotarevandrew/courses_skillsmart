from api import activate_cleaner, createDefaultState, transfer_to_cleaner
from command_robot import MoveCommand, TurnCommand, SetStateCommand, StartCommand, StopCommand

if __name__ == '__main__':
    commands = [
        MoveCommand(100),
        TurnCommand(-90),
        SetStateCommand('soap'),
        StartCommand(),
        MoveCommand(50),
        StopCommand(),
    ]
    state = activate_cleaner(commands, transfer_to_cleaner, createDefaultState())
    print(state.x, state.y, state.angle, state.state)