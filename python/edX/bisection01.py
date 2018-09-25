low = 0
high = 100
print("Please think of a number between 0 and 100!")
gameOver = False
while (not gameOver):
    guess = (high + low) // 2
    while (True):
        print("Is your secret number " + str(guess) + "?")
        feedback = input("Enter 'h' to indicate the guess is too high. Enter 'l' to indicate the guess is too low. Enter 'c' to indicate I guessed correctly. ")
        if ('l' == feedback):
            low = guess
            break
        if ('h' == feedback):
            high = guess
            break
        if ('c' == feedback):
            print("Game over. Your secret number was:", guess)
            gameOver = True
            break
        print("Sorry, I did not understand your input.")
