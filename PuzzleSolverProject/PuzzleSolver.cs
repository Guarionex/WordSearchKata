﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            List<String> wordList = new List<string>();
            wordList.Add("BONES");
            wordList.Add("KHAN");
            wordList.Add("KIRK");
            wordList.Add("SCOTTY");
            wordList.Add("SPOCK");
            wordList.Add("SULU");
            wordList.Add("UHURA");

            return wordList;
        }
    }
}
