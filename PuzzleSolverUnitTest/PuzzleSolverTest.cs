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

        [SetUp]
        public void init()
        {
            sut = new PuzzleSolver();

            validWordsString = "BONES,KHAN,KIRK,SCOTTY,SPOCK,SULU,UHURA";

            valid4x4Letters = new Char[4, 4];
            valid4x4Letters[0, 0] = 'K';
            valid4x4Letters[0, 1] = 'R';
            valid4x4Letters[0, 2] = 'I';
            valid4x4Letters[0, 3] = 'K';
            valid4x4Letters[1, 0] = 'E';
            valid4x4Letters[1, 1] = 'M';
            valid4x4Letters[1, 2] = 'H';
            valid4x4Letters[1, 3] = 'P';
            valid4x4Letters[2, 0] = 'X';
            valid4x4Letters[2, 1] = 'A';
            valid4x4Letters[2, 2] = 'D';
            valid4x4Letters[2, 3] = 'M';
            valid4x4Letters[3, 0] = 'N';
            valid4x4Letters[3, 1] = 'C';
            valid4x4Letters[3, 2] = 'H';
            valid4x4Letters[3, 3] = 'U';

        }        

        [Test]
        public void GivenPuzzleSolverWhenPassedLetterCharacterAtPosition00ThenAddLetterAtThrowsNoException()
        {
            sut.AddLetterAt('U', 0, 0);
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedNumberCharacterAtPosition00ThenAddLetterAtThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(NumberCharacterAt00));
        }

        private void NumberCharacterAt00()
        {
            sut.AddLetterAt('5', 0, 0);
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedSpaceCharacterAtPosition00ThenAddLetterAtThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(SpaceCharacterAt00));
        }

        private void SpaceCharacterAt00()
        {
            sut.AddLetterAt(' ', 0, 0);
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedSymbolCharacterAtPosition00ThenAddLetterAtThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(SymbolCharacterAt00));
        }

        private void SymbolCharacterAt00()
        {
            sut.AddLetterAt('$', 0, 0);
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedCommaCharacterAtPosition00ThenAddLetterAtThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(CommaCharacterAt00));
        }

        private void CommaCharacterAt00()
        {
            sut.AddLetterAt(',', 0, 0);
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedPunctiationCharacterAtPosition00ThenAddLetterAtThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(PunctiationCharacterAt00));
        }

        private void PunctiationCharacterAt00()
        {
            sut.AddLetterAt('!', 0, 0);
        }

        [Test]
        public void GivenValidCharacterWhenPassedMegativeXPositionThenAddLetterAtThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(ValidLetterAtMinus10));
        }

        private void ValidLetterAtMinus10()
        {
            sut.AddLetterAt('U', -1, 0);
        }

        [Test]
        public void GivenValidCharacterWhenPassingMegativeYPositionThenAddLetterAtThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(ValidLetterAt1Minus0));
        }

        private void ValidLetterAt1Minus0()
        {
            sut.AddLetterAt('U', 0, -1);
        }

        [Test]
        public void GivenPuzzleSolverWhenSettingPuzzleDimensionTo2x2ThenSetDimensionsThrowsNoException()
        {
            sut.SetDimensions(2, 2);
        }

        [Test]
        public void GivenPuzzleSolverWhenSettingPuzzleToLargeDimensionsThenSetDimensionsThrowsNoException()
        {
            sut.SetDimensions(1000, 1000);
        }

        [Test]
        public void GivenPuzzleSolverWhenSettingPuzzleDimensionsToNegativeXThenSetDimensionsThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(NegativeXDimension));
        }

        private void NegativeXDimension()
        {
            sut.SetDimensions(-1, 0);
        }

        [Test]
        public void GivenPuzzleSolverWhenSettingPuzzleDimensionsToNegativeYThenSetDimensionsThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(NegativeYDimension));
        }

        private void NegativeYDimension()
        {
            sut.SetDimensions(0, -1);
        }

        [Test]
        public void GivenPuzzleSolverWhenSettingPuzzleDimensionsToUnequalXYThenSetDimensionsThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(UnequalXY));
        }

        private void UnequalXY()
        {
            sut.SetDimensions(2, 1000);
        }

        [Test]
        public void GivenPuzzleSolverWhenSettingPuzzleDimensionsTooSmallThenSetDimensionsThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(OnebyOneDimension));
        }

        private void OnebyOneDimension()
        {
            sut.SetDimensions(1, 1);
        }

        [Test]
        public void GivenPuzzleSolverWhenSettingPuzzleDimensionsIs00ThenSetDimensionsThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(ZeroByZeroDimension));
        }

        private void ZeroByZeroDimension()
        {
            sut.SetDimensions(0, 0);
        }

        [Test]
        public void GivenValidDimensionsWhenAddingValidCharacterAtValidPositionThenAddLetterAtThrowsNoException()
        {
            sut.SetDimensions(20, 20);
            sut.AddLetterAt('U', 20, 20);
        }

        [Test]
        public  void GivenValidDimensionsWhenAddingValidCharacterAt00ThenAddLetterAtThrowsNoException()
        {
            sut.SetDimensions(20, 20);
            sut.AddLetterAt('U', 0, 0);
        }

        [Test]
        public void GivenValidDimensionsWhenAddingValidCharacterAtUnequalXYThenAddLetterAtThrowsNoException()
        {
            sut.SetDimensions(20, 20);
            sut.AddLetterAt('U', 0, 20);
        }

        [Test]
        public void GivenValidDimensionsWhenAddingValidCharacterAtAnXBiggerThanItsHorizontalSizeThenAddLetterAtThrowsArgumentOutOfRangeException()
        {
            sut.SetDimensions(20, 20);
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(OutOfRangeX));
        }

        private void OutOfRangeX()
        {
            sut.AddLetterAt('U', 21, 20);
        }

        [Test]
        public void GivenSmallestDimensionsWhenAddingValidCharacterAtAnXBiggerThanItsHorizontalSizeThenAddLetterAtThrowsArgumentOutOfRangeException()
        {
            sut.SetDimensions(2, 2);
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(SmallDimensionsOutOfRangeX));
        }

        private void SmallDimensionsOutOfRangeX()
        {
            sut.AddLetterAt('U', 5, 0);
        }

        [Test]
        public void GivenValidDimensionsWhenAddingValidCharacterAtAnYBiggerThanItsVerticalSizeThenAddLetterAtThrowsArgumentOutOfRangeException()
        {
            sut.SetDimensions(20, 20);
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(OutOfRangeY));
        }

        private void OutOfRangeY()
        {
            sut.AddLetterAt('U', 20, 21);
        }

        [Test]
        public void GivenSmallestDimensionsWhenAddingValidCharacterAtAnYBiggerThanItsVerticalSizeThenAddLetterAtThrowsArgumentOutOfRangeException()
        {
            sut.SetDimensions(2, 2);
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(SmallDimensionsOutOfRangeY));
        }

        private void SmallDimensionsOutOfRangeY()
        {
            sut.AddLetterAt('U', 0, 5);
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
    }
}
