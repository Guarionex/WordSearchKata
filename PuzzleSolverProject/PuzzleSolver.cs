﻿using System;
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
            if(word.Any(char.IsDigit))
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
