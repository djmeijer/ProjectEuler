namespace ProjectEuler.Problems
{
    internal class ProblemSolver9 : Solver
    {
        /* Special Pythagorean triplet
         * 
         * A Pythagorean triplet is a set of three natural numbers,
         * a < b < c, for which, a^2 + b^2 = c^2
         * For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
         * There exists exactly one Pythagorean triplet for which a + b + c = 1000.
         * Find the product abc.
         * 
         */

        protected override void DoCalculation()
        {
            for (var a = 0; a < 1001; a++)
                for (var b = 0; b < 1001; b++)
                    for (var c = 0; c < 1001; c++)
                        if (a < b && b < c && a * a + b * b == c * c && a + b + c == 1000)
                            SetAnswer(a * b * c);
        }

        /* Haskell solution
         *
         * main = print $ head[a * b * c | a < -[1..998], b < -[1..998], c < -[1..998], a < b, b < c, a * a + b * b == c * c, a + b + c == 1000]
         *
         * -- Compiling: ghc -O2 -threaded <filename>.hs
         * -- Execution: ./<filename> +RTS -N
         * -- Done in about 2.5s, answer: 31875000.
         */
    }
}