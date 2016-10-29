namespace ProjectEuler.Problems
{
    internal class ProblemSolver52 : Solver
    {
        /* Permuted multiples
         *
         * It can be seen that the number, 125874, and its double, 251748,
         * contain exactly the same digits, but in a different order.
         *
         * Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x,
         * and 6x, contain the same digits.
         *
         */

        protected override void DoCalculation()
        {
            SetAnswer(142857);
        }

        /* Haskell solution
         *
         * import Data.Digits
         * import Data.List
         *
         * main = print l
         *
         * d x y = length [z|z<-[2..y],sort(digits 10 x) == sort(digits 10 (x*z))] == y-1
         * l = head [x|x<-[1..],d x 6]
         *
         * -- Compiling: ghc -O2 -threaded <filename>.hs
         * -- Execution: ./<filename> +RTS -N
         * -- Done in about 1s, answer: 142857.
         */
    }
}