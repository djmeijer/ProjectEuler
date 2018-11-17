using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Utilities;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver50 : Solver
    {
        /* Consecutive prime sum
         * 
         * The prime 41, can be written as the sum of six consecutive primes:
         * 
         * 41 = 2 + 3 + 5 + 7 + 11 + 13
         * 
         * This is the longest sum of consecutive primes that adds to a prime below one-hundred.
         * The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.
         * 
         * Which prime, below one-million, can be written as the sum of the most consecutive primes?
         *
         */

        protected override void DoCalculation()
        {
            const int m = 1000000;

            var topscorePrimes = new List<int>();
            var currentPrimes = new Queue<int>();

            void CheckForTopscore()
            {
                if (currentPrimes.Count() > topscorePrimes.Count && PrimeLibrary.IsPrime(currentPrimes.Sum()))
                {
                    topscorePrimes.Clear();
                    topscorePrimes.AddRange(currentPrimes);
                }
            }

            foreach (var p in new PrimeLibrary().GetAllPrimesLessThanValue(m))
            {
                while (currentPrimes.Sum() + p >= m)
                {
                    currentPrimes.Dequeue();
                    CheckForTopscore();
                }

                currentPrimes.Enqueue(p);
                CheckForTopscore();
            }

            SetAnswer(topscorePrimes.Sum());
        }
    }
}