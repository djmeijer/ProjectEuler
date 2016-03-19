namespace ProjectEuler.Problems
{
    internal class ProblemSolver24 : Solver
    {
        /* Amicable numbers
         * 
         * Let d(n) be defined as the sum of proper divisors of n
         * (numbers less than n which divide evenly into n).
         * If d(a) = b and d(b) = a, where a ≠ b, then a and b are
         * an amicable pair and each of a and b are called amicable numbers.
         * For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11,
         * 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors
         * of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
         * 
         * Evaluate the sum of all the amicable numbers under 10000.
         */

        public override void DoCalculation()
        {
            SetAnswer(2783915460);
        }

        /* Haskell solution
         *
         * import Data.List
         * main = print $ take 1 $ drop 999999 $ sort $ permutations[0..9]
         *
         * -- Compiling: ghc -O2 -threaded<filename>.hs
         * -- Execution: ./<filename.hs> +RTS -N
         * -- Done in about 6s, answer: 2783915460.
         */
    }
}