using NUnit.Framework;
using PuzzleSolverProject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverUnitTest
{
    [TestFixture]
    public class PuzzleFileParserTest
    {
        private const String Example15x15TestCase = nameof(PuzzleFileParserTestData.Example15x15TestCase);

        private PuzzleFileParser sut;
        private String validPuzzleFileName;
        private String testPuzzlePath;

        [SetUp]
        public void init()
        {
            sut = new PuzzleFileParser();

            validPuzzleFileName = "Valid4x4.txt";
            testPuzzlePath = @"C:\Users\chesp\source\repos\WordSearchKata\TestPuzzles\";
        }

        [Test]
        public void GivenAValidStringFileNameContainingAValidWordPuzzleWhenPassedIntoParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsNoException()
        {
            sut.ParseFileToWordSearchPuzzle(testPuzzlePath + validPuzzleFileName);
        }

        [Test]
        public void GivenAValidStringFileNameContainingAValidWordPuzzleWhenPassedIntoParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleReturnsAWordSearchPuzzle()
        {
            Assert.IsInstanceOf(typeof(WordSearchPuzzle), sut.ParseFileToWordSearchPuzzle(testPuzzlePath + validPuzzleFileName));
        }

        [Test, TestCaseSource(typeof(PuzzleFileParserTestData), Example15x15TestCase)]
        public void GivenAValidStringFileNameContainingAValidWordPuzzleWhenPassedIntoParseFileToWordSearchPuzzleThenResultingWordSearchPuzzleGetWordsListHasTheSolution(Dictionary<String, List<Vector2>> expected)
        {
            WordSearchPuzzle puzzle = sut.ParseFileToWordSearchPuzzle(testPuzzlePath + "Example15x15.txt");
            Dictionary<String, List<Vector2>> result = puzzle.GetWordsLocation();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenAInvalidStringFileNameWhenPassedIntoParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsFileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(new TestDelegate(ParseFileInvalidFileName));
        }

        private void ParseFileInvalidFileName()
        {
            sut.ParseFileToWordSearchPuzzle("meh.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingAlphaNumericWordsWhenPassedIntoParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileAlphaNumericWords));
        }

        private void ParseFileAlphaNumericWords()
        {
            sut.ParseFileToWordSearchPuzzle(testPuzzlePath + "alphaNumeric4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingWordsWithSpacesWhenPassedIntoParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileWordsSpaces));
        }

        private void ParseFileWordsSpaces()
        {
            sut.ParseFileToWordSearchPuzzle(testPuzzlePath + "spaces4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingWordsWithSymbolsWhenPassedIntoParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileWordsSymbols));
        }

        private void ParseFileWordsSymbols()
        {
            sut.ParseFileToWordSearchPuzzle(testPuzzlePath + "symbols4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingWordsWithPunctuationsWhenPassedIntoParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileWordsPunctuations));
        }

        private void ParseFileWordsPunctuations()
        {
            sut.ParseFileToWordSearchPuzzle(testPuzzlePath + "punctuation4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithSSVWordsPuzzleWhenPassedIntoParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseFileSSV));
        }

        private void ParseFileSSV()
        {
            sut.ParseFileToWordSearchPuzzle(testPuzzlePath + "ssv4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithCSSVWordsPuzzleWhenPassedIntoParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseFileCSSV));
        }

        private void ParseFileCSSV()
        {
            sut.ParseFileToWordSearchPuzzle(testPuzzlePath + "cssv4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithEmptyWordPuzzleWhenPassedIntoParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileEmptyWord));
        }

        private void ParseFileEmptyWord()
        {
            sut.ParseFileToWordSearchPuzzle(testPuzzlePath + "empty4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithSSVLettersPuzzleWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseFileSSVLetters));
        }

        private void ParseFileSSVLetters()
        {
            sut.ParseFileToWordSearchPuzzle(testPuzzlePath + "ssvLetters4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithCSSVLettersPuzzleWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseFileCSSVLetters));
        }

        private void ParseFileCSSVLetters()
        {
            sut.ParseFileToWordSearchPuzzle(testPuzzlePath + "cssvLetters4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithUnequalDimensionsPuzzleWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseFileUnequal));
        }

        private void ParseFileUnequal()
        {
            sut.ParseFileToWordSearchPuzzle(testPuzzlePath + "unequalLetters4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithVaryingLengthsPuzzleWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseFileVarying));
        }

        private void ParseFileVarying()
        {
            sut.ParseFileToWordSearchPuzzle(testPuzzlePath + "varyingLetters4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingNumbersWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileNumberInLetters));
        }

        private void ParseFileNumberInLetters()
        {
            sut.ParseFileToWordSearchPuzzle(testPuzzlePath + "numberLetters4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingSymbolsWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileSymbolsInLetters));
        }

        private void ParseFileSymbolsInLetters()
        {
            sut.ParseFileToWordSearchPuzzle(testPuzzlePath + "symbolLetters4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingPunctuationsWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFilePunctuationsInLetters));
        }

        private void ParseFilePunctuationsInLetters()
        {
            sut.ParseFileToWordSearchPuzzle(testPuzzlePath + "punctuationLetters4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWith2x2PuzzleWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsNoException()
        {
            sut.ParseFileToWordSearchPuzzle(testPuzzlePath + "valid2x2.txt");
        }

        [Test]
        public void GivenValidFileNameWith1x1PuzzleWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(ParseFile1x1));
        }

        private void ParseFile1x1()
        {
            sut.ParseFileToWordSearchPuzzle(testPuzzlePath + "1x1.txt");
        }

        [Test]
        public void GivenValidFileNameWith1x1WithTrailingCommaPuzzleWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(ParseFile1x1Comma));
        }

        private void ParseFile1x1Comma()
        {
            sut.ParseFileToWordSearchPuzzle(testPuzzlePath + "1x1Comma.txt");
        }

        [Test]
        public void GivenValidFileNameWith0x0PuzzleWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(ParseFile0x0));
        }

        private void ParseFile0x0()
        {
            sut.ParseFileToWordSearchPuzzle(testPuzzlePath + "0x0.txt");
        }

        [Test]
        public void GivenValidFileNameWith4x4PuzzleWithInvalidWordSearchPuzzleWhenCallingParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(new TestDelegate(ParseFileInvalidPuzzle));
        }

        private void ParseFileInvalidPuzzle()
        {
            sut.ParseFileToWordSearchPuzzle(testPuzzlePath + "wordMissing4x4.txt");
        }
    }
}
