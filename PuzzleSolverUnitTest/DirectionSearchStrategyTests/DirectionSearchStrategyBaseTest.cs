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
        protected const String Base4x4PuzzleTestCase = nameof(DirectionSearchStrategyTestData.Base4x4PuzzleTestCase);
        protected const String Base5x5PuzzleTestCase = nameof(DirectionSearchStrategyTestData.Base5x5PuzzleTestCase);

        protected abstract IDirectionSearchStrategy CreateInstance(WordSearchPuzzle puzzle);

        [Test, TestCaseSource(typeof(DirectionSearchStrategyTestData), Base4x4PuzzleTestCase)]
        public void Given4x4WordSearchPuzzleWhenPassingStarting00and4ToGetNeighborsFromThenGetNeighborsFromDoesNotReturnNull(WordSearchPuzzle puzzle)
        {
            IDirectionSearchStrategy sut = CreateInstance(puzzle);

            Vector2 startLocation = new Vector2(0, 0);
            int length = 4;

            List<Vector2> result = sut.GetNeighborsFrom(startLocation, length);

            Assert.IsNotNull(result);
        }

        [Test, TestCaseSource(typeof(DirectionSearchStrategyTestData), Base5x5PuzzleTestCase)]
        public void Given5x5WordSearchPuzzleWhenPassing22And5ToGetNeighborsFromThenGetNeighborsFromReturnsVector2ListWith3Elements(WordSearchPuzzle puzzle)
        {
            IDirectionSearchStrategy sut = CreateInstance(puzzle);

            Vector2 startLocation = new Vector2(2, 2);
            int length = 5;
            List<Vector2> locations = sut.GetNeighborsFrom(startLocation, length);

            int result = locations.Count;
            int expected = 3;

            Assert.AreEqual(expected, result);
        }
    }
}
