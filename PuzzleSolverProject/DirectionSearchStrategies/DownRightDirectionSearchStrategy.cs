using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject.DirectionSearchStrategies
{
    public class DownRightDirectionSearchStrategy : IDirectionSearchStrategy
    {
        private const int STARTING_OFFSET = 0;

        private WordSearchPuzzle puzzle;

        public DownRightDirectionSearchStrategy(WordSearchPuzzle wordSearchPuzzle)
        {
            puzzle = wordSearchPuzzle;
        }

        public List<Vector2> GetAllLocationsOfLetter(Char letter)
        {
            List<Vector2> positions = puzzle.LettersMap.Where(kvp => kvp.Value == letter).Select(kvp => kvp.Key).ToList();
            return positions;
        }

        public List<String> GetAllWords()
        {
            return puzzle.WordsList;
        }

        public List<Vector2> GetNeighborsFrom(Vector2 startPosition, int length)
        {
            List<Vector2> positionsDownRightFromStartPosition = new List<Vector2>();
            for (int x = STARTING_OFFSET, y = STARTING_OFFSET; x < length && y < length; x++, y++)
            {
                Vector2 downRightNeighbor = new Vector2(startPosition.X + x, startPosition.Y + y);
                if (puzzle.LettersMap.ContainsKey(downRightNeighbor))
                {
                    positionsDownRightFromStartPosition.Add(downRightNeighbor);
                }
            }
            return positionsDownRightFromStartPosition;
        }

        public String GetStringFromLocations(List<Vector2> locations)
        {
            Char[] candidateLetters = locations.Select(key => puzzle.LettersMap[key]).ToArray();
            return new String(candidateLetters);
        }
    }
}
