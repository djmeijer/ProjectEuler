﻿using System;
using ProjectEuler.Problems;

namespace ProjectEuler
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Solver solver = new ProblemSolver19();
            solver.ShowAnswer();
        }
    }
}