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

prime = genPrimes()
for x in range(25):
    print(prime.__next__(), end=', ')
