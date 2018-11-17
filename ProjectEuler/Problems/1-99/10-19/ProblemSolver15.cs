namespace ProjectEuler.Problems
{
    internal class ProblemSolver15 : Solver
    {
        /* Lattice paths
         * 
         * Starting in the top left corner of a 2×2 grid,
         * and only being able to move to the right and down,
         * there are exactly 6 routes to the bottom right corner.
         * 
         * How many such routes are there through a 20×20 grid?
         * 
         */

        protected override void DoCalculation()
        {
            const int gridSize = 20;
            long paths = 1;

            for (var i = 0; i < gridSize; i++)
            {
                paths *= 2 * gridSize - i;
                paths /= i + 1;
            }

            SetAnswer(paths);
        }
    }
}