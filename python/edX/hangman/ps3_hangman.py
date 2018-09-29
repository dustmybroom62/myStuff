# Hangman game
#

# -----------------------------------
# Helper code
# You don't need to understand this helper code,
# but you will have to know how to use the functions
# (so be sure to read the docstrings!)

import random

WORDLIST_FILENAME = "words.txt"

def loadWords():
    """
    Returns a list of valid words. Words are strings of lowercase letters.
    
    Depending on the size of the word list, this function may
    take a while to finish.
    """
    print("Loading word list from file...")
    # inFile: file
    inFile = open(WORDLIST_FILENAME, 'r')
    # line: string
    line = inFile.readline()
    inFile.close()
    # wordlist: list of strings
    wordlist = line.split()
    print("  ", len(wordlist), "words loaded.")
    return wordlist

def chooseWord(wordlist):
    """
    wordlist (list): list of words (strings)

    Returns a word from wordlist at random
    """
    return random.choice(wordlist)

# end of helper code
# -----------------------------------

# Load the list of words into the variable wordlist
# so that it can be accessed from anywhere in the program
wordlist = loadWords()

def isWordGuessed(secretWord, lettersGuessed):
    '''
    secretWord: string, the word the user is guessing
    lettersGuessed: list, what letters have been guessed so far
    returns: boolean, True if all the letters of secretWord are in lettersGuessed;
      False otherwise
    '''
    # FILL IN YOUR CODE HERE...
    for c in secretWord:
        if c not in lettersGuessed:
            return False
    return True



def getGuessedWord(secretWord, lettersGuessed):
    '''
    secretWord: string, the word the user is guessing
    lettersGuessed: list, what letters have been guessed so far
    returns: string, comprised of letters and underscores that represents
      what letters in secretWord have been guessed so far.
    '''
    # FILL IN YOUR CODE HERE...
    result = ''
    for c in secretWord:
        if c in lettersGuessed:
            result += c
        else:
            result += '_ '
    return result


#  a2z = ''.join(list(map(chr, list(range(ord('a'), 26 + ord('a'))))))
a2z = ''.join(chr(i + ord('a')) for i in range(26))
#  import string
#  a2z = string.ascii_lowercase


def getAvailableLetters(lettersGuessed):
    '''
    lettersGuessed: list, what letters have been guessed so far
    returns: string, comprised of letters that represents what letters have not
      yet been guessed.
    '''
    # FILL IN YOUR CODE HERE...
    global a2z
    result = ''
    for c in a2z:
        if c not in lettersGuessed:
            result += c
    return result


def printIntro(secretWord):
    print('Welcome to the game, Hangman!')
    print('I am thinking of a word that is', len(secretWord), 'letters long.')


def printSeperator():
    print('-------------')


def beginTurn(guessesLeft, lettersGuessed):
    printSeperator()
    print('You have', guessesLeft, 'guesses left.')
    print('Available letters:', getAvailableLetters(lettersGuessed))


def getGuess():
    return input('Please guess a letter: ')


def scrubInput(g):
    global a2z
    if 1 != len(g):
        return False
    s = g.lower()
    if s in a2z:
        return s
    return False


def showWinner():
    printSeperator()
    print("Congratulations, you won!")


def showLoser(secretWord):
    printSeperator()
    print('Sorry, you ran out of guesses. The word was', secretWord)


def hangman(secretWord):
    '''
    secretWord: string, the secret word to guess.

    Starts up an interactive game of Hangman.

    * At the start of the game, let the user know how many 
      letters the secretWord contains.

    * Ask the user to supply one guess (i.e. letter) per round.

    * The user should receive feedback immediately after each guess 
      about whether their guess appears in the computers word.

    * After each round, you should also display to the user the 
      partially guessed word so far, as well as letters that the 
      user has not yet guessed.

    Follows the other limitations detailed in the problem write-up.
    '''
    # FILL IN YOUR CODE HERE...
    guessesLeft = 8
    lettersGuessed = []
    gameOver = False
    printIntro(secretWord)
    while not gameOver:
        beginTurn(guessesLeft, lettersGuessed)
        guess = scrubInput(getGuess())
        if not guess:
            print('Invalid Input: single letters only.')
        elif guess in lettersGuessed:
            print("Oops! You've already guessed that letter:", getGuessedWord(secretWord, lettersGuessed))
        else:
            lettersGuessed.append(guess)
            if guess in secretWord:
                print('Good guess:', getGuessedWord(secretWord, lettersGuessed))
                if isWordGuessed(secretWord, lettersGuessed):
                    gameOver = True
                    showWinner()
            else:
                guessesLeft -= 1
                print('Oops! That letter is not in my word:', getGuessedWord(secretWord, lettersGuessed))
                if (1 > guessesLeft):
                    gameOver = True
                    showLoser(secretWord)









# When you've completed your hangman function, uncomment these two lines
# and run this file to test! (hint: you might want to pick your own
# secretWord while you're testing)

secretWord = chooseWord(wordlist).lower()
# secretWord = 'baby'
hangman(secretWord)
