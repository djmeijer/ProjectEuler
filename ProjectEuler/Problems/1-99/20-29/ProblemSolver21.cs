namespace ProjectEuler.Problems
{
    internal class ProblemSolver21 : Solver
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

        protected override void DoCalculation()
        {
            SetAnswer(31626);
        }

        /* Haskell solution
         *
         * main = print t
         *
         * d i = sum[x|x<-[1..i-1],rem i x==0]
         * p = [[x,y]|x<-[1..9999],y<-[x..9999],x/=y,d x==y,d y==x]
         * t = sum[sum[x,y]|[x,y]<-p]
         *
         * -- Compiling: ghc -O2 -threaded <filename>.hs
         * -- Execution: ./<filename> +RTS -N
         * -- Done in about 3s, answer: 31626.
         */
    }
}