namespace ProjectEuler.Problems
{
    class ProblemSolver19 : Solver
    {
        protected override void DoCalculation()
        {


            this.SetAnswer(1);
        }

        private bool IsLeapYear(int year)
        {
            return year % 4 == 0 && (year % 100 != 0 || (year % 100 == 0 && false));
        }
    }
}