﻿using NUnit.Framework;
using PuzzleSolverProject;
using PuzzleSolverProject.DirectionSearchStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverUnitTest.DirectionSearchStrategyTests
{
    [TestFixture(typeof(DownDirectionSearchStrategy))]
    public class DownDirectionSearchStrategyTest<T> : DirectionSearchStrategyBaseTest where T : IDirectionSearchStrategy
    {
        protected override IDirectionSearchStrategy CreateInstance(WordSearchPuzzle puzzle)
        {
            return new DownDirectionSearchStrategy(puzzle);
        }

        [Test, TestCaseSource(typeof(DirectionSearchStrategyTestData), Base4x4PuzzleTestCase)]
        public void Given4x4WordSearchPuzzleWhenPassing00And4ToGetNeighborsFromThenGetNeighborsFromReturnsListOfLocationsFrom00Down(WordSearchPuzzle puzzle)
        {
            IDirectionSearchStrategy sut = CreateInstance(puzzle);

            Vector2 startLocation = new Vector2(0, 0);
            int length = 4;

            List<Vector2> result = sut.GetNeighborsFrom(startLocation, length);
            List<Vector2> expected = new List<Vector2>();
            expected.Add(new Vector2(0, 0));
            expected.Add(new Vector2(0, 1));
            expected.Add(new Vector2(0, 2));
            expected.Add(new Vector2(0, 3));

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(DirectionSearchStrategyTestData), Base4x4PuzzleTestCase)]
        public void Given4x4WordSearchPuzzleWhenPassing30And4ToGetNeighborsFromThenGetNeighborsFromReturnsListOfLocationsFrom30Down(WordSearchPuzzle puzzle)
        {
            IDirectionSearchStrategy sut = CreateInstance(puzzle);

            Vector2 startLocation = new Vector2(3, 0);
            int length = 4;

            List<Vector2> result = sut.GetNeighborsFrom(startLocation, length);
            List<Vector2> expected = new List<Vector2>();
            expected.Add(new Vector2(3, 0));
            expected.Add(new Vector2(3, 1));
            expected.Add(new Vector2(3, 2));
            expected.Add(new Vector2(3, 3));

            Assert.AreEqual(expected, result);
        }
    }
}
