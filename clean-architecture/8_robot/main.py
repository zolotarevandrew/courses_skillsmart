from pure_robot import runCommand, createDefaultState
from api import cleanerApi

if __name__ == '__main__':
    api = cleanerApi(runCommand, createDefaultState)
    state = api('move 100')
    state = api('turn -90')
    state = api('set soap')
    state = api('move 50')
    state = api('stop')
    print(state.x, state.y, state.angle, state.state)
    
