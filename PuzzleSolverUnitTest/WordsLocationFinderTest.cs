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

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), RightWordTestCase)]
        public void Given4x4WordWithTwoRightWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("KHAN");

            sut = new WordsLocationFinder(puzzle);
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            List<Vector2> khanLocation = new List<Vector2>();
            khanLocation.Add(new Vector2(0, 3));
            khanLocation.Add(new Vector2(1, 3));
            khanLocation.Add(new Vector2(2, 3));
            khanLocation.Add(new Vector2(3, 3));
            expected.Add("KHAN", khanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), UpLeftWordTestCase)]
        public void Given4x4WordWithOneUpLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            sut = new WordsLocationFinder(puzzle);
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), UpLeftWordTestCase)]
        public void Given4x4WordWithTwoUpLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("HAN");

            sut = new WordsLocationFinder(puzzle);
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            List<Vector2> hanLocation = new List<Vector2>();
            hanLocation.Add(new Vector2(2, 3));
            hanLocation.Add(new Vector2(1, 2));
            hanLocation.Add(new Vector2(0, 1));
            expected.Add("HAN", hanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), UpRightWordTestCase)]
        public void Given4x4WordWithOneUpRightWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            sut = new WordsLocationFinder(puzzle);
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), UpRightWordTestCase)]
        public void Given4x4WordWithOneTwoUpRightWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("HAN");

            sut = new WordsLocationFinder(puzzle);
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            List<Vector2> hanLocation = new List<Vector2>();
            hanLocation.Add(new Vector2(0, 2));
            hanLocation.Add(new Vector2(1, 1));
            hanLocation.Add(new Vector2(2, 0));
            expected.Add("HAN", hanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), DownLeftWordTestCase)]
        public void Given4x4WordWithOneDownLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            sut = new WordsLocationFinder(puzzle);
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), DownLeftWordTestCase)]
        public void Given4x4WordWithTwoDownLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("HAN");

            sut = new WordsLocationFinder(puzzle);
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            List<Vector2> hanLocation = new List<Vector2>();
            hanLocation.Add(new Vector2(3, 1));
            hanLocation.Add(new Vector2(2, 2));
            hanLocation.Add(new Vector2(1, 3));
            expected.Add("HAN", hanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), DownRightWordTestCase)]
        public void Given4x4WordWithOneDownRightWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            sut = new WordsLocationFinder(puzzle);
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), DownRightWordTestCase)]
        public void Given4x4WordWithTwoDownRightWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("HAN");

            sut = new WordsLocationFinder(puzzle);
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            List<Vector2> hanLocation = new List<Vector2>();
            hanLocation.Add(new Vector2(0, 1));
            hanLocation.Add(new Vector2(1, 2));
            hanLocation.Add(new Vector2(2, 3));
            expected.Add("HAN", hanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), ValidOneWordPuzzleTestCase)]
        public void GivenValid4x4WordPuzzleWithWordsWhenCallingGetWordsLocationThenGetWordsLocationReturnsDictionaryWithElements(WordSearchPuzzle puzzle)
        {
            sut = new WordsLocationFinder(puzzle);

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            Assert.IsNotEmpty(result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), PuzzleWithNoWordsAddedTestCase)]
        public void Given4x4WordPuzzleWithMissingWordWhenCallingGetWordsLocationThenGetWordsLocationReturnsEmptyDictionary(WordSearchPuzzle puzzle)
        {
            puzzle.AddWord("UHURA");

            sut = new WordsLocationFinder(puzzle);

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            Assert.IsEmpty(result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), PuzzleWithWordTwiceTestCase)]
        public void Given4x4WordPuzzleWithWordTwiceWhenCallingGetWordsLocationThenGetWordsLocationReturnsEmptyDictionary(WordSearchPuzzle puzzle)
        {
            sut = new WordsLocationFinder(puzzle);

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            Assert.IsEmpty(result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), ValidOneWordPuzzleTestCase)]
        public void Given4x4WordPuzzleWithWordAddedTwiceWhenCallingGetWordsLocationThenGetWordsLocationReturnsEmptyDictionary(WordSearchPuzzle puzzle)
        {
            puzzle.AddWord("KIRK");

            sut = new WordsLocationFinder(puzzle);

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            Assert.IsEmpty(result);
        }

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
