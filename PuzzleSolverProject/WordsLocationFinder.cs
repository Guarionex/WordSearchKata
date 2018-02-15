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
            WordSeachAlgorithm algorithm = new WordSeachAlgorithm(puzzle.LettersMap);
            return algorithm.SearchEachWord(puzzle.WordsList);
        }
    }
}
