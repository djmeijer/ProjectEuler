using System;
using System.Numerics;
using System.Windows.Forms;

namespace ProjectEuler
{
    abstract class Solver
    {
        private string answer;
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
                TimeSpan ts = this.end - this.start;
                string speed;
                if (ts < new TimeSpan(0, 1, 0))
                    speed = "Congratulations!";
                else
                    speed = "Come on, this should be faster!";
                Console.WriteLine("The answer is: " + answer);
                Console.WriteLine("Calculation was done in " + ts + ". " + speed);
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

        protected void SetAnswer(double answer)
        {
            this.answer = answer.ToString();
        }

        protected void SetAnswer(float answer)
        {
            this.answer = answer.ToString();
        }

        protected void SetAnswer(BigInteger answer)
        {
            this.answer = answer.ToString();
        }
    }
}