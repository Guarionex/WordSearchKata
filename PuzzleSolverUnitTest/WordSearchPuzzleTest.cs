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
        private PuzzleSolver solver;

        [SetUp]
        public void init()
        {
            sut = new WordSearchPuzzle();
            solver = new PuzzleSolver();
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
        public void Given4x4WordPuzzleWhenCallingSearchHorizontalWithKIRKThenSearchHorizontalThrowsNoException()
        {
            sut.AddWord("KIRK");
            sut.AddWord("KHAN");
            sut.AddLetterAt('Q', 0, 0);
            sut.AddLetterAt('G', 1, 0);
            sut.AddLetterAt('J', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('X', 0, 1);
            sut.AddLetterAt('U', 1, 1);
            sut.AddLetterAt('A', 2, 1);
            sut.AddLetterAt('F', 3, 1);
            sut.AddLetterAt('L', 0, 2);
            sut.AddLetterAt('H', 1, 2);
            sut.AddLetterAt('G', 2, 2);
            sut.AddLetterAt('J', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('I', 1, 3);
            sut.AddLetterAt('R', 2, 3);
            sut.AddLetterAt('K', 3, 3);

            sut.SearchHorizontal("KIRK");
        }

        [Test]
        public void Given4x4WordPuzzleWithAHorizontalWordWhenCallingSearchHorizontalWithKIRKThenSearchHorizontalReturnsAListOfVectors()
        {
            sut.AddWord("KIRK");
            sut.AddWord("KHAN");
            sut.AddLetterAt('Q', 0, 0);
            sut.AddLetterAt('G', 1, 0);
            sut.AddLetterAt('J', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('X', 0, 1);
            sut.AddLetterAt('U', 1, 1);
            sut.AddLetterAt('A', 2, 1);
            sut.AddLetterAt('F', 3, 1);
            sut.AddLetterAt('L', 0, 2);
            sut.AddLetterAt('H', 1, 2);
            sut.AddLetterAt('G', 2, 2);
            sut.AddLetterAt('J', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('I', 1, 3);
            sut.AddLetterAt('R', 2, 3);
            sut.AddLetterAt('K', 3, 3);

            Assert.IsInstanceOf(typeof(List<Vector2>), sut.SearchHorizontal("KIRK"));
        }

        [Test]
        public void Given4x4WordPuzzleWithAHorizontalWordInLastRowWhenCallingSearchHorizontalWithKIRKThenSearchHorizontalReturnsAListOfVectorsWithTheHorizontalWordKeys()
        {
            sut.AddWord("KIRK");
            sut.AddWord("KHAN");
            sut.AddLetterAt('Q', 0, 0);
            sut.AddLetterAt('G', 1, 0);
            sut.AddLetterAt('J', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('X', 0, 1);
            sut.AddLetterAt('U', 1, 1);
            sut.AddLetterAt('A', 2, 1);
            sut.AddLetterAt('F', 3, 1);
            sut.AddLetterAt('L', 0, 2);
            sut.AddLetterAt('H', 1, 2);
            sut.AddLetterAt('G', 2, 2);
            sut.AddLetterAt('J', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('I', 1, 3);
            sut.AddLetterAt('R', 2, 3);
            sut.AddLetterAt('K', 3, 3);

            List<Vector2> result = sut.SearchHorizontal("KIRK");
            List<Vector2> expected = new List<Vector2>();
            expected.Add(new Vector2(0, 3));
            expected.Add(new Vector2(1, 3));
            expected.Add(new Vector2(2, 3));
            expected.Add(new Vector2(3, 3));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Given4x4WordPuzzleWithAHorizontalWordInThirdRowWhenCallingSearchHorizontalWithKIRKThenSearchHorizontalReturnsAListOfVectorsWithTheHorizontalWordKeys()
        {
            sut.AddWord("KIRK");
            sut.AddWord("KHAN");
            sut.AddLetterAt('Q', 0, 0);
            sut.AddLetterAt('G', 1, 0);
            sut.AddLetterAt('J', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('X', 0, 1);
            sut.AddLetterAt('U', 1, 1);
            sut.AddLetterAt('A', 2, 1);
            sut.AddLetterAt('F', 3, 1);
            sut.AddLetterAt('K', 0, 2);
            sut.AddLetterAt('I', 1, 2);
            sut.AddLetterAt('R', 2, 2);
            sut.AddLetterAt('K', 3, 2);
            sut.AddLetterAt('L', 0, 3);
            sut.AddLetterAt('H', 1, 3);
            sut.AddLetterAt('G', 2, 3);
            sut.AddLetterAt('J', 3, 3);

            List<Vector2> result = sut.SearchHorizontal("KIRK");
            List <Vector2> expected = new List<Vector2>();
            expected.Add(new Vector2(0, 2));
            expected.Add(new Vector2(1, 2));
            expected.Add(new Vector2(2, 2));
            expected.Add(new Vector2(3, 2));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenALetterWhenPassedToFindAllLetterPositionsThenFinAllLetterPositionsReturnsAListOfVector2()
        {
            Assert.IsInstanceOf(typeof(List<Vector2>), sut.FindAllLetterPositions('K'));
        }

        [Test]
        public void GivenALetterKOfAPuzzleWhenPassedToFindAllLetterPositionsThenFinAllLetterPositionsReturnsAListOfVector2WithValidPositionsForTheLetter()
        {
            sut.AddLetterAt('Q', 0, 0);
            sut.AddLetterAt('G', 1, 0);
            sut.AddLetterAt('J', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('X', 0, 1);
            sut.AddLetterAt('U', 1, 1);
            sut.AddLetterAt('A', 2, 1);
            sut.AddLetterAt('F', 3, 1);
            sut.AddLetterAt('L', 0, 2);
            sut.AddLetterAt('H', 1, 2);
            sut.AddLetterAt('G', 2, 2);
            sut.AddLetterAt('J', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('I', 1, 3);
            sut.AddLetterAt('R', 2, 3);
            sut.AddLetterAt('K', 3, 3);

            List<Vector2> result = sut.FindAllLetterPositions('K');
            List<Vector2> expected = new List<Vector2>();
            expected.Add(new Vector2(0, 3));
            expected.Add(new Vector2(3, 3));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenALetterHOfAPuzzleWhenPassedToFindAllLetterPositionsThenFinAllLetterPositionsReturnsAListOfVector2WithValidPositionsForTheLetter()
        {
            sut.AddLetterAt('Q', 0, 0);
            sut.AddLetterAt('G', 1, 0);
            sut.AddLetterAt('J', 2, 0);
            sut.AddLetterAt('N', 3, 0);
            sut.AddLetterAt('X', 0, 1);
            sut.AddLetterAt('U', 1, 1);
            sut.AddLetterAt('A', 2, 1);
            sut.AddLetterAt('F', 3, 1);
            sut.AddLetterAt('L', 0, 2);
            sut.AddLetterAt('H', 1, 2);
            sut.AddLetterAt('G', 2, 2);
            sut.AddLetterAt('J', 3, 2);
            sut.AddLetterAt('K', 0, 3);
            sut.AddLetterAt('I', 1, 3);
            sut.AddLetterAt('R', 2, 3);
            sut.AddLetterAt('K', 3, 3);

            List<Vector2> result = sut.FindAllLetterPositions('H');
            List<Vector2> expected = new List<Vector2>();
            expected.Add(new Vector2(1, 2));

            Assert.AreEqual(expected, result);
        }
    }
}
