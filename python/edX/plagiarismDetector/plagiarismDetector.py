#A common problem in academic settings is plagiarism
#detection. Fortunately, software can make this pretty easy!
#
#In this problem, you'll be given two files with text in
#them. Write a function called check_plagiarism with two
#parameters, each representing a filename. The function
#should find if there are any instances of 5 or more
#consecutive words appearing in both files. If there are,
#return the longest such string of words (in terms of number
#of words, not length of the string). If there are not,
#return the boolean False.
#
#For simplicity, the files will be lower-case text and spaces
#only: there will be no punctuation, upper-case text, or
#line breaks.
#
#We've given you three files to experiment with. file_1.txt
#and file_2.txt share a series of 5 words: we would expect
#check_plagiarism("file_1.txt", "file_2.txt") to return the
#string "if i go crazy then". file_1.txt and file_3.txt
#share two series of 5 words, and one series of 11 words:
#we would expect check_plagiarism("file_1.txt", "file_3.txt")
#to return the string "i left my body lying somewhere in the
#sands of time". file_2.txt and file_3.txt do not share any
#text, so we would expect check_plagiarism("file_2.txt",
#"file_3.txt") to return the boolean False.
#
#Be careful: there are a lot of ways to do this problem, but
#some would be massively time- or memory-intensive. If you
#get a MemoryError, it means that your solution requires
#storing too much in memory for the code to ever run to
#completion. If you get a message that says "KILLED", it
#means your solution takes too long to run.


#Add your code here!
def buildIndex(lst):
    result = {}
    for i in range(len(lst)):
        w = lst[i]
        result[w] = result.get(lst[i], [])
        result[w].append(i)
    return result


def longest_match(lst, idx1, idx2):
    longList = []; curList = []
    maxPos = len(lst)
    for word in idx1.keys():
        if word not in idx2.keys():
            continue
        if 3 > len(word):
            continue
        # loop thru indexes for word
        for start_1 in idx1[word]:
            for start_2 in idx2[word]:
                pos1 = start_1
                pos2 = start_2
                curList.clear()
                while pos1 >= 0:
                    if pos2 in idx2.get(lst[pos1], []):
                        curList.insert(0, lst[pos1])
                    else:
                        break
                    pos1 -= 1; pos2 -= 1
                pos1 = start_1 + 1; pos2 = start_2 + 1
                while pos1 < maxPos:
                    if pos2 in idx2.get(lst[pos1], []):
                        curList.append(lst[pos1])
                    else:
                        break
                    pos1 += 1; pos2 += 1
                if len(curList) > len(longList):
                    longList.clear()
                    longList = curList[:]
    return longList


def check_plagiarism(filename_1, filename_2):
    try:
        f1 = open(filename_1)
        list_1 = list(f1.read().split(' '))
    finally:
        if f1 is not None:
            f1.close()
    index_1 = buildIndex(list_1)

    try:
        f2 = open(filename_2)
        list_2 = list(f2.read().split(' '))
    finally:
        if f2 is not None:
            f2.close()
    index_2 = buildIndex(list_2)
    result = None
    if len(list_1) < len(list_2):
        list_2.clear()
        result = longest_match(list_1, index_1, index_2)
    else:
        list_1.clear()
        result = longest_match(list_2, index_2, index_1)
    if len(result) < 5:
        return False
    return ' '.join(result)

#Below are some lines of code that will test your function.
#You can change the value of the variable(s) to test your
#function with different inputs.
#
#If your function works correctly, this will originally
#print:
#if i go crazy then
#i left my body lying somewhere in the sands of time
#False
print(check_plagiarism("file_1.txt", "file_2.txt"))
print(check_plagiarism("file_1.txt", "file_3.txt"))
print(check_plagiarism("file_2.txt", "file_3.txt"))




