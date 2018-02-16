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
    class PuzzleFileParserTestData
    {
        public static IEnumerable Example15x15TestCase
        {
            get
            {
                List<Vector2> bonesLocation = new List<Vector2>();
                bonesLocation.Add(new Vector2(0, 6));
                bonesLocation.Add(new Vector2(0, 7));
                bonesLocation.Add(new Vector2(0, 8));
                bonesLocation.Add(new Vector2(0, 9));
                bonesLocation.Add(new Vector2(0, 10));
                List<Vector2> khanLocations = new List<Vector2>();
                khanLocations.Add(new Vector2(5, 9));
                khanLocations.Add(new Vector2(5, 8));
                khanLocations.Add(new Vector2(5, 7));
                khanLocations.Add(new Vector2(5, 6));
                List<Vector2> kirkLocations = new List<Vector2>();
                kirkLocations.Add(new Vector2(4, 7));
                kirkLocations.Add(new Vector2(3, 7));
                kirkLocations.Add(new Vector2(2, 7));
                kirkLocations.Add(new Vector2(1, 7));
                List<Vector2> scottyLocations = new List<Vector2>();
                scottyLocations.Add(new Vector2(0, 5));
                scottyLocations.Add(new Vector2(1, 5));
                scottyLocations.Add(new Vector2(2, 5));
                scottyLocations.Add(new Vector2(3, 5));
                scottyLocations.Add(new Vector2(4, 5));
                scottyLocations.Add(new Vector2(5, 5));
                List<Vector2> spockLocations = new List<Vector2>();
                spockLocations.Add(new Vector2(2, 1));
                spockLocations.Add(new Vector2(3, 2));
                spockLocations.Add(new Vector2(4, 3));
                spockLocations.Add(new Vector2(5, 4));
                spockLocations.Add(new Vector2(6, 5));
                List<Vector2> suluLocations = new List<Vector2>();
                suluLocations.Add(new Vector2(3, 3));
                suluLocations.Add(new Vector2(2, 2));
                suluLocations.Add(new Vector2(1, 1));
                suluLocations.Add(new Vector2(0, 0));
                List<Vector2> uhuraLocations = new List<Vector2>();
                uhuraLocations.Add(new Vector2(4, 0));
                uhuraLocations.Add(new Vector2(3, 1));
                uhuraLocations.Add(new Vector2(2, 2));
                uhuraLocations.Add(new Vector2(1, 3));
                uhuraLocations.Add(new Vector2(0, 4));

                Dictionary<String, List<Vector2>> expectedFromExample15x15 = new Dictionary<string, List<Vector2>>();
                expectedFromExample15x15.Add("BONES", bonesLocation);
                expectedFromExample15x15.Add("KHAN", khanLocations);
                expectedFromExample15x15.Add("KIRK", kirkLocations);
                expectedFromExample15x15.Add("SCOTTY", scottyLocations);
                expectedFromExample15x15.Add("SPOCK", spockLocations);
                expectedFromExample15x15.Add("SULU", suluLocations);
                expectedFromExample15x15.Add("UHURA", uhuraLocations);

                yield return new TestCaseData(new WordsMapDecorator(expectedFromExample15x15));
            }
        }
    }
}
