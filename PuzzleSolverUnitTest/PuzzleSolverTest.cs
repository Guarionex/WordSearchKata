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
    }
}
