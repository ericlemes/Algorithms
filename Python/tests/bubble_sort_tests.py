import unittest
import bubble_sort

class BubbleSortTests(unittest.TestCase):
    def test_bubble_sort(self) :
        a = [10, 25, 15, 2, 13, 1, 5]
        bubble_sort.bubble_sort(a);
        self.assertEqual([1, 2, 5, 10, 13, 15, 25], a)
    
if __name__ == '__main__':
    unittest.main()
    
