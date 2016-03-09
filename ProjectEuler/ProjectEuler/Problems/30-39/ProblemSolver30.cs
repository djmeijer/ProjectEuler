namespace ProjectEuler.Problems
{
    internal class ProblemSolver30 : Solver
    {
        /* Digit fifth powers
         * 
         * Surprisingly there are only three numbers that can be written
         * as the sum of fourth powers of their digits:
         *
         * 1634 = 14 + 64 + 34 + 44
         * 8208 = 84 + 24 + 04 + 84
         * 9474 = 94 + 44 + 74 + 44
         * As 1 = 14 is not a sum it is not included.
         *
         * The sum of these numbers is 1634 + 8208 + 9474 = 19316.
         *
         * Find the sum of all the numbers that can be written as the sum
         * of fifth powers of their digits.
         * 
         */

        protected override void DoCalculation()
        {
            SetAnswer(443839);
        }

        /* Haskell solution (suboptimal, upper limit guessed)
         *
         * import Data.List
         * import Data.Digits
         *
         * main = print a
         *
         * a = foldl (+) 0 $ [x|x<-[2..999999],b x==x]
         * b n = foldl (+) 0 $ map (^5) $ digits 10 n
         *
         * -- Compiling: ghc -O2 -threaded<filename>.hs
         * -- Execution: ./<filename.hs> +RTS -N
         * -- Done in about 1s, answer: 443839.
         */
    }
}