using PuzzleSolverProject.GetNeighbors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject
{
    class WordSeachAlgorithm
    {
        private const int INVALID_COUNT = 0;
        private const int FIRST_LETTER_OF_WORD_INDEX = 0;

        private Dictionary<DirectionEnum, IDirectionSearchStrategy> searchDirectionStrategy;

        public WordSeachAlgorithm(WordSearchPuzzle puzzle)
        {
            DirectionSearchFactory getNeighborsFactory = new DirectionSearchFactory(puzzle);
            searchDirectionStrategy = getNeighborsFactory.GetNeighborStrategy;
        }

        public Dictionary<String, List<Vector2>> SearchEachWord(List<String> words)
        {
            Dictionary<String, List<Vector2>> wordMap = new Dictionary<string, List<Vector2>>();
            try
            {
                foreach (String word in words)
                {
                    List<List<Vector2>> wordDirections = SearchAllDirections(word);
                    List<Vector2> foundWordLocation = wordDirections.Single(dircetion => dircetion.Count > INVALID_COUNT);
                    wordMap.Add(word, foundWordLocation);
                }
            }
            catch(Exception e)
            {
                wordMap.Clear();
            }

            return wordMap;
        }

        private List<List<Vector2>> SearchAllDirections(String word)
        {
            List<List<Vector2>> wordDirections = new List<List<Vector2>>();
            foreach (DirectionEnum direction in Enum.GetValues(typeof(DirectionEnum)))
            {
                wordDirections.Add(SearchWordInDirection(word, searchDirectionStrategy[direction]));
            }

            return wordDirections;
        }

        private List<Vector2> SearchWordInDirection(String word, IDirectionSearchStrategy directionSearchStrategy)
        {
            List<Vector2> wordPosition = new List<Vector2>();
            List<Vector2> firstLetterLocations = directionSearchStrategy.GetAllLocationsOfLetter(word[FIRST_LETTER_OF_WORD_INDEX]);

            foreach (Vector2 location in firstLetterLocations)
            {
                List<Vector2> candidate = directionSearchStrategy.GetNeighborsFrom(location, word.Length);
                String foundWord = directionSearchStrategy.GetStringFromLocations(candidate);

                if (word.Equals(foundWord))
                {
                    wordPosition.AddRange(candidate);
                }
            }

            return wordPosition;
        }
    }
}
