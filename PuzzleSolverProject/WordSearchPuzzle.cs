using System;
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
            searchDirection.Add(DirectionEnum.DownRight, GetDownRightNeighborsStartingFrom);
            searchDirection.Add(DirectionEnum.UpLeft, GetUpLeftNeighborsStartingFrom);
            searchDirection.Add(DirectionEnum.DownLeft, GetDownLeftNeighborsStartingFrom);
        }

        public void AddWord(String word)
        {
            Words.Add(word);
        }

        public void AddLetterAt(Char letter, int x, int y)
        {
            Letters.Add(new Vector2(x, y), letter);
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

        public List<Vector2> SearchUpRight(String word)
        {
            return SearchWordInDirection(word, DirectionEnum.UpRight);
        }

        public List<Vector2> SearchDownLeft(String word)
        {
            return SearchWordInDirection(word, DirectionEnum.DownLeft);
        }

        public List<Vector2> SearchDownRight(String word)
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

        private List<Vector2> GetUpNeighborsStartingFrom(Vector2 startPosition, int length)
        {
            Vector2 maxPosition = new Vector2(startPosition.X, startPosition.Y - (length - 1));
            List<Vector2> positionsWithinRange = Letters.Select(kvp => kvp.Key).Where(key => (maxPosition - key).X == 0 && (maxPosition - key).Y <= 0).ToList();
            List<Vector2> positionsUpFromStartPosition = positionsWithinRange.Where(vector => vector.Y <= startPosition.Y).ToList();
            positionsUpFromStartPosition.Reverse();
            return positionsUpFromStartPosition;
        }

        private List<Vector2> GetDownNeighborsStartingFrom(Vector2 startPosition, int length)
        {
            Vector2 maxPosition = new Vector2(startPosition.X, startPosition.Y + length - 1);
            List<Vector2> positionsWithinRange = Letters.Select(kvp => kvp.Key).Where(key => (maxPosition - key).X == 0 && (maxPosition - key).Y >= 0).ToList();
            List<Vector2> positionsBottomOfStartPosition = positionsWithinRange.Where(vector => vector.Y >= startPosition.Y).ToList();
            return positionsBottomOfStartPosition;
        }

        private List<Vector2> GetLeftNeighborsStartingFrom(Vector2 startPosition, int length)
        {
            Vector2 maxPosition = new Vector2(startPosition.X - (length - 1), startPosition.Y);
            List<Vector2> positionsWithinRange = Letters.Select(kvp => kvp.Key).Where(key => (maxPosition - key).X <= 0 && (maxPosition - key).Y == 0).ToList();
            List<Vector2> positionsLeftFromStartingPoint = positionsWithinRange.Where(vector => vector.X <= startPosition.X).ToList();
            positionsLeftFromStartingPoint.Reverse();
            return positionsLeftFromStartingPoint;
        }

        private List<Vector2> GetRightNeighborsStartingFrom(Vector2 startPosition, int length)
        {
            Vector2 maxPosition = new Vector2(startPosition.X + length - 1, startPosition.Y);
            List<Vector2> positionsWithinRange = Letters.Select(kvp => kvp.Key).Where(key => (maxPosition - key).X >= 0 && (maxPosition - key).Y == 0).ToList();
            List<Vector2> positionsRightOfStartingPoint = positionsWithinRange.Where(vector => vector.X >= startPosition.X).ToList();
           return positionsRightOfStartingPoint;
        }

        private List<Vector2> GetUpLeftNeighborsStartingFrom(Vector2 startPosition, int length)
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

        private List<Vector2> GetUpRightNeighborsStartingFrom(Vector2 startPosition, int length)
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

        private List<Vector2> GetDownLeftNeighborsStartingFrom(Vector2 startPosition, int length)
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

        private List<Vector2> GetDownRightNeighborsStartingFrom(Vector2 startPosition, int length)
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
            Dictionary<String, List<Vector2>> foundWords = new Dictionary<String, List<Vector2>>();

            foreach(String word in Words)
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
                    foundWords.Add(word, foundWordLocation);
                }
            }

            return foundWords;
        }
    }
}
