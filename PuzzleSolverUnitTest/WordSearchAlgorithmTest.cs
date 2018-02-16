using NUnit.Framework;
using PuzzleSolverProject;
using PuzzleSolverProject.DirectionSearchStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverUnitTest
{
    [TestFixture]
    public class WordSearchAlgorithmTest
    {
        private const String ValidOneWordPuzzleTestCase = nameof(WordSearchAlgorithmTestData.ValidOneWordPuzzleTestCase);
        private const String PuzzleWithNoWordsAddedTestCase = nameof(WordSearchAlgorithmTestData.PuzzleWithNoWordsAddedTestCase);
        private const String OneUpWordTestCase = nameof(WordSearchAlgorithmTestData.OneUpWordTestCase);
        private const String TwoWordsUpTestCase = nameof(WordSearchAlgorithmTestData.TwoWordsUpTestCase);
        private const String DownWordTestCase = nameof(WordSearchAlgorithmTestData.DownWordTestCase);
        private const String OneUpOneDownWordTestCase = nameof(WordSearchAlgorithmTestData.OneUpOneDownWordTestCase);
        private const String LeftWordTestCase = nameof(WordSearchAlgorithmTestData.LeftWordTestCase);
        private const String RightWordTestCase = nameof(WordSearchAlgorithmTestData.RightWordTestCase);
        private const String UpLeftWordTestCase = nameof(WordSearchAlgorithmTestData.UpLeftWordTestCase);
        private const String UpRightWordTestCase = nameof(WordSearchAlgorithmTestData.UpRightWordTestCase);
        private const String DownLeftWordTestCase = nameof(WordSearchAlgorithmTestData.DownLeftWordTestCase);
        private const String DownRightWordTestCase = nameof(WordSearchAlgorithmTestData.DownRightWordTestCase);
        private const String PuzzleWithWordTwiceTestCase = nameof(WordSearchAlgorithmTestData.PuzzleWithWordTwiceTestCase);

        private WordSearchAlgorithm sut;

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), ValidOneWordPuzzleTestCase)]
        public void Given4x4WordWithTwoWordsPuzzleWhenCallingSearchEachWordsThenSearchEachWordReturnsAStringListVector2Dictionary(WordSearchPuzzle puzzle)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();
            Assert.IsInstanceOf(typeof(Dictionary<String, List<Vector2>>), result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), PuzzleWithNoWordsAddedTestCase)]
        public void Given4x4WordPuzzleWithWordNotInPuzzleWhenCallingSearchEachWordsThenSearchEachWordLicationsThrowsNoException(WordSearchPuzzle puzzle)
        {
            puzzle.AddWord("UHURA");

            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            sut.SearchEachWord();
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), ValidOneWordPuzzleTestCase)]
        public void Given4x4WordPuzzleWith2WordsOneOfWhichIsNotInThePuzzleWhenCallingSearchEachWordsThenSearchEachWordLicationsReturnsAnEmptyDictionary(WordSearchPuzzle puzzle)
        {
            puzzle.AddWord("KHAN");
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();
            Dictionary<String, List<Vector2>> expected = new Dictionary<string, List<Vector2>>();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), OneUpWordTestCase)]
        public void Given4x4WordWithOneUpWordsPuzzleWhenCallingSearchEachWordsThenSearchEachWordReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), TwoWordsUpTestCase)]
        public void Given4x4WordWithTwoUpWordsPuzzleWhenCallingSearchEachWordsThenSearchEachWordReturnsAStringVector2DictionaryWithEntryForKIRKAndKHAN(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("KHAN");

            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            List<Vector2> khanLocation = new List<Vector2>();
            khanLocation.Add(new Vector2(3, 3));
            khanLocation.Add(new Vector2(3, 2));
            khanLocation.Add(new Vector2(3, 1));
            khanLocation.Add(new Vector2(3, 0));
            expected.Add("KHAN", khanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), DownWordTestCase)]
        public void Given4x4WordWithOneDownWordsPuzzleWhenCallingSearchEachWordsThenSearchEachWordReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), DownWordTestCase)]
        public void Given4x4WordWithTwoDownWordsPuzzleWhenCallingSearchEachWordsThenSearchEachWordReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("KHAN");

            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            List<Vector2> khanLocation = new List<Vector2>();
            khanLocation.Add(new Vector2(3, 0));
            khanLocation.Add(new Vector2(3, 1));
            khanLocation.Add(new Vector2(3, 2));
            khanLocation.Add(new Vector2(3, 3));
            expected.Add("KHAN", khanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), OneUpOneDownWordTestCase)]
        public void Given4x4WordWithUpAndDownWordsPuzzleWhenCallingSearchEachWordsThenSearchEachWordReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), LeftWordTestCase)]
        public void Given4x4WordWithOneLeftWordsPuzzleWhenCallingSearchEachWordsThenSearchEachWordReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), LeftWordTestCase)]
        public void Given4x4WordWithTwoLeftWordsPuzzleWhenCallingSearchEachWordsThenSearchEachWordReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("KHAN");
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            List<Vector2> khanLocation = new List<Vector2>();
            khanLocation.Add(new Vector2(3, 3));
            khanLocation.Add(new Vector2(2, 3));
            khanLocation.Add(new Vector2(1, 3));
            khanLocation.Add(new Vector2(0, 3));
            expected.Add("KHAN", khanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), RightWordTestCase)]
        public void Given4x4WordWithOneRightWordsPuzzleWhenCallingSearchEachWordsThenSearchEachWordReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), RightWordTestCase)]
        public void Given4x4WordWithTwoRightWordsPuzzleWhenCallingSearchEachWordsThenSearchEachWordReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("KHAN");
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            List<Vector2> khanLocation = new List<Vector2>();
            khanLocation.Add(new Vector2(0, 3));
            khanLocation.Add(new Vector2(1, 3));
            khanLocation.Add(new Vector2(2, 3));
            khanLocation.Add(new Vector2(3, 3));
            expected.Add("KHAN", khanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), UpLeftWordTestCase)]
        public void Given4x4WordWithOneUpLeftWordsPuzzleWhenCallingSearchEachWordsThenSearchEachWordReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), UpLeftWordTestCase)]
        public void Given4x4WordWithTwoUpLeftWordsPuzzleWhenCallingSearchEachWordsThenSearchEachWordReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("HAN");
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            List<Vector2> hanLocation = new List<Vector2>();
            hanLocation.Add(new Vector2(2, 3));
            hanLocation.Add(new Vector2(1, 2));
            hanLocation.Add(new Vector2(0, 1));
            expected.Add("HAN", hanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), UpRightWordTestCase)]
        public void Given4x4WordWithOneUpRightWordsPuzzleWhenCallingSearchEachWordsThenSearchEachWordReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), UpRightWordTestCase)]
        public void Given4x4WordWithOneTwoUpRightWordsPuzzleWhenCallingSearchEachWordsThenSearchEachWordReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("HAN");
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            List<Vector2> hanLocation = new List<Vector2>();
            hanLocation.Add(new Vector2(0, 2));
            hanLocation.Add(new Vector2(1, 1));
            hanLocation.Add(new Vector2(2, 0));
            expected.Add("HAN", hanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), DownLeftWordTestCase)]
        public void Given4x4WordWithOneDownLeftWordsPuzzleWhenCallingSearchEachWordsThenSearchEachWordReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), DownLeftWordTestCase)]
        public void Given4x4WordWithTwoDownLeftWordsPuzzleWhenCallingSearchEachWordsThenSearchEachWordReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("HAN");
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            List<Vector2> hanLocation = new List<Vector2>();
            hanLocation.Add(new Vector2(3, 1));
            hanLocation.Add(new Vector2(2, 2));
            hanLocation.Add(new Vector2(1, 3));
            expected.Add("HAN", hanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), DownRightWordTestCase)]
        public void Given4x4WordWithOneDownRightWordsPuzzleWhenCallingSearchEachWordsThenSearchEachWordReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), DownRightWordTestCase)]
        public void Given4x4WordWithTwoDownRightWordsPuzzleWhenCallingSearchEachWordsThenSearchEachWordReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("HAN");
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            List<Vector2> hanLocation = new List<Vector2>();
            hanLocation.Add(new Vector2(0, 1));
            hanLocation.Add(new Vector2(1, 2));
            hanLocation.Add(new Vector2(2, 3));
            expected.Add("HAN", hanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), ValidOneWordPuzzleTestCase)]
        public void GivenValid4x4WordPuzzleWithWordsWhenCallingSearchEachWordThenSearchEachWordReturnsDictionaryWithElements(WordSearchPuzzle puzzle)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            Assert.IsNotEmpty(result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), PuzzleWithNoWordsAddedTestCase)]
        public void Given4x4WordPuzzleWithMissingWordWhenCallingSearchEachWordThenSearchEachWordReturnsEmptyDictionary(WordSearchPuzzle puzzle)
        {
            puzzle.AddWord("UHURA");
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            Assert.IsEmpty(result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), PuzzleWithWordTwiceTestCase)]
        public void Given4x4WordPuzzleWithWordTwiceWhenCallingSearchEachWordThenSearchEachWordReturnsEmptyDictionary(WordSearchPuzzle puzzle)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            Assert.IsEmpty(result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), ValidOneWordPuzzleTestCase)]
        public void Given4x4WordPuzzleWithWordAddedTwiceWhenCallingSearchEachWordThenSearchEachWordReturnsEmptyDictionary(WordSearchPuzzle puzzle)
        {
            puzzle.AddWord("KIRK");
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            Assert.IsEmpty(result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), PuzzleWithNoWordsAddedTestCase)]
        public void GivenInvalid4x4WordPuzzleWhenCallingSearchEachWordTwiceThenSecondSearchEachWordReturnsEmptyDictionary(WordSearchPuzzle puzzle)
        {
            puzzle.AddWord("UHURA");

            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);
            sut.SearchEachWord();

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            Assert.IsEmpty(result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), PuzzleWithNoWordsAddedTestCase)]
        public void Given4x4WordPuzzleWithoutWordsWhenCallingSearchEachWordThenSearchEachWordReturnsEmptyDictionary(WordSearchPuzzle puzzle)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            Assert.IsEmpty(result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), PuzzleWithNoWordsAddedTestCase)]
        public void Given4x4WordPuzzleWithoutWordsWhenCallingSearchEachWordAddingAWordThenCallingSearchEachWordAgainReturnsDictionaryWithElements(WordSearchPuzzle puzzle)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);
            sut.SearchEachWord();
            puzzle.AddWord("KIRK");

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            Assert.IsNotEmpty(result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), DownRightWordTestCase)]
        public void GivenValid4x4WordPuzzleWhenCallingSearchEachWordThenSearchEachWordReturnsAllWordsLocations(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory, puzzle.WordsList);
            sut.SearchEachWord();

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord();

            Assert.AreEqual(expected, result);
        }
    }
}
