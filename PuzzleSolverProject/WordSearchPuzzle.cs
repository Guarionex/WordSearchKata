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

        public List<String> Words { get; }
        public Dictionary<Vector2, Char> Letters { get;}
        private bool isChanged;
        private Dictionary<String, List<Vector2>> wordLocations;
        private bool isValid;

        public WordSearchPuzzle()
        {
            Words = new List<String>();
            Letters = new Dictionary<Vector2, Char>();
            isChanged = false;
            wordLocations = new Dictionary<string, List<Vector2>>();
            isValid = true;
        }

        public void AddWord(String word)
        {
            Words.Add(word);
            isChanged = true;
        }

        public void AddLetterAt(Char letter, int x, int y)
        {
            Letters.Add(new Vector2(x, y), letter);
            isChanged = true;
        }

        public Dictionary<String, List<Vector2>> GetWordsLocation()
        {
            FindAllWordLocations();
            return wordLocations;
        }

        private void FindAllWordLocations()
        {
            
            if (isChanged)
            {
                wordLocations.Clear();
                try
                {
                    foreach (String word in Words)
                    {
                        WordSeachAlgorithm algorithm = new WordSeachAlgorithm(Letters);
                        List<List<Vector2>> wordDirections = algorithm.SearchAllDirections(word);
                        List<Vector2> foundWordLocation = wordDirections.Single(dircetion => dircetion.Count > INVALID_COUNT);
                        wordLocations.Add(word, foundWordLocation);
                    }
                }
                catch(Exception e)
                {
                    wordLocations.Clear();
                }

                isChanged = false;
            }
        }

        public bool IsValid()
        {
            FindAllWordLocations();

            if (wordLocations.Count == INVALID_COUNT)
            {
                isValid = false;
            }

            return isValid;
        }

        public override string ToString()
        {
            FindAllWordLocations();

            String output = "";
            if (wordLocations.Count > INVALID_COUNT)
            {
                foreach (KeyValuePair<String, List<Vector2>> wordMap in wordLocations)
                {
                    output += wordMap.Key + ": ";
                    output += letterLocationsToString(wordMap.Value);
                }

                output = output.Remove(output.LastIndexOf('\n'));
            }
            return output;
        }

        private String letterLocationsToString(List<Vector2> lettersLocations)
        {
            String lettersOutput = "";
            foreach (Vector2 letterLocation in lettersLocations)
            {
                lettersOutput += "(" + letterLocation.X + "," + letterLocation.Y + "),";
            }

            lettersOutput = lettersOutput.Remove(lettersOutput.LastIndexOf(','));
            lettersOutput += "\n";

            return lettersOutput;
        }
    }
}
