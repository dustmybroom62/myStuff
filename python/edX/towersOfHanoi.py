import datetime

def move(n, source, target, auxiliary):
    count['deep'] += 1
    if count['deep'] > count['maxdeep']:
        count['maxdeep'] = count['deep']
    if n > 0:
        # move n - 1 disks from source to auxiliary, so they are out of the way
        move(n - 1, source, auxiliary, target)
        # move the nth disk from source to target
        target.append(source.pop())
        count['val'] += 1
        # Display our progress
        if 0 == count['val'] % print_every:
            print(A, B, C, '%s moves: %d' % (sep, count['val']), sep = '\n')
            now = datetime.datetime.now()
            print(sep, 'deep:', count['deep'], 'time:', now, 'elapsed:', now - count['start'])
        # move the n - 1 disks that we left on auxiliary onto target
        move(n - 1, auxiliary, target, source)
    count['deep'] -= 1

A = []; B = []; C = []; count = {'val' : 0, 'deep' : 0, 'maxdeep' : 0}
sep = '##############'
def solveTowers(numDisks):
    # set up tower A
    [A.append(i) for i in range(numDisks, 0, -1)]
    print(A, B, C, '%s moves: %d' % (sep, count['val']), sep = '\n')
    # initiate call from source A to target C with auxiliary B
    move(numDisks, A, C, B)
    print(A, B, C, sep = '\n')
    print('max deep:', count['maxdeep'])


towers = 20
print_every = 1
if towers > 10:
    print_every = 2 ** (towers - (towers // 10) - 1)

count['start'] = datetime.datetime.now()
print(count['start'])
solveTowers(towers)
end = datetime.datetime.now()
print('end time:', end)
print('elapsed time: ', end - count['start'])
