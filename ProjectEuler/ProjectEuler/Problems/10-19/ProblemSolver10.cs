﻿namespace ProjectEuler
{
    class ProblemSolver10 : Solver
    {
        /* Summation of primes
         * 
         * The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
         * Find the sum of all the primes below two million.
         * 
         */

        protected override void DoCalculation()
        {
            int i = 0;
            int[] primes = Primes.Get();
            long total = 0;
            while (true)
            {
                if (primes[i] < 2000000)
                    total += primes[i];
                else
                    break;
                i++;
            }
            this.SetAnswer(total);
        }
    }
}