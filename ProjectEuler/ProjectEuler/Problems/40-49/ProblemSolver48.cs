namespace ProjectEuler.Problems
{
    internal class ProblemSolver48 : Solver
    {
        /* Self powers
         * 
         * The series, 11 + 22 + 33 + ... + 1010 = 10405071317.
         *
         * Find the last ten digits of the series, 11 + 22 + 33 + ... + 10001000.
         *
         */

        public override void DoCalculation()
        {
            SetAnswer(9110846700);
        }

        /* Haskell solution
         *
         * main = print (read $ reverse $ take 10 $ reverse $ show $ sum [x^x|x<-[1..1000]] :: Int)
         *
         * -- Compiling: ghc -O2 -threaded<filename>.hs
         * -- Execution: ./<filename.hs> +RTS -N
         * -- Done in about 0.1s, answer: 9110846700.
         */
    }
}