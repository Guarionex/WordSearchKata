﻿using NUnit.Framework;
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
    }
}
