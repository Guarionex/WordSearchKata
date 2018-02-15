using NUnit.Framework;
using PuzzleSolverProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PuzzleSolverUnitTest
{
    [TestFixture]
    public class WordSearchPuzzleTest
    {
        private const String ValidOneWordPuzzleTestCase = nameof(WordSearchPuzzleTestData.ValidOneWordPuzzleTestCase);
        private const String OneUpWordTestCase = nameof(WordSearchPuzzleTestData.OneUpWordTestCase);
        private const String TwoWordsUpTestCase = nameof(WordSearchPuzzleTestData.TwoWordsUpTestCase);
        private const String DownWordTestCase = nameof(WordSearchPuzzleTestData.DownWordTestCase);
        private const String OneUpOneDownWordTestCase = nameof(WordSearchPuzzleTestData.OneUpOneDownWordTestCase);
        private const String LeftWordTestCase = nameof(WordSearchPuzzleTestData.LeftWordTestCase);
        private const String RightWordTestCase = nameof(WordSearchPuzzleTestData.RightWordTestCase);
        private const String UpLeftWordTestCase = nameof(WordSearchPuzzleTestData.UpLeftWordTestCase);
        private const String UpRightWordTestCase = nameof(WordSearchPuzzleTestData.UpRightWordTestCase);
        private const String DownLeftWordTestCase = nameof(WordSearchPuzzleTestData.DownLeftWordTestCase);
        private const String DownRightWordTestCase = nameof(WordSearchPuzzleTestData.DownRightWordTestCase);
        private const String PuzzleWithWordTwiceTestCase = nameof(WordSearchPuzzleTestData.PuzzleWithWordTwiceTestCase);
        private const String PuzzleWithNoWordsAddedTestCase = nameof(WordSearchPuzzleTestData.PuzzleWithNoWordsAddedTestCase);

        private WordSearchPuzzle sut;

        [SetUp]
        public void init()
        {
            sut = new WordSearchPuzzle();
        }

        [Test]
        public void GivenWordSearchPuzzleWhenAddWordIsPassedAStringThenAddWordThrowsNoException()
        {
            sut.AddWord("PILLAR");
        }

        [Test]
        public void GivenWordSearchPuzleWhenCallingWordsThenGetWordsReturnAListOfStrings()
        {
            List<String> result = sut.WordsList;
            Assert.IsInstanceOf(typeof(List<String>), result);
        }

        [Test]
        public void GivenWordSearchPuzzleWithAWordAddedWhenCallingGetWordThenGetWordReturnsAListOfStringWithTheAddedWord()
        {
            sut.AddWord("PILLAR");
            List<String> result = sut.WordsList;
            List<String> expected = new List<String>();
            expected.Add("PILLAR");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenWordSearchPuzzleWithMultipleWordsAddedWhenCallingGetWordThenGetWordReturnsAListOfStringWithTheAddedWords()
        {
            sut.AddWord("PILLAR");
            sut.AddWord("TDD");
            List<String> result = sut.WordsList;
            List<String> expected = new List<String>();
            expected.Add("PILLAR");
            expected.Add("TDD");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenWordSearchPuzzleWhenCallingAddLetterAtWithCharXAt0x0ThenAddLetterAtThrowsNoException()
        {
            sut.AddLetterAt('X', 2, 2);
        }

        [Test]
        public void GivenWordSearchPuzzleWhenCallingLettersThenLettersReturnsADictionaryOfVector2KeysWithCharValues()
        {
            Dictionary<Vector2, Char> result = sut.LettersMap;
            Assert.IsInstanceOf(typeof(Dictionary<Vector2, Char>), result);
        }

        [Test]
        public void GivenWordSearchPuzzleWithLetterXAddedAt2x2WhenCallingLettersThenLettersReturnsADictionaryOfVector2KeysWithCharValuesWithTheAddedLetterAtTt2x2()
        {
            sut.AddLetterAt('X', 2, 2);
            Dictionary<Vector2, Char> result = sut.LettersMap;
            Dictionary<Vector2, Char> expected = new Dictionary<Vector2, Char>();
            expected.Add(new Vector2(2, 2), 'X');

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenWordSearchPuzzleWithMultipleLetterAddedWhenCallingLettersThenLettersReturnsADictionaryOfVector2KeysWithCharValuesWithTheAddedLetters()
        {
            sut.AddLetterAt('X', 2, 2);
            sut.AddLetterAt('P', 0, 0);
            Dictionary<Vector2, Char> result = sut.LettersMap;
            Dictionary<Vector2, Char> expected = new Dictionary<Vector2, Char>();
            expected.Add(new Vector2(2, 2), 'X');
            expected.Add(new Vector2(0, 0), 'P');

            Assert.AreEqual(expected, result);
        }
    }
}
