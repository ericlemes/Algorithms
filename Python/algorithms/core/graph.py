class Edge(object):
    item = None
    vertices = None
    
    def __init__(self, item):
        self.item = item
        self.vertices = []
        
class Vertex(object):
    edge = None
    
class WeightedVertex(Vertex):    
    weight = 0
    
    def __init__(self, edge, weight):
        self.edge = edge
        self.weight = weight
        
def calculate_all_routes(start_edge, end_edge, stop_callback):
    routes = []    
    _calculate_all_routes_recur(start_edge, end_edge, stop_callback, [(start_edge, 0)], routes)
    return routes

def _calculate_all_routes_recur(edge, end_edge, stop_callback, curr_route, routes):
    if edge == end_edge and len(curr_route) > 1:
        routes.append(curr_route)
    
    if stop_callback(curr_route):
        return
    
    for v in edge.vertices:
        newroute = curr_route[:]
        newroute.append((v.edge, v.weight))        
        _calculate_all_routes_recur(v.edge, end_edge, stop_callback, newroute, routes)
    
def print_route(route):
    s = ""
    for r in route:
        if (s != ""):
            s += " "
        s += str(r[0].item)        
        s += str(r[1])
    return s

    

    