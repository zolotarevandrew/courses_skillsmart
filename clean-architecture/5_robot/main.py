from cleaner import activate_cleaner, createDefaultState

if __name__ == '__main__':

    func = activate_cleaner((
        'move 100',
        'turn -90',
        'set soap',
        'start',
        'move 50',
        'stop'
    ))
    state = func(createDefaultState())
    print(state.x, state.y, state.angle, state.state)
