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

        public void AddLetterAt(char letter, int x, int y)
        {
            if(!char.IsLetter(letter))
            {
                throw new ArgumentException();
            }
            else if(x < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if(y < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void SetDimensions(int x, int y)
        {
            if(x < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if(y < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if(x != y)
            {
                throw new ArgumentException();
            }
            else if(x <= 1 && x <= 1)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
