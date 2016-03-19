﻿namespace ProjectEuler.Problems
{
    internal class ProblemSolver6 : Solver
    {
        /* Sum square difference
         * 
         * The sum of the squares of the first ten natural numbers is,
         * 1^2 + 2^2 + ... + 10^2 = 385
         * The square of the sum of the first ten natural numbers is,
         * (1 + 2 + ... + 10)^2 = 55^2 = 3025
         * Hence the difference between the sum of the squares of the first
         * ten natural numbers and the square of the sum is 3025 − 385 = 2640.
         * Find the difference between the sum of the squares of the first
         * one hundred natural numbers and the square of the sum.
         * 
         */

        public override void DoCalculation()
        {
            int sumOfSquares = 0, squareOfSum = 0;
            for (var i = 1; i < 101; i++)
            {
                sumOfSquares += i * i;
                squareOfSum += i;
            }
            squareOfSum *= squareOfSum;
            SetAnswer(squareOfSum - sumOfSquares);
        }
    }
}