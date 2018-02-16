using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject.GetNeighbors
{
    class DownDirectionSearchStrategy : IDirectionSearchStrategy
    {
        private const int ZERO_INDEX_OFFSET = 1;
        private const int DIFFERENCE_THRESHOLD = 0;

        private Dictionary<Vector2, Char> letters;

        public void AddPositionToLettersDictionary(Dictionary<Vector2, Char> positionsToLetters)
        {
            letters = positionsToLetters;
        }

        public List<Vector2> GetNeighborsFrom(Vector2 startPosition, int length)
        {
            Vector2 maxPosition = new Vector2(startPosition.X, startPosition.Y + length - ZERO_INDEX_OFFSET);
            List<Vector2> positionsWithinRange = letters.Select(kvp => kvp.Key).Where(position => withinRangeWhereCondition(maxPosition, position)).ToList();
            List<Vector2> positionsDownFromStartPosition = positionsWithinRange.Where(vector => vector.Y >= startPosition.Y).ToList();
            return positionsDownFromStartPosition;
        }

        private bool withinRangeWhereCondition(Vector2 maxPosition, Vector2 currentPosition)
        {
            return (maxPosition - currentPosition).X == DIFFERENCE_THRESHOLD && (maxPosition - currentPosition).Y >= DIFFERENCE_THRESHOLD;
        }
    }
}
