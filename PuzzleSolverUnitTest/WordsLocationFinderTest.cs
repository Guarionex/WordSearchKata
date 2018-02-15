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
        private const String PuzzleWithNoWordsAddedTestCase = nameof(WordLocationFinderTestData.PuzzleWithNoWordsAddedTestCase);

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


        [Test, TestCaseSource(typeof(WordLocationFinderTestData), PuzzleWithNoWordsAddedTestCase)]
        public void Given4x4WordPuzzleWithWordNotInPuzzleWhenCallingGetWordsLocationsThenGetWordsLicationsThrowsNoException(WordSearchPuzzle puzzle)
        {
            puzzle.AddWord("UHURA");

            sut.GetWordsLocation(puzzle);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), ValidOneWordPuzzleTestCase)]
        public void Given4x4WordPuzzleWith2WordsOneOfWhichIsNotInThePuzzleWhenCallingGetWordsLocationsThenGetWordsLicationsReturnsAnEmptyDictionary(WordSearchPuzzle puzzle)
        {
            puzzle.AddWord("KHAN");

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation(puzzle);
            Dictionary<String, List<Vector2>> expected = new Dictionary<string, List<Vector2>>();

            Assert.AreEqual(expected, result);
        }
    }
}
