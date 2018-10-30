def print_without_vowels(s):
    '''
    s: the string to convert
    Finds a version of s without vowels and whose characters appear in the 
    same order they appear in s. Prints this version of s.
    Does not return anything
    '''
    # Your code here
    vowels = 'aeiouAEIOU'
    for c in s:
        if c not in vowels:
            print(c, end='')
    print()
    

# print_without_vowels('A man without a country')

def genPrimes():
    prev = []
    x = 2
    while True:
        prev.append(x)
        yield x
        found = False
        while not found:
            x += 1
            found = True
            for p in prev:
                if 0 == x % p:
                    found = False
                    break

def primes_list(N):
    prime = genPrimes()
    primes = []
    p = prime.__next__()
    while p <= N:
        primes.append(p)
        p = prime.__next__()
    return primes

    
# print(primes_list(25))

def cipher(map_from, map_to, code):
    """ map_from, map_to: strings where each contain 
                          N unique lowercase letters. 
        code: string (assume it only contains letters also in map_from)
        Returns a tuple of (key_code, decoded).
        key_code is a dictionary with N keys mapping str to str where 
        each key is a letter in map_from at index i and the corresponding 
        value is the letter in map_to at index i. 
        decoded is a string that contains the decoded version 
        of code using the key_code mapping. """
    # Your code here
    d = {}
    for i in range(len(map_from)):
        d[map_from[i]] = map_to[i]
    
    s = ''
    for c in code:
        s += d[c]
    return (d, s)


# print(cipher("abcd", "dcba", "dab"))

class Person(object):     
    def __init__(self, name):         
        self.name = name     
    def say(self, stuff):         
        return self.name + ' says: ' + stuff     
    def __str__(self):         
        return self.name  

class Lecturer(Person):     
    def lecture(self, stuff):         
        return 'I believe that ' + Person.say(self, stuff)  

class Professor(Lecturer): 
    def say(self, stuff): 
        return self.name + ' says: ' + self.lecture(stuff)

class ArrogantProfessor(Person): 
    def lecture(self, stuff): 
        return 'It is obvious that ' + Person.say(self, stuff)
    def say(self, stuff):
        return Person.say(self, self.lecture(stuff))


# e = Person('eric') 
# le = Lecturer('eric') 
# pe = Professor('eric') 
# ae = ArrogantProfessor('eric')
# #region a
# print(e.say('the sky is blue'))
# print('eric says: the sky is blue')

# print(le.say('the sky is blue'))
# print('eric says: the sky is blue')

# print(le.lecture('the sky is blue'))
# print('I believe that eric says: the sky is blue')

# print(pe.say('the sky is blue'))
# print('eric says: I believe that eric says: the sky is blue')

# print(pe.lecture('the sky is blue'))
# print('I believe that eric says: the sky is blue')
# #endregion a
# print(ae.say('the sky is blue'))
# print('eric says: It is obvious that eric says: the sky is blue')

# print(ae.lecture('the sky is blue'))
# print('It is obvious that eric says: the sky is blue')

class Container(object):
    """ Holds hashable objects. Objects may occur 0 or more times """
    def __init__(self):
        """ Creates a new container with no objects in it. I.e., any object 
            occurs 0 times in self. """
        self.vals = {}
    def insert(self, e):
        """ assumes e is hashable
            Increases the number times e occurs in self by 1. """
        try:
            self.vals[e] += 1
        except:
            self.vals[e] = 1
    def __str__(self):
        s = ""
        for i in sorted(self.vals.keys()):
            if self.vals[i] != 0:
                s += str(i)+":"+str(self.vals[i])+"\n"
        return s


class Bag(Container):
    def remove(self, e):
        """ assumes e is hashable
            If e occurs in self, reduces the number of 
            times it occurs in self by 1. Otherwise does nothing. """
        if e in self.vals:
            self.vals[e] -= 1

    def count(self, e):
        """ assumes e is hashable
            Returns the number of times e occurs in self. """
        if e in self.vals:
            return self.vals[e]
        return 0

print()
d1 = Bag()
d1.insert(4)
d1.insert(4)
print(d1)
d1.remove(2)
print(d1)

d1 = Bag()
d1.insert(4)
d1.insert(4)
d1.insert(4)
print(d1.count(2))
print(d1.count(4))
