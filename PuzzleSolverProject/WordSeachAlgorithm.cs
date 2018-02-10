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

        private Dictionary<Vector2, Char> LettersMap;
        private Dictionary<DirectionEnum, IGetNeighborsFrom> searchDirectionStrategy;

        public WordSeachAlgorithm(Dictionary<Vector2, Char> lettersMap)
        {
            LettersMap = lettersMap;

            searchDirectionStrategy = new Dictionary<DirectionEnum, IGetNeighborsFrom>();
            searchDirectionStrategy.Add(DirectionEnum.Up, new UpGetNeighborsFrom());
            searchDirectionStrategy.Add(DirectionEnum.Down, new DownGetNeighborsFrom());
            searchDirectionStrategy.Add(DirectionEnum.Left, new LeftGetNeighborsFrom());
            searchDirectionStrategy.Add(DirectionEnum.Right, new RightGetNeighborsFrom());
            searchDirectionStrategy.Add(DirectionEnum.UpLeft, new UpLeftGetNeighborsFrom());
            searchDirectionStrategy.Add(DirectionEnum.UpRight, new UpRightGetNeighborsFrom());
            searchDirectionStrategy.Add(DirectionEnum.DownLeft, new DownLeftGetNeighborsFrom());
            searchDirectionStrategy.Add(DirectionEnum.DownRight, new DownRightGetNeighborsFrom());
        }

        public Dictionary<String, List<Vector2>> SearchEachWord(List<String> words)
        {
            Dictionary<String, List<Vector2>> wordMap = new Dictionary<string, List<Vector2>>();
            foreach (String word in words)
            {
                List<List<Vector2>> wordDirections = SearchAllDirections(word);
                List<Vector2> foundWordLocation = wordDirections.Single(dircetion => dircetion.Count > INVALID_COUNT);
                wordMap.Add(word, foundWordLocation);
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

        private List<Vector2> SearchWordInDirection(String word, IGetNeighborsFrom searchDirection)
        {
            List<Vector2> wordPosition = new List<Vector2>();
            List<Vector2> firstLetterPositions = FindAllLetterPositions(word[FIRST_LETTER_OF_WORD_INDEX]);

            foreach (Vector2 position in firstLetterPositions)
            {
                searchDirection.AddPositionToLettersDictionary(LettersMap);
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
            List<Vector2> positions = LettersMap.Where(kvp => kvp.Value == letter).Select(kvp => kvp.Key).ToList();
            return positions;
        }

        private String FindWordFromPositions(List<Vector2> positions)
        {
            Char[] candidateLetters = positions.Select(key => LettersMap[key]).ToArray();

            return new String(candidateLetters);
        }
    }
}
