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

        public WordsMapDecorator GetWordsMap()
        {
            Dictionary<String, List<Vector2>> wordsLocation = FindAllWordLocations(wsPuzzle);
            return new WordsMapDecorator(wordsLocation);
        }

        private Dictionary<String, List<Vector2>> FindAllWordLocations(WordSearchPuzzle puzzle)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            WordSearchAlgorithm algorithm = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            return algorithm.SearchEachWord();
        }
    }
}
