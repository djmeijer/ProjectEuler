using System;

namespace ProjectEuler
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            int problemNumber;
            while (int.TryParse(Console.ReadLine(), out problemNumber))
            {
                try
                {
                    var type = Type.GetType($"ProjectEuler.Problems.ProblemSolver{problemNumber}");

                    if (type == null)
                    {
                        throw new Exception();
                    }

                    var problem = Activator.CreateInstance(type);

                    var calculation = type.GetMethod("DoCalculation");
                    calculation.Invoke(problem, null);

                    var answer = type.GetMethod("ShowAnswer");
                    answer.Invoke(problem, null);
                }
                catch
                {
                    Console.WriteLine("This problem isn't solved yet.");
                }
            }
        }
    }
}