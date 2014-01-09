using System;
using System.Windows.Forms;

namespace ProjectEuler
{
    abstract class Solver
    {
        protected string answer;
        private DateTime start, end;

        public Solver()
        {
            this.answer = "";
            this.start = DateTime.Now;
            this.DoCalculation();
            this.end = DateTime.Now;
            this.ShowSolution();
        }

        protected abstract void DoCalculation();

        private void ShowSolution()
        {
            if (this.answer != "")
            {
                Console.WriteLine("The answer is: " + answer);
                Console.WriteLine("Calculation was done in " + (this.end - this.start) + ".");
                Clipboard.SetText(answer);
            }
            else
                Console.WriteLine("No solution was found.");
            Console.ReadKey();
        }

        protected void SetAnswer(string answer)
        {
            this.answer = answer;
        }

        protected void SetAnswer(int answer)
        {
            this.answer = answer.ToString();
        }

        protected void SetAnswer(long answer)
        {
            this.answer = answer.ToString();
        }
    }
}