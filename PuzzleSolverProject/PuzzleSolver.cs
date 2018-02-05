using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PuzzleSolverProject
{
    public class PuzzleSolver
    {
        private int sizeX;
        private int sizeY;

        private void AddWord(String word)
        {
            if(word.Any(ch => ! char.IsLetter(ch)))
            {
                throw new ArgumentException();
            }
        }

        private void AddLetterAt(char letter, int x, int y)
        {
            if(!char.IsLetter(letter))
            {
                throw new ArgumentException();
            }
            else if(isPositionWithinDimensionRange(x, y))
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private bool isPositionWithinDimensionRange(int x, int y)
        {
            return x < 0 || x > sizeX || y < 0 || y > sizeY;
        }

        private void SetDimensions(int x, int y)
        {
            if(x < 2 && y < 2)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if(x != y)
            {
                throw new ArgumentException();
            }

            sizeX = x;
            sizeY = y;
        }

        private List<String> GetListOfWords(String csvWords)
        {
            String[] splittedCSVWords = csvWords.Split(',');
            if(isWordStringFormatInvalid(splittedCSVWords))
            {
                throw new FormatException();
            }
            List<String> wordList = new List<string>(splittedCSVWords);

            return wordList;
        }

        private bool isWordStringFormatInvalid(String[] delimetedWords)
        {
            return delimetedWords.Length == 1 || delimetedWords.Any(word => word.Any(ch => char.IsWhiteSpace(word, 0)));
        }

        private void AddAllWords(List<String> listOfWords)
        {
            if(listOfWords.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentException();
            }
            foreach(String word in listOfWords)
            {
                AddWord(word);
            }
        }

        public void ParseWordsIntoPuzzle(String rawWordString)
        {
            List<String> wordList = GetListOfWords(rawWordString);
            AddAllWords(wordList);
        }

        public void AddAllLetters(char[,] multiArrayOfLetters)
        {
            int lengthX = multiArrayOfLetters.GetLength(0);
            int lengthY = multiArrayOfLetters.GetLength(1);
            SetDimensions(lengthX, lengthY);
            for(int col = 0; col < lengthX; col++)
            {
                for(int row = 0; row < lengthY; row++)
                {
                    AddLetterAt(multiArrayOfLetters[col, row], col, row);
                }
            }
        }

        public char[,] Get2DLetterArray(String[] csvLetters)
        {
            Char[,] letters2dArray = new Char[csvLetters.Length, csvLetters.Length];
            for (int row = 0; row < csvLetters.Length; row++)
            {
                String joinedRow = csvLetters[row].Replace(",", "");
                if(isLetterStringValid(joinedRow, csvLetters[row]))
                {
                    throw new FormatException();
                }
                for(int col = 0; col < joinedRow.Length; col++)
                {
                    letters2dArray[col, row] = joinedRow[col];
                }
            }

            return letters2dArray;
        }

        private bool isLetterStringValid(String joinedLetters, String csvLetterRow)
        {
            return joinedLetters.Equals(csvLetterRow) || joinedLetters.Any(char.IsWhiteSpace);
        }
    }
}
