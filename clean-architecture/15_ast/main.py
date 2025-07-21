from commands import MoveCommand, SetStateCommand, StopCommand, TurnCommand
from interpeter import Interpreter
from state import RobotState


initial_state = RobotState(x=0.0, y=0.0, angle=0, state='WATER')
chain = MoveCommand(100, next_func=lambda move_resp:
    TurnCommand(-90, next_func=lambda turn_resp:
        SetStateCommand('soap', next_func=lambda setstate_resp:
            MoveCommand(50, next_func=lambda _: StopCommand())
        )
    ) if move_resp.status.is_ok else StopCommand()
)

interpreter = Interpreter()
final_state = interpreter.run(initial_state, chain)

print(final_state)