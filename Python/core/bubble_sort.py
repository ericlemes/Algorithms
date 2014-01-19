from array_algos import swap

def bubble_sort(list):
    switched = True
    while switched :
        switched = False
        for i in range(len(list) - 1) :
            if i + 1 > len(list) - 1 :
                break
            if list[i] > list[i + 1] :
                swap(list, i, i + 1)
                switched = True
                
            

    

