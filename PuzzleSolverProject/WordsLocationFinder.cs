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
        private const int INVALID_COUNT = 0;
        private const String OPEN_PARANTHESIS = "(";
        private const String CLOSE_PARANTHESIS = ")";
        private const String COMMA = ",";
        private const String NEW_LINE = "\n";

        private WordSearchPuzzle wsPuzzle;

        public WordsLocationFinder(WordSearchPuzzle puzzle)
        {
            wsPuzzle = puzzle;
        }

        public Dictionary<String, List<Vector2>> GetWordsLocation(WordSearchPuzzle puzzle)
        {
            return FindAllWordLocations(puzzle);
        }

        public bool IsValid(WordSearchPuzzle puzzle)
        {
            Dictionary<String, List<Vector2>> wordMap = FindAllWordLocations(puzzle);

            return wordMap.Count != INVALID_COUNT;
        }

        public override string ToString()
        {
            Dictionary<String, List<Vector2>> wordMap = FindAllWordLocations(wsPuzzle);

            String output = "";
            if (wordMap.Count > INVALID_COUNT)
            {
                foreach (KeyValuePair<String, List<Vector2>> wordLocation in wordMap)
                {
                    output += wordLocation.Key + ": ";
                    output += LetterLocationsToString(wordLocation.Value);
                }

                output = output.Remove(output.LastIndexOf('\n'));
            }
            return output;
        }

        private String LetterLocationsToString(List<Vector2> lettersLocations)
        {
            String lettersOutput = String.Empty;
            foreach (Vector2 letterLocation in lettersLocations)
            {
                lettersOutput += OPEN_PARANTHESIS + letterLocation.X + COMMA + letterLocation.Y + CLOSE_PARANTHESIS + COMMA;
            }

            lettersOutput = lettersOutput.Remove(lettersOutput.LastIndexOf(COMMA));
            lettersOutput += NEW_LINE;

            return lettersOutput;
        }

        private Dictionary<String, List<Vector2>> FindAllWordLocations(WordSearchPuzzle puzzle)
        {
            WordSeachAlgorithm algorithm = new WordSeachAlgorithm(puzzle.LettersMap);
            return algorithm.SearchEachWord(puzzle.WordsList);
        }
    }
}
