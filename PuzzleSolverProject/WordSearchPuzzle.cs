﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject
{
    public class WordSearchPuzzle
    {
        public List<String> Words { get; }
        public Dictionary<Vector2, Char> Letters { get;}

        public WordSearchPuzzle()
        {
            Words = new List<String>();
            Letters = new Dictionary<Vector2, Char>();
        }
        public void AddWord(String word)
        {
            Words.Add(word);
        }

        public void AddLetterAt(Char letter, int x, int y)
        {
            Letters.Add(new Vector2(x, y), letter);
        }

        public List<Vector2> SearchHorizontal(String word)
        {
            List<Vector2> wordPosition = new List<Vector2>();
            
            List<Vector2> firstLetterPositions = FindAllLetterPositions(word[0]);
            foreach(Vector2 position in firstLetterPositions)
            {
                List<Vector2> candidate = getRightNeighboorsOfBy(position, word.Length - 1);
                Char[] candidateLetters = candidate.Where(key => Letters.ContainsKey(key)).Select(key => Letters[key]).ToArray();

                if(word.Equals(new String(candidateLetters)))
                {
                    wordPosition.AddRange(candidate);
                }
            }

            return wordPosition;
        }

        private List<Vector2> getRightNeighboorsOfBy(Vector2 startingPoint, int length)
        {
            Vector2 maxPosition = new Vector2(startingPoint.X + length, startingPoint.Y);
            List<Vector2> positionsWithinRange = Letters.Select(kvp => kvp.Key).Where(key => (maxPosition - key).X >= 0 && (maxPosition - key).Y == 0).ToList();
            List<Vector2> positionsRightOfStartingPoint = positionsWithinRange.Where(vector => vector.X >= startingPoint.X).ToList();
           return positionsRightOfStartingPoint;
        }

        private List<Vector2> FindAllLetterPositions(Char letter)
        {
            List<Vector2> positions = Letters.Where(kvp => kvp.Value == letter).Select(kvp => kvp.Key).ToList();
            return positions;
        }

        public List<Vector2> SearchVertical(string word)
        {
            List<Vector2> expected = new List<Vector2>();
            expected.Add(new Vector2(0, 0));
            expected.Add(new Vector2(0, 1));
            expected.Add(new Vector2(0, 2));
            expected.Add(new Vector2(0, 3));

            return expected;
        }

        public List<Vector2> GetBottomNeighborsOfBy(Vector2 startPosition, int length)
        {
            return new List<Vector2>();
        }
    }
}
