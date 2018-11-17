using System;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver3 : Solver
    {
        /* Largest prime factor
         * 
         * The prime factors of 13195 are 5, 7, 13 and 29.
         * What is the largest prime factor of the number 600851475143?
         * 
         */

        protected override void DoCalculation()
        {
            int lastFactor;
            var n = 600851475143;
            if (n % 2 == 0)
            {
                lastFactor = 2;
                n /= 2;
                while (n % 2 == 0)
                    n /= 2;
            }
            else
            {
                lastFactor = 1;
            }

            var factor = 3;
            var maxFactor = Math.Sqrt(n);
            while (n > 1 && factor <= maxFactor)
            {
                if (n % factor == 0)
                {
                    n /= factor;
                    lastFactor = factor;
                    while (n % factor == 0)
                        n /= factor;
                    maxFactor = Math.Sqrt(n);
                }

                factor += 2;
            }

            if (n == 1)
                SetAnswer(lastFactor);
            else
                SetAnswer(n);
        }
    }
}