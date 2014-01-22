import unittest
from algorithms.core import fibonacci

class DataTypeTest(unittest.TestCase):
    def test_data(self):
        gen = fibonacci.fibonacci_generator()
        for i in range(10000):
            n = gen.next()
            print(str(n) + ": " + str(type(n)))
    
if __name__ == '__main__':
    unittest.main()