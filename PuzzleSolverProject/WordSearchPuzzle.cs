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

        public WordSearchPuzzle()
        {
            Words = new List<String>();
            Dimensions = new Vector2();
        }
        public void AddWord(String word)
        {
            Words.Add(word);
        }

        public void SetDimensions(int x, int y)
        {
            Dimensions = new Vector2(x, y);
        }
    }
}
