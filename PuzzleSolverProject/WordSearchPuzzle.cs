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
        public Vector2 Dimensions { get; private set; }
        public Dictionary<Vector2, Char> Letters { get;}

        public WordSearchPuzzle()
        {
            Words = new List<String>();
            Dimensions = new Vector2();
            Letters = new Dictionary<Vector2, Char>();
        }
        public void AddWord(String word)
        {
            Words.Add(word);
        }

        public void SetDimensions(int x, int y)
        {
            Dimensions = new Vector2(x, y);
        }

        public void AddLetterAt(Char letter, int x, int y)
        {
            Letters.Add(new Vector2(2, 2), 'X');
        }
    }
}
