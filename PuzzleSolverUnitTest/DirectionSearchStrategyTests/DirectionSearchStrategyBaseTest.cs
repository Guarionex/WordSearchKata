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
        protected const String BasePuzzleTestCase = nameof(DirectionSearchStrategyTestData.BasePuzzleTestCase);

        protected abstract IDirectionSearchStrategy CreateInstance(WordSearchPuzzle puzzle);

        [Test, TestCaseSource(typeof(DirectionSearchStrategyTestData), BasePuzzleTestCase)]
        public void GivenStartingLocationAndLengthWhenPassedToGetNeighborsFromThenGetNeighborsFromDoesNotReturnNull(WordSearchPuzzle puzzle)
        {
            IDirectionSearchStrategy sut = CreateInstance(puzzle);

            Vector2 startLocation = new Vector2(0, 0);
            int length = 4;

            List<Vector2> result = sut.GetNeighborsFrom(startLocation, length);

            Assert.IsNotNull(result);
        }
    }
}
