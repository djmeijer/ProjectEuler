using System;

namespace ProjectEuler
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Console.WriteLine("When you enter a positive integer I will send the librarian to look for an answer on this specific problem. There is no guarantee he will return with usefull data. It's even unclear whether he will return before the universe implodes.");

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

                    var answer = type.GetMethod("ShowAnswer");
                    answer.Invoke(problem, null);
                }
                catch
                {
                    Console.WriteLine("My apologies sir. Not even a single weird Greek parchment on this topic.");
                }
            }
        }
    }
}