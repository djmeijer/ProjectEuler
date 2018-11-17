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
        /* Reciprocal cycles
         * 
         * A unit fraction contains 1 in the numerator. The decimal representation
         * of the unit fractions with denominators 2 to 10 are given:
         * 
         * 1/2	= 	0.5
         * 1/3	= 	0.(3)
         * 1/4	= 	0.25
         * 1/5	= 	0.2
         * 1/6	= 	0.1(6)
         * 1/7	= 	0.(142857)
         * 1/8	= 	0.125
         * 1/9	= 	0.(1)
         * 1/10	= 	0.1
         * Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It
         * can be seen that 1/7 has a 6-digit recurring cycle.
         * 
         * Find the value of d < 1000 for which 1/d contains the longest recurring
         * cycle in its decimal fraction part.
         */

        private static readonly Tuple<int, int> _bounds = new Tuple<int, int>(2, 999);
        private static readonly IEnumerable<int> _primes = new PrimeLibrary().GetAllPrimesLessThanValue(_bounds.Item2);
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
             * 3. Has an unlimited amount of decimals with cycles (1 / 3 = 0,33333...). Calculate cycle length.
             */

            _results.TryAdd(d, HasFiniteDecimals(d) ? 0 : DetermineCycleLength(d));
        }

        /// <summary>
        ///     If the factorization of the denominator only consist of 2's and/or 5's,
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
            // How to calculate case with prefixed cycles?
            if (BigInteger.GreatestCommonDivisor(10, d) != 1) return -1;

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