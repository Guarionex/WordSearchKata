using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject.DirectionSearchStrategies
{
    public interface IDirectionSearchStrategy
    {
        List<Vector2> GetNeighborsFrom(Vector2 startPosition, int length);
        List<Vector2> GetAllLocationsOfLetter(Char v);
        String GetStringFromLocations(List<Vector2> locations);
        List<String> GetAllWords();
    }
}
