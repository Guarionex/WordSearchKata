using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject
{
    public class WordsMapDecorator : Dictionary<String, List<Vector2>>
    {
        private WordsLocationFinder wordsFinder;

        public WordsMapDecorator(WordsLocationFinder wordsLocationFinder)
        {
            this.wordsFinder = wordsLocationFinder;
        }
    }
}
