import math


class Robot:
    def __init__(self):
        self.x = 0
        self.y = 0
        self.distance = 0
        self.angle = 0
        self.logCommand = ''
        self.cleaningDevice = defaultCleaningDevice()

class Command:
    def __init__(self):
        self.args = []
        self.name = ''
        self.error = lambda : ''
        self.execute = None

def createCommand(input):
    command = Command()
    args = input.split(' ')
    if len(args) == 0:
        command.error = lambda : 'Invalid command available: move, turn, set, start, stop'
        return command

    name = args[0]
    if name not in availableCommands:
        command.error = lambda : 'Invalid command available: move, turn, set, start, stop'
        return command

    command.args = args[1::]
    command.name = name

    availableCommands[command.name](command)
    return command


def move(command: Command):
    if len(command.args) == 0:
        command.error = lambda : 'move command should have params'
        return command

    if not command.args[0].isnumeric():
        command.error = lambda : 'invalid move distance should be number > 0'
        return command

    distance = int(command.args[0])
    if distance <= 0:
        command.error = lambda : 'invalid move distance should be number > 0'
        return command

    def ceilTwoDecimals(value):
        return math.ceil(value * 100)/100.0
    
    def execute(robot: Robot):
        robot.distance += distance
        x0 = robot.x
        y0 = robot.y

        robot.x = ceilTwoDecimals(robot.distance * math.cos(math.radians(robot.angle)) + y0)
        robot.y = ceilTwoDecimals(robot.distance * math.sin(math.radians(robot.angle)) + x0)

        robot.logCommand = 'POS ' + str(robot.x) + ',' + str(robot.y)
        return

    command.execute = execute
    return command
    
    
def turn(command: Command):
    if len(command.args) == 0:
        command.error = lambda : 'turn command should have params'
        return command

    if not command.args[0].isnumeric():
        command.error = lambda : 'invalid angle should be number'
        return command

    angle = int(command.args[0])

    def execute(robot: Robot):
        robot.angle += angle
        robot.logCommand = 'ANGLE ' + str(robot.angle)
        return

    command.execute = execute
    return command

def set(command: Command):
    if len(command.args) == 0:
        command.error = lambda : 'set command should have params'
        return command

    devices = cleaningDevices()
    if command.args[0] not in devices:
        command.error = lambda : 'invalid cleaning device'
        return command

    device = command.args[0]

    def execute(robot: Robot):
        robot.cleaningDevice = device
        robot.logCommand = 'SET ' + robot.cleaningDevice
        return

    command.execute = execute
    return command

def start(command: Command):
    def execute(robot: Robot):
        robot.logCommand = 'START ' + robot.cleaningDevice
        return

    command.execute = execute
    return command

def stop(command: Command):
    def execute(robot: Robot):
        robot.logCommand = 'STOP'
        return

    command.execute = execute
    return command

availableCommands = {
    'move': move,
    'turn': turn,
    'set': set,
    'start': start,
    'stop': stop
}

def cleaningDevices():
    return [defaultCleaningDevice(), 'soap', 'brush']

def defaultCleaningDevice():
    return 'water'


if __name__ == '__main__':
    robot = Robot()
    print('please enter robot commands: move, turn, set, start, stop')
    while(True):
        inputStr = input()
        cmd = createCommand(inputStr)
        error = cmd.error()
        if len(error) > 0:
            print(error)
            continue

        cmd.execute(robot)
        print(robot.logCommand)

