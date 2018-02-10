using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject
{
    class UpLeftGetNeighborsFrom : IGetNeighborsFrom
    {
        private const int STARTING_OFFSET = 0;

        private Dictionary<Vector2, Char> letters;

        public void AddPositionToLettersDictionary(Dictionary<Vector2, char> positionsToLetters)
        {
            letters = positionsToLetters;
        }

        public List<Vector2> GetNeighborsFrom(Vector2 startPosition, int length)
        {
            List<Vector2> positionsUpLeftFromStartPosition = new List<Vector2>();
            for (int x = STARTING_OFFSET, y = STARTING_OFFSET; x > -length && y > -length; x--, y--)
            {
                Vector2 UpLeftNeighbor = new Vector2(startPosition.X + x, startPosition.Y + y);
                if (letters.ContainsKey(UpLeftNeighbor))
                {
                    positionsUpLeftFromStartPosition.Add(UpLeftNeighbor);
                }
            }
            return positionsUpLeftFromStartPosition;
        }
    }
}
