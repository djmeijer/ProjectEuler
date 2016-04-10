using System;
using System.Globalization;
using System.Numerics;
using System.Windows.Forms;

namespace ProjectEuler
{
    public abstract class Solver
    {
        private string _answer;
        private DateTime _end;
        private DateTime _start;

        protected abstract void DoCalculation();

        private void ShowSolution()
        {
            if (!string.IsNullOrEmpty(_answer))
            {
                var ts = _end - _start;
                var speed = ts < new TimeSpan(0, 1, 0) ? "satisfied" : "failed to satisfy";
                Console.WriteLine($"He found '{_answer}'.");
                Console.WriteLine($"It took him {ts}(hh:mm:ss:*). So he {speed} the 'one-minute' rule.");
                Clipboard.SetText(_answer);
            }
            else
            {
                Console.WriteLine("Found a papyrus! However, it is empty.");
            }
        }

        public void ShowAnswer()
        {
            _answer = string.Empty;
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
            _answer = answer.ToString(CultureInfo.InvariantCulture);
        }

        protected void SetAnswer(float answer)
        {
            _answer = answer.ToString(CultureInfo.InvariantCulture);
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