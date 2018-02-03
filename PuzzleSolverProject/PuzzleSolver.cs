using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject
{
    public class PuzzleSolver
    {
        private int sizeX;
        private int sizeY;

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
            else if(x < 0 || x > sizeX || y < 0 || y > sizeY)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void SetDimensions(int x, int y)
        {
            if(x < 2 && y < 2)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if(x != y)
            {
                throw new ArgumentException();
            }

            sizeX = x;
            sizeY = y;
        }
    }
}
