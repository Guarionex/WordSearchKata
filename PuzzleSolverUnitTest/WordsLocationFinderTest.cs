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
    public class WordsLocationFinderTest
    {
        private const String ValidOneWordPuzzleTestCase = nameof(WordLocationFinderTestData.ValidOneWordPuzzleTestCase);

        private WordsLocationFinder sut;

        [SetUp]
        public void init()
        {
            sut = new WordsLocationFinder();
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), ValidOneWordPuzzleTestCase)]
        public void Given4x4WordWithTwoWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringListVector2Dictionary(WordSearchPuzzle puzzle)
        {
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation(puzzle);
            Assert.IsInstanceOf(typeof(Dictionary<String, List<Vector2>>), result);
        }
    }
}
