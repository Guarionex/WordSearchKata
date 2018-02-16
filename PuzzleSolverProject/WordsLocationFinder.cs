using PuzzleSolverProject.DirectionSearchStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject
{
    public class WordsLocationFinder
    {
        private WordSearchPuzzle wsPuzzle;

        public WordsLocationFinder(WordSearchPuzzle puzzle)
        {
            wsPuzzle = puzzle;
        }

        public Dictionary<String, List<Vector2>> GetWordsLocation()
        {
            return FindAllWordLocations(wsPuzzle);
        }

        private Dictionary<String, List<Vector2>> FindAllWordLocations(WordSearchPuzzle puzzle)
        {
            DirectionSearchFactory getNeighborsFactory = new DirectionSearchFactory(puzzle);
            Dictionary<DirectionEnum, IDirectionSearchStrategy> directionSearchStrategies = getNeighborsFactory.GetNeighborStrategy;
            WordSeachAlgorithm algorithm = new WordSeachAlgorithm(directionSearchStrategies);

            return algorithm.SearchEachWord(puzzle.WordsList);
        }
    }
}
