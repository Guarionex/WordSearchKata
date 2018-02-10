using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject
{
    public class WordSearchPuzzle
    {
        private const int INVALID_COUNT = 0;
        private const String OPEN_PARANTHESIS = "(";
        private const String CLOSE_PARANTHESIS = ")";
        private const String COMMA = ",";
        private const String NEW_LINE = "\n";

        public List<String> WordsList { get; }
        public Dictionary<Vector2, Char> LettersMap { get;}
        private bool isChanged;
        private Dictionary<String, List<Vector2>> wordMap;
        private bool isValid;

        public WordSearchPuzzle()
        {
            WordsList = new List<String>();
            LettersMap = new Dictionary<Vector2, Char>();
            isChanged = false;
            wordMap = new Dictionary<string, List<Vector2>>();
            isValid = true;
        }

        public void AddWord(String word)
        {
            WordsList.Add(word);
            isChanged = true;
        }

        public void AddLetterAt(Char letter, int x, int y)
        {
            LettersMap.Add(new Vector2(x, y), letter);
            isChanged = true;
        }

        public Dictionary<String, List<Vector2>> GetWordsLocation()
        {
            FindAllWordLocations();
            return wordMap;
        }

        public bool IsValid()
        {
            FindAllWordLocations();

            if (wordMap.Count == INVALID_COUNT)
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }

        public override string ToString()
        {
            FindAllWordLocations();

            String output = "";
            if (wordMap.Count > INVALID_COUNT)
            {
                foreach (KeyValuePair<String, List<Vector2>> wordMap in wordMap)
                {
                    output += wordMap.Key + ": ";
                    output += letterLocationsToString(wordMap.Value);
                }

                output = output.Remove(output.LastIndexOf('\n'));
            }
            return output;
        }

        private void FindAllWordLocations()
        {
            
            if (isChanged)
            {
                wordMap.Clear();

                WordSeachAlgorithm algorithm = new WordSeachAlgorithm(LettersMap);
                wordMap = algorithm.SearchEachWord(WordsList);
                
                isChanged = false;
            }
        }

        private String letterLocationsToString(List<Vector2> lettersLocations)
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
