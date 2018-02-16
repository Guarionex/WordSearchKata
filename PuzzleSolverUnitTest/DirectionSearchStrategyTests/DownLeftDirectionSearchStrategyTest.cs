using NUnit.Framework;
using PuzzleSolverProject;
using PuzzleSolverProject.GetNeighbors;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
