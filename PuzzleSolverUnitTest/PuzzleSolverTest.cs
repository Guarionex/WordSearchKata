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
        private List<String> validWordList;
        private List<String> lowerCaseValidWordList;
        private List<String> wordListWithEmptyStringElement;
        private String validWordsString;

        [SetUp]
        public void init()
        {
            sut = new PuzzleSolver();

            validWordList = new List<string>();
            validWordList.Add("BONES");
            validWordList.Add("KHAN");
            validWordList.Add("KIRK");
            validWordList.Add("SCOTTY");
            validWordList.Add("SPOCK");
            validWordList.Add("SULU");
            validWordList.Add("UHURA");

            lowerCaseValidWordList = new List<string>();
            lowerCaseValidWordList.Add("bones");
            lowerCaseValidWordList.Add("khan");
            lowerCaseValidWordList.Add("kirk");
            lowerCaseValidWordList.Add("scotty");
            lowerCaseValidWordList.Add("spock");
            lowerCaseValidWordList.Add("sulu");
            lowerCaseValidWordList.Add("uhura");

            wordListWithEmptyStringElement = new List<string>();
            wordListWithEmptyStringElement.Add("BONES");
            wordListWithEmptyStringElement.Add("");
            wordListWithEmptyStringElement.Add("KIRK");
            wordListWithEmptyStringElement.Add("");
            wordListWithEmptyStringElement.Add("SPOCK");
            wordListWithEmptyStringElement.Add("");
            wordListWithEmptyStringElement.Add("UHURA");

            validWordsString = "BONES,KHAN,KIRK,SCOTTY,SPOCK,SULU,UHURA";
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedALettersOnlyStringThenAddWordThrowsNoException()
        {
            sut.AddWord("BONES");
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedAnAlphanumericStringThenAddWordThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(AlphanumericWord));
        }

        private void AlphanumericWord()
        {
            sut.AddWord("B0N3S");
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedAStringWithSpacesThenAddWordThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(StringWordWithSpaces));
        }

        private void StringWordWithSpaces()
        {
            sut.AddWord("BONES KHAN");
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedAStringWithSpecialCharactersThenAddWordThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(StringWordWithSpecialCharacters));
        }

        private void StringWordWithSpecialCharacters()
        {
            sut.AddWord("BONE$");
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedAStringWithACommaThenAddWordThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(StringWordWithComma));
        }

        private void StringWordWithComma()
        {
            sut.AddWord("BONES,KHAN");
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedAStringWithAPunctuationThenAddWordThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(StringWordWithPunctiation));
        }

        private void StringWordWithPunctiation()
        {
            sut.AddWord("BONES!");
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
        public void GivenPuzzleSolverWhenPassedCSVStringOfValidWordsThenGetListOfWordsReturnsAListofStringsContainigValidWords()
        {
            List<String> result = sut.GetListOfWords("BONES,KHAN,KIRK,SCOTTY,SPOCK,SULU,UHURA");
            Assert.AreEqual(validWordList, result);
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedSSVStringOfValidWordsThenGetListOfWordsThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(SSVStringOfWords));
        }

        private void SSVStringOfWords()
        {
            sut.GetListOfWords("BONES KHAN KIRK SCOTTY SPOCK SULU UHURA");
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedCommaAndSpaceSeparatedValuesStringOfValidWordsThenGetListOfWordsThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(CSSVStringOfWords));
        }

        private void CSSVStringOfWords()
        {
            sut.GetListOfWords("BONES, KHAN, KIRK, SCOTTY, SPOCK, SULU, UHURA");
        }

        [Test]
        public void GivenPuzzleSolverWhenPassedLowerCaseCSVStringOfValidWordsThenGetListOfWordsReturnsAListofStringsContainigLowerCaseValidWords()
        {
            List<String> result = sut.GetListOfWords("bones,khan,kirk,scotty,spock,sulu,uhura");
            Assert.AreEqual(lowerCaseValidWordList, result);
        }

        [Test]
        public void GivenCSVStringOfValidWordsWhenAddingListOfValidWordsThenAddAllWordsThrowsNoException()
        {
            List<String> listOfWords = sut.GetListOfWords("BONES,KHAN,KIRK,SCOTTY,SPOCK,SULU,UHURA");
            sut.AddAllWords(listOfWords);
        }

        [Test]
        public void GivenListOfStringsWithEmptyStringElementWhenAddingListOfValidWordsThenAddAllWordsThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(addAllWordsWithEmptyStrings));
        }

        private void addAllWordsWithEmptyStrings()
        {
            sut.AddAllWords(wordListWithEmptyStringElement);
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
        public void GivenListOfStringWithAlphaNumericWordsWhenPassedToAddAllWordsThenAddAllWordsThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(AddAllAlphaNumericWords));
        }

        private void AddAllAlphaNumericWords()
        {
            List<String> alphaNumericList = new List<String>();
            alphaNumericList.Add("B0NES");
            alphaNumericList.Add("KH8N");
            alphaNumericList.Add("K1RK");
            alphaNumericList.Add("SC0TTY");
            alphaNumericList.Add("SP0CK");
            alphaNumericList.Add("5ULU");
            alphaNumericList.Add("UHUR8");
            sut.AddAllWords(alphaNumericList);
        }

        [Test]
        public void GivenListOfStringOfWordsWithSpacesWhenPassedToAddAllWordsThenAddAllWordsThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(AddAllWordsWithSpaces));
        }

        private void AddAllWordsWithSpaces()
        {
            List<String> wordsWithSpacesList = new List<String>();
            wordsWithSpacesList.Add("B NES");
            wordsWithSpacesList.Add("KH N");
            wordsWithSpacesList.Add("K RK");
            wordsWithSpacesList.Add("SC TTY");
            wordsWithSpacesList.Add("SP CK");
            wordsWithSpacesList.Add(" ULU");
            wordsWithSpacesList.Add("UHUR ");
            sut.AddAllWords(wordsWithSpacesList);
        }
    }
}
