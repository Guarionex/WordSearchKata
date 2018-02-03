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

        [Test]
        public void GivenPuzzleSolverWhenPassedLetterCharacterAtPosition00ThenAddCharacterAtThrowsNoException()
        {
            sut.AddLetterAt('U', 0, 0);
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedNumberCharacterAtPosition00ThenAddCharacterAtThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(NumberCharacterAt00));
        }

        private void NumberCharacterAt00()
        {
            sut.AddLetterAt('5', 0, 0);
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedSpaceCharacterAtPosition00ThenAddCharacterAtThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(SpaceCharacterAt00));
        }

        private void SpaceCharacterAt00()
        {
            sut.AddLetterAt(' ', 0, 0);
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedSymbolCharacterAtPosition00ThenAddCharacterAtThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(SymbolCharacterAt00));
        }

        private void SymbolCharacterAt00()
        {
            sut.AddLetterAt('$', 0, 0);
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedCommaCharacterAtPosition00ThenAddCharacterAtThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(CommaCharacterAt00));
        }

        private void CommaCharacterAt00()
        {
            sut.AddLetterAt(',', 0, 0);
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedPunctiationCharacterAtPosition00ThenAddCharacterAtThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(PunctiationCharacterAt00));
        }

        private void PunctiationCharacterAt00()
        {
            sut.AddLetterAt('!', 0, 0);
        }
    }
}
