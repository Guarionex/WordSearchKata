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
        private Dictionary<String, List<Vector2>> wordsMap;

        public WordsMapDecorator(Dictionary<String, List<Vector2>> wordsMap)
        {
            this.wordsMap = wordsMap;
        }

        public void IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
