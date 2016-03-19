namespace ProjectEuler.Problems
{
    internal class ProblemSolver34 : Solver
    {
        /* Digit factorials
         * 
         * 145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.
         *
         * Find the sum of all numbers which are equal to the sum of the
         * factorial of their digits.
         *
         * Note: as 1! = 1 and 2! = 2 are not sums they are not included.
         * 
         */

        public override void DoCalculation()
        {
            SetAnswer(40730);
        }

        /* Haskell solution
         *
         * import Data.Digits
         *
         * main = print l
         *
         * f x = product [n|n<-[1..x]]
         * l = sum [x|x<-[1..999999],sum [f y|y<-digits 10 x] == x] - 3
         *
         * -- Compiling: ghc -O2 -threaded<filename>.hs
         * -- Execution: ./<filename.hs> +RTS -N
         * -- Done in about 1.5s, answer: 40730.
         */
    }
}