using NUnit.Framework;
using PuzzleSolverProject;
using System;
using System.Collections.Generic;
using System.IO;
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

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), ValidOneWordPuzzleTestCase)]
        public void GivenValidPuzzleWhenCallingGetWordsMapThenGetWordsMapDoesNotReturnNull(WordSearchPuzzle puzzle)
        {
            sut = new WordsLocationFinder(puzzle);

            sut.GetWordsMap();
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), ValidOneWordPuzzleTestCase)]
        public void GivenValidPuzzleWhenCallingGetWordsMapThenGetWordsMapReturnsAWordsMapDecorator(WordSearchPuzzle puzzle)
        {
            sut = new WordsLocationFinder(puzzle);

            WordsMapDecorator result = sut.GetWordsMap();

            Assert.IsInstanceOf<WordsMapDecorator>(result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), OneUpWordTestCase)]
        public void GivenValidPuzzleWithOneWhenCallingGetWordsMapThenGetWordsMapReturnsAWordsMapDecoratorWithOneWord(WordSearchPuzzle puzzle, WordsMapDecorator expected)
        {
            sut = new WordsLocationFinder(puzzle);

            WordsMapDecorator result = sut.GetWordsMap();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), TwoWordsUpTestCase)]
        public void GivenValidPuzzleWithTwoWordsWhenCallingGetWordsMapThenGetWordsMapReturnsAWordsMapDecoratorWithTwoWords(WordSearchPuzzle puzzle, WordsMapDecorator expected)
        {
            sut = new WordsLocationFinder(puzzle);

            WordsMapDecorator result = sut.GetWordsMap();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordLocationFinderTestData), PuzzleWithNoWordsAddedTestCase)]
        public void GivenInvalidPuzzleWhenCallingGetWordsMapThenGetWordsMapThrowsInvalidDataException(WordSearchPuzzle puzzle)
        {
            sut = new WordsLocationFinder(puzzle);

            Assert.Throws<InvalidDataException>(new TestDelegate(GetWordsMapInvalidPuzzle));
        }

        private void GetWordsMapInvalidPuzzle()
        {
            sut.GetWordsMap();
        }
    }
}
