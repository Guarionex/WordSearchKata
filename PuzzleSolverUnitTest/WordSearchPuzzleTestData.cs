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
                WordSearchPuzzleTestData testData = new WordSearchPuzzleTestData();
                WordSearchPuzzle setupSUT = testData.KIRKUpInFirstColumnPuzzle();

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
                WordSearchPuzzleTestData testData = new WordSearchPuzzleTestData();
                WordSearchPuzzle setupSUT = testData.KIRKUpInFirstColumnPuzzle();
                setupSUT.AddWord("KHAN");

                yield return new TestCaseData(setupSUT);
            }
        }

        public static IEnumerable OneUpWordTestCase
        {
            get
            {
                WordSearchPuzzleTestData testData = new WordSearchPuzzleTestData();

                WordSearchPuzzle setupSUT = testData.KIRKUpInFirstColumnPuzzle();

                List<Vector2> kirkLocation = testData.KIRKUpInFirstColumnLocations();
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);

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

                WordSearchPuzzleTestData testData = new WordSearchPuzzleTestData();
                List<Vector2> kirkLocation = testData.KIRKUpInFirstColumnLocations();
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable DownWordTestCase
        {
            get
            {
                WordSearchPuzzleTestData testData = new WordSearchPuzzleTestData();
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

                WordSearchPuzzleTestData testData = new WordSearchPuzzleTestData();
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
                WordSearchPuzzleTestData testData = new WordSearchPuzzleTestData();
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

        public static IEnumerable OneDownRightWordTestCase
        {
            get
            {
                WordSearchPuzzleTestData testData = new WordSearchPuzzleTestData();
                WordSearchPuzzle setupSUT = testData.DownRightWordsPuzzle();
                setupSUT.AddWord("KIRK");

                List<Vector2> kirkLocation = testData.KIRKDownRightLocations();
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable TwoDownRightWordTestCase
        {
            get
            {
                WordSearchPuzzleTestData testData = new WordSearchPuzzleTestData();
                WordSearchPuzzle setupSUT = testData.DownRightWordsPuzzle();
                setupSUT.AddWord("KIRK");
                setupSUT.AddWord("HAN");

                List<Vector2> kirkLocation = testData.KIRKDownRightLocations();
                List<Vector2> hanLocation = new List<Vector2>();
                hanLocation.Add(new Vector2(0, 1));
                hanLocation.Add(new Vector2(1, 2));
                hanLocation.Add(new Vector2(2, 3));
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);
                expected.Add("HAN", hanLocation);

                yield return new TestCaseData(setupSUT, expected);
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

        private WordSearchPuzzle DownRightWordsPuzzle()
        {
            WordSearchPuzzle setupSUT = new WordSearchPuzzle();
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

            return setupSUT;
        }

        private List<Vector2> KIRKDownRightLocations()
        {
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(0, 0));
            kirkLocation.Add(new Vector2(1, 1));
            kirkLocation.Add(new Vector2(2, 2));
            kirkLocation.Add(new Vector2(3, 3));

            return kirkLocation;
        }
    }
}
