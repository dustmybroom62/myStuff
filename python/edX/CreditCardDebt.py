balance = 320000
annualInterestRate = 0.2
monthlyPaymentRate = 0.04


def remainingBalance(balanceIn, air, mpr, months):
    """
    :param balanceIn: the starting balance
    :param air: annual interest rate as decimal e.g. 0.18 for 18%
    :param mpr: monthly payment rate as decimal e.g. 0.02 for 2%
    :param months: number of months as integer
    :return: remaining balance after specified number of months to 2 decimals
    """
    if 1 > months:
        return balanceIn

    mir = air / 12  # monthly interest rate
    payment = balanceIn * mpr
    newBalance = balanceIn - payment
    if 0.0 >= newBalance:
        return newBalance

    newBalance += (newBalance * mir)
    return remainingBalance(newBalance, air, mpr, months - 1)


def remainingBalanceFixedPayment(balance, air, payment, months):
    """
    :param balance: the starting balance
    :param air: annual interest rate as decimal e.g. 0.18 for 18%
    :param payment: monthly payment as integer (must be multiple of 10)
    :param months: number of months as integer
    :return: remaining balance after specified number of months to 2 decimals
    """
    if 1 > months:
        return balance

    mir = air / 12  # monthly interest rate
    newBalance = balance - payment
    if 0.0 >= newBalance:
        return newBalance

    newBalance += (newBalance * mir)
    return remainingBalanceFixedPayment(newBalance, air, payment, months - 1)


def minFixedPayment(balance, air, months):
    """
    :param balance: the balance to pay off
    :param air: annual interest rate as decimal e.g. 0.18 for 18%
    :param months: max number of months to pay off balance as integer
    :return: minimum fixed monthly payment (as multiple of 10) as integer
    """
    epsilon = 0.01
    upperBound = (balance * (1 + (air / 12)) ** months) / 12
    lowerBound = balance / 12
    lowestPayment = balance

    testBalance = 0.0
    while ((upperBound - lowerBound) > epsilon):
        payment = (lowerBound + upperBound) / 2
        testBalance = remainingBalanceFixedPayment(balance, air, payment, months)

        if (0 < testBalance):
            lowerBound = payment
        elif (0 > testBalance):
            lowestPayment = payment
            upperBound = payment
        else:
            lowestPayment = payment
            break

    return round(lowestPayment, 2)


#  print('Remaining balance:', round(remainingBalance(42.0, 0.2, 0.04, 12), 2))

print('Lowest Payment:', minFixedPayment(balance, annualInterestRate, 12))

print()
#  print('Lowest Payment:', minFixedPayment(999999, 0.18, 12))
