using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Problems
{
    class ProblemSolver23 : Solver
    {
        /* Non-abundant sums

         * A perfect number is a number for which the sum of its proper divisors is
         * exactly equal to the number. For example, the sum of the proper divisors
         * of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.
         *
         * A number n is called deficient if the sum of its proper divisors is less
         * than n and it is called abundant if this sum exceeds n.
         *
         * As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest
         * number that can be written as the sum of two abundant numbers is 24. By
         * mathematical analysis, it can be shown that all integers greater than 28123
         * can be written as the sum of two abundant numbers. However, this upper limit
         * cannot be reduced any further by analysis even though it is known that the
         * greatest number that cannot be expressed as the sum of two abundant numbers
         * is less than this limit.
         *
         * Find the sum of all the positive integers which cannot be written as the sum
         * of two abundant numbers.
         */

        protected override void DoCalculation()
        {
            int limit = 28123;
            IEnumerable<int> abundantNumbers = GetAbundantNumbers(limit).ToList();
            IEnumerable<int> abundantSums = new HashSet<int>(abundantNumbers.SelectMany(a => abundantNumbers.Select(b => a + b)));

            int sum = 0;
            for (int i = 1; i <= limit; i++)
            {
                if (!abundantSums.Contains(i))
                {
                    sum += i;
                }
            }
            SetAnswer(sum);
        }

        private IEnumerable<int> GetAbundantNumbers(int upperLimit)
        {
            List<int> abundantNumbers = new List<int>();
            for (int i = 1; i <= upperLimit; i++)
            {
                int sum = 0;
                for (int j = 1; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        sum += j;
                    }
                }
                if (sum > i)
                {
                    abundantNumbers.Add(i);
                }
            }
            return abundantNumbers;
        }

        /* Possible Haskell solutions (but way too slow)
         *
         * import Data.List
         * main = print n
         *
         * --a = [x|x<-[1..28123],sum[y|y<-[1..x-1],rem x y==0]>x]
         * --r x = length[[y,z]|y<-a,z<-a,y+z==x]>0
         * --n = sum $ nub $ filter(not.r)[x|x<-[1..28123],y<-a,z<-a]
         *
         * a = [x|x<-[1..28123],sum[y|y<-[1..x-1],rem x y==0]>x]
         * c = [x+y|x<-a,y<-a]
         * n = sum[x|x<-[1..28123],not(elem x c)]
         */
  }
}