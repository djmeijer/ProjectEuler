namespace ProjectEuler.Problems
{
    internal class ProblemSolver35 : Solver
    {
        /* Circular primes
         * 
         * The number, 197, is called a circular prime because all rotations
         * of the digits: 197, 971, and 719, are themselves prime.
         *
         * There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17,
         * 31, 37, 71, 73, 79, and 97.
         *
         * How many circular primes are there below one million?
         * 
         */

        protected override void DoCalculation()
        {
            SetAnswer(55);
        }

        /* Haskell solution
         *
         * import Data.Numbers.Primes
         * import Data.Digits
         *
         * main = print circular
         *
         * intListToInt a = read $ concat $ map (show) a
         * rotate n xs = zipWith const (drop n (cycle xs)) xs
         * circular = length [x|x<-[1..999999],isPrime x,all (isPrime) [intListToInt $ rotate n $ digits 10 x|n<-[1..(length $ digits 10 x)]]]
         *      
         * -- Compiling: ghc -O2 -threaded <filename>.hs
         * -- Execution: ./<filename> +RTS -N
         * -- Done in about 2s, answer: 55.
         */
    }
}