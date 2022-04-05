import math
from collections import namedtuple

RobotState = namedtuple("RobotState", "x y angle state")

# режимы работы устройства очистки
WATER = 1 # полив водой
SOAP  = 2 # полив мыльной пеной
BRUSH = 3 # чистка щётками

def createDefaultState():
    return RobotState(0.0, 0.0, 0, WATER)


# перемещение
def move(transfer,dist,state):
    angle_rads = state.angle * (math.pi/180.0)   
    new_state = RobotState(
        state.x + dist * math.cos(angle_rads),
        state.y + dist * math.sin(angle_rads),
        state.angle,
        state.state)  
    transfer(f'POS({new_state.x},{new_state.y})')
    return new_state

# поворот
def turn(transfer,turn_angle,state):
    new_state = RobotState(
        state.x,
        state.y,
        state.angle + turn_angle,
        state.state)
    transfer(f'ANGLE {new_state.angle}')
    return new_state

# установка режима работы
def set_state(transfer,new_internal_state,state):
    if new_internal_state=='water':
        self_state = WATER  
    elif new_internal_state=='soap':
        self_state = SOAP
    elif new_internal_state=='brush':
        self_state = BRUSH
    else:
        return state  
    new_state = RobotState(
        state.x,
        state.y,
        state.angle,
        self_state)
    transfer(f'STATE {new_state.state}')
    return new_state

# начало чистки
def start(transfer,state):
    transfer(f'START WITH {state.state}')
    return state

# конец чистки
def stop(transfer,state):
    transfer('STOP')
    return state

def runCommand(flow, transfer, state):
    stack = []

    def run(state):
        cmd = stack[-1]
        if cmd=='move' and len(stack) == 2:
            stack.pop()
            arg = stack.pop()
            state = move(transfer,int(arg),state) 
        elif cmd=='turn' and len(stack) == 2:
            stack.pop()
            arg = stack.pop()
            state = turn(transfer,int(arg),state)
        elif cmd=='set' and len(stack) == 2:
            stack.pop()
            arg = stack.pop()
            state = set_state(transfer,arg,state) 
        elif cmd=='start' and len(stack) == 1:
            arg = stack.pop()
            state = start(transfer,state)
        elif cmd=='stop' and len(stack) == 1:
            stack.pop()
            state = stop(transfer,state)
        return state

    for item in flow:
        stack.append(item)
        state = run(state)
    return state