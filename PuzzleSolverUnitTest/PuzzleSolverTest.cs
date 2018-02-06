using NUnit.Framework;
using PuzzleSolverProject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverUnitTest
{
    [TestFixture]
    public class PuzzleSolverTest
    {
        private PuzzleSolver sut;
        private String validPuzzleFileName;
        private String projectPath;

        [SetUp]
        public void init()
        {
            sut = new PuzzleSolver();

            validPuzzleFileName = "Valid4x4.txt";
            projectPath = @"C:\Users\chesp\source\repos\WordSearchKata\";
        }

        [Test]
        public void GivenAValidStringFileNameContainingAValidWordPuzzleWhenPassedIntoParsePuzzleWordFileThenParsePuzzleWordFileThrowsNoException()
        {
            sut.ParsePuzzleWordFile(projectPath + validPuzzleFileName);
        }

        [Test]
        public void GivenAInvalidStringFileNameWhenPassedIntoParsePuzzleWordFileThenParsePuzzleWordFileThrowsFileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(new TestDelegate(ParseFileInvalidFileName));
        }

        private void ParseFileInvalidFileName()
        {
            sut.ParsePuzzleWordFile("meh.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingAlphaNumericWordsWhenPassedIntoParsePuzzleWordFileThenParsePuzzleWordFileThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileAlphaNumericWords));
        }

        private void ParseFileAlphaNumericWords()
        {
            sut.ParsePuzzleWordFile(projectPath + "alphaNumeric4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingWordsWithSpacesWhenPassedIntoParsePuzzleWordFileThenParsePuzzleWordFileThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileWordsSpaces));
        }

        private void ParseFileWordsSpaces()
        {
            sut.ParsePuzzleWordFile(projectPath + "spaces4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingWordsWithSymbolsWhenPassedIntoParsePuzzleWordFileThenParsePuzzleWordFileThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileWordsSymbols));
        }

        private void ParseFileWordsSymbols()
        {
            sut.ParsePuzzleWordFile(projectPath + "symbols4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingWordsWithPunctuationsWhenPassedIntoParsePuzzleWordFileThenParsePuzzleWordFileThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileWordsPunctuations));
        }

        private void ParseFileWordsPunctuations()
        {
            sut.ParsePuzzleWordFile(projectPath + "punctuation4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithSSVWordsPuzzleWhenPassedIntoParsePuzzleWordFileThenParsePuzzleWordFileThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseFileSSV));
        }

        private void ParseFileSSV()
        {
            sut.ParsePuzzleWordFile(projectPath + "ssv4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithCSSVWordsPuzzleWhenPassedIntoParsePuzzleWordFileThenParsePuzzleWordFileThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseFileCSSV));
        }

        private void ParseFileCSSV()
        {
            sut.ParsePuzzleWordFile(projectPath + "cssv4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithEmptyWordPuzzleWhenPassedIntoParsePuzzleWordFileThenParsePuzzleWordFileThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileEmptyWord));
        }

        private void ParseFileEmptyWord()
        {
            sut.ParsePuzzleWordFile(projectPath + "empty4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithSSVLettersPuzzleWhenPassedToParsePuzzleWordFileThenParsePuzzleWordFileThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseFileSSVLetters));
        }

        private void ParseFileSSVLetters()
        {
            sut.ParsePuzzleWordFile(projectPath + "ssvLetters4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithCSSVLettersPuzzleWhenPassedToParsePuzzleWordFileThenParsePuzzleWordFileThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseFileCSSVLetters));
        }

        private void ParseFileCSSVLetters()
        {
            sut.ParsePuzzleWordFile(projectPath + "cssvLetters4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithUnequalDimensionsPuzzleWhenPassedToParsePuzzleWordFileThenParsePuzzleWordFileThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseFileUnequal));
        }

        private void ParseFileUnequal()
        {
            sut.ParsePuzzleWordFile(projectPath + "unequalLetters4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithVaryingLengthsPuzzleWhenPassedToParsePuzzleWordFileThenParsePuzzleWordFileThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseFileVarying));
        }

        private void ParseFileVarying()
        {
            sut.ParsePuzzleWordFile(projectPath + "varyingLetters4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingNumbersWhenPassedToParsePuzzleWordFileThenParsePuzzleWordFileThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileNumberInLetters));
        }

        private void ParseFileNumberInLetters()
        {
            sut.ParsePuzzleWordFile(projectPath + "numberLetters4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingSymbolsWhenPassedToParsePuzzleWordFileThenParsePuzzleWordFileThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileSymbolsInLetters));
        }

        private void ParseFileSymbolsInLetters()
        {
            sut.ParsePuzzleWordFile(projectPath + "symbolLetters4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingPunctuationsWhenPassedToParsePuzzleWordFileThenParsePuzzleWordFileThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFilePunctuationsInLetters));
        }

        private void ParseFilePunctuationsInLetters()
        {
            sut.ParsePuzzleWordFile(projectPath + "punctuationLetters4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWith2x2PuzzleWhenPassedToParsePuzzleWordFileThenParsePuzzleWordFileThrowsNoException()
        {
            sut.ParsePuzzleWordFile(projectPath + "valid2x2.txt");
        }

        [Test]
        public void GivenValidFileNameWith1x1PuzzleWhenPassedToParsePuzzleWordFileThenParsePuzzleWordFileThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(ParseFile1x1));
        }

        private void ParseFile1x1()
        {
            sut.ParsePuzzleWordFile(projectPath + "1x1.txt");
        }

        [Test]
        public void GivenValidFileNameWith1x1WithTrailingCommaPuzzleWhenPassedToParsePuzzleWordFileThenParsePuzzleWordFileThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(ParseFile1x1Comma));
        }

        private void ParseFile1x1Comma()
        {
            sut.ParsePuzzleWordFile(projectPath + "1x1Comma.txt");
        }

        [Test]
        public void GivenValidFileNameWith0x0PuzzleWhenPassedToParsePuzzleWordFileThenParsePuzzleWordFileThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(ParseFile0x0));
        }

        private void ParseFile0x0()
        {
            sut.ParsePuzzleWordFile(projectPath + "0x0.txt");
        }

        [Test]
        public void GivenValidFileNameWithValidPuzzleWhenPassedToParsePuzzleWordFileThenParsePuzzleWorldFileReturnsAWordSearchPuzzle()
        {
            Assert.IsInstanceOf(typeof(WordSearchPuzzle), sut.ParsePuzzleWordFile(projectPath + validPuzzleFileName));
        }
    }
}
