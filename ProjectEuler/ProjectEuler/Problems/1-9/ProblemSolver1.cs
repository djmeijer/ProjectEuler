namespace ProjectEuler.Problems
{
    internal class ProblemSolver1 : Solver
    {
        /* Multiples of 3 and 5
         * 
         * If we list all the natural numbers below 10 that are multiples of 3 or 5,
         * we get 3, 5, 6 and 9. The sum of these multiples is 23.
         * Find the sum of all the multiples of 3 or 5 below 1000.
         * 
         */

        protected override void DoCalculation()
        {
            SetAnswer(SumDivisibleBy(3) + SumDivisibleBy(5) - SumDivisibleBy(15));
        }

        private int SumDivisibleBy(int n)
        {
            int target = 999, p = target / n;
            return n * p * (p + 1) / 2;
        }
    }
}