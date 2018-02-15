using NUnit.Framework;
using PuzzleSolverProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverUnitTest
{
    [TestFixture]
    public class WordsMapDecoratorTest
    {
        private const String ValidOneWordWordsMapTestCase = nameof(WordsMapDecoratorTestData.ValidOneWordWordsMapTestCase);

        private WordsMapDecorator sut;

        [Test]
        public void GivenWordsMapDictionaryFinderWhenPassToWordsMapDecoratorConstructorThenThrowNoException()
        {
            Dictionary<String, List<Vector2>> wordsMap = new Dictionary<string, List<Vector2>>();

            sut = new WordsMapDecorator(wordsMap);
        }

        [Test, TestCaseSource(typeof(WordsMapDecoratorTestData), ValidOneWordWordsMapTestCase)]
        public void GivenValidOneWordWordsMapDictionaryWhenCallingIsValidThenIsValidThrowsNoException(Dictionary<String, List<Vector2>> wordsMap)
        {
            sut = new WordsMapDecorator(wordsMap);

            sut.IsValid();
        }

        [Test, TestCaseSource(typeof(WordsMapDecoratorTestData), ValidOneWordWordsMapTestCase)]
        public void GivenValid4x4WordPuzzleWithWordsWhenCallingIsValidThenIsValidReturnsTrue(Dictionary<String, List<Vector2>> wordsMap)
        {
            sut = new WordsMapDecorator(wordsMap);

            bool result = sut.IsValid();

            Assert.IsTrue(result);
        }
    }
}
