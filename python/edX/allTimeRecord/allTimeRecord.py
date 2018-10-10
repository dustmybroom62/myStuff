#Let's try out a sort of data analysis-style problem. In
#this problem, you're going to have access to a data set
#covering Georgia Tech's all-time football history. The data
#will be a CSV file, meaning that each line will be a comma-
#separated list of values. Each line will describe one game.
#The columns, from left-to-right, are:
#
# - Date: the date of the game, in Year-Month-Day format.
# - Opponent: the name of the opposing team
# - Location: Home, Away, or Neutral
# - Points For: Points scored by Georgia Tech
# - Points Against: Points scored by the opponent
#
#If Points For is greater than Points Against, then Georgia
#Tech won the game. If Points For is less than Points Against,
#then Georgia Tech lost the game. If the two are equal, then
#the game was a tie.
#
#You can see a subsection of this dataset in season2016.csv
#in the top left, but the actual dataset you'll be accessing
#here will have 1237 games.
#
#Write a function called all_time_record. all_time_record
#should take as input a string representing an opposing team
#name. It should return a string representing the all-time
#record between Georgia Tech and that opponent, in the form
#Wins-Losses-Ties. For example, Georgia Tech has beaten
#Clemson 51 times, lost 28 times, and tied 2 times. So,
#all_time_record("Clemson") would return the string "51-28-2".
#
#We have gone ahead and started the function and opened the
#file for you. The first line of the file are headers:
#Date,Opponent,Location,Points For,Points Against. After that,
#every line is a game.

# record_file = open('../resource/lib/public/georgia_tech_football.csv', 'r')
record_file = open('season2016.csv', 'r')

def all_time_record(opponent = None, location = None, years = None, months = None):
    recordTemplate = {'W': 0, "L": 0, "T": 0, 'us': 0, 'them': 0, 'games': 0}
    teams = {}
    record = recordTemplate.copy()
    firstGame = {'date': None, 'opponent': None}
    csv = record_file.readline()
    headers = True
    while csv:
        if headers:
            headers = False
        else:
            g = Game(csv)
            if firstGame['date'] is None or firstGame['date'] > g.Date:
                firstGame['date'] = g.Date; firstGame['opponent'] = g.Opponent
            r = g.result()
            addScore = True
            if opponent is not None:
                addScore = g.Opponent == opponent
            elif years is not None:
                addScore = g.Date.year in years
            elif months is not None:
                addScore = g.Date.month in months
            elif location is not None:
                addScore = g.Location == location
            if r is not None and addScore:
                if g.Opponent not in teams.keys():
                    teams[g.Opponent] = recordTemplate.copy()
                team = teams.get(g.Opponent)
                team['games'] += 1
                team[r] += 1; team['us'] += g.PointsFor; team['them'] += g.PointsAgainst
                record[r] += 1
                record['us'] += g.PointsFor; record['them'] += g.PointsAgainst
        csv = record_file.readline()
    record_file.close()
    if opponent is not None:
        return '%d-%d-%d us: %d them: %d firstOpponent: %s' % (record['W'], record['L'], record['T'], record['us'], record['them'], firstGame['opponent'])
    return teams

import datetime
class Game:
    def __init__(self, csvRecord = None):
        if csvRecord is None:
            self.Date = None
            self.Opponent = None
            self.Location = None
            self.PointsFor = 0
            self.PointsAgainst = 0
            self.initialized = False
        else:
            self.setFromCSV(csvRecord)

    def setFromCSV(self, csvRecord):
        values = csvRecord.split(',')
        if len(values) > 0:
            self.Date = datetime.datetime.strptime(values[0], '%Y-%m-%d').date()
        if len(values) > 1:
            self.Opponent = values[1]
        if len(values) > 2:
            self.Location = values[2]
        if len(values) > 3:
            self.PointsFor = int(values[3])
        if len(values) > 4:
            self.PointsAgainst = int(values[4])
        self.initialized = True

    def result(self):
        if not self.initialized:
            return None
        if self.PointsFor > self.PointsAgainst:
            return "W"
        if self.PointsAgainst > self.PointsFor:
            return "L"
        return "T"

#Below are some lines of code that will test your function.
#You can change the value of the variable(s) to test your
#function with different inputs.
#
#If your function works correctly, this will originally
#print: 51-28-2, 51-33-1, and 29-21-3, each on a separate
#line.
# print(all_time_record("Clemson"))
# print(all_time_record("Duke"))
# print(all_time_record("North Carolina"))
# print(all_time_record(years=range(2015, 2016)))
results = all_time_record()
# print(results)
max_us = {'name': None, 'pts': 0}; min_us = {'name': None, 'pts': 0}
scoreless = {}
highDiff = {'name': None, 'pts': 0}
highAvgDiff = {'name': None, 'pts': 0}
for k in results.keys():
    us = results[k]['us']
    if us > max_us['pts']:
        max_us['pts'] = us; max_us['name'] = k
    if min_us['name'] is None or us < min_us['pts']:
        min_us['pts'] = us; min_us['name'] = k;
    if results[k]['them'] == 0:
        scoreless[k] = 0
    diff = results[k]['us'] - results[k]['them']
    if diff > highDiff['pts']:
        highDiff['pts'] = diff; highDiff['name'] = k
    games = results[k]['games']
    if games >= 5:
        avgDiff = diff / games
        if avgDiff > highAvgDiff['pts']:
            highAvgDiff['pts'] = avgDiff; highAvgDiff['name'] = k

print('highAvgDiff', highAvgDiff)
# print('highDiff', highDiff)
# print('scoreless', scoreless)
# print('min_us', min_us)
# print('max_us', max_us)






