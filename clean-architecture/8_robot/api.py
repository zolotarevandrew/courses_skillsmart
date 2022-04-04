

def transfer(message):
    print(message)

state = None

def cleanerApi(runCommand, createDefaultState):
    global state
    state = createDefaultState()
    def execute(input):
        global state
        cmd = input.split(' ')
        state = runCommand(cmd, transfer, state)
        return state
    return execute


    