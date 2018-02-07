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
            searchDirection.Add(DirectionEnum.Right, GetRightNeighborsOfBy);
            searchDirection.Add(DirectionEnum.Down, GetBottomNeighborsOfBy);
            searchDirection.Add(DirectionEnum.Up, GetUpNeighborsOfBy);
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
            return SearchWordInDirection(word, DirectionEnum.Right);
        }

        private List<Vector2> GetRightNeighborsOfBy(Vector2 startPosition, int length)
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

        public List<Vector2> SearchVertical(string word)
        {
            return SearchWordInDirection(word, DirectionEnum.Down);
        }

        private List<Vector2> GetBottomNeighborsOfBy(Vector2 startPosition, int length)
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

        private List<Vector2> GetUpNeighborsOfBy(Vector2 startPosition, int length)
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
    }
}
