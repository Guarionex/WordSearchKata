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
        private const String WordMissingInPuzzleTestCase = nameof(WordSearchPuzzleTestData.WordMissingInPuzzleTestCase);
        private const String OneOfTwoWordsMissingInPuzzleTestCase = nameof(WordSearchPuzzleTestData.OneOfTwoWordsMissingInPuzzleTestCase);
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
            Assert.IsInstanceOf(typeof(List<String>), sut.WordsList);
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
            Assert.IsInstanceOf(typeof(Dictionary<Vector2, Char>), sut.LettersMap);
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

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), ValidOneWordPuzzleTestCase)]
        public void Given4x4WordWithTwoWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringListVector2Dictionary(WordSearchPuzzle setupSUT)
        {
            sut = setupSUT;
            Assert.IsInstanceOf(typeof(Dictionary<String, List<Vector2>>), sut.GetWordsLocation());
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), WordMissingInPuzzleTestCase)]
        public void Given4x4WordPuzzleWithWordNotInPuzzleWhenCallingGetWordsLocationsThenGetWordsLicationsThrowsNoException(WordSearchPuzzle setupSUT)
        {
            sut = setupSUT;
            sut.GetWordsLocation();
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), OneOfTwoWordsMissingInPuzzleTestCase)]
        public void Given4x4WordPuzzleWith2WordsTheFirstOfWhichIsNotInThePuzzleWhenCallingGetWordsLocationsThenGetWordsLicationsReturnsAnEmptyDictionary(WordSearchPuzzle setupSUT)
        {
            sut = setupSUT;

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();
            Dictionary<String, List<Vector2>> expected = new Dictionary<string, List<Vector2>>();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), OneUpWordTestCase)]
        public void Given4x4WordWithOneUpWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle setupSUT, Dictionary<String, List<Vector2>> expected)
        {
            sut = setupSUT;
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), TwoWordsUpTestCase)]
        public void Given4x4WordWithTwoUpWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRKAndKHAN(WordSearchPuzzle setupSUT, Dictionary<String, List<Vector2>> expected)
        {
            sut = setupSUT;
            setupSUT.AddWord("KHAN");
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            List<Vector2> khanLocation = new List<Vector2>();
            khanLocation.Add(new Vector2(3, 3));
            khanLocation.Add(new Vector2(3, 2));
            khanLocation.Add(new Vector2(3, 1));
            khanLocation.Add(new Vector2(3, 0));
            expected.Add("KHAN", khanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), DownWordTestCase)]
        public void Given4x4WordWithOneDownWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle setupSUT, Dictionary<String, List<Vector2>> expected)
        {
            sut = setupSUT;
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), DownWordTestCase)]
        public void Given4x4WordWithTwoDownWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle setupSUT, Dictionary<String, List<Vector2>> expected)
        {
            sut = setupSUT;
            setupSUT.AddWord("KHAN");
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            List<Vector2> khanLocation = new List<Vector2>();
            khanLocation.Add(new Vector2(3, 0));
            khanLocation.Add(new Vector2(3, 1));
            khanLocation.Add(new Vector2(3, 2));
            khanLocation.Add(new Vector2(3, 3));
            expected.Add("KHAN", khanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), OneUpOneDownWordTestCase)]
        public void Given4x4WordWithUpAndDownWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle setupSUT, Dictionary<String, List<Vector2>> expected)
        {
            sut = setupSUT;
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), LeftWordTestCase)]
        public void Given4x4WordWithOneLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle setupSUT, Dictionary<String, List<Vector2>> expected)
        {
            sut = setupSUT;
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), LeftWordTestCase)]
        public void Given4x4WordWithTwoLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords(WordSearchPuzzle setupSUT, Dictionary<String, List<Vector2>> expected)
        {
            sut = setupSUT;
            setupSUT.AddWord("KHAN");
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

            List<Vector2> khanLocation = new List<Vector2>();
            khanLocation.Add(new Vector2(3, 3));
            khanLocation.Add(new Vector2(2, 3));
            khanLocation.Add(new Vector2(1, 3));
            khanLocation.Add(new Vector2(0, 3));
            expected.Add("KHAN", khanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), RightWordTestCase)]
        public void Given4x4WordWithOneRightWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK(WordSearchPuzzle setupSUT, Dictionary<String, List<Vector2>> expected)
        {
            sut = setupSUT;
            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();

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

            Assert.IsTrue(sut.IsValid());
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), WordMissingInPuzzleTestCase)]
        public void Given4x4WordPuzzleWithMissingWordWhenCallingIsValidThenIsValidReturnsFalse(WordSearchPuzzle setupSUT)
        {
            sut = setupSUT;

            Assert.IsFalse(sut.IsValid());
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), PuzzleWithWordTwiceTestCase)]
        public void Given4x4WordPuzzleWithWordTwiceWhenCallingIsValidThenIsValidReturnsFalse(WordSearchPuzzle setupSUT)
        {
            sut = setupSUT;

            Assert.IsFalse(sut.IsValid());
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), ValidOneWordPuzzleTestCase)]
        public void Given4x4WordPuzzleWithWordAddedTwiceWhenCallingIsValidThenIsValidReturnsFalse(WordSearchPuzzle setupSUT)
        {
            sut = setupSUT;
            sut.AddWord("KIRK");

            Assert.IsFalse(sut.IsValid());
        }

        [Test, TestCaseSource(typeof(WordSearchPuzzleTestData), WordMissingInPuzzleTestCase)]
        public void GivenInvalid4x4WordPuzzleWhenCallingIsValidTwiceThenSecondIsValidReturnsFalse(WordSearchPuzzle setupSUT)
        {
            sut = setupSUT;
            sut.IsValid();

            Assert.IsFalse(sut.IsValid());
        }

        [Test]
        public void Given4x4WordPuzzleWithoutWordsWhenCallingIsValidThenIsValidReturnsFalse()
        {
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('K', 3, 0);
            sut.AddLetterAt('R', 0, 1);
            sut.AddLetterAt('R', 1, 1);
            sut.AddLetterAt('J', 2, 1);
            sut.AddLetterAt('I', 3, 1);
            sut.AddLetterAt('I', 0, 2);
            sut.AddLetterAt('L', 1, 2);
            sut.AddLetterAt('I', 2, 2);
            sut.AddLetterAt('R', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('X', 3, 3);

            Assert.IsFalse(sut.IsValid());
        }

        [Test]
        public void Given4x4WordPuzzleWithoutWordsWhenCallingIsValidAddingAWordThenCallingIsValidAgainReturnsTrue()
        {
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('K', 3, 0);
            sut.AddLetterAt('R', 0, 1);
            sut.AddLetterAt('R', 1, 1);
            sut.AddLetterAt('J', 2, 1);
            sut.AddLetterAt('I', 3, 1);
            sut.AddLetterAt('I', 0, 2);
            sut.AddLetterAt('L', 1, 2);
            sut.AddLetterAt('I', 2, 2);
            sut.AddLetterAt('R', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('X', 3, 3);

            sut.IsValid();

            sut.AddWord("KIRK");

            Assert.IsTrue(sut.IsValid());
        }

        [Test]
        public void GivenValid4x4WordPuzzleWhenCallingIsValidThenGetWordsLocationReturnsAllWordsLocations()
        {
            sut.AddWord("KIRK");
            sut.AddWord("HAN");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('X', 3, 0);
            sut.AddLetterAt('H', 0, 1);
            sut.AddLetterAt('I', 1, 1);
            sut.AddLetterAt('I', 2, 1);
            sut.AddLetterAt('K', 3, 1);
            sut.AddLetterAt('R', 0, 2);
            sut.AddLetterAt('A', 1, 2);
            sut.AddLetterAt('R', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('X', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('N', 2, 3);
            sut.AddLetterAt('K', 3, 3);

            sut.IsValid();

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(0, 0));
            kirkLocation.Add(new Vector2(1, 1));
            kirkLocation.Add(new Vector2(2, 2));
            kirkLocation.Add(new Vector2(3, 3));

            List<Vector2> hanLocation = new List<Vector2>();
            hanLocation.Add(new Vector2(0, 1));
            hanLocation.Add(new Vector2(1, 2));
            hanLocation.Add(new Vector2(2, 3));
            Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
            expected.Add("KIRK", kirkLocation);
            expected.Add("HAN", hanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Given4x4WordPuzzleWhenCallingToStringThenToStringReturnsAString()
        {
            sut.AddWord("KIRK");
            sut.AddWord("KHAN");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('K', 0, 1);
            sut.AddLetterAt('I', 1, 1);
            sut.AddLetterAt('R', 2, 1);
            sut.AddLetterAt('K', 3, 1);
            sut.AddLetterAt('R', 0, 2);
            sut.AddLetterAt('L', 1, 2);
            sut.AddLetterAt('I', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('H', 1, 3);
            sut.AddLetterAt('A', 2, 3);
            sut.AddLetterAt('N', 3, 3);

            Assert.IsInstanceOf(typeof(String), sut.ToString());
        }

        [Test]
        public void Given4x4WordPuzzleWhenCallingToStringThenToStringReturnsAStringWithWordsAndTheirLetterLocations()
        {
            sut.AddWord("KIRK");
            sut.AddWord("KHAN");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('K', 0, 1);
            sut.AddLetterAt('I', 1, 1);
            sut.AddLetterAt('R', 2, 1);
            sut.AddLetterAt('K', 3, 1);
            sut.AddLetterAt('R', 0, 2);
            sut.AddLetterAt('L', 1, 2);
            sut.AddLetterAt('I', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('H', 1, 3);
            sut.AddLetterAt('A', 2, 3);
            sut.AddLetterAt('N', 3, 3);

            String result = sut.ToString();
            String expected = "KIRK: (0,1),(1,1),(2,1),(3,1)\n";
            expected += "KHAN: (0,3),(1,3),(2,3),(3,3)";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Given4x4WordPuzzleWith3WordsWhenCallingToStringThenToStringReturnsAStringWithWordsAndTheirLetterLocations()
        {
            sut.AddWord("KIRK");
            sut.AddWord("KHAN");
            sut.AddWord("SULU");
            sut.AddLetterAt('S', 0, 0);
            sut.AddLetterAt('U', 1, 0);
            sut.AddLetterAt('L', 2, 0);
            sut.AddLetterAt('U', 3, 0);
            sut.AddLetterAt('K', 0, 1);
            sut.AddLetterAt('I', 1, 1);
            sut.AddLetterAt('R', 2, 1);
            sut.AddLetterAt('K', 3, 1);
            sut.AddLetterAt('R', 0, 2);
            sut.AddLetterAt('L', 1, 2);
            sut.AddLetterAt('I', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('H', 1, 3);
            sut.AddLetterAt('A', 2, 3);
            sut.AddLetterAt('N', 3, 3);

            String result = sut.ToString();
            String expected = "KIRK: (0,1),(1,1),(2,1),(3,1)\n";
            expected += "KHAN: (0,3),(1,3),(2,3),(3,3)\n";
            expected += "SULU: (0,0),(1,0),(2,0),(3,0)";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Given4x4WordPuzzleWithAWordMissingWhenCallingToStringThenToStringReturnsAnEmptyString()
        {
            sut.AddWord("KIRK");
            sut.AddWord("KHAN");
            sut.AddWord("SULU");
            sut.AddLetterAt('S', 0, 0);
            sut.AddLetterAt('X', 1, 0);
            sut.AddLetterAt('L', 2, 0);
            sut.AddLetterAt('U', 3, 0);
            sut.AddLetterAt('K', 0, 1);
            sut.AddLetterAt('I', 1, 1);
            sut.AddLetterAt('R', 2, 1);
            sut.AddLetterAt('K', 3, 1);
            sut.AddLetterAt('R', 0, 2);
            sut.AddLetterAt('L', 1, 2);
            sut.AddLetterAt('I', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('H', 1, 3);
            sut.AddLetterAt('A', 2, 3);
            sut.AddLetterAt('N', 3, 3);

            String result = sut.ToString();
            String expected = "";

            Assert.AreEqual(expected, result);
        }
    }
}
