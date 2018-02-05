using NUnit.Framework;
using PuzzleSolverProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverUnitTest
{
    [TestFixture]
    public class PuzzleSolverTest
    {
        private PuzzleSolver sut;
        private String validWordsString;
        private Char[,] valid4x4Letters;
        private String[] validCSVLetters;

        [SetUp]
        public void init()
        {
            sut = new PuzzleSolver();

            validWordsString = "BONES,KHAN,KIRK,SCOTTY,SPOCK,SULU,UHURA";

            valid4x4Letters = new Char[4, 4];
            valid4x4Letters[0, 0] = 'K';
            valid4x4Letters[0, 1] = 'E';
            valid4x4Letters[0, 2] = 'X';
            valid4x4Letters[0, 3] = 'N';
            valid4x4Letters[1, 0] = 'R';
            valid4x4Letters[1, 1] = 'M';
            valid4x4Letters[1, 2] = 'A';
            valid4x4Letters[1, 3] = 'C';
            valid4x4Letters[2, 0] = 'I';
            valid4x4Letters[2, 1] = 'H';
            valid4x4Letters[2, 2] = 'D';
            valid4x4Letters[2, 3] = 'H';
            valid4x4Letters[3, 0] = 'K';
            valid4x4Letters[3, 1] = 'P';
            valid4x4Letters[3, 2] = 'M';
            valid4x4Letters[3, 3] = 'U';

            validCSVLetters = new String[4];
            validCSVLetters[0] = "K,R,I,K";
            validCSVLetters[1] = "E,M,H,P";
            validCSVLetters[2] = "X,A,D,M";
            validCSVLetters[3] = "N,C,H,U";
        }

        [Test]
        public void GivenCSVStringOfValidWordsWhenPassingGivenStringToParseWordsIntoPuzzleThenParseWordsIntoPuzzleThrowsNoException()
        {
            sut.ParseWordsIntoPuzzle(validWordsString);
        }

        [Test]
        public void GivenCSVStringWithAlphaNumericWordsWhenPassingToParseWordsIntoPuzzleThenParseWordsIntoPuzzleThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseAlphaNumericWords));
        }

        private void ParseAlphaNumericWords()
        {
            String csvAlphaNumericWords = "B0NES,KH8N,K1RK,SCO77Y,5POCK,5ULU,UHUR8";
            sut.ParseWordsIntoPuzzle(csvAlphaNumericWords);
        }

        [Test]
        public void GivenCSVStringOfWordsWithSpacesWhenPassingToParseWordsIntoPuzzleThenParseWordsIntoPuzzleThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseWordsWithSpaces));
        }

        private void ParseWordsWithSpaces()
        {
            String csvWordsWithSpaces = "B NES,KH N,K RK,SCO  Y,S POCK,SU LU,UHUR ";
            sut.ParseWordsIntoPuzzle(csvWordsWithSpaces);
        }

        [Test]
        public void GivenCSVStringOfWordsWithSymbolsWhenPassingToParseWordsIntoPuzzleThenParseWordsIntoPuzzleThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseWordsWithSymbols));
        }

        private void ParseWordsWithSymbols()
        {
            String csvWordsWithSymbols = "BONE$,KH@N,KIRK,SC*TTY,$POCK,$ULU,U#UR@";
            sut.ParseWordsIntoPuzzle(csvWordsWithSymbols);
        }

        [Test]
        public void GivenCSVStringOfWordsWithPunctuationsWhenPassingToParseWordsIntoPuzzleThenParseWordsIntoPuzzleThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseWordsWithPunctuations));
        }

        private void ParseWordsWithPunctuations()
        {
            String csvWordsWithPunctuations = "BONES.,KHAN?,K!RK,SCOTTY!,SPOCK?,SULU.,UHURA;";
            sut.ParseWordsIntoPuzzle(csvWordsWithPunctuations);
        }

        [Test]
        public void GivenSSVStringOfValidWordsWhenPassingToParseWordsIntoPuzzleThenParseWordsIntoPuzzleThrowFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseSSVWords));
        }

        private void ParseSSVWords()
        {
            String csvWordsWithPunctuations = "BONES KHAN KIRK SCOTTY SPOCK SULU UHURA";
            sut.ParseWordsIntoPuzzle(csvWordsWithPunctuations);
        }

        [Test]
        public void GivenCSSVStringOfValidWordsWhenPassingToParseWordsIntoPuzzleThenParseWordsIntoPuzzleThrowFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseCSSVWords));
        }

        private void ParseCSSVWords()
        {
            String cssvWords = "BONES, KHAN, KIRK, SCOTTY, SPOCK, SULU, UHURA";
            sut.ParseWordsIntoPuzzle(cssvWords);
        }

        [Test]
        public void GivenCSVStringOfWordsWithEmptyStringsThenPassingToParseWordsIntoPuzzleThenThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseCSVWordsWithEmptyStrings));
        }

        private void ParseCSVWordsWithEmptyStrings()
        {
            String csvWordsWithEmptyStrings = "BONES,,KIRK,,SPOCK,,UHURA";
            sut.ParseWordsIntoPuzzle(csvWordsWithEmptyStrings);
        }

        [Test]
        public void GivenValid2DCharacterArrayOfLettersWhenPassedToAddAllLettersThenNoExceptionisThrown()
        {
            sut.AddAllLetters(valid4x4Letters);
        }

        [Test]
        public void Given2DCharacterArrayOfLettersWithNumbersWhenPassedToAddAllLettersThenAddAllLettersThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(AddAllLettersNumbers));
        }

        private void AddAllLettersNumbers()
        {
            Char[,] lettersWithNumbers4x4 = valid4x4Letters;
            lettersWithNumbers4x4[0, 0] = '6';
            sut.AddAllLetters(lettersWithNumbers4x4);
        }

        [Test]
        public void Given2DCharacterArrayOfLettersWithSpaceWhenPassedToAddAllLettersThenAddAllLettersThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(AddAllLettersSpace));
        }

        private void AddAllLettersSpace()
        {
            Char[,] lettersWithSpace4x4 = valid4x4Letters;
            lettersWithSpace4x4[0, 0] = ' ';
            sut.AddAllLetters(lettersWithSpace4x4);
        }

        [Test]
        public void Given2DCharacterArrayOfLettersWithSymbolWhenPassedToAddAllLettersThenAddAllLettersThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(AddAllLettersSymbol));
        }

        private void AddAllLettersSymbol()
        {
            Char[,] lettersWithSymbol4x4 = valid4x4Letters;
            lettersWithSymbol4x4[0, 0] = '$';
            sut.AddAllLetters(lettersWithSymbol4x4);
        }

        [Test]
        public void Given2DCharacterArrayOfLettersWithPunctuationWhenPassedToAddAllLettersThenAddAllLettersThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(AddAllLettersPunctuation));
        }

        private void AddAllLettersPunctuation()
        {
            Char[,] lettersWithPunctuation4x4 = valid4x4Letters;
            lettersWithPunctuation4x4[0, 0] = '!';
            sut.AddAllLetters(lettersWithPunctuation4x4);
        }

        [Test]
        public void GivenValid2DCharacterArrayOfLettersWithEqualXYDimensionsWhenPassedToAddAllLettersThenAddAllLettersThrowsNoException()
        {
            sut.AddAllLetters(valid4x4Letters);
        }

        [Test]
        public void Given2DCharacterArrayOfLettersWithUnequalXYDimensionsWhenPassedToAddAllLettersThenAddAllLettersThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(AddAllLettersUnequalXY));
        }

        private void AddAllLettersUnequalXY()
        {
            Char[,] unequalXY = new Char[4, 5];
            Array.Copy(valid4x4Letters, unequalXY, 16);
            unequalXY[3, 1] = 'w';
            unequalXY[3, 2] = 'x';
            unequalXY[3, 3] = 'y';
            unequalXY[3, 4] = 'z';
            sut.AddAllLetters(unequalXY);
        }

        [Test]
        public void GivenValid2DCharacterArrayOfLettersWith2x2DimensionsWhenPassedToAddAllLettersThenAddAllLettersThrowsNoException()
        {
            Char[,] smallestValidLetters = new Char[2, 2];
            Array.Copy(valid4x4Letters, smallestValidLetters, 4);
            sut.AddAllLetters(smallestValidLetters);
        }

        [Test]
        public void Given2DCharacterArrayOfLettersWith1x1DimensionsWhenPassedToAddAllLettersThenAddAllLettersThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(AddAllLetters1x1));
        }

        private void AddAllLetters1x1()
        {
            Char[,] tooSmallLetters = new Char[1, 1];
            Array.Copy(valid4x4Letters, tooSmallLetters, 1);
            sut.AddAllLetters(tooSmallLetters);
        }

        [Test]
        public void Given2DCharacterArrayOfLettersWith0x0DimensionsWhenPassedToAddAllLettersThenAddAllLettersThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(AddAllLetters0x0));
        }

        private void AddAllLetters0x0()
        {
            Char[,] tooSmallLetters = new Char[0, 0];
            sut.AddAllLetters(tooSmallLetters);
        }

        [Test]
        public void GivenValidStringArrayOfCSVLettersWhenPassedToGet2DLetterArrayThenGet2DLetterArrayReturnsA2DArrayOfCharacters()
        {
            Char[,] result = sut.Get2DLetterArray(validCSVLetters);
            Assert.IsInstanceOf(typeof(Char[,]), result);
        }

        [Test]
        public void GivenValidStringArrayOfCSVLettersWhenPassedToGet2DLetterArrayThenGet2DLetterArrayReturnsAValid2DArrayOfCharacters()
        {
            Char[,] result = sut.Get2DLetterArray(validCSVLetters);
            Assert.AreEqual(valid4x4Letters, result);
        }

        [Test]
        public void GivenValidStringArrayOfLowerCaseCSVLettersWhenPassedToGet2DLetterArrayThenGet2DLetterArrayReturnsAValid2DArrayOfLowerCaseCharacters()
        {
            String[] lowerCaseCSVLetters = new String[4];
            for(int row = 0; row < validCSVLetters.Length; row++)
            {
                lowerCaseCSVLetters[row] = validCSVLetters[row].ToLower();
            }
            Char[,] valid4x4LowerCaseLetters = new Char[4, 4];
            valid4x4LowerCaseLetters[0, 0] = 'k';
            valid4x4LowerCaseLetters[0, 1] = 'e';
            valid4x4LowerCaseLetters[0, 2] = 'x';
            valid4x4LowerCaseLetters[0, 3] = 'n';
            valid4x4LowerCaseLetters[1, 0] = 'r';
            valid4x4LowerCaseLetters[1, 1] = 'm';
            valid4x4LowerCaseLetters[1, 2] = 'a';
            valid4x4LowerCaseLetters[1, 3] = 'c';
            valid4x4LowerCaseLetters[2, 0] = 'i';
            valid4x4LowerCaseLetters[2, 1] = 'h';
            valid4x4LowerCaseLetters[2, 2] = 'd';
            valid4x4LowerCaseLetters[2, 3] = 'h';
            valid4x4LowerCaseLetters[3, 0] = 'k';
            valid4x4LowerCaseLetters[3, 1] = 'p';
            valid4x4LowerCaseLetters[3, 2] = 'm';
            valid4x4LowerCaseLetters[3, 3] = 'u';
            Char[,] result = sut.Get2DLetterArray(lowerCaseCSVLetters);
            Assert.AreEqual(valid4x4LowerCaseLetters, result);
        }

        [Test]
        public void GivenStringArrayOfSSVLettersWhenPassedToGet2DLetterArrayThenGet2DLetterArrayThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(Get2DLetterArraySSV));
        }

        private void Get2DLetterArraySSV()
        {
            String[] ssvLetters = new String[4];
            ssvLetters[0] = "K R I K";
            ssvLetters[1] = "E M H P";
            ssvLetters[2] = "X A D M";
            ssvLetters[3] = "N C H U";
            sut.Get2DLetterArray(ssvLetters);
        }

        [Test]
        public void GivenStringArrayOfCSSVLettersWhenPassedToGet2DLetterArrayThenGet2DLetterArrayThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(Get2DLetterArrayCSSV));
        }

        private void Get2DLetterArrayCSSV()
        {
            String[] ssvLetters = new String[4];
            ssvLetters[0] = "K, R, I, K";
            ssvLetters[1] = "E, M, H, P";
            ssvLetters[2] = "X, A, D, M";
            ssvLetters[3] = "N, C, H, U";
            sut.Get2DLetterArray(ssvLetters);
        }

        [Test]
        public void GivenStringArrayOfLettersWithUnequalDimensionsWhenPassedToGet2DLetterArrayThenGet2DLetterArrayThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(Get2DLetterArrayUnequalDimensions));
        }

        private void Get2DLetterArrayUnequalDimensions()
        {
            String[] unequalDimensionsLetters = new String[3];
            unequalDimensionsLetters[0] = "K,R,I,K";
            unequalDimensionsLetters[1] = "E,M,H,P";
            unequalDimensionsLetters[2] = "X,A,D,M";
            sut.Get2DLetterArray(unequalDimensionsLetters);
        }

        [Test]
        public void GivenStringArrayOfLettersWithVaryingLengthsWhenPassedToGet2DLetterArrayThenGet2DLetterArrayThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(Get2DLetterArrayVaryingLengths));
        }

        private void Get2DLetterArrayVaryingLengths()
        {
            String[] varyingLengthsLetters = new String[4];
            varyingLengthsLetters[0] = "K,R,I,K";
            varyingLengthsLetters[1] = "E,M,H";
            varyingLengthsLetters[2] = "X,A,D,M";
            varyingLengthsLetters[3] = "N,C";
            sut.Get2DLetterArray(varyingLengthsLetters);
        }
    }
}
