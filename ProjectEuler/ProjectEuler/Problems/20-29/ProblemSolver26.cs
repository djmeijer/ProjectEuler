using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using ProjectEuler.Utilities;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver26 : Solver
    {
        private static readonly Tuple<int, int> _bounds = new Tuple<int, int>(2, 999);
        private static readonly IEnumerable<int> _primes = PrimeNumberDiscoverer.Get(_bounds.Item2);
        private readonly ConcurrentDictionary<int, int> _results = new ConcurrentDictionary<int, int>();

        protected override void DoCalculation()
        {
            Parallel.For(_bounds.Item1, _bounds.Item2, CalculateReciprocalCycleLength);
            var result = _results.OrderByDescending(f => f.Value).First();
            SetAnswer(result.Key);
        }

        private void CalculateReciprocalCycleLength(int d)
        {
            /* A fraction of the form 1/d shown as decimal:
             * 1. Is a rounded number, an integer (1 / 1 = 1). Skip this.
             * 2. Has a limited amount of decimals (1 / 2 = 0,5). Cycle length is 0.
             * 3. Has an unlimited amound of decimals with cycles (1 / 3 = 0,33333...). Calculate cycle length.
             */

            _results.TryAdd(d, HasFiniteDecimals(d) ? 0 : DetermineCycleLength(d));
        }

        /// <summary>
        ///     If the factorization of the denominater only consist of 2's and/or 5's,
        ///     then the amount of decimals is finite.
        /// </summary>
        private static bool HasFiniteDecimals(int d)
        {
            var allowedSet = new List<int> {2, 5};
            return FactorizeInteger(d).All(f => allowedSet.Contains(f));
        }

        /// <summary>
        ///     Factorize a given integer.
        /// </summary>
        private static IEnumerable<int> FactorizeInteger(int d)
        {
            var first = _primes
                .TakeWhile(p => p <= Math.Sqrt(d))
                .FirstOrDefault(p => d % p == 0);
            return first == 0
                ? new[] {d}
                : new[] {first}.Concat(FactorizeInteger(d / first));
        }

        private static int DetermineCycleLength(int d)
        {
            if (BigInteger.GreatestCommonDivisor(10, d) != 1)
            {
                return -1;
            }

            var found = false;
            var length = 0;
            while (!found)
            {
                length++;
                found = (BigInteger.Pow(10, length) % d).Equals(1);
            }
            return length;
        }
    }
}