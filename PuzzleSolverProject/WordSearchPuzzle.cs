using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject
{
    public class WordSearchPuzzle
    {
        private List<String> words = new List<string>();
        public void AddWord(String word)
        {
            words.Add(word);
        }

        public List<String> GetWords()
        {
            return words;
        }
    }
}
