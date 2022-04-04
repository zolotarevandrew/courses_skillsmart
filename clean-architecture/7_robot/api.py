def transfer(message):
    print(message)

def cleanerApi(move, turn, set_state, start, stop):
    def execute(input, state):
        for code in input:
            cmd = code.split(' ')
            if cmd[0]=='move':
                state = move(transfer,int(cmd[1]),state) 
            elif cmd[0]=='turn':
                state = turn(transfer,int(cmd[1]),state)
            elif cmd[0]=='set':
                state = set_state(transfer,cmd[1],state) 
            elif cmd[0]=='start':
                state = start(transfer,state)
            elif cmd[0]=='stop':
                state = stop(transfer,state)
        return state
    return execute


    