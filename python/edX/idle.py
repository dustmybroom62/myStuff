a = "Hello"
b = "world"
c = a + b
d = print(c)
print(d)

varA = "a"
varB = "b"

if (str == type(varA)) or (str == type(varB)):
    print("string involved")
elif varA > varB:
    print("bigger")
elif varA < varB:
    print("smaller")
else:
    print("equal")

print('-' * 30)

x = 2
while (x <= 10):
    print(x)
    x += 2
print("Goodbye!")

print('-' * 30)

x = 10
print("Hello!")
while (x > 0):
    print(x)
    x -= 2

print('-' * 30)

end = 6

total = 0
x = 0
while (x < end):
    total += (x + 1)
    x += 1
print(total)

print('-' * 30)

for x in range(2, 11, 2):
    print(x)
print("Goodbye!")

print('-' * 30)

print("Hello!")
for x in range(10, 0, -2):
    print(x)

print('-' * 30)

total = 0
for x in range(0, end):
    total += (x + 1)
print(total)

print('-' * 30)

num = 10
for num in range(5):
    print(num)
print(num)

print('-' * 30)

for variable in range(20):
    if variable % 4 == 0:
        print(variable)
    if variable % 16 == 0:
        print('Foo!')


print('-' * 30)

divisor = 2
for num in range(0, 10, 2):
    print(num/divisor) 


print('-' * 30)

school = 'Massachusetts Institute of Technology'
numVowels = 0
numCons = 0

for char in school:
    if char == 'a' or char == 'e' or char == 'i' \
       or char == 'o' or char == 'u':
        numVowels += 1
    elif char == 'o' or char == 'M':
        print(char)
    else:
        numCons -= 1

print('numVowels is: ' + str(numVowels))
print('numCons is: ' + str(numCons))

print('-' * 30)

s = 'azcbobobegghakl'
vowels = 'aeiou'
numVowels = 0
for letter in s:
    if letter in vowels:
        numVowels += 1
print("Number of vowels:", numVowels)

print('-' * 30)

s = 'azcbobobegghbobr'

bob = 'bob'
numBobs = 0
start = 0
while (start < len(s) - len(bob) + 1):
    if (bob == s[start : start + len(bob)]):
        numBobs += 1
    start += 1
print("Number of times bob occurs is:", numBobs)


print('-' * 30)

s = 'azcbobobegghakl'
longestStr = ''
currentStr = ''
for letter in s:
    if 0 == len(currentStr) or letter >= currentStr[-1]:
        currentStr += letter
        if len(longestStr) < len(currentStr):
            longestStr = currentStr
    else:
        currentStr = letter
print("Longest substring in alphabetical order is:", longestStr)

























