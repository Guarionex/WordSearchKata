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

        public void AddWord(String word)
        {
            if(word.Any(ch => ! char.IsLetter(ch)))
            {
                throw new ArgumentException();
            }
        }

        public void AddLetterAt(char letter, int x, int y)
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

        public void SetDimensions(int x, int y)
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

        public List<String> GetListOfWords(String csvWords)
        {

            String[] ssvWords = csvWords.Split(' ');
            if (ssvWords.Length > 1)
            {
                throw new FormatException();
            }

            String[] splittedCSVWords = csvWords.Split(',');
            List<String> wordList = new List<string>(splittedCSVWords);

            return wordList;
        }

        public void addAllWords(List<String> listOfWords)
        {
            if(listOfWords.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentException();
            }
        }

        public void ParseWordsIntoPuzzle(String rawWordString)
        {
            if(rawWordString.Any(char.IsDigit))
            {
                throw new ArgumentException();
            }
            else if(rawWordString.Any(char.IsWhiteSpace))
            {
                throw new ArgumentException();
            }
            else if(rawWordString.Any(char.IsSymbol))
            {
                throw new ArgumentException();
            }
            else if(Regex.IsMatch(rawWordString, @"[\p{P}-[,]]"))
            {
                throw new ArgumentException();
            }
        }
    }
}
