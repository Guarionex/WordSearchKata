using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject
{
    class Program
    {
        static void Main(string[] args)
        {
            PuzzleFileParser solver = new PuzzleFileParser();
            WordSearchPuzzle puzzle = solver.ParseFileToWordSearchPuzzle(args[0]);
            WordsLocationFinder wordsFinder = new WordsLocationFinder(puzzle);
            WordsMapDecorator wordsMap = new WordsMapDecorator(wordsFinder.GetWordsLocation());
            Console.WriteLine(wordsMap.ToString());
        }
    }
}
