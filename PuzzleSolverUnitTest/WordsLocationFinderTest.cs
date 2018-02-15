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

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), ValidOneWordPuzzleTestCase)]
        public void Given4x4WordPuzzleWith2WordsOneOfWhichIsNotInThePuzzleWhenCallingGetWordsLocationsThenGetWordsLicationsReturnsAnEmptyDictionary(WordSearchPuzzle puzzle)
        {
            puzzle.AddWord("KHAN");

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation(puzzle);
            Dictionary<String, List<Vector2>> expected = new Dictionary<string, List<Vector2>>();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), OneUpWordTestCase)]
        public void Given4x4WordWithOneUpWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation(puzzle);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), TwoWordsUpTestCase)]
        public void Given4x4WordWithTwoUpWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRKAndKHAN(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("KHAN");
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation(puzzle);

            List<Vector2> khanLocation = new List<Vector2>();
            khanLocation.Add(new Vector2(3, 3));
            khanLocation.Add(new Vector2(3, 2));
            khanLocation.Add(new Vector2(3, 1));
            khanLocation.Add(new Vector2(3, 0));
            expected.Add("KHAN", khanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), DownWordTestCase)]
        public void Given4x4WordWithOneDownWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation(puzzle);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), DownWordTestCase)]
        public void Given4x4WordWithTwoDownWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("KHAN");
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation(puzzle);

            List<Vector2> khanLocation = new List<Vector2>();
            khanLocation.Add(new Vector2(3, 0));
            khanLocation.Add(new Vector2(3, 1));
            khanLocation.Add(new Vector2(3, 2));
            khanLocation.Add(new Vector2(3, 3));
            expected.Add("KHAN", khanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), OneUpOneDownWordTestCase)]
        public void Given4x4WordWithUpAndDownWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation(puzzle);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), LeftWordTestCase)]
        public void Given4x4WordWithOneLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation(puzzle);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), LeftWordTestCase)]
        public void Given4x4WordWithTwoLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("KHAN");
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation(puzzle);

            List<Vector2> khanLocation = new List<Vector2>();
            khanLocation.Add(new Vector2(3, 3));
            khanLocation.Add(new Vector2(2, 3));
            khanLocation.Add(new Vector2(1, 3));
            khanLocation.Add(new Vector2(0, 3));
            expected.Add("KHAN", khanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), RightWordTestCase)]
        public void Given4x4WordWithOneRightWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation(puzzle);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), RightWordTestCase)]
        public void Given4x4WordWithTwoRightWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("KHAN");
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation(puzzle);

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
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation(puzzle);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), UpLeftWordTestCase)]
        public void Given4x4WordWithTwoUpLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("HAN");
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation(puzzle);

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
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation(puzzle);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), UpRightWordTestCase)]
        public void Given4x4WordWithOneTwoUpRightWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("HAN");
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation(puzzle);

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
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation(puzzle);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), DownLeftWordTestCase)]
        public void Given4x4WordWithTwoDownLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("HAN");
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation(puzzle);

            List<Vector2> hanLocation = new List<Vector2>();
            hanLocation.Add(new Vector2(3, 1));
            hanLocation.Add(new Vector2(2, 2));
            hanLocation.Add(new Vector2(1, 3));
            expected.Add("HAN", hanLocation);

            Assert.AreEqual(expected, result);
        }
    }
}
