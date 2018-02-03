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
    public class PuzzleSolverTest
    {
        private PuzzleSolver sut;

        [SetUp]
        public void init()
        {
            sut = new PuzzleSolver();
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedALettersOnlyStringThenAddWordThrowsNoException()
        {
            sut.AddWord("BONES");
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedAnAlphanumericStringThenAddWordThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(AlphanumericWord));
        }

        private void AlphanumericWord()
        {
            sut.AddWord("B0N3S");
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedAStringWithSpacesThenAddWordThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(StringWordWithSpaces));
        }

        private void StringWordWithSpaces()
        {
            sut.AddWord("BONES KHAN");
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedAStringWithSpecialCharactersThenAddWordThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(StringWordWithSpecialCharacters));
        }

        private void StringWordWithSpecialCharacters()
        {
            sut.AddWord("BONE$");
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedAStringWithACommaThenAddWordThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(StringWordWithComma));
        }

        private void StringWordWithComma()
        {
            sut.AddWord("BONES,KHAN");
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedAStringWithAPunctuationThenAddWordThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(StringWordWithPunctiation));
        }

        private void StringWordWithPunctiation()
        {
            sut.AddWord("BONES!");
        }
    }
}
