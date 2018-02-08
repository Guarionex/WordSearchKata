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
            Assert.IsInstanceOf(typeof(List<String>), sut.Words);
        }

        [Test]
        public void GivenWordSearchPuzzleWithAWordAddedWhenCallingGetWordThenGetWordReturnsAListOfStringWithTheAddedWord()
        {
            sut.AddWord("PILLAR");
            List<String> result = sut.Words;
            List<String> expected = new List<String>();
            expected.Add("PILLAR");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenWordSearchPuzzleWithMultipleWordsAddedWhenCallingGetWordThenGetWordReturnsAListOfStringWithTheAddedWords()
        {
            sut.AddWord("PILLAR");
            sut.AddWord("TDD");
            List<String> result = sut.Words;
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
            Assert.IsInstanceOf(typeof(Dictionary<Vector2, Char>), sut.Letters);
        }

        [Test]
        public void GivenWordSearchPuzzleWithLetterXAddedAt2x2WhenCallingLettersThenLettersReturnsADictionaryOfVector2KeysWithCharValuesWithTheAddedLetterAtTt2x2()
        {
            sut.AddLetterAt('X', 2, 2);
            Dictionary<Vector2, Char> result = sut.Letters;
            Dictionary<Vector2, Char> expected = new Dictionary<Vector2, Char>();
            expected.Add(new Vector2(2, 2), 'X');

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenWordSearchPuzzleWithMultipleLetterAddedWhenCallingLettersThenLettersReturnsADictionaryOfVector2KeysWithCharValuesWithTheAddedLetters()
        {
            sut.AddLetterAt('X', 2, 2);
            sut.AddLetterAt('P', 0, 0);
            Dictionary<Vector2, Char> result = sut.Letters;
            Dictionary<Vector2, Char> expected = new Dictionary<Vector2, Char>();
            expected.Add(new Vector2(2, 2), 'X');
            expected.Add(new Vector2(0, 0), 'P');

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Given4x4WordWithTwoWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringListVector2Dictionary()
        {
            sut.AddWord("KIRK");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('R', 0, 1);
            sut.AddLetterAt('R', 1, 1);
            sut.AddLetterAt('J', 2, 1);
            sut.AddLetterAt('A', 3, 1);
            sut.AddLetterAt('I', 0, 2);
            sut.AddLetterAt('L', 1, 2);
            sut.AddLetterAt('I', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('M', 3, 3);
            Assert.IsInstanceOf(typeof(Dictionary<String, List<Vector2>>), sut.GetWordsLocation());
        }

        [Test]
        public void Given4x4WordWithOneUpWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK()
        {
            sut.AddWord("KIRK");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('R', 0, 1);
            sut.AddLetterAt('R', 1, 1);
            sut.AddLetterAt('J', 2, 1);
            sut.AddLetterAt('A', 3, 1);
            sut.AddLetterAt('I', 0, 2);
            sut.AddLetterAt('L', 1, 2);
            sut.AddLetterAt('I', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('M', 3, 3);

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(0, 3));
            kirkLocation.Add(new Vector2(0, 2));
            kirkLocation.Add(new Vector2(0, 1));
            kirkLocation.Add(new Vector2(0, 0));
            Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
            expected.Add("KIRK", kirkLocation);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Given4x4WordWithTwoUpWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRKAndKHAN()
        {
            sut.AddWord("KIRK");
            sut.AddWord("KHAN");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('R', 0, 1);
            sut.AddLetterAt('R', 1, 1);
            sut.AddLetterAt('J', 2, 1);
            sut.AddLetterAt('A', 3, 1);
            sut.AddLetterAt('I', 0, 2);
            sut.AddLetterAt('L', 1, 2);
            sut.AddLetterAt('X', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('K', 3, 3);

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(0, 3));
            kirkLocation.Add(new Vector2(0, 2));
            kirkLocation.Add(new Vector2(0, 1));
            kirkLocation.Add(new Vector2(0, 0));

            List<Vector2> khanLocation = new List<Vector2>();
            khanLocation.Add(new Vector2(3, 3));
            khanLocation.Add(new Vector2(3, 2));
            khanLocation.Add(new Vector2(3, 1));
            khanLocation.Add(new Vector2(3, 0));
            Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
            expected.Add("KIRK", kirkLocation);
            expected.Add("KHAN", khanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Given4x4WordWithOneDownWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK()
        {
            sut.AddWord("KIRK");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('I', 0, 1);
            sut.AddLetterAt('R', 1, 1);
            sut.AddLetterAt('J', 2, 1);
            sut.AddLetterAt('A', 3, 1);
            sut.AddLetterAt('R', 0, 2);
            sut.AddLetterAt('L', 1, 2);
            sut.AddLetterAt('I', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('M', 3, 3);

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(0, 0));
            kirkLocation.Add(new Vector2(0, 1));
            kirkLocation.Add(new Vector2(0, 2));
            kirkLocation.Add(new Vector2(0, 3));
            Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
            expected.Add("KIRK", kirkLocation);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Given4x4WordWithTwoDownWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords()
        {
            sut.AddWord("KIRK");
            sut.AddWord("KHAN");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('K', 3, 0);
            sut.AddLetterAt('I', 0, 1);
            sut.AddLetterAt('R', 1, 1);
            sut.AddLetterAt('J', 2, 1);
            sut.AddLetterAt('H', 3, 1);
            sut.AddLetterAt('R', 0, 2);
            sut.AddLetterAt('L', 1, 2);
            sut.AddLetterAt('I', 2, 2);
            sut.AddLetterAt('A', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('N', 3, 3);

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(0, 0));
            kirkLocation.Add(new Vector2(0, 1));
            kirkLocation.Add(new Vector2(0, 2));
            kirkLocation.Add(new Vector2(0, 3));

            List<Vector2> khanLocation = new List<Vector2>();
            khanLocation.Add(new Vector2(3, 0));
            khanLocation.Add(new Vector2(3, 1));
            khanLocation.Add(new Vector2(3, 2));
            khanLocation.Add(new Vector2(3, 3));

            Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
            expected.Add("KIRK", kirkLocation);
            expected.Add("KHAN", khanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Given4x4WordWithUpAndDownWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords()
        {
            sut.AddWord("KIRK");
            sut.AddWord("KHAN");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('I', 0, 1);
            sut.AddLetterAt('R', 1, 1);
            sut.AddLetterAt('J', 2, 1);
            sut.AddLetterAt('A', 3, 1);
            sut.AddLetterAt('R', 0, 2);
            sut.AddLetterAt('L', 1, 2);
            sut.AddLetterAt('X', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('K', 3, 3);

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(0, 0));
            kirkLocation.Add(new Vector2(0, 1));
            kirkLocation.Add(new Vector2(0, 2));
            kirkLocation.Add(new Vector2(0, 3));

            List<Vector2> khanLocation = new List<Vector2>();
            khanLocation.Add(new Vector2(3, 3));
            khanLocation.Add(new Vector2(3, 2));
            khanLocation.Add(new Vector2(3, 1));
            khanLocation.Add(new Vector2(3, 0));

            Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
            expected.Add("KIRK", kirkLocation);
            expected.Add("KHAN", khanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Given4x4WordWithOneLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK()
        {
            sut.AddWord("KIRK");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('K', 0, 1);
            sut.AddLetterAt('R', 1, 1);
            sut.AddLetterAt('I', 2, 1);
            sut.AddLetterAt('K', 3, 1);
            sut.AddLetterAt('R', 0, 2);
            sut.AddLetterAt('L', 1, 2);
            sut.AddLetterAt('I', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('M', 3, 3);

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(3, 1));
            kirkLocation.Add(new Vector2(2, 1));
            kirkLocation.Add(new Vector2(1, 1));
            kirkLocation.Add(new Vector2(0, 1));
            Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
            expected.Add("KIRK", kirkLocation);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Given4x4WordWithTwoLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords()
        {
            sut.AddWord("KIRK");
            sut.AddWord("KHAN");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('K', 0, 1);
            sut.AddLetterAt('R', 1, 1);
            sut.AddLetterAt('I', 2, 1);
            sut.AddLetterAt('K', 3, 1);
            sut.AddLetterAt('R', 0, 2);
            sut.AddLetterAt('L', 1, 2);
            sut.AddLetterAt('X', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('N', 0, 3);
            sut.AddLetterAt('A', 1, 3);
            sut.AddLetterAt('H', 2, 3);
            sut.AddLetterAt('K', 3, 3);

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(3, 1));
            kirkLocation.Add(new Vector2(2, 1));
            kirkLocation.Add(new Vector2(1, 1));
            kirkLocation.Add(new Vector2(0, 1));

            List<Vector2> khanLocation = new List<Vector2>();
            khanLocation.Add(new Vector2(3, 3));
            khanLocation.Add(new Vector2(2, 3));
            khanLocation.Add(new Vector2(1, 3));
            khanLocation.Add(new Vector2(0, 3));
            Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
            expected.Add("KIRK", kirkLocation);
            expected.Add("KHAN", khanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Given4x4WordWithOneRightWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK()
        {
            sut.AddWord("KIRK");
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
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('M', 3, 3);

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(0, 1));
            kirkLocation.Add(new Vector2(1, 1));
            kirkLocation.Add(new Vector2(2, 1));
            kirkLocation.Add(new Vector2(3, 1));
            Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
            expected.Add("KIRK", kirkLocation);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Given4x4WordWithTwoRightWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords()
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

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(0, 1));
            kirkLocation.Add(new Vector2(1, 1));
            kirkLocation.Add(new Vector2(2, 1));
            kirkLocation.Add(new Vector2(3, 1));

            List<Vector2> khanLocation = new List<Vector2>();
            khanLocation.Add(new Vector2(0, 3));
            khanLocation.Add(new Vector2(1, 3));
            khanLocation.Add(new Vector2(2, 3));
            khanLocation.Add(new Vector2(3, 3));
            Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
            expected.Add("KIRK", kirkLocation);
            expected.Add("KHAN", khanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Given4x4WordWithOneUpLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK()
        {
            sut.AddWord("KIRK");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('X', 0, 1);
            sut.AddLetterAt('R', 1, 1);
            sut.AddLetterAt('E', 2, 1);
            sut.AddLetterAt('K', 3, 1);
            sut.AddLetterAt('R', 0, 2);
            sut.AddLetterAt('L', 1, 2);
            sut.AddLetterAt('I', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('K', 3, 3);

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(3, 3));
            kirkLocation.Add(new Vector2(2, 2));
            kirkLocation.Add(new Vector2(1, 1));
            kirkLocation.Add(new Vector2(0, 0));
            Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
            expected.Add("KIRK", kirkLocation);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Given4x4WordWithTwoUpLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords()
        {
            sut.AddWord("KIRK");
            sut.AddWord("HAN");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('N', 0, 1);
            sut.AddLetterAt('R', 1, 1);
            sut.AddLetterAt('E', 2, 1);
            sut.AddLetterAt('K', 3, 1);
            sut.AddLetterAt('R', 0, 2);
            sut.AddLetterAt('A', 1, 2);
            sut.AddLetterAt('I', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('H', 2, 3);
            sut.AddLetterAt('K', 3, 3);

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(3, 3));
            kirkLocation.Add(new Vector2(2, 2));
            kirkLocation.Add(new Vector2(1, 1));
            kirkLocation.Add(new Vector2(0, 0));

            List<Vector2> hanLocation = new List<Vector2>();
            hanLocation.Add(new Vector2(2, 3));
            hanLocation.Add(new Vector2(1, 2));
            hanLocation.Add(new Vector2(0, 1));
            Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
            expected.Add("KIRK", kirkLocation);
            expected.Add("HAN", hanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Given4x4WordWithOneUpRightWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK()
        {
            sut.AddWord("KIRK");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('K', 3, 0);
            sut.AddLetterAt('X', 0, 1);
            sut.AddLetterAt('I', 1, 1);
            sut.AddLetterAt('R', 2, 1);
            sut.AddLetterAt('K', 3, 1);
            sut.AddLetterAt('R', 0, 2);
            sut.AddLetterAt('I', 1, 2);
            sut.AddLetterAt('R', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('G', 3, 3);

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(0, 3));
            kirkLocation.Add(new Vector2(1, 2));
            kirkLocation.Add(new Vector2(2, 1));
            kirkLocation.Add(new Vector2(3, 0));
            Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
            expected.Add("KIRK", kirkLocation);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Given4x4WordWithOneTwoUpRightWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords()
        {
            sut.AddWord("KIRK");
            sut.AddWord("HAN");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('N', 2, 0);
            sut.AddLetterAt('K', 3, 0);
            sut.AddLetterAt('X', 0, 1);
            sut.AddLetterAt('A', 1, 1);
            sut.AddLetterAt('R', 2, 1);
            sut.AddLetterAt('K', 3, 1);
            sut.AddLetterAt('H', 0, 2);
            sut.AddLetterAt('I', 1, 2);
            sut.AddLetterAt('R', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('G', 3, 3);

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(0, 3));
            kirkLocation.Add(new Vector2(1, 2));
            kirkLocation.Add(new Vector2(2, 1));
            kirkLocation.Add(new Vector2(3, 0));

            List<Vector2> hanLocation = new List<Vector2>();
            hanLocation.Add(new Vector2(0, 2));
            hanLocation.Add(new Vector2(1, 1));
            hanLocation.Add(new Vector2(2, 0));
            Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
            expected.Add("KIRK", kirkLocation);
            expected.Add("HAN", hanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Given4x4WordWithOneDownLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK()
        {
            sut.AddWord("KIRK");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('K', 3, 0);
            sut.AddLetterAt('X', 0, 1);
            sut.AddLetterAt('I', 1, 1);
            sut.AddLetterAt('I', 2, 1);
            sut.AddLetterAt('K', 3, 1);
            sut.AddLetterAt('R', 0, 2);
            sut.AddLetterAt('R', 1, 2);
            sut.AddLetterAt('R', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('G', 3, 3);

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(3, 0));
            kirkLocation.Add(new Vector2(2, 1));
            kirkLocation.Add(new Vector2(1, 2));
            kirkLocation.Add(new Vector2(0, 3));
            Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
            expected.Add("KIRK", kirkLocation);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Given4x4WordWithTwoDownLeftWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForAllWords()
        {
            sut.AddWord("KIRK");
            sut.AddWord("HAN");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('K', 3, 0);
            sut.AddLetterAt('X', 0, 1);
            sut.AddLetterAt('I', 1, 1);
            sut.AddLetterAt('I', 2, 1);
            sut.AddLetterAt('H', 3, 1);
            sut.AddLetterAt('R', 0, 2);
            sut.AddLetterAt('R', 1, 2);
            sut.AddLetterAt('A', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('N', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('G', 3, 3);

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(3, 0));
            kirkLocation.Add(new Vector2(2, 1));
            kirkLocation.Add(new Vector2(1, 2));
            kirkLocation.Add(new Vector2(0, 3));

            List<Vector2> hanLocation = new List<Vector2>();
            hanLocation.Add(new Vector2(3, 1));
            hanLocation.Add(new Vector2(2, 2));
            hanLocation.Add(new Vector2(1, 3));
            Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
            expected.Add("KIRK", kirkLocation);
            expected.Add("HAN", hanLocation);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Given4x4WordWithOneDownRightWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK()
        {
            sut.AddWord("KIRK");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('X', 3, 0);
            sut.AddLetterAt('X', 0, 1);
            sut.AddLetterAt('I', 1, 1);
            sut.AddLetterAt('I', 2, 1);
            sut.AddLetterAt('K', 3, 1);
            sut.AddLetterAt('R', 0, 2);
            sut.AddLetterAt('R', 1, 2);
            sut.AddLetterAt('R', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('X', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('K', 3, 3);

            Dictionary<String, List<Vector2>> result = sut.GetWordsLocation();
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(0, 0));
            kirkLocation.Add(new Vector2(1, 1));
            kirkLocation.Add(new Vector2(2, 2));
            kirkLocation.Add(new Vector2(3, 3));
            Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
            expected.Add("KIRK", kirkLocation);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Given4x4WordWithTwoDownRightWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringVector2DictionaryWithEntryForKIRK()
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
        public void Given4x4WordPuzzleWithWordsWhenCallingIsValidThenIsValidThrowsNoException()
        {
            sut.AddWord("KIRK");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('R', 0, 1);
            sut.AddLetterAt('R', 1, 1);
            sut.AddLetterAt('J', 2, 1);
            sut.AddLetterAt('A', 3, 1);
            sut.AddLetterAt('I', 0, 2);
            sut.AddLetterAt('L', 1, 2);
            sut.AddLetterAt('I', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('M', 3, 3);

            sut.IsValid();
        }

        [Test]
        public void GivenValid4x4WordPuzzleWithWordsWhenCallingIsValidThenIsValidReturnsTrue()
        {
            sut.AddWord("KIRK");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('R', 0, 1);
            sut.AddLetterAt('R', 1, 1);
            sut.AddLetterAt('J', 2, 1);
            sut.AddLetterAt('A', 3, 1);
            sut.AddLetterAt('I', 0, 2);
            sut.AddLetterAt('L', 1, 2);
            sut.AddLetterAt('I', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('M', 3, 3);

            Assert.IsTrue(sut.IsValid());
        }

        [Test]
        public void Given4x4WordPuzzleWithMissingWordWhenCallingIsValidThenIsValidReturnsFalse()
        {
            sut.AddWord("KIRK");
            sut.AddLetterAt('X', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('R', 0, 1);
            sut.AddLetterAt('R', 1, 1);
            sut.AddLetterAt('J', 2, 1);
            sut.AddLetterAt('A', 3, 1);
            sut.AddLetterAt('I', 0, 2);
            sut.AddLetterAt('L', 1, 2);
            sut.AddLetterAt('I', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('M', 3, 3);

            Assert.IsFalse(sut.IsValid());
        }

        [Test]
        public void Given4x4WordPuzzleWithWordTwiceWhenCallingIsValidThenIsValidReturnsFalse()
        {
            sut.AddWord("KIRK");
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
            sut.AddLetterAt('K', 3, 3);

            Assert.IsFalse(sut.IsValid());
        }

        [Test]
        public void Given4x4WordPuzzleWithWordAddedTwiceWhenCallingIsValidThenIsValidReturnsFalse()
        {
            sut.AddWord("KIRK");
            sut.AddWord("KIRK");
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
        public void Given4x4WordPuzzleWhenAddingAWordAfterCheckingIsValidThenHasChangeReturnsTrue()
        {
            sut.AddWord("KIRK");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('R', 0, 1);
            sut.AddLetterAt('R', 1, 1);
            sut.AddLetterAt('J', 2, 1);
            sut.AddLetterAt('A', 3, 1);
            sut.AddLetterAt('I', 0, 2);
            sut.AddLetterAt('L', 1, 2);
            sut.AddLetterAt('I', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('M', 3, 3);

            sut.IsValid();
            sut.AddWord("KHAN");

            Assert.IsTrue(sut.HasChanged);
        }

        [Test]
        public void Given4x4WordPuzzleWhenCallingIsValidThenHasChangeReturnsFalse()
        {
            sut.AddWord("KIRK");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('R', 0, 1);
            sut.AddLetterAt('R', 1, 1);
            sut.AddLetterAt('J', 2, 1);
            sut.AddLetterAt('A', 3, 1);
            sut.AddLetterAt('I', 0, 2);
            sut.AddLetterAt('L', 1, 2);
            sut.AddLetterAt('I', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('M', 3, 3);

            sut.IsValid();

            Assert.IsFalse(sut.HasChanged);
        }

        [Test]
        public void Given4x4WordPuzzleWhenAddingALetterAfterCheckingIsValidThenHasChangeReturnsTrue()
        {
            sut.AddWord("KIRK");
            sut.AddLetterAt('K', 0, 0);
            sut.AddLetterAt('E', 1, 0);
            sut.AddLetterAt('F', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('R', 0, 1);
            sut.AddLetterAt('R', 1, 1);
            sut.AddLetterAt('J', 2, 1);
            sut.AddLetterAt('A', 3, 1);
            sut.AddLetterAt('I', 0, 2);
            sut.AddLetterAt('L', 1, 2);
            sut.AddLetterAt('I', 2, 2);
            sut.AddLetterAt('H', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('D', 1, 3);
            sut.AddLetterAt('J', 2, 3);
            sut.AddLetterAt('M', 3, 3);

            sut.IsValid();
            sut.AddLetterAt('G', 4, 4);

            Assert.IsTrue(sut.HasChanged);
        }

        [Test]
        public void GivenInvalid4x4WordPuzzleWhenCallingIsValidTwiceThenSecondIsValidReturnsFalse()
        {
            sut.AddWord("KIRK");
            sut.AddWord("KIRK");
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
            Assert.IsFalse(sut.IsValid());
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
    }
}
