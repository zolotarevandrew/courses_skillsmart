
from robot import WATER, SOAP, BRUSH, RobotState, create_robot

robot = create_robot(RobotState(0.0, 0.0, 0, WATER))
if robot.available.canMove:
    robot = robot.move(100)
if robot.available.canTurn:
    robot = robot.turn(-90)
if robot.available.canSetState:
    robot = robot.set_state(BRUSH)
if robot.available.canTurn:
    robot = robot.turn(180)
if robot.available.canMove:
    robot = robot.move(-90)

print(robot.get_log())

