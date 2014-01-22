import unittest
from algorithms.core import bubble_sort

class BubbleSortTests(unittest.TestCase):
    """def test_bubble_sort(self) :
        a = [10, 25, 15, 2, 13, 1, 5]
        bubble_sort.bubble_sort(a);
        self.assertEqual([1, 2, 5, 10, 13, 15, 25], a)"""
        
    def test_big_bubble_sort(self):
        l = [x for x in range(20000, 0, -1)]
        bubble_sort.bubble_sort(l)
    
if __name__ == '__main__':
    unittest.main()
    
