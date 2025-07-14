from commands import MoveCommand, TurnCommand, SetStateCommand, StartCommand, StopCommand, CommandHandler
from event_store import EventStore
from event_processors import MovedRequestedEventListener, StartRequestedEventListener, StateChangedRequestedEventListener, StopRequestedEventListener, TurnRequestedEventListener
from events import MoveRequestedEvent, StartRequestedEvent, StateChangedRequestedEvent, StopRequestedEvent, TurnRequestedEvent
from robot import CleaningMode, RobotState
from state_projector import StateProjector

if __name__ == '__main__':
    store = EventStore()
    robot_id = 'robot_001'

    store.addListener(MoveRequestedEvent, MovedRequestedEventListener(store))
    store.addListener(TurnRequestedEvent, TurnRequestedEventListener(store))
    store.addListener(StateChangedRequestedEvent, StateChangedRequestedEventListener(store))
    store.addListener(StopRequestedEvent, StopRequestedEventListener(store))
    store.addListener(StartRequestedEvent, StartRequestedEventListener(store))

    handler = CommandHandler(store)

    handler.handle_command(robot_id, StartCommand())
    handler.handle_command(robot_id, MoveCommand(100))
    handler.handle_command(robot_id, TurnCommand(-90))
    handler.handle_command(robot_id, SetStateCommand('soap'))
    handler.handle_command(robot_id, MoveCommand(50))
    handler.handle_command(robot_id, StopCommand())

    initial_state = RobotState(0.0, 0.0, 0, CleaningMode.WATER.value)
    project = StateProjector(initial_state)
    events = store.get_events(robot_id)
    print(events)
    state = project.project_state(events)
    print(state)
