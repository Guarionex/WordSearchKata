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
            PuzzleSolver solver = new PuzzleSolver();
            WordSearchPuzzle puzzle = solver.ParsePuzzleWordFile(args[0]);
            Console.WriteLine(puzzle.ToString());
        }
    }
}
