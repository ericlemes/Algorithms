import unittest
from algorithms.core import array_algos

class ArrayTests (unittest.TestCase) :
    def test_merge_two_sorted_arrays(self):
        a1 = [3, 5, 7]
        a2 = [2, 4, 6]
        amerge = array_algos.merge_two_sorted_arrays(a1, a2)        
        self.assertEqual([2, 3, 4, 5, 6, 7], amerge)        
        
    def test_get_word_ocurrences(self):
        l = [ \
                [ 'w', 'a', 'k', 'o'], \
                [ 's', 'a', 'c', 'h'], \
                [ 'r', 'c', 'h', 'i'], \
                [ 't', 'h', 'u', 'n'], \
                [ 'g', 'i', 'j', 'y'], \
                [ 'g', 'n', 'j', 'q']  \
            ]        
        self.assertEqual(4, array_algos.get_word_ocurrences(l, "sachin"))
    
    def test_find_subset_which_sum_is_zero(self):
        l = [1, 2, 3]
        s = array_algos.find_subset_which_sum_is_zero(l)
        self.assertEqual([-1, -2, 3], s)
    
if __name__ == '__main__':
    unittest.main()
    