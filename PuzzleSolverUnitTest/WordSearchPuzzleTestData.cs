using NUnit.Framework;
using PuzzleSolverProject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverUnitTest
{
    class WordSearchPuzzleTestData
    {
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
    }
}
