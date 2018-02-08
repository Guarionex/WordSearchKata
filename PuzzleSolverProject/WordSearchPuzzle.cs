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
        private delegate List<Vector2> getNeighborsOfBy(Vector2 startPosition, int length);
        private Dictionary<DirectionEnum, getNeighborsOfBy> searchDirection;

        public WordSearchPuzzle()
        {
            Words = new List<String>();
            Letters = new Dictionary<Vector2, Char>();
            searchDirection = new Dictionary<DirectionEnum, getNeighborsOfBy>();
            searchDirection.Add(DirectionEnum.Right, GetRightNeighborsStartingFrom);
            searchDirection.Add(DirectionEnum.Down, GetDownNeighborsStartingFrom);
            searchDirection.Add(DirectionEnum.Up, GetUpNeighborsStartingFrom);
            searchDirection.Add(DirectionEnum.UpRight, GetUpRightNeighborsStartingFrom);
            searchDirection.Add(DirectionEnum.Left, GetLeftNeighborsStartingFrom);
        }

        public void AddWord(String word)
        {
            Words.Add(word);
        }

        public void AddLetterAt(Char letter, int x, int y)
        {
            Letters.Add(new Vector2(x, y), letter);
        }

        public List<Vector2> SearchRight(String word)
        {
            return SearchWordInDirection(word, DirectionEnum.Right);
        }

        private List<Vector2> GetRightNeighborsStartingFrom(Vector2 startPosition, int length)
        {
            Vector2 maxPosition = new Vector2(startPosition.X + length - 1, startPosition.Y);
            List<Vector2> positionsWithinRange = Letters.Select(kvp => kvp.Key).Where(key => (maxPosition - key).X >= 0 && (maxPosition - key).Y == 0).ToList();
            List<Vector2> positionsRightOfStartingPoint = positionsWithinRange.Where(vector => vector.X >= startPosition.X).ToList();
           return positionsRightOfStartingPoint;
        }

        private List<Vector2> FindAllLetterPositions(Char letter)
        {
            List<Vector2> positions = Letters.Where(kvp => kvp.Value == letter).Select(kvp => kvp.Key).ToList();
            return positions;
        }

        public List<Vector2> SearchDown(string word)
        {
            return SearchWordInDirection(word, DirectionEnum.Down);
        }

        private List<Vector2> GetDownNeighborsStartingFrom(Vector2 startPosition, int length)
        {
            Vector2 maxPosition = new Vector2(startPosition.X, startPosition.Y + length - 1);
            List<Vector2> positionsWithinRange = Letters.Select(kvp => kvp.Key).Where(key => (maxPosition - key).X == 0 && (maxPosition - key).Y >= 0).ToList();
            List<Vector2> positionsBottomOfStartPosition = positionsWithinRange.Where(vector => vector.Y >= startPosition.Y).ToList();
            return positionsBottomOfStartPosition;
        }

        private List<Vector2> SearchWordInDirection(String word, DirectionEnum direction)
        {
            List<Vector2> wordPosition = new List<Vector2>();
            List<Vector2> firstLetterPositions = FindAllLetterPositions(word[0]);

            foreach (Vector2 position in firstLetterPositions)
            {
                List<Vector2> candidate = searchDirection[direction](position, word.Length);
                Char[] candidateLetters = candidate.Where(key => Letters.ContainsKey(key)).Select(key => Letters[key]).ToArray();

                if (word.Equals(new String(candidateLetters)))
                {
                    wordPosition.AddRange(candidate);
                }
            }

            return wordPosition;
        }
        
        private List<Vector2> GetUpRightNeighborsStartingFrom(Vector2 startPosition, int length)
        {
            List<Vector2> positionsUpRightFromStartPosition = new List<Vector2>();
            for (int x = 0, y = 0; x < 4 && y > -4; x++, y--)
            {
                Vector2 upRightNeighbor = new Vector2(startPosition.X + x, startPosition.Y + y);
                if(Letters.ContainsKey(upRightNeighbor))
                {
                    positionsUpRightFromStartPosition.Add(upRightNeighbor);
                }
            }
            return positionsUpRightFromStartPosition;
        }

        public List<Vector2> SearchUpRight(String word)
        {
            return SearchWordInDirection(word, DirectionEnum.UpRight);
        }

        private List<Vector2> GetUpNeighborsStartingFrom(Vector2 startPosition, int length)
        {
            Vector2 maxPosition = new Vector2(startPosition.X, startPosition.Y - (length - 1));
            List<Vector2> positionsWithinRange = Letters.Select(kvp => kvp.Key).Where(key => (maxPosition - key).X == 0 && (maxPosition - key).Y <= 0).ToList();
            List<Vector2> positionsUpFromStartPosition = positionsWithinRange.Where(vector => vector.Y <= startPosition.Y).ToList();
            positionsUpFromStartPosition.Reverse();
            return positionsUpFromStartPosition;
        }

        public List<Vector2> SearchUp(String word)
        {
            return SearchWordInDirection(word, DirectionEnum.Up);
        }

        private List<Vector2> GetLeftNeighborsStartingFrom(Vector2 startPosition, int length)
        {
            Vector2 maxPosition = new Vector2(startPosition.X - (length - 1), startPosition.Y);
            List<Vector2> positionsWithinRange = Letters.Select(kvp => kvp.Key).Where(key => (maxPosition - key).X <= 0 && (maxPosition - key).Y == 0).ToList();
            List<Vector2> positionsLeftFromStartingPoint = positionsWithinRange.Where(vector => vector.X <= startPosition.X).ToList();
            positionsLeftFromStartingPoint.Reverse();
            return positionsLeftFromStartingPoint;
        }

        public List<Vector2> SearchLeft(String word)
        {
            return SearchWordInDirection(word, DirectionEnum.Left);
        }
    }
}
