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
    [TestFixture(typeof(DownLeftDirectionSearchStrategy))]
    public class DownLeftDirectionSearchStrategyTest<T> : DirectionSearchStrategyBaseTest where T : IDirectionSearchStrategy
    {
        protected override IDirectionSearchStrategy CreateInstance(WordSearchPuzzle puzzle)
        {
            return new DownLeftDirectionSearchStrategy(puzzle);
        }

        [Test, TestCaseSource(typeof(DirectionSearchStrategyTestData), Base4x4PuzzleTestCase)]
        public void Given4x4WordSearchPuzzleWhenPassing30And4ToGetNeighborsFromThenGetNeighborsFromReturnsListOfLocationsFrom30DownLeft(WordSearchPuzzle puzzle)
        {
            IDirectionSearchStrategy sut = CreateInstance(puzzle);

            Vector2 startLocation = new Vector2(3, 0);
            int length = 4;

            List<Vector2> result = sut.GetNeighborsFrom(startLocation, length);
            List<Vector2> expected = new List<Vector2>();
            expected.Add(new Vector2(3, 0));
            expected.Add(new Vector2(2, 1));
            expected.Add(new Vector2(1, 2));
            expected.Add(new Vector2(0, 3));

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(DirectionSearchStrategyTestData), Base4x4PuzzleTestCase)]
        public void Given4x4WordSearchPuzzleWhenPassing20And3ToGetNeighborsFromThenGetNeighborsFromReturnsListOfLocationsFrom20DownLeft(WordSearchPuzzle puzzle)
        {
            IDirectionSearchStrategy sut = CreateInstance(puzzle);

            Vector2 startLocation = new Vector2(2, 0);
            int length = 3;

            List<Vector2> result = sut.GetNeighborsFrom(startLocation, length);
            List<Vector2> expected = new List<Vector2>();
            expected.Add(new Vector2(2, 0));
            expected.Add(new Vector2(1, 1));
            expected.Add(new Vector2(0, 2));

            Assert.AreEqual(expected, result);
        }
    }
}
