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
    public class PuzzleSolverTest
    {
        private PuzzleFileParser sut;
        private String validPuzzleFileName;
        private String projectPath;

        [SetUp]
        public void init()
        {
            sut = new PuzzleFileParser();

            validPuzzleFileName = "Valid4x4.txt";
            projectPath = @"C:\Users\chesp\source\repos\WordSearchKata\";
        }

        [Test]
        public void GivenAValidStringFileNameContainingAValidWordPuzzleWhenPassedIntoParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsNoException()
        {
            sut.ParseFileToWordSearchPuzzle(projectPath + validPuzzleFileName);
        }

        [Test]
        public void GivenAValidStringFileNameContainingAValidWordPuzzleWhenPassedIntoParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleReturnsAWordSearchPuzzle()
        {
            Assert.IsInstanceOf(typeof(WordSearchPuzzle), sut.ParseFileToWordSearchPuzzle(projectPath + validPuzzleFileName));
        }

        [Test]
        public void GivenAValidStringFileNameContainingAValidWordPuzzleWhenPassedIntoParseFileToWordSearchPuzzleThenResultingWordSearchPuzzleGetWordsListHasTheSolution()
        {
            WordSearchPuzzle puzzle = sut.ParseFileToWordSearchPuzzle(projectPath + "Example15x15.txt");
            Dictionary<String, List<Vector2>> result = puzzle.GetWordsLocation();

            List<Vector2> bonesLocation = new List<Vector2>();
            bonesLocation.Add(new Vector2(0, 6));
            bonesLocation.Add(new Vector2(0, 7));
            bonesLocation.Add(new Vector2(0, 8));
            bonesLocation.Add(new Vector2(0, 9));
            bonesLocation.Add(new Vector2(0, 10));
            List<Vector2> khanLocations = new List<Vector2>();
            khanLocations.Add(new Vector2(5, 9));
            khanLocations.Add(new Vector2(5, 8));
            khanLocations.Add(new Vector2(5, 7));
            khanLocations.Add(new Vector2(5, 6));
            List<Vector2> kirkLocations = new List<Vector2>();
            kirkLocations.Add(new Vector2(4, 7));
            kirkLocations.Add(new Vector2(3, 7));
            kirkLocations.Add(new Vector2(2, 7));
            kirkLocations.Add(new Vector2(1, 7));
            List<Vector2> scottyLocations = new List<Vector2>();
            scottyLocations.Add(new Vector2(0, 5));
            scottyLocations.Add(new Vector2(1, 5));
            scottyLocations.Add(new Vector2(2, 5));
            scottyLocations.Add(new Vector2(3, 5));
            scottyLocations.Add(new Vector2(4, 5));
            scottyLocations.Add(new Vector2(5, 5));
            List<Vector2> spockLocations = new List<Vector2>();
            spockLocations.Add(new Vector2(2, 1));
            spockLocations.Add(new Vector2(3, 2));
            spockLocations.Add(new Vector2(4, 3));
            spockLocations.Add(new Vector2(5, 4));
            spockLocations.Add(new Vector2(6, 5));
            List<Vector2> suluLocations = new List<Vector2>();
            suluLocations.Add(new Vector2(3, 3));
            suluLocations.Add(new Vector2(2, 2));
            suluLocations.Add(new Vector2(1, 1));
            suluLocations.Add(new Vector2(0, 0));
            List<Vector2> uhuraLocations = new List<Vector2>();
            uhuraLocations.Add(new Vector2(4, 0));
            uhuraLocations.Add(new Vector2(3, 1));
            uhuraLocations.Add(new Vector2(2, 2));
            uhuraLocations.Add(new Vector2(1, 3));
            uhuraLocations.Add(new Vector2(0, 4));

            Dictionary<String, List<Vector2>> expected = new Dictionary<string, List<Vector2>>();
            expected.Add("BONES", bonesLocation);
            expected.Add("KHAN", khanLocations);
            expected.Add("KIRK", kirkLocations);
            expected.Add("SCOTTY", scottyLocations);
            expected.Add("SPOCK", spockLocations);
            expected.Add("SULU", suluLocations);
            expected.Add("UHURA", uhuraLocations);

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
            sut.ParseFileToWordSearchPuzzle(projectPath + "alphaNumeric4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingWordsWithSpacesWhenPassedIntoParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileWordsSpaces));
        }

        private void ParseFileWordsSpaces()
        {
            sut.ParseFileToWordSearchPuzzle(projectPath + "spaces4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingWordsWithSymbolsWhenPassedIntoParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileWordsSymbols));
        }

        private void ParseFileWordsSymbols()
        {
            sut.ParseFileToWordSearchPuzzle(projectPath + "symbols4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingWordsWithPunctuationsWhenPassedIntoParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileWordsPunctuations));
        }

        private void ParseFileWordsPunctuations()
        {
            sut.ParseFileToWordSearchPuzzle(projectPath + "punctuation4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithSSVWordsPuzzleWhenPassedIntoParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseFileSSV));
        }

        private void ParseFileSSV()
        {
            sut.ParseFileToWordSearchPuzzle(projectPath + "ssv4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithCSSVWordsPuzzleWhenPassedIntoParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseFileCSSV));
        }

        private void ParseFileCSSV()
        {
            sut.ParseFileToWordSearchPuzzle(projectPath + "cssv4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithEmptyWordPuzzleWhenPassedIntoParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileEmptyWord));
        }

        private void ParseFileEmptyWord()
        {
            sut.ParseFileToWordSearchPuzzle(projectPath + "empty4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithSSVLettersPuzzleWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseFileSSVLetters));
        }

        private void ParseFileSSVLetters()
        {
            sut.ParseFileToWordSearchPuzzle(projectPath + "ssvLetters4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithCSSVLettersPuzzleWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseFileCSSVLetters));
        }

        private void ParseFileCSSVLetters()
        {
            sut.ParseFileToWordSearchPuzzle(projectPath + "cssvLetters4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithUnequalDimensionsPuzzleWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseFileUnequal));
        }

        private void ParseFileUnequal()
        {
            sut.ParseFileToWordSearchPuzzle(projectPath + "unequalLetters4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithVaryingLengthsPuzzleWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsFormatException()
        {
            Assert.Throws<FormatException>(new TestDelegate(ParseFileVarying));
        }

        private void ParseFileVarying()
        {
            sut.ParseFileToWordSearchPuzzle(projectPath + "varyingLetters4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingNumbersWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileNumberInLetters));
        }

        private void ParseFileNumberInLetters()
        {
            sut.ParseFileToWordSearchPuzzle(projectPath + "numberLetters4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingSymbolsWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFileSymbolsInLetters));
        }

        private void ParseFileSymbolsInLetters()
        {
            sut.ParseFileToWordSearchPuzzle(projectPath + "symbolLetters4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWithPuzzleContainingPunctuationsWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(ParseFilePunctuationsInLetters));
        }

        private void ParseFilePunctuationsInLetters()
        {
            sut.ParseFileToWordSearchPuzzle(projectPath + "punctuationLetters4x4.txt");
        }

        [Test]
        public void GivenValidFileNameWith2x2PuzzleWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsNoException()
        {
            sut.ParseFileToWordSearchPuzzle(projectPath + "valid2x2.txt");
        }

        [Test]
        public void GivenValidFileNameWith1x1PuzzleWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(ParseFile1x1));
        }

        private void ParseFile1x1()
        {
            sut.ParseFileToWordSearchPuzzle(projectPath + "1x1.txt");
        }

        [Test]
        public void GivenValidFileNameWith1x1WithTrailingCommaPuzzleWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(ParseFile1x1Comma));
        }

        private void ParseFile1x1Comma()
        {
            sut.ParseFileToWordSearchPuzzle(projectPath + "1x1Comma.txt");
        }

        [Test]
        public void GivenValidFileNameWith0x0PuzzleWhenPassedToParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(new TestDelegate(ParseFile0x0));
        }

        private void ParseFile0x0()
        {
            sut.ParseFileToWordSearchPuzzle(projectPath + "0x0.txt");
        }

        [Test]
        public void GivenValidFileNameWith4x4PuzzleWithInvalidWordSearchPuzzleWhenCallingParseFileToWordSearchPuzzleThenParseFileToWordSearchPuzzleThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(new TestDelegate(ParseFileInvalidPuzzle));
        }

        private void ParseFileInvalidPuzzle()
        {
            sut.ParseFileToWordSearchPuzzle(projectPath + "wordMissing4x4.txt");
        }
    }
}
