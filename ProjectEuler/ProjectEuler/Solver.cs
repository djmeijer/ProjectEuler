using System;
using System.Numerics;
using System.Windows.Forms;

namespace ProjectEuler
{
    internal abstract class Solver
    {
        private string _answer;
        private DateTime _end;
        private DateTime _start;

        protected abstract void DoCalculation();

        private void ShowSolution()
        {
            if (_answer != "")
            {
                var ts = _end - _start;
                var speed = ts < new TimeSpan(0, 1, 0) ? "Congratulations!" : "Come on, this should be faster!";
                Console.WriteLine("The answer is: " + _answer);
                Console.WriteLine("Calculation was done in " + ts + "(hh:mm:ss:*). " + speed);
                Clipboard.SetText(_answer);
            }
            else
                Console.WriteLine("No solution was found.");
            Console.ReadKey();
        }

        public void ShowAnswer()
        {
            _answer = "";
            _start = DateTime.Now;
            DoCalculation();
            _end = DateTime.Now;
            ShowSolution();
        }

        protected void SetAnswer(string answer)
        {
            _answer = answer;
        }

        protected void SetAnswer(int answer)
        {
            _answer = answer.ToString();
        }

        protected void SetAnswer(long answer)
        {
            _answer = answer.ToString();
        }

        protected void SetAnswer(double answer)
        {
            _answer = answer.ToString();
        }

        protected void SetAnswer(float answer)
        {
            _answer = answer.ToString();
        }

        protected void SetAnswer(BigInteger answer)
        {
            _answer = answer.ToString();
        }

        protected void SetAnswer(bool answer)
        {
            _answer = answer.ToString();
        }
    }
}