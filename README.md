# WordSearchKata
Word Search Kata for Pillar Technology.

Word Search Puzzle solver developed in C# using NUnit Framework for TDD in Visual Studio. 
The program takes in a file containing a word search puzzle along with the words to find.
It then searches for all the words in eight directions, horizontal, vertical, diagonally descending, diagonally ascending, and reverse on all axes.

Github's official .gitignore for Visual Studios was used.

# Build
There is a Makefile provided to build and test the solution.

## Windows
To use the Makefile in Windows, you must have Visual Studios installed. Load up the Developer Command Prompt for VS.
Navigate to the folder where the solution folder that contains the Makefile. The following commands are available from the Makefile:

|Command|Action performed|
|-------|----------------|
|nmake -f Makefile| Builds production project and unit test project|
|nmake -f Makefile all| Builds production project and unit test project|
|nmake -f Makefile build-test| Builds all and runs the unit test|

## OSX and Linux
Open a console and navigate to the project folder where Makefile is located. Unfortunately I lack a Mac or Linux machine to confirm this. The following commands are available from Makefile:

|Command|Action performed|
|-------|----------------|
|Makefile| Builds production project and unit test project|
|Makefile all| Builds production project and unit test project|
|Makefile build-test| Builds all and runs the unit test|

## Makefile Fails
If the Makefile fails to build or import NuGets for test, you will have to load the solution in Visual Studios.
Open Visual Studios and click open solution. Navigate to the location of you cloned the repo and load WordSearchKata.sln. Visual studios will automatically download NuGet packages. If it fails, download the following NuGet:

* NUnit
* NUnit3TestAdapter

# Input
Program name is a command line program called PuzzleSolverProject.exe. It takes in a single input, which is a text file.

## Usage
With the production project build through Makefile, in the console or command prompt, navigate to the Executables folder. Run the following command:

PuzzleSolverProject [filePath+fileName]

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









