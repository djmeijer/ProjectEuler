using System.Linq;
using ProjectEuler.Utilities;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver7 : Solver
    {
        /* 10.001st prime
         * 
         * By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13,
         * we can see that the 6th prime is 13. What is the 10.001st prime number?
         * 
         */

        protected override void DoCalculation()
        {
            var prime = PrimeNumberDiscoverer.Take(10001).Last();
            SetAnswer(prime);
        }
    }
}