import unittest
from algorithms.core import fibonacci

class FibonacciTests(unittest.TestCase) :
    def test_fib_negative(self):
        with self.assertRaises(TypeError) :
            fibonacci.fibonacci_recursive(-1)
        with self.assertRaises(TypeError) :
            fibonacci.fibonacci_recursive(0)
            
    def test_fib_base(self):
        self.assertEqual(0, fibonacci.fibonacci_recursive(1))
        self.assertEqual(1, fibonacci.fibonacci_recursive(2))
    
    def test_fib_10(self):  
        self.assertEqual(1, fibonacci.fibonacci_recursive(3))
        self.assertEqual(3, fibonacci.fibonacci_recursive(5))
        self.assertEqual(34, fibonacci.fibonacci_recursive(10))
        
    def test_fib_iter_negative(self):
        with self.assertRaises(TypeError) :
            fibonacci.fibonacci_iterative(-1)
        with self.assertRaises(TypeError) :
            fibonacci.fibonacci_iterative(0)
            
    def test_fib_iter_base(self):
        self.assertEqual(0, fibonacci.fibonacci_iterative(1))
        self.assertEqual(1, fibonacci.fibonacci_iterative(2))
    
    def test_fib_iter_10(self):  
        self.assertEqual(1, fibonacci.fibonacci_iterative(3))
        self.assertEqual(3, fibonacci.fibonacci_iterative(5))
        self.assertEqual(34, fibonacci.fibonacci_iterative(10))
        
    def test_fib_generator(self):        
        g = fibonacci.fibonacci_generator()
        l = [g.next() for i in range(7)]                
        self.assertEqual([0, 1, 1, 2, 3, 5, 8], l)    
        
if __name__ == '__main__':
    unittest.main()
    
    
