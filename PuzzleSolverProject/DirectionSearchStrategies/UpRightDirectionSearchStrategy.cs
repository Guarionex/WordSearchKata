using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject.DirectionSearchStrategies
{
    public class UpRightDirectionSearchStrategy : IDirectionSearchStrategy
    {
        private const int STARTING_OFFSET = 0;
        
        private WordSearchPuzzle puzzle;

        public UpRightDirectionSearchStrategy(WordSearchPuzzle wordSearchPuzzle)
        {
            puzzle = wordSearchPuzzle;
        }

        public List<Vector2> GetAllLocationsOfLetter(Char letter)
        {
            List<Vector2> positions = puzzle.LettersMap.Where(kvp => kvp.Value == letter).Select(kvp => kvp.Key).ToList();
            return positions;
        }

        public List<string> GetAllWords()
        {
            throw new NotImplementedException();
        }

        public List<Vector2> GetNeighborsFrom(Vector2 startPosition, int length)
        {
            List<Vector2> positionsUpRightFromStartPosition = new List<Vector2>();
            for (int x = STARTING_OFFSET, y = STARTING_OFFSET; x < length && y > -length; x++, y--)
            {
                Vector2 upRightNeighbor = new Vector2(startPosition.X + x, startPosition.Y + y);
                if (puzzle.LettersMap.ContainsKey(upRightNeighbor))
                {
                    positionsUpRightFromStartPosition.Add(upRightNeighbor);
                }
            }
            return positionsUpRightFromStartPosition;
        }

        public String GetStringFromLocations(List<Vector2> locations)
        {
            Char[] candidateLetters = locations.Select(key => puzzle.LettersMap[key]).ToArray();
            return new String(candidateLetters);
        }
    }
}
