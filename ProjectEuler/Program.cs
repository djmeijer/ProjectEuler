using System;

namespace ProjectEuler
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Console.WriteLine("When you enter a positive integer I will send the librarian to look for an answer on this specific problem. There is no guarantee he will return with usefull data. It's even unclear whether he will return before the universe implodes.");

            while (int.TryParse(Console.ReadLine(), out int problemNumber))
            {
                Type type = Type.GetType($"ProjectEuler.Problems.ProblemSolver{problemNumber}");

                if (type == null)
                {
                    Console.WriteLine("My apologies sir. Not even a single weird Greek parchment on this topic.");
                }
                else
                {
                    var problem = Activator.CreateInstance(type);

                    var answer = type.GetMethod("ShowAnswer");
                    try
                    {
                        answer.Invoke(problem, null);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.InnerException);
                    }
                }
            }
        }
    }
}