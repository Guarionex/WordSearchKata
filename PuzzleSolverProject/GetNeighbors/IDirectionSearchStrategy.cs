using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject.GetNeighbors
{
    public interface IDirectionSearchStrategy
    {
        void AddPositionToLettersDictionary(Dictionary<Vector2, Char> positionsToLetters);
        List<Vector2> GetNeighborsFrom(Vector2 startPosition, int length);
        List<Vector2> GetAllLocationsOfLetter(Char v);
    }
}
