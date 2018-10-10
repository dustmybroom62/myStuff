#One of the early common methods for encrypting text was the
#Playfair cipher. You can read more about the Playfair cipher
#here: https://en.wikipedia.org/wiki/Playfair_cipher
#
#The Playfair cipher starts with a 5x5 matrix of letters,
#such as this one:
#
# D A V I O
# Y N E R B
# C F G H K
# L M P Q S
# T U W X Z
#
#To fit the 26-letter alphabet into 25 letters, I and J are
#merged into one letter. When decrypting the message, it's
#relatively easy to tell from context whether a letter is
#meant to be an i or a j.
#
#To encrypt a message, we first remove all non-letters and
#convert the entire message to the same case. Then, we break
#the message into pairs. For example, imagine we wanted to
#encrypt the message "PS. Hello, worlds". First, we could
#convert it to PSHELLOWORLDS, and then break it into letter
#pairs: PS HE LL OW OR LD S. If there is an odd number of
#characters, we add X to the end.
#
#Then, for each pair of letters, we locate both letters in
#the cipher square. There are four possible orientations
#for the pair of letters: they could be in different rows
#and columns (the "rectangle" case), they could be in the
#same row but different columns (the "row" case), they could
#be in the same column but different rows (the "column"
#case), or they could be the same letter (the "same" case).
#
#Looking at the message PS HE LL OW OR LD SX:
#
# - PS is the Row case: P and S are in the same row.
# - HE is the Rectangle case: H and E are in different rows
#   and columns of the square.
# - LD is the Column case: L and D are in the same column.
# - LL is the Same case as it's two of the same letter.
#
#For the Same case, we replace the second letter in the pair
#with X, and then proceed as normal. When decrypting, it
#would be easy to see the our result was not intended to be
#PS HELXO WORLDSX, and we would thus assume the X is meant to
#repeat the previous letter, becoming PS HELLO WORLDSX.
#
#What we do for each of the other three cases is different:
#
# - For the Rectangle case, we replace each letter with
#   the letter in the same row, but the other letter's
#   column. For example, we would replace HE with GR:
#   G is in the same row as H but the same column as E,
#   and R is in the same row as E but the same column as
#   H. For another example, CS would become KL: K is in
#   C's row but S's column, and L is in C's column but S's
#   row.
# - For the Row case, we pick the letter to the right of
#   each letter, wrapping around the end of the row if we
#   need to. PS becomes QL: Q is to the right of P, and L
#   is to the right of S if we wrap around the end of the
#   row.
# - For the Column case, we pick the letter below each
#   letter, wrapping around if necessary. LD becomes TY:
#   T is below L and Y is below D.
#
#We would then return the resultant encrypted message.
#
#Decrypting a message is essentially the same process.
#You would use the exact same cipher and process, except
#for the Row and Column cases, you would shift left and up
#instead of right and down.
#
#Write two methods: encrypt and decrypt. encrypt should
#take as input a string, and return an encrypted version
#of it according to the rules above.
#
#To encrypt the string, you would:
#
# - Convert the string to uppercase.
# - Replace all Js with Is.
# - Remove all non-letter characters.
# - Add an X to the end if the length if odd.
# - Break the string into character pairs.
# - Replace the second letter of any same-character
#   pair with X (e.g. LL -> LX).
# - Encrypt it.
#
#decrypt should, in turn, take as input a string and
#return the unencrypted version, just undoing the last
#step. You don't need to worry about Js and Is, duplicate
#letters, or odd numbers of characters in decrypt.
#
#For example:
#
# encrypt("PS. Hello, world") -> "QLGRQTVZIBTYQZ"
# decrypt("QLGRQTVZIBTYQZ") -> "PSHELXOWORLDSX"
#
#HINT: You might find it easier if you implement some
#helper functions, like a find_letter function that
#returns the row and column of a letter in the cipher.
#
#HINT 2: Once you've written encrypt, decrypt should
#be trivial: try to think of how you can modify encrypt
#to serve as decrypt.
#
#To make this easier, we've gone ahead and created the
#cipher as a 2D tuple for you:
CIPHER = (("D", "A", "V", "I", "O"),
          ("Y", "N", "E", "R", "B"),
          ("C", "F", "G", "H", "K"),
          ("L", "M", "P", "Q", "S"),
          ("T", "U", "W", "X", "Z"))



#Add your code here!
def findLetter(cipherTuple, letter):
    for r in range(len(cipherTuple)):
        for c in range(len(cipherTuple[r])):
            if letter == cipherTuple[r][c]:
                return {'row': r, 'col': c}
    return None

def doRectangle(cipherTuple, pos1, pos2):
    return cipherTuple[pos1['row']][pos2['col']] + cipherTuple[pos2['row']][pos1['col']]

def doSameRow(cipherTuple, pos1, pos2, direct):
    row = cipherTuple[pos1['row']]
    return row[(pos1['col'] + direct + len(row)) % len(row)] + row[(pos2['col'] + direct + len(row)) % len(row)]

def doSameCol(cipherTuple, pos1, pos2, direct):
    row1 = cipherTuple[(pos1['row'] + direct + len(cipherTuple)) % len(cipherTuple)]
    row2 = cipherTuple[(pos2['row'] + direct + len(cipherTuple)) % len(cipherTuple)]
    return row1[pos1['col']] + row2[pos2['col']]

def processString(cipherTuple, theString, direct):
    result = ''
    for i in range(0, len(theString), 2):
        pair = theString[i: i + 2]
        c1 = pair[0]; c2 = pair[1]
        if c1 == c2:
            c2 = 'X' # Same Case
        pos1 = findLetter(cipherTuple, c1)
        pos2 = findLetter(cipherTuple, c2)
        if pos1['row'] == pos2['row']:
            result += doSameRow(cipherTuple, pos1, pos2, direct)
        elif pos1['col'] == pos2['col']:
            result += doSameCol(cipherTuple, pos1, pos2, direct)
        else:
            result += doRectangle(cipherTuple, pos1, pos2)
    return result

import string

def encrypt(s):
    f = ''
    w = s.upper()
    for c in w:
        if c in string.ascii_uppercase:
            if 'J' == c:
                f += 'I'
            else:
                f += c
    if 0 != len(f) % 2:
        f += 'X'
    return processString(CIPHER, f, 1)

def decrypt(s):
    return processString(CIPHER, s, -1)

#Below are some lines of code that will test your function.
#You can change the value of the variable(s) to test your
#function with different inputs.
#
#If your function works correctly, this will originally
#       PSHELXOWORLDSX
#       QLGRLXVZIBTYQZ
#print: QLGRQTVZIBTYQZ, then PSHELXOWORLDSX
#print: QLGRQTVZIBTYQZ, then PSHELXOWORLDSX
#       QLGRQTVZIBTY
# print(processString(CIPHER, 'QLGRQTVZIBTYQZ', -1))
print(encrypt("PS. Hello, worlds"))
print(decrypt("QLGRQTVZIBTYQZ"))
print(encrypt("maharaja Blythe region holystone pupae"))
