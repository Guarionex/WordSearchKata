using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject
{
    public class PuzzleSolver
    {
        public void AddWord(String word)
        {
            if(word.Any(ch => ! char.IsLetter(ch)))
            {
                throw new ArgumentException();
            }
        }

        public void AddCharacterAt(char letter, int x, int y)
        {
            if(char.IsDigit(letter))
            {
                throw new ArgumentException();
            }
            else if(char.IsWhiteSpace(letter))
            {
                throw new ArgumentException();
            }
            else if(char.IsSymbol(letter))
            {
                throw new ArgumentException();
            }
            else if(letter == ',')
            {
                throw new ArgumentException();
            }
        }
    }
}
