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

        [Test]
        public void GivenDirectionSearchFactoryWhenCallingCreateStrategiesThenCreateStrategiesReturnsDictionaryWith8KVP()
        {
            Dictionary<DirectionEnum, IDirectionSearchStrategy> strategies = sut.CreateStrategies();

            int result = strategies.Count;
            int expected = 8;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenDirectionSearchFactoryWhenCallingCreateStrategiesThenCreateStrategiesReturnsDictionaryWithAllEightStrategiesOnlyOnceEach()
        {
            Dictionary<DirectionEnum, IDirectionSearchStrategy> strategiesMap = sut.CreateStrategies();

            Dictionary<Type, int> result = new Dictionary<Type, int>();
            foreach (IDirectionSearchStrategy strategy in strategiesMap.Values)
            {
                if(result.ContainsKey(strategy.GetType()))
                {
                    result[strategy.GetType()]++;
                }
                else
                {
                    result.Add(strategy.GetType(), 1);
                }
            }

            Dictionary<Type, int> expected = new Dictionary<Type, int>();
            expected.Add(typeof(UpDirectionSearchStrategy), 1);
            expected.Add(typeof(DownDirectionSearchStrategy), 1);
            expected.Add(typeof(LeftDirectionSearchStrategy), 1);
            expected.Add(typeof(RightDirectionSearchStrategy), 1);
            expected.Add(typeof(UpLeftDirectionSearchStrategy), 1);
            expected.Add(typeof(UpRightDirectionSearchStrategy), 1);
            expected.Add(typeof(DownLeftDirectionSearchStrategy), 1);
            expected.Add(typeof(DownRightDirectionSearchStrategy), 1);

            Assert.AreEqual(expected, result);
        }
    }
}
