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
            String[] splittedCSVWords = csvWords.Split(',');
            if(splittedCSVWords.Length == 1)
            {
                throw new FormatException();
            }
            else if(splittedCSVWords.Any(s => s.Any(ch => char.IsWhiteSpace(s, 0))))
            {
                throw new FormatException();
            }
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
                String[] cssvWords = Regex.Split(rawWordString, ", ");
                if (cssvWords.Length > 1)
                {
                    throw new FormatException();
                }
                String[] csvWords = rawWordString.Split(',');
                if (csvWords.Length > 1)
                {
                    throw new ArgumentException();
                }
                throw new FormatException();
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
