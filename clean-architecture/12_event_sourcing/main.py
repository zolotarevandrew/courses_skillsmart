from api import CommandHandler
from commands import MoveCommand, TurnCommand, SetStateCommand, StartCommand, StopCommand
from event_store import InMemoryEventStore
from robot import RobotAggregate, RobotId

if __name__ == '__main__':
    store = InMemoryEventStore()
    handler = CommandHandler(store)
    rid = RobotId(1)

    handler.handle(StartCommand(rid))
    handler.handle(MoveCommand(rid, 100))
    handler.handle(TurnCommand(rid, -90))
    handler.handle(SetStateCommand(rid, 'soap'))
    handler.handle(MoveCommand(rid, 50))
    handler.handle(StopCommand(rid))


    agg = RobotAggregate(rid)
    for e in store.load_events(rid):
        agg.apply(e)
    print(agg.state.x, agg.state.y, agg.state.angle, agg.state.state)