namespace ProjectEuler.Problems
{
    internal class ProblemSolver28 : Solver
    {
        /* Number spirals diagoanls
         * 
         * Starting with the number 1 and moving to the right in
         * a clockwise direction a 5 by 5 spiral is formed as follows:
         *
         * 21 22 23 24 25
         * 20  7  8  9 10
         * 19  6  1  2 11
         * 18  5  4  3 12
         * 17 16 15 14 13
         *
         * It can be verified that the sum of the numbers on the diagonals is 101.
         *
         * What is the sum of the numbers on the diagonals in a 1001 by 1001
         * spiral formed in the same way?
         * 
         */

        public override void DoCalculation()
        {
            var diagonalSum = 0;

            // Peel away the borders of the grid until we reach the center.
            for (var n = 1001; n >= 3; n = n - 2)
            {
                var tr = n * n;
                for (var i = 1; i <= 3; i++)
                {
                    diagonalSum += tr - i * (n - 1);
                }
                diagonalSum += tr;
            }

            // Center of a 3x3 grid is always a 1.
            diagonalSum++;

            SetAnswer(diagonalSum);
        }
    }
}