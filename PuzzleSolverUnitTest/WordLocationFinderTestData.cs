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
                WordSearchPuzzle setupSUT = testData.KIRKUpInFirstColumnPuzzle();

                yield return new TestCaseData(setupSUT);
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
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);

                yield return new TestCaseData(setupSUT, expected);
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
    }
}
