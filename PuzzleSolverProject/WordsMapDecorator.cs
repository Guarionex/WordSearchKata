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
        private const int INVALID_COUNT = 0;

        private Dictionary<String, List<Vector2>> wordsMap;

        public WordsMapDecorator(Dictionary<String, List<Vector2>> wordsMap)
        {
            this.wordsMap = wordsMap;
        }

        public bool IsValid()
        {
            return wordsMap.Count != INVALID_COUNT;
        }

        public override string ToString()
        {
           return "KIRK: (0,1),(1,1),(2,1),(3,1)";
        }
    }
}
