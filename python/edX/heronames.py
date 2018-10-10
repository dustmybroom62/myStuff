
def generate_name(filename, personName):
    try:
        f = open(filename)
        heroNames = f.readlines()
    except FileNotFoundError:
        print("FileNotFoundError")
        return None
    except:
        print("something else went wrong")
        return None
    finally:
        if f is not None:
            f.close()

    personNames = personName.split(" ")
    firstInitial = personNames[0][0].upper()
    lastInitial = personNames[-1][0].upper()

    offset = 0
    base = ord('A')
    heroName01 = heroNames[(ord(firstInitial) - base) + offset].strip()
    offset += 26
    heroName02 = heroNames[(ord(lastInitial) - base) + offset].strip()
    return heroName01 + " " + heroName02


#If your function works correctly, this will originally
#print: Captain Hawk, Doctor Yellow Jacket, and Moon Moon,
#each on their own line.
print(generate_name("heronames.txt", "Addison Zook"))
print(generate_name("heronames.txt", "Uma Irwin"))
print(generate_name("heronames.txt", "David Joyner"))
