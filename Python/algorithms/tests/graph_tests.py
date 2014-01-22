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
        
    def test_calculate_shortest_rout_weighted(self):
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
        
        route = graph.calculate_shortest_route_weighted(a, d)                
        self.assertEqual("A B D", graph.print_route(route))        
            
    def test_calculate_shortest_route_unweighted(self):
        a = graph.Edge("A")
        b = graph.Edge("B")
        c = graph.Edge("C")
        d = graph.Edge("D")
        a.vertices.append(graph.Vertex(b))
        a.vertices.append(graph.Vertex(c))
        b.vertices.append(graph.Vertex(c))
        b.vertices.append(graph.Vertex(d))
        c.vertices.append(graph.Vertex(d))
        d.vertices.append(graph.Vertex(a))
        
        route = graph.calculate_shortest_route_unweighted(a, d);
        self.assertEqual("A C D", graph.print_route(route))
        
    def test_calculate_longest_route_unweighted(self):
        a = graph.Edge("A")
        b = graph.Edge("B")
        c = graph.Edge("C")
        d = graph.Edge("D")
        a.vertices.append(graph.Vertex(b))
        a.vertices.append(graph.Vertex(c))
        b.vertices.append(graph.Vertex(c))
        b.vertices.append(graph.Vertex(d))
        c.vertices.append(graph.Vertex(d))
        d.vertices.append(graph.Vertex(a))
        route = graph.calculate_longest_route_unweighted(a, d);
        self.assertEqual("A B C D", graph.print_route(route))
    
if __name__ == '__main__':
    unittest.main()
    
