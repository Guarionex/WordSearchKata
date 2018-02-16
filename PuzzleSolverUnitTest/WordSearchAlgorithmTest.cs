using NUnit.Framework;
using PuzzleSolverProject;
using PuzzleSolverProject.DirectionSearchStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverUnitTest
{
    [TestFixture]
    public class WordSearchAlgorithmTest
    {
        private const String ValidOneWordPuzzleTestCase = nameof(WordSearchAlgorithmTestData.ValidOneWordPuzzleTestCase);

        private WordSearchAlgorithm sut;

        [Test, TestCaseSource(typeof(WordSearchAlgorithmTestData), ValidOneWordPuzzleTestCase)]
        public void Given4x4WordWithTwoWordsPuzzleWhenCallingGetWordsLocationsThenGetWordsReturnsAStringListVector2Dictionary(WordSearchPuzzle puzzle)
        {
            DirectionSearchFactory directionSearchFactory = new DirectionSearchFactory(puzzle);
            sut = new WordSearchAlgorithm(directionSearchFactory.CreateStrategies());

            Dictionary<String, List<Vector2>> result = sut.SearchEachWord(puzzle.WordsList);
            Assert.IsInstanceOf(typeof(Dictionary<String, List<Vector2>>), result);
        }
    }
}
