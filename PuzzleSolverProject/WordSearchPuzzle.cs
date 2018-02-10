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
        private const int FIRST_LETTER_OF_WORD_INDEX = 0;
        private const int INVALID_COUNT = 0;

        public List<String> Words { get; }
        public Dictionary<Vector2, Char> Letters { get;}
        private delegate List<Vector2> getNeighborsFrom(Vector2 startPosition, int length);
        private Dictionary<DirectionEnum, IGetNeighborsFrom> searchDirectionStrategy;
        private bool isChanged;
        private Dictionary<String, List<Vector2>> wordLocations;
        private bool isValid;

        public WordSearchPuzzle()
        {
            Words = new List<String>();
            Letters = new Dictionary<Vector2, Char>();

            searchDirectionStrategy = new Dictionary<DirectionEnum, IGetNeighborsFrom>();
            searchDirectionStrategy.Add(DirectionEnum.Up, new UpGetNeighborsFrom());
            searchDirectionStrategy.Add(DirectionEnum.Down, new DownGetNeighborsFrom());
            searchDirectionStrategy.Add(DirectionEnum.Left, new LeftGetNeighborsFrom());
            searchDirectionStrategy.Add(DirectionEnum.Right, new RightGetNeighborsFrom());
            searchDirectionStrategy.Add(DirectionEnum.UpLeft, new UpLeftGetNeighborsFrom());
            searchDirectionStrategy.Add(DirectionEnum.UpRight, new UpRightGetNeighborsFrom());
            searchDirectionStrategy.Add(DirectionEnum.DownLeft, new DownLeftGetNeighborsFrom());
            searchDirectionStrategy.Add(DirectionEnum.DownRight, new DownRightGetNeighborsFrom());

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

        private List<Vector2> SearchWordInDirection(String word, IGetNeighborsFrom searchDirection)
        {
            List<Vector2> wordPosition = new List<Vector2>();
            List<Vector2> firstLetterPositions = FindAllLetterPositions(word[FIRST_LETTER_OF_WORD_INDEX]);

            foreach (Vector2 position in firstLetterPositions)
            {
                searchDirection.AddPositionToLettersDictionary(Letters);
                List<Vector2> candidate = searchDirection.GetNeighborsFrom(position, word.Length);
                String foundWord = FindWordFromPositions(candidate);

                if (word.Equals(foundWord))
                {
                    wordPosition.AddRange(candidate);
                }
            }

            return wordPosition;
        }

        private List<Vector2> FindAllLetterPositions(Char letter)
        {
            List<Vector2> positions = Letters.Where(kvp => kvp.Value == letter).Select(kvp => kvp.Key).ToList();
            return positions;
        }

        private String FindWordFromPositions(List<Vector2> positions)
        {
            Char[] candidateLetters = positions.Select(key => Letters[key]).ToArray();

            return new String(candidateLetters);
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
                        List<List<Vector2>> wordDirections = SearchAllDirections(word);
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

        private List<List<Vector2>> SearchAllDirections(String word)
        {
            List<List<Vector2>> wordDirections = new List<List<Vector2>>();

            foreach(DirectionEnum direction in Enum.GetValues(typeof(DirectionEnum)))
            {
                wordDirections.Add(SearchWordInDirection(word, searchDirectionStrategy[direction]));
            }

            return wordDirections;
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
