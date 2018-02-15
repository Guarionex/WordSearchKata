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

        private WordSearchPuzzle KIRKUpInFirstColumnPuzzle()
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
            setupSUT.AddLetterAt('I', 2, 2);
            setupSUT.AddLetterAt('H', 3, 2);
            setupSUT.AddLetterAt('K', 0, 3);
            setupSUT.AddLetterAt('D', 1, 3);
            setupSUT.AddLetterAt('J', 2, 3);
            setupSUT.AddLetterAt('M', 3, 3);

            return setupSUT;
        }
    }
}
