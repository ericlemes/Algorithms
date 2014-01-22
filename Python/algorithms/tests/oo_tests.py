import unittest

class OOTests(unittest.TestCase):
    def test_dynamic_properties(self):
        class Dummy(object):
            pass
        
        def do_something(dummy):
            dummy.foo = "bar2"
                
        a = Dummy()
        a.foo = "bar"
        self.assertEqual("bar", a.foo)
        do_something(a)
        self.assertEqual("bar2", a.foo)
        
    def test_virtual_methods(self):
        class Base(object):
            def do_something(self):
                self.data = "abc"
                
        class Inherited(Base):
            def do_something(self):
                Base.do_something(self)
                self.data = self.data + "def"
            
        a = Inherited()
        a.do_something()
        self.assertEqual("abcdef", a.data)
        
        
        

if __name__ == '__main__':
    unittest.main()