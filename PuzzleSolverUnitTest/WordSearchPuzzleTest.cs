using NUnit.Framework;
using PuzzleSolverProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void GivenWordSearchPuzleWhenCallingGetWordsThenGetWordsReturnAListOfStrings()
        {
            Assert.IsInstanceOf(typeof(List<String>), sut.GetWords());
        }

        [Test]
        public void GivenWordSearchPuzzleWithAWordAddedWhenCallingGetWordThenGetWordReturnsAListOfStringWithTheAddedWord()
        {
            sut.AddWord("PILLAR");
            List<String> result = sut.GetWords();
            List<String> expected = new List<String>();
            expected.Add("PILLAR");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenWordSearchPuzzleWithMultipleWordsAddedWhenCallingGetWordThenGetWordReturnsAListOfStringWithTheAddedWords()
        {
            sut.AddWord("PILLAR");
            sut.AddWord("TDD");
            List<String> result = sut.GetWords();
            List<String> expected = new List<String>();
            expected.Add("PILLAR");
            expected.Add("TDD");

            Assert.AreEqual(expected, result);
        }
    }
}
