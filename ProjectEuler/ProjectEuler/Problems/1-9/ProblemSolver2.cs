﻿namespace ProjectEuler.Problems
{
    class ProblemSolver2 : Solver
    {
        /* Even Fibonacci numbers
         * 
         * Each new term in the Fibonacci sequence is generated by adding the previous two terms.
         * By starting with 1 and 2, the first 10 terms will be: 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
         * By considering the terms in the Fibonacci sequence whose values do not exceed four million,
         * find the sum of the even-valued terms.
         * 
         */

        protected override void DoCalculation()
        {
            const int limit = 4000000;
            int sum = 0, a = 1, b = 1, c = a + b;
            while (c < limit)
            {
                sum += c;
                a = b + c;
                b = c + a;
                c = a + b;
            }
            SetAnswer(sum);
        }
    }
}