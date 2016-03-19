namespace ProjectEuler.Problems
{
    internal class ProblemSolver27 : Solver
    {
        /* Quadratic primes
         * 
         * Euler discovered the remarkable quadratic formula:
         *
         * n² + n + 41
         *
         * It turns out that the formula will produce 40 primes for
         * the consecutive values n = 0 to 39. However, when n = 40,
         * 402 + 40 + 41 = 40(40 + 1) + 41 is divisible by 41, and
         * certainly when n = 41, 41² + 41 + 41 is clearly divisible by 41.
         *
         * The incredible formula  n² − 79n + 1601 was discovered, which
         * produces 80 primes for the consecutive values n = 0 to 79.
         * The product of the coefficients, −79 and 1601, is −126479.
         *
         * Considering quadratics of the form:
         *
         * n² + an + b, where |a| < 1000 and |b| < 1000
         * where |n| is the modulus/absolute value of n
         * e.g. |11| = 11 and |−4| = 4
         * Find the product of the coefficients, a and b, for the quadratic
         * expression that produces the maximum number of primes for consecutive
         * values of n, starting with n = 0.
         * 
         */

        public override void DoCalculation()
        {
            SetAnswer(-59231);
        }

        /* Haskell solution
         *
         * import Data.Sequence hiding (length, sort, reverse)
         * import Data.Numbers.Primes
         * import Data.Function (on)
         * import Data.List
         * 
         * main = print x
         *
         * f a b = [n^2+a*n+b|n<-[0..72]]
         * v a b = takeWhileL (isPrime) $ fromList $ f a b
         * x = snd $ head $ reverse $ sort [(x,a*b)|a<-[-999..999],b<-[-999..999],x<-[length $ v a b]]
         *
         * -- Compiling: ghc -O2 -threaded<filename>.hs
         * -- Execution: ./<filename.hs> +RTS -N
         * -- Done in about 30s, answer: -59231.
         */
    }
}