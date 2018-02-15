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
        private const String ValidTwoWordWordsMapTestCase = nameof(WordsMapDecoratorTestData.ValidTwoWordWordsMapTestCase);
        private const String ValidThreeWordWordsMapTestCase = nameof(WordsMapDecoratorTestData.ValidThreeWordWordsMapTestCase);

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
        public void GivenValidOneWordWordsMapDictionaryWhenCallingIsValidThenIsValidReturnsTrue(Dictionary<String, List<Vector2>> wordsMap)
        {
            sut = new WordsMapDecorator(wordsMap);

            bool result = sut.IsValid();

            Assert.IsTrue(result);
        }

        [Test]
        public void GivenEmptyWordsMapDictionaryWhenCallingIsValidThenIsValidReturnsFalse()
        {
            Dictionary<String, List<Vector2>> wordsMap = new Dictionary<string, List<Vector2>>();
            sut = new WordsMapDecorator(wordsMap);

            bool result = sut.IsValid();

            Assert.IsFalse(result);
        }

        [Test, TestCaseSource(typeof(WordsMapDecoratorTestData), ValidOneWordWordsMapTestCase)]
        public void GivenValidOneWordWordsMapDictionaryWhenCallingToStringThenToStringReturnsAString(Dictionary<String, List<Vector2>> wordsMap)
        {
            sut = new WordsMapDecorator(wordsMap);

            String result = sut.ToString();

            Assert.IsInstanceOf(typeof(String), result);
        }

        [Test, TestCaseSource(typeof(WordsMapDecoratorTestData), ValidOneWordWordsMapTestCase)]
        public void GivenValidOneWordWordsMapDictionaryWhenCallingToStringThenToStringReturnsAStringWithWordsAndTheirLetterLocations(Dictionary<String, List<Vector2>> wordsMap)
        {
            sut = new WordsMapDecorator(wordsMap);

            String result = sut.ToString();
            String expected = "KIRK: (0,1),(1,1),(2,1),(3,1)";

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordsMapDecoratorTestData), ValidTwoWordWordsMapTestCase)]
        public void GivenValidTwoWordWordsMapDictionaryWhenCallingToStringThenToStringReturnsAStringWithWordsAndTheirLetterLocations(Dictionary<String, List<Vector2>> wordsMap)
        {
            sut = new WordsMapDecorator(wordsMap);

            String result = sut.ToString();
            String expected = "KIRK: (0,1),(1,1),(2,1),(3,1)\n";
            expected += "KHAN: (0,3),(1,3),(2,3),(3,3)";

            Assert.AreEqual(expected, result);
        }

        [Test, TestCaseSource(typeof(WordsMapDecoratorTestData), ValidThreeWordWordsMapTestCase)]
        public void GivenValidThreeWordWordsMapDictionaryWhenCallingToStringThenToStringReturnsAStringWithWordsAndTheirLetterLocations(Dictionary<String, List<Vector2>> wordsMap)
        {
            sut = new WordsMapDecorator(wordsMap);

            String result = sut.ToString();
            String expected = "KIRK: (0,1),(1,1),(2,1),(3,1)\n";
            expected += "KHAN: (0,3),(1,3),(2,3),(3,3)\n";
            expected += "SULU: (0,0),(1,0),(2,0),(3,0)";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenEmptyWordsMapDictionaryWhenCallingToStringThenToStringReturnsAnEmptyString()
        {
            Dictionary<String, List<Vector2>> wordsMap = new Dictionary<string, List<Vector2>>();
            sut = new WordsMapDecorator(wordsMap);

            String result = sut.ToString();
            String expected = "";

            Assert.AreEqual(expected, result);
        }
    }
}
