using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject.DirectionSearchStrategies
{
    public class RightDirectionSearchStrategy : IDirectionSearchStrategy
    {
        private const int ZERO_INDEX_OFFSET = 1;
        private const int DIFFERENCE_THRESHOLD = 0;
        
        private WordSearchPuzzle puzzle;

        public RightDirectionSearchStrategy(WordSearchPuzzle wordSearchPuzzle)
        {
            puzzle = wordSearchPuzzle;
        }

        public List<Vector2> GetAllLocationsOfLetter(Char letter)
        {
            List<Vector2> positions = puzzle.LettersMap.Where(kvp => kvp.Value == letter).Select(kvp => kvp.Key).ToList();
            return positions;
        }

        public List<Vector2> GetNeighborsFrom(Vector2 startPosition, int length)
        {
            Vector2 maxPosition = new Vector2(startPosition.X + length - ZERO_INDEX_OFFSET, startPosition.Y);
            List<Vector2> positionsWithinRange = puzzle.LettersMap.Select(kvp => kvp.Key).Where(position => withinRangeWhereCondition(maxPosition, position)).ToList();
            List<Vector2> positionsRightOfStartingPoint = positionsWithinRange.Where(vector => vector.X >= startPosition.X).ToList();
            return positionsRightOfStartingPoint;
        }

        public String GetStringFromLocations(List<Vector2> locations)
        {
            Char[] candidateLetters = locations.Select(key => puzzle.LettersMap[key]).ToArray();
            return new String(candidateLetters);
        }

        private bool withinRangeWhereCondition(Vector2 maxPosition, Vector2 currentPosition)
        {
            return (maxPosition - currentPosition).X >= DIFFERENCE_THRESHOLD && (maxPosition - currentPosition).Y == DIFFERENCE_THRESHOLD;
        }
    }
}
