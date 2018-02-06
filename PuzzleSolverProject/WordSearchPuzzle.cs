using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject
{
    public class WordSearchPuzzle
    {
        public List<String> Words { get; }

        public WordSearchPuzzle()
        {
            Words = new List<String>();
        }
        public void AddWord(String word)
        {
            Words.Add(word);
        }

        public void SetDimensions(int x, int y)
        {
            
        }
    }
}
