from typing import Generic
from typing import TypeVar
from commands import Command

TState = TypeVar("TState")

class Interpreter(Generic[TState]):
    def run(self, state: TState, command: Command) -> TState:
        response = command.interpret(state)
        new_state = state.apply(response) 
        next_command = command.next(response) if command.next else None
        if next_command is None:
            return new_state

        return self.run(new_state, next_command)