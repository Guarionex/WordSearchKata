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
        public Dictionary<String, List<Vector2>> GetWordsLocation(WordSearchPuzzle puzzle)
        {
            WordSeachAlgorithm algorithm = new WordSeachAlgorithm(puzzle.LettersMap);
            Dictionary<String, List<Vector2>>  wordMap = algorithm.SearchEachWord(puzzle.WordsList);

            return wordMap;
        }

        public bool IsValid(WordSearchPuzzle puzzle)
        {
            throw new NotImplementedException();
        }
    }
}
