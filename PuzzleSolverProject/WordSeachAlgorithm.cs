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
        private const int FIRST_LETTER_OF_WORD_INDEX = 0;

        private Dictionary<Vector2, Char> LettersMap;
        public WordSeachAlgorithm(Dictionary<Vector2, Char> lettersMap)
        {
            LettersMap = lettersMap;
        }

        public List<Vector2> SearchWordInDirection(String word, IGetNeighborsFrom searchDirection)
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
