import unittest

from robot import parseCommand

class ParseCommandTests(unittest.TestCase):

  def emptyInput_shouldBeError(self):
      self.assertTrue(len(parseCommand('').error()) > 0)

  def invalidCommand_shouldBeError(self):
      self.assertTrue(len(parseCommand('test 1').error()) > 0)

  def validMoveCommand_shouldBeSuccess(self):
      self.assertTrue(len(parseCommand('move 1').error()) == 0)

  def validSetCommand_shouldBeSuccess(self):
      self.assertTrue(len(parseCommand('set soap').error()) == 0)

  def validStopCommand_shouldBeSuccess(self):
      self.assertTrue(len(parseCommand('stop').error()) == 0)

  def validStartCommand_shouldBeSuccess(self):
      self.assertTrue(len(parseCommand('start').error()) == 0)

  def validTurnCommand_shouldBeSuccess(self):
      self.assertTrue(len(parseCommand('turn 90').error()) == 0)

if __name__ == '__main__':
    unittest.main()