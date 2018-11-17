using System.Numerics;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver20 : Solver
    {
        /* Factorial digit sum
         * 
         * n! means n × (n − 1) × ... × 3 × 2 × 1
         * 
         * For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
         * and the sum of the digits in the number 10! is
         * 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
         * 
         * Find the sum of the digits in the number 100!
         * 
         */

        protected override void DoCalculation()
        {
            var factorial = GetFactorial(100);
            SetAnswer(GetFactorialSum(factorial));
        }

        private static BigInteger GetFactorial(int i)
        {
            BigInteger factorial = i;
            i--;
            while (i > 0)
            {
                factorial *= i;
                i--;
            }

            return factorial;
        }

        private static BigInteger GetFactorialSum(BigInteger factorial)
        {
            BigInteger sum = 0;
            while (factorial >= 10)
            {
                sum += factorial % 10;
                factorial /= 10;
            }

            sum += factorial % 10;
            return sum;
        }
    }
}