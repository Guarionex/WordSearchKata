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

        [Test, TestCaseSource(typeof(DirectionSearchStrategyTestData), Base4x4PuzzleTestCase)]
        public void Given4x4WordSearchPuzzleWhenPassingKToGetAllLocationsOfLetterThenGetAllLocationsOfLetterDoesNotReturnNull(WordSearchPuzzle puzzle)
        {
            IDirectionSearchStrategy sut = CreateInstance(puzzle);

            List<Vector2> result = sut.GetAllLocationsOfLetter('K');

            Assert.IsNotNull(result);
        }

        [Test, TestCaseSource(typeof(DirectionSearchStrategyTestData), Base4x4PuzzleTestCase)]
        public void Given4x4WordSearchPuzzleWhenPassingKToGetAllLocationsOfLetterThenGetAllLocationsOfLetterReturnsLocationOf2Ks(WordSearchPuzzle puzzle)
        {
            IDirectionSearchStrategy sut = CreateInstance(puzzle);

            List<Vector2> result = sut.GetAllLocationsOfLetter('K');
            List<Vector2> expected = new List<Vector2>();
            expected.Add(new Vector2(0, 0));
            expected.Add(new Vector2(0, 3));

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(DirectionSearchStrategyTestData), Base4x4PuzzleTestCase)]
        public void Given4x4WordSearchPuzzleWhenPassingEToGetAllLocationsOfLetterThenGetAllLocationsOfLetterReturnsLocationOf1E(WordSearchPuzzle puzzle)
        {
            IDirectionSearchStrategy sut = CreateInstance(puzzle);

            List<Vector2> result = sut.GetAllLocationsOfLetter('E');
            List<Vector2> expected = new List<Vector2>();
            expected.Add(new Vector2(1, 0));

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(DirectionSearchStrategyTestData), Base4x4PuzzleTestCase)]
        public void Given4x4WordSearchPuzzleWhenFirstRowLocationListToGetStringFromLocationsThenGetStringFromLocationsDoesNotReturnNull(WordSearchPuzzle puzzle)
        {
            IDirectionSearchStrategy sut = CreateInstance(puzzle);
            List<Vector2> firstRow = new List<Vector2>();
            firstRow.Add(new Vector2(0, 0));
            firstRow.Add(new Vector2(1, 0));
            firstRow.Add(new Vector2(2, 0));
            firstRow.Add(new Vector2(3, 0));

            String result = sut.GetStringFromLocations(firstRow);

            Assert.IsNotNull(result);
        }
    }
}
