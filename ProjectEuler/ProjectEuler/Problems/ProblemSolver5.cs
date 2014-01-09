using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    class ProblemSolver5 : Solver
    {
        /* Smallest multiple
         * 
         * 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
         * What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
         * 
         */

        protected override void DoCalculation()
        {
            int[] primes = Primes.Get100000();
            double k = 20, n = 1, i = 1;
            bool check = true;
            double[] a = new double[primes.Length];
            double limit = Math.Sqrt(k);
            while (primes[(int)i] <= k)
            {
                a[(int)i] = 1;
                if (check)
                    if (primes[(int)i] <= limit)
                        a[(int)i] = Math.Floor(Math.Log(k) / Math.Log(primes[(int)i]));
                    else
                        check = false;
                n *= Math.Pow(primes[(int)i], a[(int)i]);
                i++;
            }
            this.SetAnswer(n);
        }
    }
}