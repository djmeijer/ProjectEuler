using System;
using System.Numerics;
using System.Windows.Forms;

namespace ProjectEuler
{
    internal abstract class Solver
    {
        private DateTime _end;
        private DateTime _start;
        private string _answer;

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
            this._answer = answer;
        }

        protected void SetAnswer(int answer)
        {
            this._answer = answer.ToString();
        }

        protected void SetAnswer(long answer)
        {
            this._answer = answer.ToString();
        }

        protected void SetAnswer(double answer)
        {
            this._answer = answer.ToString();
        }

        protected void SetAnswer(float answer)
        {
            this._answer = answer.ToString();
        }

        protected void SetAnswer(BigInteger answer)
        {
            this._answer = answer.ToString();
        }

        protected void SetAnswer(bool answer)
        {
            this._answer = answer.ToString();
        }
    }
}