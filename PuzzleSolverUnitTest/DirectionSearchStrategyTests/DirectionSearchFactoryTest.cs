using NUnit.Framework;
using PuzzleSolverProject;
using PuzzleSolverProject.DirectionSearchStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverUnitTest.DirectionSearchStrategyTests
{
    [TestFixture]
    public class DirectionSearchFactoryTest
    {
        private DirectionSearchFactory sut;

        [SetUp]
        public void init()
        {
            WordSearchPuzzle puzzle = new WordSearchPuzzle();
            sut = new DirectionSearchFactory(puzzle);
        }
        [Test]
        public void GivenDirectionSearchFactoryWhenCallingCreateStrategiesThenCreateStrategiesDoesNotReturnNull()
        {
            Dictionary<DirectionEnum, IDirectionSearchStrategy> result = sut.CreateStrategies();

            Assert.IsNotNull(result);
        }
    }
}
