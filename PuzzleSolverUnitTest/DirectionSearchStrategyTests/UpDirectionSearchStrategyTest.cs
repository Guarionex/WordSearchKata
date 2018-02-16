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
    [TestFixture(typeof(UpDirectionSearchStrategy))]
    public class UpDirectionSearchStrategyTest<T> : DirectionSearchStrategyBaseTest where T : IDirectionSearchStrategy
    {
        
        protected override IDirectionSearchStrategy CreateInstance(WordSearchPuzzle puzzle)
        {
            return new UpDirectionSearchStrategy(puzzle);
        }

        [Test, TestCaseSource(typeof(DirectionSearchStrategyTestData), BasePuzzleTestCase)]
        public void GivenStartingLocation03AndLength4WhenPassedToGetNeighborsFromThenGetNeighborsFromReturnsListOfLocationsFrom03Up(WordSearchPuzzle puzzle)
        {
            IDirectionSearchStrategy sut = CreateInstance(puzzle);

            Vector2 startLocation = new Vector2(0, 3);
            int length = 4;

            List<Vector2> result = sut.GetNeighborsFrom(startLocation, length);
            List<Vector2> expected = new List<Vector2>();
            expected.Add(new Vector2(0, 3));
            expected.Add(new Vector2(0, 2));
            expected.Add(new Vector2(0, 1));
            expected.Add(new Vector2(0, 0));

            Assert.AreEqual(expected, result);
        }
    }
}
