using System;

namespace ProjectEuler
{
    class ProblemSolver17 : Solver
    {
        /* Number letter counts
         * 
         * If the numbers 1 to 5 are written out in words:
         * one, two, three, four, five, then there are
         * 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
         * 
         * If all the numbers from 1 to 1000 (one thousand)
         * inclusive were written out in words, how many
         * letters would be used?
         * 
         * NOTE: Do not count spaces or hyphens. For example,
         * 342 (three hundred and forty-two) contains 23
         * letters and 115 (one hundred and fifteen) contains
         * 20 letters. The use of "and" when writing out numbers
         * is in compliance with British usage.
         * 
         */

        protected override void DoCalculation()
        {
            int lettersUsed = 0;
            for (int i = 1; i <= 40; i++)
                lettersUsed += this.GetNumberOfLetters(i);
            this.SetAnswer(lettersUsed);
        }

        private int GetNumberOfLetters(int i)
        {
            string text = this.GetTextFromNumber(i);
            Console.WriteLine(i + ": " + text);
            int numberOfLetters = 0;
            foreach (char c in text)
                if (c != ' ' && c != '-')
                    numberOfLetters++;
            return numberOfLetters;
        }

        private string GetTextFromNumber(int i)
        {
            string text = "";
            string[] words = new string[] {
                "zero",         // 0
                "one",          // 1
                "two",          // 2
                "three",        // 3
                "four",         // 4
                "five",         // 5
                "six",          // 6
                "seven",        // 7
                "eight",        // 8
                "nine",         // 9
                "ten",          // 10
                "eleven",       // 11
                "twelve",       // 12
                "teen",         // 13
                "thir",         // 14
                "fif",          // 15
                "eigh",     // 16
                "twen",         // 17
                "ty",           // 18
                "eighty",       // 19
                "hundred",      // 20
                "thousand"      // 21
            };
            if (i == 1000)
                text = words[1] + words[20];
            else if (i > 99 && i < 1000)
            {
                if (i >= 0 && i <= 19)
                    if (i >= 0 && i <= 12)
                        text = words[i];
                    else
                        if (i == 13)
                            text = words[i + 1];
                        else if (i == 14)
                            text = words[4];
                        else if (i == 15)
                            text = words[i];
                        else if (i == 16 || i == 17 || i == 19)
                            text = words[i - 10];
                        else if (i == 18)
                            text = words[16];
                        text += words[13];
            }
            return text;
        }
    }
}