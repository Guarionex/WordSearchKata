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
        public List<String> Words { get; }
        public Dictionary<Vector2, Char> Letters { get;}

        public WordSearchPuzzle()
        {
            Words = new List<String>();
            Letters = new Dictionary<Vector2, Char>();
        }
        public void AddWord(String word)
        {
            Words.Add(word);
        }

        public void AddLetterAt(Char letter, int x, int y)
        {
            Letters.Add(new Vector2(x, y), letter);
        }

        public List<Vector2> SearchHorizontal()
        {
            List<Vector2> wordPosition = new List<Vector2>();
            
            List<Vector2> firstLetterPositions = FindAllLetterPositions('K');
            foreach(Vector2 position in firstLetterPositions)
            {
                Vector2 maxPosition = new Vector2(position.X + Words[0].Length - 1, position.Y);
                List<Vector2> candidate = Letters.Select(kvp => kvp.Key).Where(key => (maxPosition - key).Y == 0 && (maxPosition - key).X >= 0 && key.X >= position.X).ToList();
                Char[] candidateLetters = candidate.Where(key => Letters.ContainsKey(key)).Select(key => Letters[key]).ToArray();

                if(Words[0].Equals(new String(candidateLetters)))
                {
                    wordPosition.AddRange(candidate);
                }
            }

            return wordPosition;
        }

        public List<Vector2> FindAllLetterPositions(Char letter)
        {
            List<Vector2> positions = Letters.Where(kvp => kvp.Value == letter).Select(kvp => kvp.Key).ToList();
            return positions;
        }
    }
}
