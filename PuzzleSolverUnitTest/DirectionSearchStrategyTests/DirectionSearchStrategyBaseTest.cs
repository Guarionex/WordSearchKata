using NUnit.Framework;
using PuzzleSolverProject;
using PuzzleSolverProject.GetNeighbors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverUnitTest.DirectionSearchStrategyTests
{
    [TestFixture]
    public abstract class DirectionSearchStrategyBaseTest
    {
        private const String BasePuzzleTestCase = nameof(DirectionSearchStrategyTestData.BasePuzzleTestCase);

        protected abstract IDirectionSearchStrategy CreateInstance(WordSearchPuzzle puzzle);

        [Test, TestCaseSource(typeof(DirectionSearchStrategyTestData), BasePuzzleTestCase)]
        public void GivenStartingLocationAndLengthWhenPassedToGetNeighborsFromThenGetNeighborsFromThrowsNoException(WordSearchPuzzle puzzle)
        {
            IDirectionSearchStrategy sut = CreateInstance(puzzle);

            Vector2 startLocation = new Vector2(0, 0);
            int length = 4;
            sut.GetNeighborsFrom(startLocation, length);
        }
    }
}
