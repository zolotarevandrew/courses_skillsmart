from pure_robot import runCommand, createDefaultState
from api import cleanerApi

if __name__ == '__main__':
    api = cleanerApi(runCommand, createDefaultState)
    flow = '100 move -90 turn soap set start 50 move stop'.split(' ')
    state = api(flow)
    print(state.x, state.y, state.angle, state.state)
    
