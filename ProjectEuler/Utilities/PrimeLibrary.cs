using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Utilities
{
    public class PrimeLibrary : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            yield return 2;
            yield return 3;

            var n = 5;

            while (n < int.MaxValue)
            {
                if (IsPrime(n)) yield return n;
                n++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal IEnumerable<int> GetAllPrimesLessThanValue(int n)
        {
            /* Given a number n, how much primes will there be with a value less than n?
             * This is the Prime Counting Function π(n).
             * We can make an estimation using the PNT (Prime Number Theorem)
             * see http://mathworld.wolfram.com/PrimeNumberTheorem.html.
             * π(n)∼n/(ln n-1.08366)
             */
            int EstimationLegendre(int x) => (int) (x / (Math.Log(x) - 1.08366));
            var pi = n < 20 ? n : EstimationLegendre(n);

            return this.Take(pi).Where(p => p < n);
        }

        public static bool IsPrime(int n)
        {
            if (n % 2 == 0) return false;

            for (var i = 3; i < Math.Sqrt(n) + 1; i += 2)
                if (n % i == 0)
                    return false;

            return true;
        }
    }
}