import unittest
from main import conquestCampaign

class ConquestCampaingTest(unittest.TestCase):
    def test_twoCellsOnly_twoBatallions_shouldBeAtDayOne(self):
        result = conquestCampaign(1, 2, (1,1), (1,2))
        self.assertEqual(result, 1)

    def test_threeToFourCells_twoBatallions_shouldBeAtDayThree(self):
        result = conquestCampaign(3, 4, (2,2), (3,4))
        self.assertEqual(result, 3)

if __name__ == "__main__":
    unittest.main()