from commands import Command, MoveCommand, SetStateCommand, StartCommand, StopCommand, TurnCommand
from event_store import DomainEventStore
from robot import RobotAggregate


class CommandHandler:
    def __init__(self, event_store: DomainEventStore):
        self.event_store = event_store

    def handle(self, command: Command) -> RobotAggregate:
        agg = RobotAggregate(command.robot_id)
        for ev in self.event_store.load_events(agg.robot_id):
            agg.apply(ev)

        if isinstance(command, MoveCommand):
            agg.move(command.distance)
        elif isinstance(command, TurnCommand):
            agg.turn(command.turn_angle)
        elif isinstance(command, SetStateCommand):
            agg.set_state(command.new_state)
        elif isinstance(command, StartCommand):
            agg.start()
        elif isinstance(command, StopCommand):
            agg.stop()

        for ev in agg.uncommitted_events:
            self.event_store.append_event(agg.robot_id, ev)
        agg.clear_events()
        return agg