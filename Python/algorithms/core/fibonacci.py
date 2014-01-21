def fibonacci_recursive(n):
    if (n <= 0) :
        e = TypeError("n must be greater than 0")        
        raise e
    elif (n == 1) :
        return 0
    elif (n == 2) :
        return 1
    else :
        return fibonacci_recursive(n - 1) + fibonacci_recursive(n - 2)

def fibonacci_iterative(n):
    if (n <= 0) :
        e = TypeError("n must be greater than 0")        
        raise e
    n1, n2 = 0, 1
    for i in range(1, n):
        n1, n2 = n2, n1 + n2
    return n1
    
def fibonacci_generator():    
    n1, n2 = 0, 1
    while True:
        yield n1     
        n1, n2 = n2, n1 + n2        
        
    
    
    