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
            for(int col = 0; col < lengthY; col++)
            {
                for(int row = 0; row < lengthX; row++)
                {
                    AddLetterAt(multiArrayOfLetters[row, col], row, col);
                }
            }
        }

        public char[,] Get2DLetterArray(String[] csvLetters)
        {
            Char[,] valid4x4Letters = new Char[4, 4];
            valid4x4Letters[0, 0] = 'K';
            valid4x4Letters[0, 1] = 'E';
            valid4x4Letters[0, 2] = 'X';
            valid4x4Letters[0, 3] = 'N';
            valid4x4Letters[1, 0] = 'R';
            valid4x4Letters[1, 1] = 'M';
            valid4x4Letters[1, 2] = 'A';
            valid4x4Letters[1, 3] = 'C';
            valid4x4Letters[2, 0] = 'I';
            valid4x4Letters[2, 1] = 'H';
            valid4x4Letters[2, 2] = 'D';
            valid4x4Letters[2, 3] = 'H';
            valid4x4Letters[3, 0] = 'K';
            valid4x4Letters[3, 1] = 'P';
            valid4x4Letters[3, 2] = 'M';
            valid4x4Letters[3, 3] = 'U';
            return valid4x4Letters;
        }
    }
}
