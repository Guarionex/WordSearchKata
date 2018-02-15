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
    class WordsMapDecoratorTestData
    {
        public static IEnumerable ValidOneWordWordsMapTestCase
        {
            get
            {
                WordsMapDecoratorTestData testData = new WordsMapDecoratorTestData();
                List<Vector2> kirkLocation = testData.KIRKUpInSecondRowLocations();
                Dictionary<String, List<Vector2>> wordsMap = new Dictionary<String, List<Vector2>>();
                wordsMap.Add("KIRK", kirkLocation);

                yield return new TestCaseData(wordsMap);
            }
        }

        public static IEnumerable ValidTwoWordWordsMapTestCase
        {
            get
            {
                WordsMapDecoratorTestData testData = new WordsMapDecoratorTestData();
                List<Vector2> kirkLocation = testData.KIRKUpInSecondRowLocations();
                List<Vector2> khanLocation = testData.KHANDownInFourthRowLocations();
                Dictionary<String, List<Vector2>> wordsMap = new Dictionary<String, List<Vector2>>();
                wordsMap.Add("KIRK", kirkLocation);
                wordsMap.Add("KHAN", khanLocation);

                yield return new TestCaseData(wordsMap);
            }
        }

        private List<Vector2> KIRKUpInSecondRowLocations()
        {
            List<Vector2> kirkLocation = new List<Vector2>();
            kirkLocation.Add(new Vector2(0, 1));
            kirkLocation.Add(new Vector2(1, 1));
            kirkLocation.Add(new Vector2(2, 1));
            kirkLocation.Add(new Vector2(3, 1));

            return kirkLocation;
        }

        private List<Vector2> KHANDownInFourthRowLocations()
        {
            List<Vector2> khanLocation = new List<Vector2>();
            khanLocation.Add(new Vector2(0, 3));
            khanLocation.Add(new Vector2(1, 3));
            khanLocation.Add(new Vector2(2, 3));
            khanLocation.Add(new Vector2(3, 3));

            return khanLocation;
        }
    }
}
