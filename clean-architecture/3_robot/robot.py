import math
from device import CleaningDevice

class Robot:
    def __init__(self, logger):
        self.x = 0
        self.y = 0
        self.logger = logger
        self.distance = 0
        self.angle = 0
        self.cleaningDevice = CleaningDevice.WATER

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

    def ceilTwoDecimals(self, value):
        return math.ceil(value * 100)/100.0

    def setState(self, device):
        if device not in [CleaningDevice.WATER, CleaningDevice.BRUSH, CleaningDevice.SOAP]:
            return

        self.cleaningDevice = device
        self.logger.log('SET ' + self.cleaningDevice)

    def move(self, distance: int):
        self.distance += distance
        self.x += self.ceilTwoDecimals(self.distance * math.cos(math.radians(self.angle)))
        self.y += self.ceilTwoDecimals(self.distance * math.sin(math.radians(self.angle)))

        self.logger.log('POS ' + str(self.x) + ',' + str(self.y))

    def start(self):
        self.logger.log('START ' + self.cleaningDevice)

    def stop(self):
        self.logger.log('STOP')

    def turn(self, value):
        self.angle += value
        self.logger.log('ANGLE ' + str(self.angle))
