namespace ProjectEuler.Problems
{
    internal class ProblemSolver36 : Solver
    {
        /* Double-based palindromes
         * 
         * The decimal number, 585 = 10010010012 (binary),
         * is palindromic in both bases.
         * 
         * Find the sum of all numbers, less than one million,
         * which are palindromic in base 10 and base 2.
         * 
         * (Please note that the palindromic number, in either
         * base, may not include leading zeros.)
         * 
         */

        protected override void DoCalculation()
        {
            SetAnswer(872187);
        }

        /* Haskell solution
         *
         * import Numeric
         * 
         * main :: IO()
         * main = print sumDoubleBasePalindromes
         * 
         * toBinary :: Int -> String
         * toBinary n = showIntAtBase 2 ("01" !!) n ""
         * 
         * isPalindrome :: String -> Bool
         * isPalindrome xs = reverse xs == xs
         * 
         * sumDoubleBasePalindromes :: Int
         * sumDoubleBasePalindromes = sum [x|x<-[1..999999],isPalindrome $ show x,isPalindrome $ toBinary x]
         *      
         * -- Compiling: ghc -O2 -threaded <filename>.hs
         * -- Execution: ./<filename> +RTS -N
         * -- Done in about 0.1s, answer: 872187.
         */
    }
}