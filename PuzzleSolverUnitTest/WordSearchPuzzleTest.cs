﻿using NUnit.Framework;
using PuzzleSolverProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PuzzleSolverUnitTest
{
    [TestFixture]
    public class WordSearchPuzzleTest
    {
        private WordSearchPuzzle sut;
        private PuzzleSolver solver;

        [SetUp]
        public void init()
        {
            sut = new WordSearchPuzzle();
            solver = new PuzzleSolver();
        }

        [Test]
        public void GivenWordSearchPuzzleWhenAddWordIsPassedAStringThenAddWordThrowsNoException()
        {
            sut.AddWord("PILLAR");
        }

        [Test]
        public void GivenWordSearchPuzleWhenCallingWordsThenGetWordsReturnAListOfStrings()
        {
            Assert.IsInstanceOf(typeof(List<String>), sut.Words);
        }

        [Test]
        public void GivenWordSearchPuzzleWithAWordAddedWhenCallingGetWordThenGetWordReturnsAListOfStringWithTheAddedWord()
        {
            sut.AddWord("PILLAR");
            List<String> result = sut.Words;
            List<String> expected = new List<String>();
            expected.Add("PILLAR");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenWordSearchPuzzleWithMultipleWordsAddedWhenCallingGetWordThenGetWordReturnsAListOfStringWithTheAddedWords()
        {
            sut.AddWord("PILLAR");
            sut.AddWord("TDD");
            List<String> result = sut.Words;
            List<String> expected = new List<String>();
            expected.Add("PILLAR");
            expected.Add("TDD");

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenWordSearchPuzzleWhenCallingSetDimensionsAt4x4ThenSetDimensionsThrowNoException()
        {
            sut.SetDimensions(4, 4);
        }

        [Test]
        public void GivenWordSearchPuzzleWhenCallingDimensionsThenDimensionsReturnsAVector2()
        {
            Assert.IsInstanceOf(typeof(Vector2), sut.Dimensions);
        }

        [Test]
        public void GivenWordSearchPuzzleWithSetDimensions4x4WhenCallingDimensionsThenDimensionsReturnsAVector2With4x4Value()
        {
            sut.SetDimensions(4, 4);
            Vector2 result = sut.Dimensions;
            Vector2 expected = new Vector2(4, 4);
            Assert.AreEqual(expected, result);
        }
    }
}