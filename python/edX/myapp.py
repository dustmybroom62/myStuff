import math

def iterPower(base, exp):
    '''
    base: int or float.
    exp: int >= 0

    returns: int or float, base^exp
    '''
    # Your code here
    result = 1
    for n in range(0, exp):
        result *= base
    return result


def recurPower(base, exp):
    '''
    base: int or float.
    exp: int >= 0

    returns: int or float, base^exp
    '''
    # Your code here
    if exp == 0:
        return 1
    return base * (recurPower(base, exp - 1))


def gcdIter(a, b):
    '''
    a, b: positive integers

    returns: a positive integer, the greatest common divisor of a & b.
    '''
    # Your code here
    test = a
    if b < a:
        test = b
    while (test > 1) and (0 != a % test + b % test):
        test -= 1
    return test


def gcdRecur(a, b):
    '''
    a, b: positive integers

    returns: a positive integer, the greatest common divisor of a & b.
    '''
    # Your code here
    if (b == 0):
        return a
    return gcdRecur(b, a % b)


def isIn(char, aStr):
    '''
    char: a single character
    aStr: an alphabetized string

    returns: True if char is in aStr; False otherwise
    '''
    # Your code here
    strLen = len(aStr)
    if 0 == strLen:
        return False
    if 1 == strLen:
        return char == aStr
    testPos = strLen // 2
    testChar = aStr[testPos]
    if char == testChar:
        return True
    print(testChar)
    if char > testChar:
        return isIn(char, aStr[testPos + 1:])
    return isIn(char, aStr[:testPos])


def polysum(n, s):
    """
    :param n: value of n
    :param s: value of s
    :return: the polysum for n, s
    """
    area = (0.25 * n * s**2) / math.tan(math.pi / n)
    perim = s * n
    return round(area + perim ** 2, 4)


def oddTuples(aTup):
    '''
    aTup: a tuple

    returns: tuple, every other element of aTup.
    '''
    result = ()
    ctr = 0
    for t in aTup:
        ctr += 1
        if 1 == ctr % 2:
            result += (t,)

    return result


def biggest(aDict):
    '''
    aDict: A dictionary, where all the values are lists.

    returns: The key with the largest number of values associated with it
    '''
    # Your Code Here
    biggestKey = None
    longestCount = 0
    for k in aDict:
        count = len(aDict[k])
        if count > longestCount:
            biggestKey = k
            longestCount = count
    return biggestKey


animals = { 'a': ['aardvark'], 'b': ['baboon'], 'c': ['coati']}

animals['d'] = ['donkey']
animals['d'].append('dog')
animals['d'].append('dingo')

print(biggest(animals))
print(biggest({'a': []}))
print(biggest({}))

# tup = ('I', 'am', 'a', 'test', 'tuple')
# print(oddTuples(tup))


# print(polysum(15, 4))

# s = 'abcdefg'
# x = 'd'
# print(isIn(x, s))



# x = 9
# y = 12
# print('iter', gcdIter(x, y))
# print('recur', gcdRecur(x, y))

# print('**', x ** y)
#
# print('iter', iterPower(x, y))
# print()
# print('recur', recurPower(x, y))


# str1 = 'exterminate!'
# str2 = 'number one - the larch'
# # print(str2.find('!'))
# print(str2.replace('one', 'seven'))
# print(str2.index('n'))

# basecapturerate = 0.33
# cpmultiplier = 0.75
# ball, curve, berry, throw, medal = 1, 1, 1, 1, 1
# baserate = (1 - (basecapturerate / (2 * cpmultiplier)))
# multipliers = ball * curve * berry * throw * medal
# probability = 1 - baserate ** multipliers
# print(round(probability, 2))


# from lib import mylib
#
# x = 3 + 7
# print('hello world!')
#
# mylib.myfunc('so', msg2='there')

# # can_afford = True
# can_afford = True
# # destination_is_safe = True
# destination_is_safe = True
# # educational_value = True
# educational_value = True
# # relatives_nearby = True
# relatives_nearby = False
# # is_international = True
# is_international = False
# # have_passport = True
# have_passport = True
# # afraid_to_fly = True
# afraid_to_fly = False
# # have_a_car = True
# have_a_car = False
# # is_a_beach = True
# is_a_beach = False
# # is_warm = False
# is_warm = True
# # has_skiing = True
# has_skiing = False
# # is_a_city = True
# is_a_city = True
# # is_off_peak = True
# is_off_peak = True
# # has_attraction = False
# has_attraction = False

# is_a_beach = False
# has_skiing = True
# has_attraction = True
# is_international = False
# have_a_car = False
# is_off_peak = False
# have_passport = False
# relatives_nearby = False
# destination_is_safe = True
# educational_value = True
# can_afford = True
# is_a_city = True
# is_warm = True
# afraid_to_fly = False

# cond1 = (can_afford and destination_is_safe) or \
#         (not can_afford and destination_is_safe and (educational_value or relatives_nearby))
# print("cond1:", cond1)
#
# cond2 = (is_international and have_passport and not afraid_to_fly) or \
#         (not is_international and (have_a_car or not afraid_to_fly))
# print("cond2:", cond2)
#
# canBeach = is_warm
# canSki = not is_warm
# canCity = (is_off_peak or has_attraction)
#
# cond3 = (is_a_beach and canBeach) or \
#         (has_skiing and canSki) or \
#         (is_a_city and canCity)
# print("cond3:", cond3)
#
# print(cond1 and cond2 and cond3)

