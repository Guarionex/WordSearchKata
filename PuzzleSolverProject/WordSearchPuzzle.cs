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
        private delegate List<Vector2> getNeighborsFrom(Vector2 startPosition, int length);
        private Dictionary<DirectionEnum, getNeighborsFrom> searchDirection;
        private bool isChanged;
        private Dictionary<String, List<Vector2>> wordLocations;
        private bool isValid;

        public WordSearchPuzzle()
        {
            Words = new List<String>();
            Letters = new Dictionary<Vector2, Char>();
            searchDirection = new Dictionary<DirectionEnum, getNeighborsFrom>();
            searchDirection.Add(DirectionEnum.Right, GetRightNeighborsFrom);
            searchDirection.Add(DirectionEnum.Down, GetDownNeighborsFrom);
            searchDirection.Add(DirectionEnum.Up, GetUpNeighborsFrom);
            searchDirection.Add(DirectionEnum.UpRight, GetUpRightFrom);
            searchDirection.Add(DirectionEnum.Left, GetLeftNeighborsFrom);
            searchDirection.Add(DirectionEnum.DownRight, GetDownRightNeighborsFrom);
            searchDirection.Add(DirectionEnum.UpLeft, GetUpLeftNeighborsFrom);
            searchDirection.Add(DirectionEnum.DownLeft, GetDownLeftNeighborsFrom);
            isChanged = false;
            wordLocations = new Dictionary<string, List<Vector2>>();
            isValid = true;
        }

        public void AddWord(String word)
        {
            Words.Add(word);
            isChanged = true;
        }

        public void AddLetterAt(Char letter, int x, int y)
        {
            Letters.Add(new Vector2(x, y), letter);
            isChanged = true;
        }

        private List<Vector2> SearchUp(String word)
        {
            return SearchWordInDirection(word, DirectionEnum.Up);
        }

        private List<Vector2> SearchDown(string word)
        {
            return SearchWordInDirection(word, DirectionEnum.Down);
        }

        private List<Vector2> SearchLeft(String word)
        {
            return SearchWordInDirection(word, DirectionEnum.Left);
        }

        private List<Vector2> SearchRight(String word)
        {
            return SearchWordInDirection(word, DirectionEnum.Right);
        }

        private List<Vector2> SearchUpLeft(string word)
        {
            return SearchWordInDirection(word, DirectionEnum.UpLeft);
        }

        private List<Vector2> SearchUpRight(String word)
        {
            return SearchWordInDirection(word, DirectionEnum.UpRight);
        }

        private List<Vector2> SearchDownLeft(String word)
        {
            return SearchWordInDirection(word, DirectionEnum.DownLeft);
        }

        private List<Vector2> SearchDownRight(String word)
        {
            return SearchWordInDirection(word, DirectionEnum.DownRight);
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

        private List<Vector2> FindAllLetterPositions(Char letter)
        {
            List<Vector2> positions = Letters.Where(kvp => kvp.Value == letter).Select(kvp => kvp.Key).ToList();
            return positions;
        }

        private List<Vector2> GetUpNeighborsFrom(Vector2 startPosition, int length)
        {
            Vector2 maxPosition = new Vector2(startPosition.X, startPosition.Y - (length - 1));
            List<Vector2> positionsWithinRange = Letters.Select(kvp => kvp.Key).Where(key => (maxPosition - key).X == 0 && (maxPosition - key).Y <= 0).ToList();
            List<Vector2> positionsUpFromStartPosition = positionsWithinRange.Where(vector => vector.Y <= startPosition.Y).ToList();
            positionsUpFromStartPosition.Reverse();
            return positionsUpFromStartPosition;
        }

        private List<Vector2> GetDownNeighborsFrom(Vector2 startPosition, int length)
        {
            Vector2 maxPosition = new Vector2(startPosition.X, startPosition.Y + length - 1);
            List<Vector2> positionsWithinRange = Letters.Select(kvp => kvp.Key).Where(key => (maxPosition - key).X == 0 && (maxPosition - key).Y >= 0).ToList();
            List<Vector2> positionsBottomOfStartPosition = positionsWithinRange.Where(vector => vector.Y >= startPosition.Y).ToList();
            return positionsBottomOfStartPosition;
        }

        private List<Vector2> GetLeftNeighborsFrom(Vector2 startPosition, int length)
        {
            Vector2 maxPosition = new Vector2(startPosition.X - (length - 1), startPosition.Y);
            List<Vector2> positionsWithinRange = Letters.Select(kvp => kvp.Key).Where(key => (maxPosition - key).X <= 0 && (maxPosition - key).Y == 0).ToList();
            List<Vector2> positionsLeftFromStartingPoint = positionsWithinRange.Where(vector => vector.X <= startPosition.X).ToList();
            positionsLeftFromStartingPoint.Reverse();
            return positionsLeftFromStartingPoint;
        }

        private List<Vector2> GetRightNeighborsFrom(Vector2 startPosition, int length)
        {
            Vector2 maxPosition = new Vector2(startPosition.X + length - 1, startPosition.Y);
            List<Vector2> positionsWithinRange = Letters.Select(kvp => kvp.Key).Where(key => (maxPosition - key).X >= 0 && (maxPosition - key).Y == 0).ToList();
            List<Vector2> positionsRightOfStartingPoint = positionsWithinRange.Where(vector => vector.X >= startPosition.X).ToList();
           return positionsRightOfStartingPoint;
        }

        private List<Vector2> GetUpLeftNeighborsFrom(Vector2 startPosition, int length)
        {
            List<Vector2> positionsUpLeftFromStartPosition = new List<Vector2>();
            for (int x = 0, y = 0; x > -length && y > -length; x--, y--)
            {
                Vector2 UpLeftNeighbor = new Vector2(startPosition.X + x, startPosition.Y + y);
                if (Letters.ContainsKey(UpLeftNeighbor))
                {
                    positionsUpLeftFromStartPosition.Add(UpLeftNeighbor);
                }
            }
            return positionsUpLeftFromStartPosition;
        }

        private List<Vector2> GetUpRightFrom(Vector2 startPosition, int length)
        {
            List<Vector2> positionsUpRightFromStartPosition = new List<Vector2>();
            for (int x = 0, y = 0; x < length && y > -length; x++, y--)
            {
                Vector2 upRightNeighbor = new Vector2(startPosition.X + x, startPosition.Y + y);
                if(Letters.ContainsKey(upRightNeighbor))
                {
                    positionsUpRightFromStartPosition.Add(upRightNeighbor);
                }
            }
            return positionsUpRightFromStartPosition;
        }

        private List<Vector2> GetDownLeftNeighborsFrom(Vector2 startPosition, int length)
        {
            List<Vector2> positionsdownLeftFromStartPosition = new List<Vector2>();
            for (int x = 0, y = 0; x > -length && y < length; x--, y++)
            {
                Vector2 downLeftNeighbor = new Vector2(startPosition.X + x, startPosition.Y + y);
                if (Letters.ContainsKey(downLeftNeighbor))
                {
                    positionsdownLeftFromStartPosition.Add(downLeftNeighbor);
                }
            }
            return positionsdownLeftFromStartPosition;
        }

        private List<Vector2> GetDownRightNeighborsFrom(Vector2 startPosition, int length)
        {
            List<Vector2> positionsDownRightFromStartPosition = new List<Vector2>();
            for (int x = 0, y = 0; x < length && y < length; x++, y++)
            {
                Vector2 downRightNeighbor = new Vector2(startPosition.X + x, startPosition.Y + y);
                if (Letters.ContainsKey(downRightNeighbor))
                {
                    positionsDownRightFromStartPosition.Add(downRightNeighbor);
                }
            }
            return positionsDownRightFromStartPosition;
        }

        public Dictionary<String, List<Vector2>> GetWordsLocation()
        {
            FindAllWordLocations();
            return wordLocations;
        }

        private void FindAllWordLocations()
        {
            
            if (isChanged)
            {
                wordLocations.Clear();
                try
                {
                    foreach (String word in Words)
                    {
                        List<List<Vector2>> wordDirections = new List<List<Vector2>>();
                        wordDirections.Add(SearchUp(word));
                        wordDirections.Add(SearchDown(word));
                        wordDirections.Add(SearchLeft(word));
                        wordDirections.Add(SearchRight(word));
                        wordDirections.Add(SearchUpLeft(word));
                        wordDirections.Add(SearchUpRight(word));
                        wordDirections.Add(SearchDownLeft(word));
                        wordDirections.Add(SearchDownRight(word));
                        List<Vector2> foundWordLocation = wordDirections.Single(dircetion => dircetion.Count > 0);
                        if (foundWordLocation.Count > 0)
                        {
                            wordLocations.Add(word, foundWordLocation);
                        }
                    }
                }
                catch(Exception e)
                {
                    wordLocations.Clear();
                }

                isChanged = false;
            }
        }

        public bool IsValid()
        {
            FindAllWordLocations();

            if (wordLocations.Count == 0)
            {
                isValid = false;
            }

            return isValid;
        }

        public override string ToString()
        {
            FindAllWordLocations();

            String output = "";
            if (wordLocations.Count > 0)
            {
                foreach (KeyValuePair<String, List<Vector2>> wordMap in wordLocations)
                {
                    output += wordMap.Key + ": ";
                    output += letterLocationsToString(wordMap.Value);
                }

                output = output.Remove(output.LastIndexOf('\n'));
            }
            return output;
        }

        private String letterLocationsToString(List<Vector2> lettersLocations)
        {
            String lettersOutput = "";
            foreach (Vector2 letterLocation in lettersLocations)
            {
                lettersOutput += "(" + letterLocation.X + "," + letterLocation.Y + "),";
            }

            lettersOutput = lettersOutput.Remove(lettersOutput.LastIndexOf(','));
            lettersOutput += "\n";

            return lettersOutput;
        }
    }
}
