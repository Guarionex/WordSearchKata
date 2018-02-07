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
            List<Vector2> expected = new List<Vector2>();
            expected.Add(new Vector2(0, 3));
            expected.Add(new Vector2(1, 3));
            expected.Add(new Vector2(2, 3));
            expected.Add(new Vector2(3, 3));
            return expected;
        }
    }
}
