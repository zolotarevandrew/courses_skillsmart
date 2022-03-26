import math


class RobotLogger:
    def log(self, value: str):
        print(value)
        
class Robot:
    def __init__(self):
        self.x = 0
        self.y = 0
        self.logger = RobotLogger()
        self.distance = 0
        self.angle = 0
        self.cleaningDevice = self.defaultCleaningDevice()

    def executeCommand(self, inputStr):
        cmd = inputStr.split(' ')
        if cmd[0]=='move':
            self.move(int(cmd[1])) 

        elif cmd[0]=='turn':
            self.turn(int(cmd[1]))         

        elif cmd[0]=='set':
            self.setState(cmd[1]) 

        elif cmd[0]=='start':
            self.start()

        elif cmd[0]=='stop':
            self.stop()

    def defaultCleaningDevice(self):
        return 'water'

    def cleaningDevices(self):
        return [self.defaultCleaningDevice(), 'soap', 'brush']

    def ceilTwoDecimals(self, value):
        return math.ceil(value * 100)/100.0

    def setState(self, device: int):
        if device not in self.cleaningDevices():
            return

        self.cleaningDevice = device
        self.logger.log('SET ' + robot.cleaningDevice)

    def move(self, distance: int):
        self.distance += distance
        self.x += self.ceilTwoDecimals(self.distance * math.cos(math.radians(self.angle)))
        self.y += self.ceilTwoDecimals(self.distance * math.sin(math.radians(self.angle)))

        self.logger.log('POS ' + str(self.x) + ',' + str(self.y))

    def start(self):
        self.logger.log('START ' + robot.cleaningDevice)

    def stop(self):
        self.logger.log('STOP')

    def turn(self, value):
        robot.angle += value
        self.logger.log('ANGLE ' + str(robot.angle))



if __name__ == '__main__':
    robot = Robot()
    print('please enter robot commands: move, turn, set, start, stop')
    while(True):
        inputStr = input()
        robot.executeCommand(inputStr)

