using NUnit.Framework;
using PuzzleSolverProject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverUnitTest
{
    class WordLocationFinderTestData
    {
        public static IEnumerable ValidOneWordPuzzleTestCase
        {
            get
            {
                WordLocationFinderTestData testData = new WordLocationFinderTestData();
                WordSearchPuzzle puzzle = testData.KIRKUpInFirstColumnPuzzle();

                yield return new TestCaseData(puzzle);
            }
        }

        public static IEnumerable PuzzleWithNoWordsAddedTestCase
        {
            get
            {
                WordSearchPuzzle puzzle = new WordSearchPuzzle();
                puzzle.AddLetterAt('S', 0, 0);
                puzzle.AddLetterAt('U', 1, 0);
                puzzle.AddLetterAt('L', 2, 0);
                puzzle.AddLetterAt('U', 3, 0);
                puzzle.AddLetterAt('K', 0, 1);
                puzzle.AddLetterAt('I', 1, 1);
                puzzle.AddLetterAt('R', 2, 1);
                puzzle.AddLetterAt('K', 3, 1);
                puzzle.AddLetterAt('R', 0, 2);
                puzzle.AddLetterAt('L', 1, 2);
                puzzle.AddLetterAt('I', 2, 2);
                puzzle.AddLetterAt('H', 3, 2);
                puzzle.AddLetterAt('K', 0, 3);
                puzzle.AddLetterAt('H', 1, 3);
                puzzle.AddLetterAt('A', 2, 3);
                puzzle.AddLetterAt('N', 3, 3);

                yield return new TestCaseData(puzzle);
            }
        }

        public static IEnumerable OneUpWordTestCase
        {
            get
            {
                WordLocationFinderTestData testData = new WordLocationFinderTestData();

                WordSearchPuzzle setupSUT = testData.KIRKUpInFirstColumnPuzzle();

                List<Vector2> kirkLocation = testData.KIRKUpInFirstColumnLocations();
                Dictionary<String, List<Vector2>> wordsLocation = new Dictionary<String, List<Vector2>>();
                wordsLocation.Add("KIRK", kirkLocation);
                WordsMapDecorator expected = new WordsMapDecorator(wordsLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable TwoWordsUpTestCase
        {
            get
            {
                WordSearchPuzzle setupSUT = new WordSearchPuzzle();
                setupSUT.AddWord("KIRK");
                setupSUT.AddLetterAt('K', 0, 0);
                setupSUT.AddLetterAt('E', 1, 0);
                setupSUT.AddLetterAt('F', 2, 0);
                setupSUT.AddLetterAt('N', 3, 0);
                setupSUT.AddLetterAt('R', 0, 1);
                setupSUT.AddLetterAt('R', 1, 1);
                setupSUT.AddLetterAt('J', 2, 1);
                setupSUT.AddLetterAt('A', 3, 1);
                setupSUT.AddLetterAt('I', 0, 2);
                setupSUT.AddLetterAt('L', 1, 2);
                setupSUT.AddLetterAt('X', 2, 2);
                setupSUT.AddLetterAt('H', 3, 2);
                setupSUT.AddLetterAt('K', 0, 3);
                setupSUT.AddLetterAt('D', 1, 3);
                setupSUT.AddLetterAt('J', 2, 3);
                setupSUT.AddLetterAt('K', 3, 3);

                WordLocationFinderTestData testData = new WordLocationFinderTestData();
                List<Vector2> kirkLocation = testData.KIRKUpInFirstColumnLocations();
                Dictionary<String, List<Vector2>> wordsLocation = new Dictionary<String, List<Vector2>>();
                wordsLocation.Add("KIRK", kirkLocation);
                WordsMapDecorator expected = new WordsMapDecorator(wordsLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable DownWordTestCase
        {
            get
            {
                WordSearchPuzzle setupSUT = new WordSearchPuzzle();
                setupSUT.AddWord("KIRK");
                setupSUT.AddLetterAt('K', 0, 0);
                setupSUT.AddLetterAt('E', 1, 0);
                setupSUT.AddLetterAt('F', 2, 0);
                setupSUT.AddLetterAt('K', 3, 0);
                setupSUT.AddLetterAt('I', 0, 1);
                setupSUT.AddLetterAt('R', 1, 1);
                setupSUT.AddLetterAt('J', 2, 1);
                setupSUT.AddLetterAt('H', 3, 1);
                setupSUT.AddLetterAt('R', 0, 2);
                setupSUT.AddLetterAt('L', 1, 2);
                setupSUT.AddLetterAt('I', 2, 2);
                setupSUT.AddLetterAt('A', 3, 2);
                setupSUT.AddLetterAt('K', 0, 3);
                setupSUT.AddLetterAt('D', 1, 3);
                setupSUT.AddLetterAt('J', 2, 3);
                setupSUT.AddLetterAt('N', 3, 3);

                WordLocationFinderTestData testData = new WordLocationFinderTestData();
                List<Vector2> kirkLocation = testData.KIRKDownInFirstColumnLocations();
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable OneUpOneDownWordTestCase
        {
            get
            {
                WordSearchPuzzle setupSUT = new WordSearchPuzzle();
                setupSUT.AddWord("KIRK");
                setupSUT.AddWord("KHAN");
                setupSUT.AddLetterAt('K', 0, 0);
                setupSUT.AddLetterAt('E', 1, 0);
                setupSUT.AddLetterAt('F', 2, 0);
                setupSUT.AddLetterAt('N', 3, 0);
                setupSUT.AddLetterAt('I', 0, 1);
                setupSUT.AddLetterAt('R', 1, 1);
                setupSUT.AddLetterAt('J', 2, 1);
                setupSUT.AddLetterAt('A', 3, 1);
                setupSUT.AddLetterAt('R', 0, 2);
                setupSUT.AddLetterAt('L', 1, 2);
                setupSUT.AddLetterAt('X', 2, 2);
                setupSUT.AddLetterAt('H', 3, 2);
                setupSUT.AddLetterAt('K', 0, 3);
                setupSUT.AddLetterAt('D', 1, 3);
                setupSUT.AddLetterAt('J', 2, 3);
                setupSUT.AddLetterAt('K', 3, 3);

                WordLocationFinderTestData testData = new WordLocationFinderTestData();
                List<Vector2> kirkLocation = testData.KIRKDownInFirstColumnLocations();

                List<Vector2> khanLocation = new List<Vector2>();
                khanLocation.Add(new Vector2(3, 3));
                khanLocation.Add(new Vector2(3, 2));
                khanLocation.Add(new Vector2(3, 1));
                khanLocation.Add(new Vector2(3, 0));

                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);
                expected.Add("KHAN", khanLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable LeftWordTestCase
        {
            get
            {
                WordSearchPuzzle setupSUT = new WordSearchPuzzle();
                setupSUT.AddWord("KIRK");
                setupSUT.AddLetterAt('K', 0, 0);
                setupSUT.AddLetterAt('E', 1, 0);
                setupSUT.AddLetterAt('F', 2, 0);
                setupSUT.AddLetterAt('N', 3, 0);
                setupSUT.AddLetterAt('K', 0, 1);
                setupSUT.AddLetterAt('R', 1, 1);
                setupSUT.AddLetterAt('I', 2, 1);
                setupSUT.AddLetterAt('K', 3, 1);
                setupSUT.AddLetterAt('R', 0, 2);
                setupSUT.AddLetterAt('L', 1, 2);
                setupSUT.AddLetterAt('X', 2, 2);
                setupSUT.AddLetterAt('H', 3, 2);
                setupSUT.AddLetterAt('N', 0, 3);
                setupSUT.AddLetterAt('A', 1, 3);
                setupSUT.AddLetterAt('H', 2, 3);
                setupSUT.AddLetterAt('K', 3, 3);

                List<Vector2> kirkLocation = new List<Vector2>();
                kirkLocation.Add(new Vector2(3, 1));
                kirkLocation.Add(new Vector2(2, 1));
                kirkLocation.Add(new Vector2(1, 1));
                kirkLocation.Add(new Vector2(0, 1));
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable RightWordTestCase
        {
            get
            {

                WordSearchPuzzle setupSUT = new WordSearchPuzzle();
                setupSUT.AddWord("KIRK");
                setupSUT.AddLetterAt('K', 0, 0);
                setupSUT.AddLetterAt('E', 1, 0);
                setupSUT.AddLetterAt('F', 2, 0);
                setupSUT.AddLetterAt('N', 3, 0);
                setupSUT.AddLetterAt('K', 0, 1);
                setupSUT.AddLetterAt('I', 1, 1);
                setupSUT.AddLetterAt('R', 2, 1);
                setupSUT.AddLetterAt('K', 3, 1);
                setupSUT.AddLetterAt('R', 0, 2);
                setupSUT.AddLetterAt('L', 1, 2);
                setupSUT.AddLetterAt('I', 2, 2);
                setupSUT.AddLetterAt('H', 3, 2);
                setupSUT.AddLetterAt('K', 0, 3);
                setupSUT.AddLetterAt('H', 1, 3);
                setupSUT.AddLetterAt('A', 2, 3);
                setupSUT.AddLetterAt('N', 3, 3);

                List<Vector2> kirkLocation = new List<Vector2>();
                kirkLocation.Add(new Vector2(0, 1));
                kirkLocation.Add(new Vector2(1, 1));
                kirkLocation.Add(new Vector2(2, 1));
                kirkLocation.Add(new Vector2(3, 1));
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable UpLeftWordTestCase
        {
            get
            {
                WordSearchPuzzle setupSUT = new WordSearchPuzzle();
                setupSUT.AddWord("KIRK");
                setupSUT.AddLetterAt('K', 0, 0);
                setupSUT.AddLetterAt('E', 1, 0);
                setupSUT.AddLetterAt('F', 2, 0);
                setupSUT.AddLetterAt('N', 3, 0);
                setupSUT.AddLetterAt('N', 0, 1);
                setupSUT.AddLetterAt('R', 1, 1);
                setupSUT.AddLetterAt('E', 2, 1);
                setupSUT.AddLetterAt('K', 3, 1);
                setupSUT.AddLetterAt('R', 0, 2);
                setupSUT.AddLetterAt('A', 1, 2);
                setupSUT.AddLetterAt('I', 2, 2);
                setupSUT.AddLetterAt('H', 3, 2);
                setupSUT.AddLetterAt('K', 0, 3);
                setupSUT.AddLetterAt('D', 1, 3);
                setupSUT.AddLetterAt('H', 2, 3);
                setupSUT.AddLetterAt('K', 3, 3);

                List<Vector2> kirkLocation = new List<Vector2>();
                kirkLocation.Add(new Vector2(3, 3));
                kirkLocation.Add(new Vector2(2, 2));
                kirkLocation.Add(new Vector2(1, 1));
                kirkLocation.Add(new Vector2(0, 0));
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable UpRightWordTestCase
        {
            get
            {
                WordSearchPuzzle setupSUT = new WordSearchPuzzle();
                setupSUT.AddWord("KIRK");
                setupSUT.AddLetterAt('K', 0, 0);
                setupSUT.AddLetterAt('E', 1, 0);
                setupSUT.AddLetterAt('N', 2, 0);
                setupSUT.AddLetterAt('K', 3, 0);
                setupSUT.AddLetterAt('X', 0, 1);
                setupSUT.AddLetterAt('A', 1, 1);
                setupSUT.AddLetterAt('R', 2, 1);
                setupSUT.AddLetterAt('K', 3, 1);
                setupSUT.AddLetterAt('H', 0, 2);
                setupSUT.AddLetterAt('I', 1, 2);
                setupSUT.AddLetterAt('R', 2, 2);
                setupSUT.AddLetterAt('H', 3, 2);
                setupSUT.AddLetterAt('K', 0, 3);
                setupSUT.AddLetterAt('D', 1, 3);
                setupSUT.AddLetterAt('J', 2, 3);
                setupSUT.AddLetterAt('G', 3, 3);

                List<Vector2> kirkLocation = new List<Vector2>();
                kirkLocation.Add(new Vector2(0, 3));
                kirkLocation.Add(new Vector2(1, 2));
                kirkLocation.Add(new Vector2(2, 1));
                kirkLocation.Add(new Vector2(3, 0));
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable DownLeftWordTestCase
        {
            get
            {
                WordSearchPuzzle setupSUT = new WordSearchPuzzle();
                setupSUT.AddWord("KIRK");
                setupSUT.AddLetterAt('K', 0, 0);
                setupSUT.AddLetterAt('E', 1, 0);
                setupSUT.AddLetterAt('F', 2, 0);
                setupSUT.AddLetterAt('K', 3, 0);
                setupSUT.AddLetterAt('X', 0, 1);
                setupSUT.AddLetterAt('I', 1, 1);
                setupSUT.AddLetterAt('I', 2, 1);
                setupSUT.AddLetterAt('H', 3, 1);
                setupSUT.AddLetterAt('R', 0, 2);
                setupSUT.AddLetterAt('R', 1, 2);
                setupSUT.AddLetterAt('A', 2, 2);
                setupSUT.AddLetterAt('H', 3, 2);
                setupSUT.AddLetterAt('K', 0, 3);
                setupSUT.AddLetterAt('N', 1, 3);
                setupSUT.AddLetterAt('J', 2, 3);
                setupSUT.AddLetterAt('G', 3, 3);

                List<Vector2> kirkLocation = new List<Vector2>();
                kirkLocation.Add(new Vector2(3, 0));
                kirkLocation.Add(new Vector2(2, 1));
                kirkLocation.Add(new Vector2(1, 2));
                kirkLocation.Add(new Vector2(0, 3));
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable DownRightWordTestCase
        {
            get
            {

                WordSearchPuzzle setupSUT = new WordSearchPuzzle();
                setupSUT.AddWord("KIRK");
                setupSUT.AddLetterAt('K', 0, 0);
                setupSUT.AddLetterAt('E', 1, 0);
                setupSUT.AddLetterAt('F', 2, 0);
                setupSUT.AddLetterAt('X', 3, 0);
                setupSUT.AddLetterAt('H', 0, 1);
                setupSUT.AddLetterAt('I', 1, 1);
                setupSUT.AddLetterAt('I', 2, 1);
                setupSUT.AddLetterAt('K', 3, 1);
                setupSUT.AddLetterAt('R', 0, 2);
                setupSUT.AddLetterAt('A', 1, 2);
                setupSUT.AddLetterAt('R', 2, 2);
                setupSUT.AddLetterAt('H', 3, 2);
                setupSUT.AddLetterAt('X', 0, 3);
                setupSUT.AddLetterAt('D', 1, 3);
                setupSUT.AddLetterAt('N', 2, 3);
                setupSUT.AddLetterAt('K', 3, 3);

                List<Vector2> kirkLocation = new List<Vector2>();
                kirkLocation.Add(new Vector2(0, 0));
                kirkLocation.Add(new Vector2(1, 1));
                kirkLocation.Add(new Vector2(2, 2));
                kirkLocation.Add(new Vector2(3, 3));
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable PuzzleWithWordTwiceTestCase
        {
            get
            {
                WordSearchPuzzle setupSUT = new WordSearchPuzzle();
                setupSUT.AddWord("KIRK");
                setupSUT.AddLetterAt('K', 0, 0);
                setupSUT.AddLetterAt('E', 1, 0);
                setupSUT.AddLetterAt('F', 2, 0);
                setupSUT.AddLetterAt('K', 3, 0);
                setupSUT.AddLetterAt('R', 0, 1);
                setupSUT.AddLetterAt('R', 1, 1);
                setupSUT.AddLetterAt('J', 2, 1);
                setupSUT.AddLetterAt('I', 3, 1);
                setupSUT.AddLetterAt('I', 0, 2);
                setupSUT.AddLetterAt('L', 1, 2);
                setupSUT.AddLetterAt('I', 2, 2);
                setupSUT.AddLetterAt('R', 3, 2);
                setupSUT.AddLetterAt('K', 0, 3);
                setupSUT.AddLetterAt('D', 1, 3);
                setupSUT.AddLetterAt('J', 2, 3);
                setupSUT.AddLetterAt('K', 3, 3);

                yield return new TestCaseData(setupSUT);
            }
        }

        private WordSearchPuzzle KIRKUpInFirstColumnPuzzle()
        {
            WordSearchPuzzle puzzle = new WordSearchPuzzle();
            puzzle.AddWord("KIRK");
            puzzle.AddLetterAt('K', 0, 0);
            puzzle.AddLetterAt('E', 1, 0);
            puzzle.AddLetterAt('F', 2, 0);
            puzzle.AddLetterAt('N', 3, 0);
            puzzle.AddLetterAt('R', 0, 1);
            puzzle.AddLetterAt('R', 1, 1);
            puzzle.AddLetterAt('J', 2, 1);
            puzzle.AddLetterAt('A', 3, 1);
            puzzle.AddLetterAt('I', 0, 2);
            puzzle.AddLetterAt('L', 1, 2);
            puzzle.AddLetterAt('I', 2, 2);
            puzzle.AddLetterAt('H', 3, 2);
            puzzle.AddLetterAt('K', 0, 3);
            puzzle.AddLetterAt('D', 1, 3);
            puzzle.AddLetterAt('J', 2, 3);
            puzzle.AddLetterAt('M', 3, 3);

            return puzzle;
        }

        private List<Vector2> KIRKUpInFirstColumnLocations()
        {
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(0, 3));
            kirkLocation.Add(new Vector2(0, 2));
            kirkLocation.Add(new Vector2(0, 1));
            kirkLocation.Add(new Vector2(0, 0));

            return kirkLocation;
        }

        private List<Vector2> KIRKDownInFirstColumnLocations()
        {
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(0, 0));
            kirkLocation.Add(new Vector2(0, 1));
            kirkLocation.Add(new Vector2(0, 2));
            kirkLocation.Add(new Vector2(0, 3));

            return kirkLocation;
        }
    }
}
