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

        private WordSearchAlgorithm sut;

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), ValidOneWordPuzzleTestCase)]
        public void Given4x4WordWithTwoWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringListVector2Dictionary(WordSearchPuzzle puzzle)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory.CreateStrategies());

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord(puzzle.WordsList);
            Assert.IsInstanceOf(typeof(Dictionary<String, List<Vector2>>), result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), PuzzleWithNoWordsAddedTestCase)]
        public void Given4x4WordPuzzleWithWordNotInPuzzleWhenCallingGetWordsLocationsThenGetWordsLicationsThrowsNoException(WordSearchPuzzle puzzle)
        {
            puzzle.AddWord("UHURA");

            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory.CreateStrategies());

            sut.SearchEachWord(puzzle.WordsList);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), ValidOneWordPuzzleTestCase)]
        public void Given4x4WordPuzzleWith2WordsOneOfWhichIsNotInThePuzzleWhenCallingGetWordsLocationsThenGetWordsLicationsReturnsAnEmptyDictionary(WordSearchPuzzle puzzle)
        {
            puzzle.AddWord("KHAN");
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory.CreateStrategies());

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord(puzzle.WordsList);
            Dictionary<String, List<Vector2>> expected = new Dictionary<string, List<Vector2>>();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), OneUpWordTestCase)]
        public void Given4x4WordWithOneUpWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory.CreateStrategies());

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord(puzzle.WordsList);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), TwoWordsUpTestCase)]
        public void Given4x4WordWithTwoUpWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRKAndKHAN(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("KHAN");

            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory.CreateStrategies());

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord(puzzle.WordsList);

            List<Vector2> khanLocation = new List<Vector2>();
            khanLocation.Add(new Vector2(3, 3));
            khanLocation.Add(new Vector2(3, 2));
            khanLocation.Add(new Vector2(3, 1));
            khanLocation.Add(new Vector2(3, 0));
            expected.Add("KHAN", khanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), DownWordTestCase)]
        public void Given4x4WordWithOneDownWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory.CreateStrategies());

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord(puzzle.WordsList);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), DownWordTestCase)]
        public void Given4x4WordWithTwoDownWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("KHAN");

            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory.CreateStrategies());

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord(puzzle.WordsList);

            List<Vector2> khanLocation = new List<Vector2>();
            khanLocation.Add(new Vector2(3, 0));
            khanLocation.Add(new Vector2(3, 1));
            khanLocation.Add(new Vector2(3, 2));
            khanLocation.Add(new Vector2(3, 3));
            expected.Add("KHAN", khanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), OneUpOneDownWordTestCase)]
        public void Given4x4WordWithUpAndDownWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory.CreateStrategies());

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord(puzzle.WordsList);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), LeftWordTestCase)]
        public void Given4x4WordWithOneLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory.CreateStrategies());

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord(puzzle.WordsList);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), LeftWordTestCase)]
        public void Given4x4WordWithTwoLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            puzzle.AddWord("KHAN");
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory.CreateStrategies());

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord(puzzle.WordsList);

            List<Vector2> khanLocation = new List<Vector2>();
            khanLocation.Add(new Vector2(3, 3));
            khanLocation.Add(new Vector2(2, 3));
            khanLocation.Add(new Vector2(1, 3));
            khanLocation.Add(new Vector2(0, 3));
            expected.Add("KHAN", khanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), RightWordTestCase)]
        public void Given4x4WordWithOneRightWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle puzzle, Dictionary<String, List<Vector2>> expected)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory.CreateStrategies());

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord(puzzle.WordsList);

            Assert.AreEqual(expected, result);
        }
    }
}
