def merge_two_sorted_arrays(a1, a2):
    result = []
    index1, index2 = 0, 0
    while (in_range(index1, a1) or in_range(index2, a2)):
        if (not in_range(index2, a2) or a1[index1] < a2[index2]) :
            result.append(a1[index1])
            index1 += 1
        elif (not in_range(index2, a1) or a2[index2] < a1[index1]) :
            result.append(a2[index2])
            index2 += 1
    return result;    
    
def in_range(index, list):
    return index <= len(list) - 1

def get_word_ocurrences(l, word):
    wordcount = 0
    for i in range(len(l)):
        for j in range(len(l[i])):
            wordcount += _get_word_ocurrences_recur(l, word, j, i, l[i][j])
    return wordcount

def _get_word_ocurrences_recur(l, word, startx, starty, partialword):
    if partialword != word[:len(partialword)]:
        return 0
    elif len(partialword) == len(word):
        return 1
    wordcount = 0
    for i in range(2):
        for j in range(2):
            if (i == 0 and j == 0) or not in_range(starty + i, l) or not in_range(startx + j, l[i]):
                continue
            wordcount += _get_word_ocurrences_recur(l, word, startx + j, starty + i, partialword + l[starty + i][startx + j])
    return wordcount
    
def find_subset_which_sum_is_zero(l):
    s = _find_subset_which_sum_is_zero_recur(l, 0, [])
    return s

def _find_subset_which_sum_is_zero_recur(l, startindex, subset):
    if (startindex >= len(l)):
        s = _get_subset_which_sum_is_zero(subset)
        if (s != None):
            return s
        else:
            return        
    
    for i in range(startindex, len(l)):
        newsubset = subset[:]
        newsubset.append(l[i])
        swap(l, startindex, i)
        s = _find_subset_which_sum_is_zero_recur(l, startindex + 1, newsubset)
        if (s != None):
            return s
        swap(l, startindex, i)

def _get_subset_which_sum_is_zero(subset):
    for i in range(len(subset)):
        if (sum(subset) == 0):
            return subset
        subset[i] *= -1
    

def swap(list, p1, p2):
    tmp = list[p1]
    list[p1] = list[p2]
    list[p2] = tmp
    

    


