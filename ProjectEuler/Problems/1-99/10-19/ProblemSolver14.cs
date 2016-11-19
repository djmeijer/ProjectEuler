﻿namespace ProjectEuler.Problems
{
    internal class ProblemSolver14 : Solver
    {
        /* Longest Collatz sequence
         * 
         * The following iterative sequence is defined for the set of positive integers:
         * n → n/2 (n is even)
         * n → 3n + 1 (n is odd)
         * 
         * Using the rule above and starting with 13, we generate the following sequence:
         * 13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
         * 
         * It can be seen that this sequence (starting at 13 and finishing at 1) contains
         * 10 terms. Although it has not been proved yet (Collatz Problem), it is thought
         * that all starting numbers finish at 1.
         * 
         * Which starting number, under one million, produces the longest chain?
         * 
         * NOTE: Once the chain starts the terms are allowed to go above one million.
         * 
         */

        protected override void DoCalculation()
        {
            long[] highestNumber = {0, 0};
            for (var i = 2; i < 1000000; i++)
            {
                var result = GiveCollatzSequenceLength(i);
                if (result > highestNumber[1])
                {
                    highestNumber[0] = i;
                    highestNumber[1] = result;
                }
            }
            SetAnswer(highestNumber[0]);
        }

        private static long GiveCollatzSequenceLength(int i)
        {
            long count = 0, number = i;
            while (number > 1)
            {
                if (number % 2 == 0)
                {
                    number /= 2;
                    count++;
                }
                else
                {
                    number = 3 * number + 1;
                    count++;
                }
            }
            return count + 1;
        }
    }
}