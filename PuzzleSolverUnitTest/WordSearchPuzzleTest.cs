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

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), RightWordTestCase)]
        public void Given4x4WordWithTwoRightWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle setupSUT, Dictionary<String, List<Vector2>> expected)
        {
            sut = setupSUT;
            setupSUT.AddWord("KHAN");
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            List<Vector2> khanLocation = new List<Vector2>();
            khanLocation.Add(new Vector2(0, 3));
            khanLocation.Add(new Vector2(1, 3));
            khanLocation.Add(new Vector2(2, 3));
            khanLocation.Add(new Vector2(3, 3));
            expected.Add("KHAN", khanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), UpLeftWordTestCase)]
        public void Given4x4WordWithOneUpLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle setupSUT, Dictionary<String, List<Vector2>> expected)
        {
            sut = setupSUT;
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), UpLeftWordTestCase)]
        public void Given4x4WordWithTwoUpLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle setupSUT, Dictionary<String, List<Vector2>> expected)
        {
            sut = setupSUT;
            setupSUT.AddWord("HAN");
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            List<Vector2> hanLocation = new List<Vector2>();
            hanLocation.Add(new Vector2(2, 3));
            hanLocation.Add(new Vector2(1, 2));
            hanLocation.Add(new Vector2(0, 1));
            expected.Add("HAN", hanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), UpRightWordTestCase)]
        public void Given4x4WordWithOneUpRightWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle setupSUT, Dictionary<String, List<Vector2>> expected)
        {
            sut = setupSUT;
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), UpRightWordTestCase)]
        public void Given4x4WordWithOneTwoUpRightWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle setupSUT, Dictionary<String, List<Vector2>> expected)
        {
            sut = setupSUT;
            setupSUT.AddWord("HAN");
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            List<Vector2> hanLocation = new List<Vector2>();
            hanLocation.Add(new Vector2(0, 2));
            hanLocation.Add(new Vector2(1, 1));
            hanLocation.Add(new Vector2(2, 0));
            expected.Add("HAN", hanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), DownLeftWordTestCase)]
        public void Given4x4WordWithOneDownLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle setupSUT, Dictionary<String, List<Vector2>> expected)
        {
            sut = setupSUT;
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), DownLeftWordTestCase)]
        public void Given4x4WordWithTwoDownLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle setupSUT, Dictionary<String, List<Vector2>> expected)
        {
            sut = setupSUT;
            setupSUT.AddWord("HAN");
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            List<Vector2> hanLocation = new List<Vector2>();
            hanLocation.Add(new Vector2(3, 1));
            hanLocation.Add(new Vector2(2, 2));
            hanLocation.Add(new Vector2(1, 3));
            expected.Add("HAN", hanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), DownRightWordTestCase)]
        public void Given4x4WordWithOneDownRightWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle setupSUT, Dictionary<String, List<Vector2>> expected)
        {
            sut = setupSUT;
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), DownRightWordTestCase)]
        public void Given4x4WordWithTwoDownRightWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle setupSUT, Dictionary<String, List<Vector2>> expected)
        {
            sut = setupSUT;
            setupSUT.AddWord("HAN");
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            List<Vector2> hanLocation = new List<Vector2>();
            hanLocation.Add(new Vector2(0, 1));
            hanLocation.Add(new Vector2(1, 2));
            hanLocation.Add(new Vector2(2, 3));
            expected.Add("HAN", hanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), ValidOneWordPuzzleTestCase)]
        public void Given4x4WordPuzzleWithWordsWhenCallingIsValidThenIsValidThrowsNoException(WordSearchPuzzle setupSUT)
        {
            sut = setupSUT;

            sut.IsValid();
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), ValidOneWordPuzzleTestCase)]
        public void GivenValid4x4WordPuzzleWithWordsWhenCallingIsValidThenIsValidReturnsTrue(WordSearchPuzzle setupSUT)
        {
            sut = setupSUT;

            bool result = sut.IsValid();
            Assert.IsTrue(result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), PuzzleWithNoWordsAddedTestCase)]
        public void Given4x4WordPuzzleWithMissingWordWhenCallingIsValidThenIsValidReturnsFalse(WordSearchPuzzle setupSUT)
        {
            sut = setupSUT;
            sut.AddWord("UHURA");

            bool result = sut.IsValid();
            Assert.IsFalse(result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), PuzzleWithWordTwiceTestCase)]
        public void Given4x4WordPuzzleWithWordTwiceWhenCallingIsValidThenIsValidReturnsFalse(WordSearchPuzzle setupSUT)
        {
            sut = setupSUT;

            bool result = sut.IsValid();
            Assert.IsFalse(result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), ValidOneWordPuzzleTestCase)]
        public void Given4x4WordPuzzleWithWordAddedTwiceWhenCallingIsValidThenIsValidReturnsFalse(WordSearchPuzzle setupSUT)
        {
            sut = setupSUT;
            sut.AddWord("KIRK");

            bool result = sut.IsValid();
            Assert.IsFalse(result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), PuzzleWithNoWordsAddedTestCase)]
        public void GivenInvalid4x4WordPuzzleWhenCallingIsValidTwiceThenSecondIsValidReturnsFalse(WordSearchPuzzle setupSUT)
        {
            sut = setupSUT;
            sut.AddWord("UHURA");
            sut.IsValid();

            bool result = sut.IsValid();
            Assert.IsFalse(result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), PuzzleWithNoWordsAddedTestCase)]
        public void Given4x4WordPuzzleWithoutWordsWhenCallingIsValidThenIsValidReturnsFalse(WordSearchPuzzle setupSUT)
        {
            sut = setupSUT;

            bool result = sut.IsValid();
            Assert.IsFalse(result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), PuzzleWithNoWordsAddedTestCase)]
        public void Given4x4WordPuzzleWithoutWordsWhenCallingIsValidAddingAWordThenCallingIsValidAgainReturnsTrue(WordSearchPuzzle setupSUT)
        {
            sut = setupSUT;

            sut.IsValid();

            sut.AddWord("KIRK");

            bool result = sut.IsValid();
            Assert.IsTrue(result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), DownRightWordTestCase)]
        public void GivenValid4x4WordPuzzleWhenCallingIsValidThenGetWordsLocationReturnsAllWordsLocations(WordSearchPuzzle setupSUT, Dictionary<String, List<Vector2>> expected)
        {
            sut = setupSUT;

            sut.IsValid();

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), PuzzleWithNoWordsAddedTestCase)]
        public void Given4x4WordPuzzleWhenCallingToStringThenToStringReturnsAString(WordSearchPuzzle setupSUT)
        {
            sut = setupSUT;
            sut.AddWord("KIRK");
            sut.AddWord("KHAN");

            String result = sut.ToString();
            Assert.IsInstanceOf(typeof(String), result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), PuzzleWithNoWordsAddedTestCase)]
        public void Given4x4WordPuzzleWhenCallingToStringThenToStringReturnsAStringWithWordsAndTheirLetterLocations(WordSearchPuzzle setupSUT)
        {
            sut = setupSUT;
            sut.AddWord("KIRK");
            sut.AddWord("KHAN");

            String result = sut.ToString();
            String expected = "KIRK: (0,1),(1,1),(2,1),(3,1)\n";
            expected += "KHAN: (0,3),(1,3),(2,3),(3,3)";

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), PuzzleWithNoWordsAddedTestCase)]
        public void Given4x4WordPuzzleWith3WordsWhenCallingToStringThenToStringReturnsAStringWithWordsAndTheirLetterLocations(WordSearchPuzzle setupSUT)
        {
            sut = setupSUT;
            sut.AddWord("KIRK");
            sut.AddWord("KHAN");
            sut.AddWord("SULU");

            String result = sut.ToString();
            String expected = "KIRK: (0,1),(1,1),(2,1),(3,1)\n";
            expected += "KHAN: (0,3),(1,3),(2,3),(3,3)\n";
            expected += "SULU: (0,0),(1,0),(2,0),(3,0)";

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), ValidOneWordPuzzleTestCase)]
        public void Given4x4WordPuzzleWithAWordMissingWhenCallingToStringThenToStringReturnsAnEmptyString(WordSearchPuzzle setupSUT)
        {
            sut = setupSUT;
            sut.AddWord("KHAN");
            sut.AddWord("SULU");

            String result = sut.ToString();
            String expected = "";

            Assert.AreEqual(expected, result);
        }
    }
}
