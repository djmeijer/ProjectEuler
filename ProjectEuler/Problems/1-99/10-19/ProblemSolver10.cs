using System.Linq;
using System.Numerics;
using ProjectEuler.Utilities;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver10 : Solver
    {
        /* Summation of primes
         * 
         * The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
         * Find the sum of all the primes below two million.
         * 
         */

        protected override void DoCalculation()
        {
            // Use a BigInteger type to sum the primes.
            var primes = new PrimeLibrary().GetAllPrimesLessThanValue(2000000).Select(p => (BigInteger) p);
            var total = primes.Aggregate(BigInteger.Add);

            SetAnswer(total); // 142913828922
        }
    }
}