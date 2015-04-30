using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    class ProblemSolver16 : Solver
    {
        /* Power digit sum
         * 
         * 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
         * 
         * What is the sum of the digits of the number 2^1000?
         * 
         */

        protected override void DoCalculation()
        {
            BigInteger calc = BigInteger.Pow(2, 1000), count = 0;
            string numbers = calc.ToString();
            count = numbers.Aggregate(count, (current, t) => current + BigInteger.Parse(t.ToString()));
            this.SetAnswer(count);
        }
    }
}