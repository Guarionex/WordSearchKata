﻿using NUnit.Framework;
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
                List<Vector2> kirkLocation = testData.KIRKUpInFirstColumnLocations();
                Dictionary<String, List<Vector2>> wordsMap = new Dictionary<String, List<Vector2>>();
                wordsMap.Add("KIRK", kirkLocation);

                yield return new TestCaseData(wordsMap);
            }
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
