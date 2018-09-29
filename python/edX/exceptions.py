#define the simple_divide function here
def simple_divide(item, denom):
    result = 0
    try:
        result = item / denom
    except ZeroDivisionError:
        result = 0
    return result


def fancy_divide(list_of_numbers, index):
   denom = list_of_numbers[index]
   return [simple_divide(item, denom) for item in list_of_numbers]


def displayHand(hand):
    """
    Displays the letters currently in the hand.

    For example:
    >>> displayHand({'a':1, 'x':2, 'l':3, 'e':1})
    Should print out something like:
       a x x l l l e
    The order of the letters is unimportant.

    hand: dictionary (string -> int)
    """
    x = ''
    for letter in hand.keys():
        x += (letter + ' ') * hand[letter]
    print(x)
    #    for j in range(hand[letter]):
    #        print(letter, end=" ")       # print all on the same line
    print()                             # print an empty line


def getFrequencyDict(sequence):
    """
    Returns a dictionary where the keys are elements of the sequence
    and the values are integer counts, for the number of times that
    an element is repeated in the sequence.

    sequence: string or list
    return: dictionary
    """
    # freqs: dictionary (element_type -> int)
    freq = {}
    for x in sequence:
        freq[x] = freq.get(x, 0) + 1
    return freq


def updateHand(hand, word):
    """
    Assumes that 'hand' has all the letters in word.
    In other words, this assumes that however many times
    a letter appears in 'word', 'hand' has at least as
    many of that letter in it. 

    Updates the hand: uses up the letters in the given word
    and returns the new hand, without those letters in it.

    Has no side effects: does not modify hand.

    word: string
    hand: dictionary (string -> int)    
    returns: dictionary (string -> int)
    """
    newHand = {}
    for c in hand.keys():
        newHand[c] = hand[c] - word.count(c)
    return newHand


def mutateHand(hand, word):
    for c in hand.keys():
        hand[c] -= word.count(c)
    return hand


hand = {'a':1, 'x':2, 'l':3, 'e':1}
displayHand(hand)
#  displayHand( updateHand(hand , 'lax' ) )
displayHand( mutateHand(hand, 'lax') )
displayHand(hand)

#  print( fancy_divide([0, 2, 4], 3) )

