from pure_robot import move, turn, set_state, start, stop, createDefaultState
from api import cleanerApi

if __name__ == '__main__':
    api = cleanerApi(move, turn, set_state, start, stop)
    state = api((
        'move 100',
        'turn -90',
        'set soap',
        'start',
        'move 50',
        'stop'
    ), createDefaultState())
    print(state.x, state.y, state.angle, state.state)
    
