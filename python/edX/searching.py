#Let's implement a binary search using a loop! For now,
#our search will just return True if the item is found,
#False if it's not.

#Like our linear search, our binary search needs to
#parameters: a list to search, and an item to search for.

def binary_search_looping(searchList, searchTerm):

    #First, the list must be sorted.
    searchList.sort()

    #Now, each iteration of the loop, we want to narrow
    #down the part of the list to look at. So, we need to
    #keep track of the range we've narrowed down to so
    #far. Initially, that will be the entire list, from
    #the first index to the last.
    
    min = 0
    max = len(searchList) - 1
    
    #Now, we want to loop as long as our range has any
    #numbers left to investigate. As long as there is
    #more than one number between minimum and maximum,
    #we're not done searching.
    
    while min <= max:

        #We want to check the middle item of the
        #current range, which is the average of the
        #current minimum and maximum index. For
        #example, if min was 5 and max was 15, our
        #middle number would be at index 5. We'll
        #use floor division because indices must be
        #integers.
        currentMiddle = (min + max) // 2

        #If the term in the middle is the term we're
        #looking for, we're done!
        if searchList[currentMiddle] == searchTerm:
            return True

        #If not, we want to check if the term we're
        #looking for should come earlier or later.

        #If the term we're looking for is less than
        #the current middle, then search the first
        #half of the list:
        elif searchTerm < searchList[currentMiddle]:
            max = currentMiddle - 1

        #If the term we're looking for is greater
        #than the current middle, search the second
        #half of the list:
        else:
            min = currentMiddle + 1

        #Each iteration of the loop, one of three
        #things happens: the term is found, max
        #shrinks, or min grows. Eventually, either
        #the term will be found, or min will be
        #equal to max.

    #If the search term was found, this line will
    #never be reached because the return statement
    #will end the function. So, if we get this
    #far, then the search term was not found, and
    #we can return False.
    return False

#Let's try it out!
intlist = [12, 64, 23, 3, 57, 19, 1, 17, 51, 62]
print("23 is in intlist:", binary_search_looping(intlist, 23))
print("50 is in intlist:", binary_search_looping(intlist, 50))

#Want to see something else interesting? Because of
#the way Python handles types, this exact same
#function works for any sortable data type. Check
#it out with strings:
strlist = ["David", "Joshua", "Marguerite", "Jackie"]
print("David is in strlist:", binary_search_looping(strlist, "David"))
print("Lucy is in strlist:", binary_search_looping(strlist, "Lucy"))

#Or with dates!
from datetime import date
datelist = [date(1885, 10, 13), date(2014, 11, 29), date(2016, 11, 26)]
print("10/13/1885 is in datelist:", binary_search_looping(datelist, date(1885, 10, 13)))
print("11/28/2015 is in datelist:", binary_search_looping(datelist, date(2015, 11, 28)))



#Let's implement a binary search using recursion! For now,
#our search will just return True if the item is found,
#False if it's not.

#Like our linear search, our binary search needs to
#parameters: a list to search, and an item to search for.

def binary_search_recursive(searchList, searchTerm):

    #First, the list must be sorted.
    searchList.sort()

    #With each recursive call to binary_search_recursive, the size
    #of the list will be cut in half, rounding down. If
    #the search term is not found, then eventually an
    #empty list will be passed into binary_search_recursive. So,
    #if searchList is empty, we know that the search
    #term was not found, and we can return False. This
    #is the base case for the recursive binary_search_recursive.

    if len(searchList) == 0:
        return False

    #If there are still items in the list, then we want
    #to find if searchTerm is greater than, less than,
    #or equal to the middle term in the list. For that,
    #we need the index of the middle term.

    middle = len(searchList) // 2

    #First, the easy case: if it's the middle term, we
    #found it! Return True.
    if searchList[middle] == searchTerm:
        return True

    #If the search term is less than the middle term,
    #then repeat the search on the left half of the
    #list.
    elif searchTerm < searchList[middle]:
        return binary_search_recursive(searchList[:middle], searchTerm)

    #If the search term is greater than the middle
    #term, then repeat the search on the right half
    #of the list.
    else:
        return binary_search_recursive(searchList[middle + 1:], searchTerm)

    #As long as there are items to be searched, binary_search_recursive
    #will keep getting called on smaller and smaller lists,
    #until eventually the item is found or the list of possible
    #places it could be found is empty.


#Let's try it out!
intlist = [12, 64, 23, 3, 57, 19, 1, 17, 51, 62]
print("23 is in intlist:", binary_search_recursive(intlist, 23))
print("50 is in intlist:", binary_search_recursive(intlist, 50))

#Want to see something else interesting? Because of
#the way Python handles types, this exact same
#function works for any sortable data type. Check
#it out with strings:
strlist = ["David", "Joshua", "Marguerite", "Jackie"]
print("David is in strlist:", binary_search_recursive(strlist, "David"))
print("Lucy is in strlist:", binary_search_recursive(strlist, "Lucy"))

#Or with dates!
from datetime import date
datelist = [date(1885, 10, 13), date(2014, 11, 29), date(2016, 11, 26)]
print("10/13/1885 is in datelist:", binary_search_recursive(datelist, date(1885, 10, 13)))
print("11/28/2015 is in datelist:", binary_search_recursive(datelist, date(2015, 11, 28)))


def binary_search_year(searchList, searchTerm):
    searchList.sort()

    if len(searchList) == 0:
        return False

    middle = len(searchList) // 2

    if searchList[middle].year == searchTerm:
        return True
    elif searchTerm < searchList[middle].year:
        return binary_search_year(searchList[:middle], searchTerm)
    else:
        return binary_search_year(searchList[middle + 1:], searchTerm)


print("=" * 40)
print("binary_search_year")
listOfDates = [date(2016, 11, 26), date(2014, 11, 29),
               date(2008, 11, 29), date(2000, 11, 25),
               date(1999, 11, 27), date(1998, 11, 28),
               date(1990, 12, 1), date(1989, 12, 2),
               date(1985, 11, 30)]

print(binary_search_year(listOfDates, 2016))
print(binary_search_year(listOfDates, 2007))


