using NUnit.Framework;
using PuzzleSolverProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverUnitTest
{
    [TestFixture]
    public class WordsMapDecoratorTest
    {
        private WordsMapDecorator sut;

        [Test]
        public void GivenWordsMapDictionaryFinderWhenPassToWordsMapDecoratorConstructorThenThrowNoException()
        {
            Dictionary<String, List<Vector2>> wordsMap = new Dictionary<string, List<Vector2>>();

            sut = new WordsMapDecorator(wordsMap);
        }
    }
}
