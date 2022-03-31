import pure_robot
from functools import reduce

def transfer_to_cleaner(message):
    print(message)

def createDefaultState():
    return pure_robot.createDefaultState()

def activate_cleaner(code):

    def move(cmd):
        return lambda state: pure_robot.move(transfer_to_cleaner,int(cmd[1]),state)

    def turn(cmd):
        return lambda state: pure_robot.turn(transfer_to_cleaner,int(cmd[1]),state)

    def set_state(cmd):
        return lambda state: pure_robot.set_state(transfer_to_cleaner,cmd[1],state)

    def start(cmd):
        return lambda state: pure_robot.start(transfer_to_cleaner,state)

    def stop(cmd):
        return lambda state: pure_robot.stop(transfer_to_cleaner,state)

    def compose(f1, f2):
        return lambda x : f2(f1(x))
        
    def composeAll(funcs):  
        return reduce(compose, funcs)
    
    def createFunc(command):
        cmd = command.split(' ')
        return funcs[cmd[0]](cmd)

    funcs = {
        'move': move,
        'turn': turn,
        'set': set_state,
        'start': start,
        'stop': stop,
    }
    return composeAll(list(map(createFunc, code)))