

def transfer(message):
    print(message)

state = None

def cleanerApi(runCommand, createDefaultState):
    global state
    state = createDefaultState()
    def execute(flow):
        global state
        state = runCommand(flow, transfer, state)
        return state
    return execute


    