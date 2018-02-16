using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject.GetNeighbors
{
    public class UpRightDirectionSearchStrategy : IDirectionSearchStrategy
    {
        private const int STARTING_OFFSET = 0;

        private Dictionary<Vector2, Char> letters;
        private WordSearchPuzzle puzzle;

        public UpRightDirectionSearchStrategy(WordSearchPuzzle wordSearchPuzzle)
        {
            puzzle = wordSearchPuzzle;
        }

        public void AddPositionToLettersDictionary(Dictionary<Vector2, char> positionsToLetters)
        {
            letters = positionsToLetters;
        }

        public List<Vector2> GetAllLocationsOfLetter(Char v)
        {
            throw new NotImplementedException();
        }

        public List<Vector2> GetNeighborsFrom(Vector2 startPosition, int length)
        {
            List<Vector2> positionsUpRightFromStartPosition = new List<Vector2>();
            for (int x = STARTING_OFFSET, y = STARTING_OFFSET; x < length && y > -length; x++, y--)
            {
                Vector2 upRightNeighbor = new Vector2(startPosition.X + x, startPosition.Y + y);
                if (letters.ContainsKey(upRightNeighbor))
                {
                    positionsUpRightFromStartPosition.Add(upRightNeighbor);
                }
            }
            return positionsUpRightFromStartPosition;
        }

        public String GetStringFromLocations(List<Vector2> locations)
        {
            throw new NotImplementedException();
        }
    }
}
