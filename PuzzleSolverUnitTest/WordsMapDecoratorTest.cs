using NUnit.Framework;
using PuzzleSolverProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverUnitTest
{
    [TestFixture]
    public class WordsMapDecoratorTest
    {
        private WordsMapDecorator sut;
        [Test]
        public void GivenWordsLocationFinderWhenPassToWordsMapDecoratorConstructorThenThrowNoException()
        {
            WordSearchPuzzle puzzle = new WordSearchPuzzle();
            WordsLocationFinder wordsFinder = new WordsLocationFinder(puzzle);

            sut = new WordsMapDecorator(wordsFinder);
        }
    }
}
