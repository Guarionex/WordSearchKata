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
    [TestFixture(typeof(UpLeftDirectionSearchStrategy))]
    public class UpLeftDirectionSearchStrategyTest<T> : DirectionSearchStrategyBaseTest where T : IDirectionSearchStrategy
    {
        protected override IDirectionSearchStrategy CreateInstance(WordSearchPuzzle puzzle)
        {
            return new UpLeftDirectionSearchStrategy(puzzle);
        }

        [Test, TestCaseSource(typeof(DirectionSearchStrategyTestData), Base4x4PuzzleTestCase)]
        public void Given4x4WordSearchPuzzleWhenPassing33And4ToGetNeighborsFromThenGetNeighborsFromReturnsListOfLocationsFrom33UpLeft(WordSearchPuzzle puzzle)
        {
            IDirectionSearchStrategy sut = CreateInstance(puzzle);

            Vector2 startLocation = new Vector2(3, 3);
            int length = 4;

            List<Vector2> result = sut.GetNeighborsFrom(startLocation, length);
            List<Vector2> expected = new List<Vector2>();
            expected.Add(new Vector2(3, 3));
            expected.Add(new Vector2(2, 2));
            expected.Add(new Vector2(1, 1));
            expected.Add(new Vector2(0, 0));

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(DirectionSearchStrategyTestData), Base4x4PuzzleTestCase)]
        public void Given4x4WordSearchPuzzleWhenPassing23And3ToGetNeighborsFromThenGetNeighborsFromReturnsListOfLocationsFrom23UpLeft(WordSearchPuzzle puzzle)
        {
            IDirectionSearchStrategy sut = CreateInstance(puzzle);

            Vector2 startLocation = new Vector2(2, 3);
            int length = 3;

            List<Vector2> result = sut.GetNeighborsFrom(startLocation, length);
            List<Vector2> expected = new List<Vector2>();
            expected.Add(new Vector2(2, 3));
            expected.Add(new Vector2(1, 2));
            expected.Add(new Vector2(0, 1));

            Assert.AreEqual(expected, result);
        }
    }
}
