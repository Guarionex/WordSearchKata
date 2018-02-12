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
                setupSUT.AddWord("KHAN");
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

        public static IEnumerable OneDownWordTestCase
        {
            get
            {
                WordSearchPuzzleTestData testData = new WordSearchPuzzleTestData();
                WordSearchPuzzle setupSUT = testData.DownWordsPuzzle();
                setupSUT.AddWord("KIRK");

                List<Vector2> kirkLocation = testData.KIRKDownInFirstColumnLocations();
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable TwoDownWordTestCase
        {
            get
            {
                WordSearchPuzzleTestData testData = new WordSearchPuzzleTestData();
                WordSearchPuzzle setupSUT = testData.DownWordsPuzzle();
                setupSUT.AddWord("KIRK");
                setupSUT.AddWord("KHAN");

                List<Vector2> kirkLocation = testData.KIRKDownInFirstColumnLocations();
                List<Vector2> khanLocation = new List<Vector2>();
                khanLocation.Add(new Vector2(3, 0));
                khanLocation.Add(new Vector2(3, 1));
                khanLocation.Add(new Vector2(3, 2));
                khanLocation.Add(new Vector2(3, 3));

                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);
                expected.Add("KHAN", khanLocation);

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

        public static IEnumerable OneLeftWordTestCase
        {
            get
            {
                WordSearchPuzzleTestData testData = new WordSearchPuzzleTestData();
                WordSearchPuzzle setupSUT = testData.LeftWordsPuzzle();
                setupSUT.AddWord("KIRK");

                List<Vector2> kirkLocation = testData.KIRKLeftSecondRowLocations();
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable TwoLeftWordTestCase
        {
            get
            {
                WordSearchPuzzleTestData testData = new WordSearchPuzzleTestData();
                WordSearchPuzzle setupSUT = testData.LeftWordsPuzzle();
                setupSUT.AddWord("KIRK");
                setupSUT.AddWord("KHAN");

                Dictionary<String, List<Vector2>> result = setupSUT.GetWordsLocation();
                List<Vector2> kirkLocation = testData.KIRKLeftSecondRowLocations();

                List<Vector2> khanLocation = new List<Vector2>();
                khanLocation.Add(new Vector2(3, 3));
                khanLocation.Add(new Vector2(2, 3));
                khanLocation.Add(new Vector2(1, 3));
                khanLocation.Add(new Vector2(0, 3));
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);
                expected.Add("KHAN", khanLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable OneRightWordTestCase
        {
            get
            {
                WordSearchPuzzleTestData testData = new WordSearchPuzzleTestData();
                WordSearchPuzzle setupSUT = testData.RightWordsPuzzle();
                setupSUT.AddWord("KIRK");

                List<Vector2> kirkLocation = testData.KIRKRightSecondRowLocations();
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable TwoRightWordTestCase
        {
            get
            {
                WordSearchPuzzleTestData testData = new WordSearchPuzzleTestData();
                WordSearchPuzzle setupSUT = testData.RightWordsPuzzle();
                setupSUT.AddWord("KIRK");
                setupSUT.AddWord("KHAN");

                List<Vector2> kirkLocation = testData.KIRKRightSecondRowLocations();
                List<Vector2> khanLocation = new List<Vector2>();
                khanLocation.Add(new Vector2(0, 3));
                khanLocation.Add(new Vector2(1, 3));
                khanLocation.Add(new Vector2(2, 3));
                khanLocation.Add(new Vector2(3, 3));
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);
                expected.Add("KHAN", khanLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable OneUpLeftWordTestCase
        {
            get
            {
                WordSearchPuzzleTestData testData = new WordSearchPuzzleTestData();
                WordSearchPuzzle setupSUT = testData.UpLeftWordsPuzzle();
                setupSUT.AddWord("KIRK");

                List<Vector2> kirkLocation = testData.KIRKUpLeftLocations();
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable TwoUpLeftWordTestCase
        {
            get
            {
                WordSearchPuzzleTestData testData = new WordSearchPuzzleTestData();
                WordSearchPuzzle setupSUT = testData.UpLeftWordsPuzzle();
                setupSUT.AddWord("KIRK");
                setupSUT.AddWord("HAN");

                List<Vector2> kirkLocation = testData.KIRKUpLeftLocations();
                List<Vector2> hanLocation = new List<Vector2>();
                hanLocation.Add(new Vector2(2, 3));
                hanLocation.Add(new Vector2(1, 2));
                hanLocation.Add(new Vector2(0, 1));
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);
                expected.Add("HAN", hanLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable OneUpRightWordTestCase
        {
            get
            {
                WordSearchPuzzleTestData testData = new WordSearchPuzzleTestData();
                WordSearchPuzzle setupSUT = testData.UpRightWordsPuzzle();
                setupSUT.AddWord("KIRK");

                List<Vector2> kirkLocation = testData.KIRKUpRightLocations();
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable TwoUpRightWordTestCase
        {
            get
            {
                WordSearchPuzzleTestData testData = new WordSearchPuzzleTestData();
                WordSearchPuzzle setupSUT = testData.UpRightWordsPuzzle();
                setupSUT.AddWord("KIRK");
                setupSUT.AddWord("HAN");

                List<Vector2> kirkLocation = testData.KIRKUpRightLocations();
                List<Vector2> hanLocation = new List<Vector2>();
                hanLocation.Add(new Vector2(0, 2));
                hanLocation.Add(new Vector2(1, 1));
                hanLocation.Add(new Vector2(2, 0));
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);
                expected.Add("HAN", hanLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable OneDownLeftWordTestCase
        {
            get
            {
                WordSearchPuzzleTestData testData = new WordSearchPuzzleTestData();
                WordSearchPuzzle setupSUT = testData.DownLeftWordsPuzzle();
                setupSUT.AddWord("KIRK");

                List<Vector2> kirkLocation = testData.KIRKDownLeftLocations();
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);

                yield return new TestCaseData(setupSUT, expected);
            }
        }

        public static IEnumerable TwoDownLeftWordTestCase
        {
            get
            {
                WordSearchPuzzleTestData testData = new WordSearchPuzzleTestData();
                WordSearchPuzzle setupSUT = testData.DownLeftWordsPuzzle();
                setupSUT.AddWord("KIRK");
                setupSUT.AddWord("HAN");

                List<Vector2> kirkLocation = testData.KIRKDownLeftLocations();
                List<Vector2> hanLocation = new List<Vector2>();
                hanLocation.Add(new Vector2(3, 1));
                hanLocation.Add(new Vector2(2, 2));
                hanLocation.Add(new Vector2(1, 3));
                Dictionary<String, List<Vector2>> expected = new Dictionary<String, List<Vector2>>();
                expected.Add("KIRK", kirkLocation);
                expected.Add("HAN", hanLocation);

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

        private WordSearchPuzzle DownWordsPuzzle()
        {
            WordSearchPuzzle setupSUT = new WordSearchPuzzle();
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

            return setupSUT;
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

        private WordSearchPuzzle LeftWordsPuzzle()
        {
            WordSearchPuzzle setupSUT = new WordSearchPuzzle();
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

            return setupSUT;
        }

        private List<Vector2> KIRKLeftSecondRowLocations()
        {
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(3, 1));
            kirkLocation.Add(new Vector2(2, 1));
            kirkLocation.Add(new Vector2(1, 1));
            kirkLocation.Add(new Vector2(0, 1));

            return kirkLocation;
        }

        private WordSearchPuzzle RightWordsPuzzle()
        {
            WordSearchPuzzle setupSut = new WordSearchPuzzle();
            setupSut.AddLetterAt('K', 0, 0);
            setupSut.AddLetterAt('E', 1, 0);
            setupSut.AddLetterAt('F', 2, 0);
            setupSut.AddLetterAt('N', 3, 0);
            setupSut.AddLetterAt('K', 0, 1);
            setupSut.AddLetterAt('I', 1, 1);
            setupSut.AddLetterAt('R', 2, 1);
            setupSut.AddLetterAt('K', 3, 1);
            setupSut.AddLetterAt('R', 0, 2);
            setupSut.AddLetterAt('L', 1, 2);
            setupSut.AddLetterAt('I', 2, 2);
            setupSut.AddLetterAt('H', 3, 2);
            setupSut.AddLetterAt('K', 0, 3);
            setupSut.AddLetterAt('H', 1, 3);
            setupSut.AddLetterAt('A', 2, 3);
            setupSut.AddLetterAt('N', 3, 3);

            return setupSut;
        }

        private List<Vector2> KIRKRightSecondRowLocations()
        {
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(0, 1));
            kirkLocation.Add(new Vector2(1, 1));
            kirkLocation.Add(new Vector2(2, 1));
            kirkLocation.Add(new Vector2(3, 1));

            return kirkLocation;
        }

        private WordSearchPuzzle UpLeftWordsPuzzle()
        {
            WordSearchPuzzle setupSut = new WordSearchPuzzle();
            setupSut.AddLetterAt('K', 0, 0);
            setupSut.AddLetterAt('E', 1, 0);
            setupSut.AddLetterAt('F', 2, 0);
            setupSut.AddLetterAt('N', 3, 0);
            setupSut.AddLetterAt('N', 0, 1);
            setupSut.AddLetterAt('R', 1, 1);
            setupSut.AddLetterAt('E', 2, 1);
            setupSut.AddLetterAt('K', 3, 1);
            setupSut.AddLetterAt('R', 0, 2);
            setupSut.AddLetterAt('A', 1, 2);
            setupSut.AddLetterAt('I', 2, 2);
            setupSut.AddLetterAt('H', 3, 2);
            setupSut.AddLetterAt('K', 0, 3);
            setupSut.AddLetterAt('D', 1, 3);
            setupSut.AddLetterAt('H', 2, 3);
            setupSut.AddLetterAt('K', 3, 3);

            return setupSut;
        }

        private List<Vector2> KIRKUpLeftLocations()
        {
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(3, 3));
            kirkLocation.Add(new Vector2(2, 2));
            kirkLocation.Add(new Vector2(1, 1));
            kirkLocation.Add(new Vector2(0, 0));

            return kirkLocation;
        }

        private WordSearchPuzzle UpRightWordsPuzzle()
        {
            WordSearchPuzzle setupSUT = new WordSearchPuzzle();
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

            return setupSUT;
        }

        private List<Vector2> KIRKUpRightLocations()
        {
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(0, 3));
            kirkLocation.Add(new Vector2(1, 2));
            kirkLocation.Add(new Vector2(2, 1));
            kirkLocation.Add(new Vector2(3, 0));

            return kirkLocation;
        }

        private WordSearchPuzzle DownLeftWordsPuzzle()
        {
            WordSearchPuzzle setupSUT = new WordSearchPuzzle();
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

            return setupSUT;
        }

        private List<Vector2> KIRKDownLeftLocations()
        {
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(3, 0));
            kirkLocation.Add(new Vector2(2, 1));
            kirkLocation.Add(new Vector2(1, 2));
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
