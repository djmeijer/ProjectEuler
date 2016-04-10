using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Utilities
{
    internal static class PrimeNumberDiscoverer
    {
        /// <summary>
        ///     Take first n number of primes.
        /// </summary>
        public static IEnumerable<int> Take(int n)
        {
            var result = new List<int>();
            var reached = false;
            var x = 500000;
            // Suboptimal way of extending list of primes.
            while (!reached)
            {
                x *= 2;
                result = Discover(x).ToList();
                reached = result.Count >= n;
            }

            return result.Take(n);
        }

        /// <summary>
        ///     Get all primes with a value less or equal the given upper limit.
        /// </summary>
        public static IEnumerable<int> Get(int upperLimit)
        {
            return Discover(upperLimit);
        }

        private static IEnumerable<int> Discover(int bound)
        {
            if (bound < 2)
            {
                yield break;
            }

            // The first prime number is 2.
            yield return 2;

            var composite = new BitArray((bound - 1) / 2);
            var limit = ((int) Math.Sqrt(bound) - 1) / 2;
            for (var i = 0; i < limit; i++)
            {
                if (composite[i])
                {
                    continue;
                }

                // The first number not crossed out is prime.
                var prime = 2 * i + 3;
                yield return prime;

                // Cross out all multiples of this prime, starting at the prime squared.
                for (var j = (prime * prime - 2) >> 1; j < composite.Count; j += prime)
                {
                    composite[j] = true;
                }
            }

            // The remaining numbers not crossed out are also prime.
            for (var i = limit; i < composite.Count; i++)
            {
                if (!composite[i]) yield return 2 * i + 3;
            }
        }
    }
}