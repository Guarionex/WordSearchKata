using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject
{
    [Serializable]
    public class WordsMapDecorator : Dictionary<String, List<Vector2>>
    {
        private const int INVALID_COUNT = 0;
        private const String OPEN_PARANTHESIS = "(";
        private const String CLOSE_PARANTHESIS = ")";
        private const String COMMA = ",";
        private const String NEW_LINE = "\n";
        private const String COLON_SPACE = ": ";

        private Dictionary<String, List<Vector2>> wordsMap;

        public WordsMapDecorator(Dictionary<String, List<Vector2>> wordsLocations)
        {
            wordsMap = wordsLocations;
        }

        public bool IsValid()
        {
            return wordsMap.Count != INVALID_COUNT;
        }

        public override string ToString()
        {
            String output = String.Empty;
            if (wordsMap.Count > INVALID_COUNT)
            {
                foreach (KeyValuePair<String, List<Vector2>> wordLocation in wordsMap)
                {
                    output += wordLocation.Key + COLON_SPACE;
                    output += LetterLocationsToString(wordLocation.Value);
                }

                output = output.Remove(output.LastIndexOf(NEW_LINE));
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
    }
}
