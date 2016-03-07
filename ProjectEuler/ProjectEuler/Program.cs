using System;
using ProjectEuler.Problems;

namespace ProjectEuler
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Solver solver = new ProblemSolver23();
            solver.ShowAnswer();
        }
    }
}