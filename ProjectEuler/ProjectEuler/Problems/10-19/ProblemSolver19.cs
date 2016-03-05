using ProjectEuler.Utilities;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver19 : Solver
    {
        protected override void DoCalculation()
        {
            var sundays = 0;
            var currentDay = Day.Monday;
            for (var year = 1900; year <= 2000; year++)
                for (var month = 1; month <= 12; month++)
                    for (var day = 1; day <= GetNumberOfDays(year, month); day++)
                    {
                        if (currentDay == Day.Sunday && day == 1 && year > 1900)
                            sundays++;
                        if (currentDay == Day.Saturday)
                            currentDay = Day.Sunday;
                        else
                            currentDay++;
                    }
            SetAnswer(sundays);
        }

        private static bool IsLeapYear(int year)
        {
            return year % 4 == 0 && (year % 100 != 0 || (year % 400 == 0));
        }

        private static int GetNumberOfDays(int year, int month)
        {
            switch (month)
            {
                case 1:
                    return 31;
                case 2:
                    return (IsLeapYear(year) ? 29 : 28);
                case 3:
                    return 31;
                case 4:
                    return 30; // April
                case 5:
                    return 31;
                case 6:
                    return 30; // June
                case 7:
                    return 31;
                case 8:
                    return 31;
                case 9:
                    return 30; // September
                case 10:
                    return 31;
                case 11:
                    return 30; // November
                case 12:
                    return 31;
                default:
                    return 0;
            }
        }
    }
}