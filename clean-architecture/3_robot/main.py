from robot import Robot
from logger import Logger

if __name__ == '__main__':
    robot = Robot(Logger())
    print('please enter robot commands: move, turn, set, start, stop')
    while(True):
        inputStr = input()
        robot.executeCommand(inputStr)

