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
        private const String OneUpWordTestCase = nameof(WordLocationFinderTestData.OneUpWordTestCase);
        private const String TwoWordsUpTestCase = nameof(WordLocationFinderTestData.TwoWordsUpTestCase);
        private const String DownWordTestCase = nameof(WordLocationFinderTestData.DownWordTestCase);
        private const String OneUpOneDownWordTestCase = nameof(WordLocationFinderTestData.OneUpOneDownWordTestCase);
        private const String LeftWordTestCase = nameof(WordLocationFinderTestData.LeftWordTestCase);
        private const String RightWordTestCase = nameof(WordLocationFinderTestData.RightWordTestCase);
        private const String UpLeftWordTestCase = nameof(WordLocationFinderTestData.UpLeftWordTestCase);
        private const String UpRightWordTestCase = nameof(WordLocationFinderTestData.UpRightWordTestCase);
        private const String DownLeftWordTestCase = nameof(WordLocationFinderTestData.DownLeftWordTestCase);
        private const String DownRightWordTestCase = nameof(WordLocationFinderTestData.DownRightWordTestCase);
        private const String PuzzleWithWordTwiceTestCase = nameof(WordLocationFinderTestData.PuzzleWithWordTwiceTestCase);

        private WordsLocationFinder sut;

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), PuzzleWithNoWordsAddedTestCase)]
        public void GivenInvalid4x4WordPuzzleWhenCallingGetWordsLocationTwiceThenSecondGetWordsLocationReturnsEmptyDictionary(WordSearchPuzzle puzzle)
        {
            puzzle.AddWord("UHURA");

            sut = new WordsLocationFinder(puzzle);
            sut.GetWordsLocation();

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            Assert.IsEmpty(result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), PuzzleWithNoWordsAddedTestCase)]
        public void Given4x4WordPuzzleWithoutWordsWhenCallingGetWordsLocationThenGetWordsLocationReturnsEmptyDictionary(WordSearchPuzzle puzzle)
        {
            sut = new WordsLocationFinder(puzzle);

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            Assert.IsEmpty(result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), PuzzleWithNoWordsAddedTestCase)]
        public void Given4x4WordPuzzleWithoutWordsWhenCallingGetWordsLocationAddingAWordThenCallingGetWordsLocationAgainReturnsDictionaryWithElements(WordSearchPuzzle puzzle)
        {
            sut = new WordsLocationFinder(puzzle);
            sut.GetWordsLocation();
            puzzle.AddWord("KIRK");

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            Assert.IsNotEmpty(result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), DownRightWordTestCase)]
        public void GivenValid4x4WordPuzzleWhenCallingGetWordsLocationThenGetWordsLocationReturnsAllWordsLocations(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            sut = new WordsLocationFinder(puzzle);
            sut.GetWordsLocation();

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            Assert.AreEqual(expected, result);
        }
    }
}
