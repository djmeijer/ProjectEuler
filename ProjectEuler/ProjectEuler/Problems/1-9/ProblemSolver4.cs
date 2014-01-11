namespace ProjectEuler
{
    class ProblemSolver4 : Solver
    {
        /* Largest palindrome product
         * 
         * A palindromic number reads the same both ways. The largest palindrome made
         * from the product of two 2-digit numbers is 9009 = 91 × 99.
         * Find the largest palindrome made from the product of two 3-digit numbers.
         * 
         */

        protected override void DoCalculation()
        {
            int largestPalindrome = 0, a = 999, b = 0, db = 0;
            while (a >= 100)
            {
                if (a % 11 == 0)
                {
                    b = 999;
                    db = 1;
                }
                else
                {
                    b = 990; //The largest number less than or equal 999 and divisible by 11
                    db = 11;
                }
                while (b >= a)
                {
                    if (a * b <= largestPalindrome)
                        break;
                    if (IsPalindrome(a * b))
                        largestPalindrome = a * b;
                    b -= db;
                }
            a -= 1;
            }
            this.SetAnswer(largestPalindrome);
        }

        private bool IsPalindrome(int n)
        {
            return n == Reverse(n);
        }

        private int Reverse(int n)
        {
            int reversed = 0;
            while (n > 0)
            {
                reversed = 10 * reversed + n % 10;
                n /= 10;
            }
            return reversed;
        }
    }
}