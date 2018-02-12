# WordSearchKata
Word Search Kata for Pillar Technology.

Word Search Puzzle solver developed in C# using NUnit Framework for TDD in Visual Studio. 
The program takes in a file containing a word search puzzle along with the words to find.
It then searches for all the words in eight directions, horizontal, vertical, diagonally descending, diagonally ascending, and reverse on all axes.

Github's official .gitignore for Visual Studios was used.

# Input
Program name is a command line program called PuzzleSolverProject.exe. It takes in a single input, which is a text file.

## Usage
PuzzleSolverProject.exe [filePath+fileName]

## Example Input File
```
KIRK,KHAN
K,R,I,K
E,M,H,P
X,A,D,M
N,C,H,U
```

## File Format
The text file must have a strict CSV format. 
### Words
First row must contain a CSV list of words to seach. Words must be only letters, case matters.
Repeated words not allowed and words must be in puzzle.
###Letters
Second row onwards muct contain a CSV list of letters. No symbol or punctuation is allowed, case matters.
There must be an equal amount of letters in each row to the letters in each column, making a perfect square puzzle.
Minimum puzzle dimensions is a 2x2 puzzle. The maximun is the system's max capacity for a Char[,].

Letters must include words from first row exactly and only once. 
It is possible for a random set of letters to accidentally contain shorter words multiplle times.

### Errors
|Description  | Exception|
|-------------|----------|
|File name and path invalid|FileNotFoundException|
|A word contains a number| ArgumentException|
|A word has space| ArgumentException|
|A word contains symbols| ArgumentException|
|A word contains a punctuation mark other than comma| ArgumentException|
|Word is an empty string| ArgumentException|
|Word list is SSV| FormatException|
|Word list is comma and space separated values| FormatException|
|Word list is not CSV| FormatException|
|No word list in first row| FormatException|
|Letters contain a number| ArgumentException
|Letters contain symbols| ArgumentException|
|Letters contain punctuation other than comma| ArgumentException|
|Letters are SSV| FormatException|
|Letters are comma and space separated values| FormatException|
|Dimensions are unequal| FormatException|
|Rows have different lengths| FormatException|
|Puzzle has equal dimensions smaller than 2x2| ArgumentOutOfRangeException|
|Word is not in puzzle| InvalidDataException|
|A word is in list twice| InvalidDataException|

# Output
The programs outputs the location of the words in string format printed to the console.
The order of words is ni the order from the words list in the inputed file
Every word is followed by an (x,y) location of every letter of the word.

## Example Output
```
KIRK: (3,0),(2,0),(1,0),(0,0)
KHAN: (3,0),(2,1),(1,2),(0,3)
```









