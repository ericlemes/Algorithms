import unittest
from algorithms.core import graph

class GraphTests(unittest.TestCase):
    def test_calculate_all_routes(self):
        a = graph.Edge("A")
        b = graph.Edge("B")
        c = graph.Edge("C")
        d = graph.Edge("D")
        e = graph.Edge("E")
        a.vertices.append(graph.WeightedVertex(b, 1))
        a.vertices.append(graph.WeightedVertex(c, 2))
        b.vertices.append(graph.WeightedVertex(d, 3))
        c.vertices.append(graph.WeightedVertex(d, 4))
        c.vertices.append(graph.WeightedVertex(e, 4))
        d.vertices.append(graph.WeightedVertex(e, 2))
        e.vertices.append(graph.WeightedVertex(a, 1))
        
        def route_has_five_stops(r):
            return len(r) >= 5        
        
        routes = graph.calculate_all_routes(a, a, route_has_five_stops)
        self.assertEqual(3, len(routes))
        self.assertEqual("A0 B1 D3 E2 A1", graph.print_route(routes[0]))
        self.assertEqual("A0 C2 D4 E2 A1", graph.print_route(routes[1]))
        self.assertEqual("A0 C2 E4 A1", graph.print_route(routes[2]))
            
    
if __name__ == '__main__':
    unittest.main()
    
