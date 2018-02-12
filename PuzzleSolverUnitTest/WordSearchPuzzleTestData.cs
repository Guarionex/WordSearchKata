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
    class WordSearchPuzzleTestData
    {
        public static IEnumerable GetWordsLocationReturnTypeTestCase
        {
            get
            {
                WordSearchPuzzle setupSUT = KIRKUpInFirstColumn();

                yield return new TestCaseData(setupSUT);
            }
        }

        public static IEnumerable WordMissingInPuzzleTestCase
        {
            get
            {
                WordSearchPuzzle setupSUT = new WordSearchPuzzle();
                setupSUT.AddWord("KIRK");
                setupSUT.AddLetterAt('X', 0, 0);
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

                yield return new TestCaseData(setupSUT);
            }
        }

        public static IEnumerable OneOfTwoWordsMissingInPuzzleTestCase
        {
            get
            {
                WordSearchPuzzle setupSUT = KIRKUpInFirstColumn();
                setupSUT.AddWord("KHAN");

                yield return new TestCaseData(setupSUT);
            }
        }

        public static IEnumerable KIRKUpInFirstColumnTestCase
        {
            get
            {
                WordSearchPuzzle setupSUT = KIRKUpInFirstColumn();

                List<Vector2> kirkLocation = new List<Vector2>();
                kirkLocation.Add(new Vector2(0, 3));
                kirkLocation.Add(new Vector2(0, 2));
                kirkLocation.Add(new Vector2(0, 1));
                kirkLocation.Add(new Vector2(0, 0));
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        private static WordSearchPuzzle KIRKUpInFirstColumn()
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
