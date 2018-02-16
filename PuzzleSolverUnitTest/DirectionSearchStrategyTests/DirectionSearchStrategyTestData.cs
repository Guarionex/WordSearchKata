using NUnit.Framework;
using PuzzleSolverProject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverUnitTest.DirectionSearchStrategyTests
{
    class DirectionSearchStrategyTestData
    {
        public static IEnumerable Base4x4PuzzleTestCase
        {
            get
            {
                WordSearchPuzzle puzzle = new WordSearchPuzzle();
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

                yield return new TestCaseData(puzzle);
            }
        }

        public static IEnumerable Base5x5PuzzleTestCase
        {
            get
            {
                WordSearchPuzzle puzzle = new WordSearchPuzzle();
                puzzle.AddLetterAt('K', 0, 0);
                puzzle.AddLetterAt('E', 1, 0);
                puzzle.AddLetterAt('F', 2, 0);
                puzzle.AddLetterAt('N', 3, 0);
                puzzle.AddLetterAt('H', 4, 0);
                puzzle.AddLetterAt('R', 0, 1);
                puzzle.AddLetterAt('R', 1, 1);
                puzzle.AddLetterAt('J', 2, 1);
                puzzle.AddLetterAt('A', 3, 1);
                puzzle.AddLetterAt('J', 4, 1);
                puzzle.AddLetterAt('I', 0, 2);
                puzzle.AddLetterAt('L', 1, 2);
                puzzle.AddLetterAt('I', 2, 2);
                puzzle.AddLetterAt('H', 3, 2);
                puzzle.AddLetterAt('U', 4, 2);
                puzzle.AddLetterAt('K', 0, 3);
                puzzle.AddLetterAt('D', 1, 3);
                puzzle.AddLetterAt('J', 2, 3);
                puzzle.AddLetterAt('M', 3, 3);
                puzzle.AddLetterAt('Y', 4, 3);
                puzzle.AddLetterAt('R', 0, 4);
                puzzle.AddLetterAt('D', 1, 4);
                puzzle.AddLetterAt('B', 2, 4);
                puzzle.AddLetterAt('X', 3, 4);
                puzzle.AddLetterAt('V', 4, 4);

                yield return new TestCaseData(puzzle);
            }
        }

        public static IEnumerable BaseWordsListTestCase
        {
            get
            {
                WordSearchPuzzle puzzle = new WordSearchPuzzle();
                puzzle.AddWord("KIRK");
                puzzle.AddWord("KHAN");

                yield return new TestCaseData(puzzle);
            }
        }
    }
}
