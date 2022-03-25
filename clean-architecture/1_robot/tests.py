import unittest

from robot import Robot, createCommand


class CommandsTests(unittest.TestCase):

    def test_emptyInput_shouldBeError(self):
        self.assertTrue(len(createCommand('').error()) > 0)

    def test_invalidCommand_shouldBeError(self):
        self.assertTrue(len(createCommand('test 1').error()) > 0)

    def test_invvalidMoveCommand_shouldBeError(self):
        cmd = createCommand('move s')

        self.assertTrue(len(cmd.error()) > 0)

    def test_validMoveCommand_noAngle_shouldBeSuccess(self):
        robot = Robot()
        cmd = createCommand('move 1')

        self.assertTrue(len(cmd.error()) == 0)
        cmd.execute(robot)

        self.assertEqual(robot.distance, 1)
        self.assertEqual(robot.x, 1)
        self.assertEqual(robot.y, 0)
        self.assertTrue(len(robot.logCommand) > 0)

    def test_validMoveCommand_30Angle_shouldBeSuccess(self):
        robot = Robot()
        cmd = createCommand('turn 30')
        cmd.execute(robot)

        cmd = createCommand('move 1')

        self.assertTrue(len(cmd.error()) == 0)
        cmd.execute(robot)

        self.assertEqual(robot.distance, 1)
        self.assertEqual(robot.x, 0.87)
        self.assertEqual(robot.y, 0.5)
        self.assertTrue(len(robot.logCommand) > 0)

    def test_invalidTurnCommand_shouldBeError(self):
        cmd = createCommand('turn s')

        self.assertTrue(len(cmd.error()) > 0)

    def test_validTurnCommand_30Angle_shouldBeSuccess(self):
        robot = Robot()
        cmd = createCommand('turn 30')

        self.assertTrue(len(cmd.error()) == 0)
        cmd.execute(robot)

        self.assertEqual(robot.angle, 30)
        self.assertEqual(robot.x, 0)
        self.assertEqual(robot.y, 0)
        self.assertTrue(len(robot.logCommand) > 0)

    def test_invalidSetCommand_shouldBeError(self):
        cmd = createCommand('set s')

        self.assertTrue(len(cmd.error()) > 0)

    def test_validSetCommand_water_shouldBeSuccess(self):
        robot = Robot()
        cmd = createCommand('set water')

        self.assertTrue(len(cmd.error()) == 0)
        cmd.execute(robot)

        self.assertEqual(robot.cleaningDevice, 'water')
        self.assertTrue(len(robot.logCommand) > 0)

    def test_validSetCommand_brush_shouldBeSuccess(self):
        robot = Robot()
        cmd = createCommand('set brush')

        self.assertTrue(len(cmd.error()) == 0)
        cmd.execute(robot)

        self.assertEqual(robot.cleaningDevice, 'brush')
        self.assertTrue(len(robot.logCommand) > 0)

    def test_validSetCommand_soap_shouldBeSuccess(self):
        robot = Robot()
        cmd = createCommand('set soap')

        self.assertTrue(len(cmd.error()) == 0)
        cmd.execute(robot)

        self.assertEqual(robot.cleaningDevice, 'soap')
        self.assertTrue(len(robot.logCommand) > 0)

    def test_startCommand_shouldBeSuccess(self):
        robot = Robot()
        cmd = createCommand('start')

        self.assertTrue(len(cmd.error()) == 0)
        cmd.execute(robot)

        self.assertEqual(robot.cleaningDevice, 'water')
        self.assertTrue(len(robot.logCommand) > 0)

    def test_stopCommand_shouldBeSuccess(self):
        robot = Robot()
        cmd = createCommand('stop')

        self.assertTrue(len(cmd.error()) == 0)
        cmd.execute(robot)

        self.assertEqual(robot.cleaningDevice, 'water')
        self.assertTrue(len(robot.logCommand) > 0)


if __name__ == '__main__':
    unittest.main()
