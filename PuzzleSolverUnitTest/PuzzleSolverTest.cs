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
        private String[] validCSVLetters;
        private String validPuzzleFileName;
        private String projectPath;

        [SetUp]
        public void init()
        {
            sut = new PuzzleSolver();

            validCSVLetters = new String[4];
            validCSVLetters[0] = "K,R,I,K";
            validCSVLetters[1] = "E,M,H,P";
            validCSVLetters[2] = "X,A,D,M";
            validCSVLetters[3] = "N,C,H,U";

            validPuzzleFileName = "Valid4x4.txt";
            projectPath = @"C:\Users\chesp\source\repos\WordSearchKata\";
        }

        [Test]
        public void GivenStringArrayOfValidCSVLettersWhenPassedToParseLettersThenThrowNoException()
        {
            sut.ParseLetters(validCSVLetters);
        }

        [Test]
        public void GivenStringArrayOfSSVLettersWhenPassedToParseLettersThenThrowFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseLetterArraySSV));
        }

        private void ParseLetterArraySSV()
        {
            String[] ssvLetters = new String[4];
            ssvLetters[0] = "K R I K";
            ssvLetters[1] = "E M H P";
            ssvLetters[2] = "X A D M";
            ssvLetters[3] = "N C H U";
            sut.ParseLetters(ssvLetters);
        }

        [Test]
        public void GivenStringArrayOfCSSVLettersWhenPassedToParseLettersThenThrowFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseLetterArrayCSSV));
        }

        private void ParseLetterArrayCSSV()
        {
            String[] ssvLetters = new String[4];
            ssvLetters[0] = "K, R, I, K";
            ssvLetters[1] = "E, M, H, P";
            ssvLetters[2] = "X, A, D, M";
            ssvLetters[3] = "N, C, H, U";
            sut.ParseLetters(ssvLetters);
        }

        [Test]
        public void GivenStringArrayOfLettersWithUnequalDimensionsWhenPassedToParseLettersThenParseLettersThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseLettersUnequalDimensions));
        }

        private void ParseLettersUnequalDimensions()
        {
            String[] unequalDimensionsLetters = new String[3];
            unequalDimensionsLetters[0] = "K,R,I,K";
            unequalDimensionsLetters[1] = "E,M,H,P";
            unequalDimensionsLetters[2] = "X,A,D,M";
            sut.ParseLetters(unequalDimensionsLetters);
        }

        [Test]
        public void GivenStringArrayOfLettersWithVaryingLengthsWhenPassedToParseLettersThenParseLettersThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseLettersVaryingLengths));
        }

        private void ParseLettersVaryingLengths()
        {
            String[] varyingLengthsLetters = new String[4];
            varyingLengthsLetters[0] = "K,R,I,K";
            varyingLengthsLetters[1] = "E,M,H";
            varyingLengthsLetters[2] = "X,A,D,M";
            varyingLengthsLetters[3] = "N,C";
            sut.ParseLetters(varyingLengthsLetters);
        }

        [Test]
        public void GivenStringArrayOfLettersWithNumbersWhenPassedToParseLettersThenParseLettersThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseLettersNumbers));
        }

        private void ParseLettersNumbers()
        {
            String[] lettersWithNumbers4x4 = validCSVLetters;
            lettersWithNumbers4x4[0] = lettersWithNumbers4x4[0].Replace('K', '6');
            sut.ParseLetters(lettersWithNumbers4x4);
        }

        [Test]
        public void GivenStringArrayOfLettersWithSymbolWhenPassedToParseLettersThenParseLettersThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseLettersSymbol));
        }

        private void ParseLettersSymbol()
        {
            String[] lettersWithSymbol4x4 = validCSVLetters;
            lettersWithSymbol4x4[0] = lettersWithSymbol4x4[0].Replace('K', '$');
            sut.ParseLetters(lettersWithSymbol4x4);
        }

        [Test]
        public void GivenStringArrayOfLettersWithPunctuationWhenPassedToParseLettersThenParseLettersThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseLettersPunctuation));
        }

        private void ParseLettersPunctuation()
        {
            String[] lettersWithPunctuation4x4 = validCSVLetters;
            lettersWithPunctuation4x4[0] = lettersWithPunctuation4x4[0].Replace('K', '!');
            sut.ParseLetters(lettersWithPunctuation4x4);
        }

        [Test]
        public void GivenValid2DCharacterArrayOfLettersWith2x2DimensionsWhenPassedToParseLetterThenParseLetterThrowsNoException()
        {
            String[] smallestValidLetters = new String[2];
            smallestValidLetters[0] = "K,R";
            smallestValidLetters[1] = "E,M";
            sut.ParseLetters(smallestValidLetters);
        }

        [Test]
        public void GivenValid2DCharacterArrayOfLettersWith1x1DimensionsWhenPassedToParseLetterThenParseLetterThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseLetters1x1));
        }

        private void ParseLetters1x1()
        {
            String[] csvLetters1x1 = new String[1];
            csvLetters1x1[0] = "K";
            sut.ParseLetters(csvLetters1x1);
        }

        [Test]
        public void GivenValid2DCharacterArrayOfLettersWith1x1DimensionsContainingATailingCommaWhenPassedToParseLetterThenParseLetterThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(ParseLetters1x1Comma));
        }

        private void ParseLetters1x1Comma()
        {
            String[] csvLetters1x1Comma = new String[1];
            csvLetters1x1Comma[0] = "K,";
            sut.ParseLetters(csvLetters1x1Comma);
        }

        [Test]
        public void GivenValid2DCharacterArrayOfLettersWith0x0DimensionsWhenPassedToParseLetterThenParseLetterThrowsArgumentOutOfRangeExceptionException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(ParseLetters0x0));
        }

        private void ParseLetters0x0()
        {
            String[] csvLetter0x0 = new String[0];
            sut.ParseLetters(csvLetter0x0);
        }

        [Test]
        public void GivenAValidStringFileNameContainingAValidWordPuzzleWhenPassedIntoParseFileThenParseFileThrowsNoException()
        {
            sut.ParseFile(projectPath + validPuzzleFileName);
        }

        [Test]
        public void GivenAInvalidStringFileNameWhenPassedIntoParseFileThenParseFileThrowsFileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(new TestDelegate(ParseFileInvalidFileName));
        }

        private void ParseFileInvalidFileName()
        {
            sut.ParseFile("meh.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingAlphaNumericWordsWhenPassedIntoParseFileThenParseFileThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileAlphaNumericWords));
        }

        private void ParseFileAlphaNumericWords()
        {
            sut.ParseFile(projectPath + "alphaNumeric4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingWordsWithSpacesWhenPassedIntoParseFileThenParseFileThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileWordsSpaces));
        }

        private void ParseFileWordsSpaces()
        {
            sut.ParseFile(projectPath + "spaces4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingWordsWithSymbolsWhenPassedIntoParseFileThenParseFileThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileWordsSymbols));
        }

        private void ParseFileWordsSymbols()
        {
            sut.ParseFile(projectPath + "symbols4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingWordsWithPunctuationsWhenPassedIntoParseFileThenParseFileThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileWordsPunctuations));
        }

        private void ParseFileWordsPunctuations()
        {
            sut.ParseFile(projectPath + "punctuation4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithSSVWordsPuzzleWhenPassedIntoParseFileThenParseFileThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseFileSSV));
        }

        private void ParseFileSSV()
        {
            sut.ParseFile(projectPath + "ssv4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithCSSVWordsPuzzleWhenPassedIntoParseFileThenParseFileThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseFileCSSV));
        }

        private void ParseFileCSSV()
        {
            sut.ParseFile(projectPath + "cssv4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithEmptyWordPuzzleWhenPassedIntoParseFileThenParseFileThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileEmptyWord));
        }

        private void ParseFileEmptyWord()
        {
            sut.ParseFile(projectPath + "empty4x4.txt");
        }
    }
}
