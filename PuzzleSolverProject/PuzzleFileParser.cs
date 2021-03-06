﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PuzzleSolverProject
{
    public class PuzzleFileParser
    {
        private const Char COMMA_CHAR = ',';
        private const String COMMA_STRING = ",";
        private const int FIRST_LETTER_OF_WORD_INDEX = 0;
        private const int MIN_WORD_COUNT = 1;
        private const int FIRST_WORD_INDEX = 0;
        private const int WORD_ROW_INDEX = 0;
        private const int NUMBER_OF_WORD_ROWS = 1;
        private const int MIN_DIMENSION_INDEX = 0;
        private const int MIN_DIMENSIONS_SIZE = 2;
        private const int INVALID_LETTERS_COUNT = 1;
        private const int LETTER_ROW_FIRST_INDEX = 1;
        private const int DIMENSION_X = 0;
        private const int DIMENSION_Y = 1;

        private int sizeX;
        private int sizeY;
        private WordSearchPuzzle puzzle;

        public WordSearchPuzzle ParseFileToWordSearchPuzzle(String fileName)
        {
            puzzle = new WordSearchPuzzle();
            String[] lines = File.ReadAllLines(fileName);
            ParseWordsIntoPuzzle(lines[WORD_ROW_INDEX]);

            String[] rawLetters = new String[lines.Length - NUMBER_OF_WORD_ROWS];
            Array.Copy(lines, LETTER_ROW_FIRST_INDEX, rawLetters, MIN_DIMENSION_INDEX, lines.Length - NUMBER_OF_WORD_ROWS);
            ParseLettersIntoPuzzle(rawLetters);

            return puzzle;
        }

        private void AddAllWords(List<String> listOfWords)
        {
            ValidateWords(listOfWords);

            foreach(String word in listOfWords)
            {
                AddWord(word);
            }
        }

        private void AddWord(String word)
        {
            puzzle.AddWord(word);
        }

        private void ValidateWords(List<String> listOfWords)
        {
            if(IsWordListValid(listOfWords))
            {
                throw new ArgumentException();
            }
        }

        private bool IsWordListValid(List<String> listOfWords)
        {
            return listOfWords.Any(string.IsNullOrWhiteSpace) || listOfWords.Any(word => word.Any(ch => !char.IsLetter(ch)));
        }

        private List<String> GetListOfWords(String csvWords)
        {
            String[] splittedCSVWords = csvWords.Split(COMMA_CHAR);
            if(IsWordStringFormatInvalid(splittedCSVWords))
            {
                throw new FormatException();
            }

            List<String> wordList = new List<string>(splittedCSVWords);

            return wordList;
        }

        private bool IsWordStringFormatInvalid(String[] delimitedWords)
        {
            return IsWordListASingleWord(delimitedWords) || IsWordsListCommaSpaceSeparatedValue(delimitedWords);
        }

        private bool IsWordListASingleWord(String[] delimitedWords)
        {
            return delimitedWords.Length == MIN_WORD_COUNT && delimitedWords[FIRST_WORD_INDEX].Any(ch => !char.IsLetter(ch));
        }

        private bool IsWordsListCommaSpaceSeparatedValue(String[] delimetedWords)
        {
            return delimetedWords.Any(word => word.Any(ch => char.IsWhiteSpace(word, FIRST_LETTER_OF_WORD_INDEX)));
        }

        private void ParseWordsIntoPuzzle(String rawWordString)
        {
            List<String> wordList = GetListOfWords(rawWordString);
            AddAllWords(wordList);
        }

        private void AddAllLetters(Char[,] multiArrayOfLetters)
        {
            int lengthX = multiArrayOfLetters.GetLength(DIMENSION_X);
            int lengthY = multiArrayOfLetters.GetLength(DIMENSION_Y);
            SetValidDimensions(lengthX, lengthY);
            for(int col = MIN_DIMENSION_INDEX; col < lengthX; col++)
            {
                for(int row = MIN_DIMENSION_INDEX; row < lengthY; row++)
                {
                    AddLetterAt(multiArrayOfLetters[col, row], col, row);
                }
            }
        }

        private void SetValidDimensions(int x, int y)
        {
            ValidateDimensions(x, y);

            sizeX = x;
            sizeY = y;
        }

        private void ValidateDimensions(int x, int y)
        {
            if (isDimensionsInRange(x, y))
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private bool isDimensionsInRange(int x, int y)
        {
            return x < MIN_DIMENSIONS_SIZE && y < MIN_DIMENSIONS_SIZE;
        }

        private void AddLetterAt(Char letter, int x, int y)
        {
            if (!char.IsLetter(letter))
            {
                throw new ArgumentException();
            }

            puzzle.AddLetterAt(letter, x, y);
        }

        private Char[,] Get2DLetterArray(String[] csvLetters)
        {
            Char[,] letters2dArray = new Char[csvLetters.Length, csvLetters.Length];
            for (int row = MIN_DIMENSION_INDEX; row < csvLetters.Length; row++)
            {
                String joinedRow = csvLetters[row].Replace(COMMA_STRING, String.Empty);
                ValidateRow(joinedRow, csvLetters[row], csvLetters.Length);

                for (int col = MIN_DIMENSION_INDEX; col < joinedRow.Length; col++)
                {
                    letters2dArray[col, row] = joinedRow[col];
                }
            }

            return letters2dArray;
        }

        private void ValidateRow(String joinedLetters, String csvLetterRow, int expectedLength)
        {
            if (IsRowValid(joinedLetters, csvLetterRow, expectedLength))
            {
                throw new FormatException();
            }
        }

        private bool IsRowValid(String joinedLetters, String csvLetterRow, int expectedLength)
        {
            return IsDelimitedLetterowInvalid(joinedLetters, csvLetterRow, expectedLength) || IsThereEnoughLettersInRow(joinedLetters, expectedLength);
        }

        private bool IsDelimitedLetterowInvalid(String joinedLetters, String csvLetterRow, int expectedLength)
        {
            return joinedLetters.Equals(csvLetterRow) && expectedLength != INVALID_LETTERS_COUNT;
        }

        private bool IsThereEnoughLettersInRow(String joinedLetters, int expectedLength)
        {
            return joinedLetters.Any(char.IsWhiteSpace) || joinedLetters.Length != expectedLength;
        }

        private void ParseLettersIntoPuzzle(String[] rawLetters)
        {
            Char[,] lettersGrid = Get2DLetterArray(rawLetters);
            AddAllLetters(lettersGrid);
        }
    }
}
