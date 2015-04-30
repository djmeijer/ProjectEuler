namespace ProjectEuler.Problems
{
    class ProblemSolver7 : Solver
    {
        /* 10001st prime
         * 
         * By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13,
         * we can see that the 6th prime is 13. What is the 10 001st prime number?
         * 
         */

        protected override void DoCalculation()
        {
            int[] primes = Primes.Get();
            int prime = 10001;
            this.SetAnswer(primes[prime - 1]);
        }
    }
}