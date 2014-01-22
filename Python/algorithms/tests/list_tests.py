import unittest
from algorithms.core import list_algos

class ListTests(unittest.TestCase):
    def test_powerset(self):
        l = [1, 2, 3]
        powerset = list_algos.powerset(l)
        self.assertEqual([[1], [1, 2], [2], [1, 2, 3], [2, 3], [1, 3], [3]], powerset)        
    

if __name__ == '__main__':
    unittest.main()