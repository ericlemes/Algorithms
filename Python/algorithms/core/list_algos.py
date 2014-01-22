def powerset(l):
    if len(l) == 0:
        return []
    
    s = [l[0]]
    sets = [s]    
    for subset in powerset(l[1:]):            
        sets.append(s + subset)
        sets.append(subset)
    return sets
    
