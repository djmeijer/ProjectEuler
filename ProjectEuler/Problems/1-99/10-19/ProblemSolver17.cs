using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    internal class ProblemSolver17 : Solver
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
            var lettersUsed = 0;
            for (var i = 1; i <= 1000; i++)
                lettersUsed += GetNumberOfLetters(i);
            SetAnswer(lettersUsed);
        }

        private int GetNumberOfLetters(int i)
        {
            var text = GetTextFromNumber(i);
            return text.Count(c => c != ' ' && c != '-');
        }

        private string GetTextFromNumber(int i)
        {
            var digits = GetDigitsList(i);

            #region Text

            var text = "";
            string[] words =
            {
                "one", // 0
                "two", // 1
                "three", // 2
                "four", // 3
                "five", // 4
                "six", // 5
                "seven", // 6
                "eight", // 7
                "nine", // 8
                "ten", // 9
                "eleven", // 10
                "twelve", // 11
                "teen", // 12
                "thir", // 13
                "fif", // 14
                "eigh", // 15
                "twen", // 16
                "ty", // 17
                "eighty", // 18
                "hundred", // 19
                "thousand", // 20
                "and", // 21
                "for" // 22
            };

            #endregion

            if (digits.Count == 4)
            {
                text = words[0] + " " + words[20];
            }
            else
            {
                if (digits.Count == 3)
                {
                    text += words[digits[2] - 1] + " " + words[19] + " ";
                    i -= digits[2] * 100;
                    if (i > 0)
                        text += words[21] + " ";
                }

                if (i >= 0 && i <= 19)
                {
                    if (i > 0 && i <= 12)
                    {
                        text += words[i - 1];
                    }
                    else
                    {
                        if (i == 13)
                            text += words[i];
                        else if (i == 15)
                            text += words[i - 1];
                        else if (new[] {14, 16, 17, 19}.Contains(i))
                            text += words[i - 11];
                        else if (i == 18)
                            text += words[i - 3];
                        text += words[12];
                    }
                }
                else
                {
                    if (digits[1] == 2)
                        text += words[16] + words[17];
                    else if (digits[1] == 3)
                        text += words[13] + words[17];
                    else if (digits[1] == 4)
                        text += words[22] + words[17];
                    else if (digits[1] == 5)
                        text += words[14] + words[17];
                    else if (digits[1] == 8)
                        text += words[15] + words[17];
                    else
                        text += words[digits[1] - 1] + words[17];
                    if (digits[0] > 0)
                        text += "-" + words[digits[0] - 1];
                }
            }

            return text;
        }

        private static List<int> GetDigitsList(int i)
        {
            var digits = new List<int>();
            while (i >= 10)
            {
                digits.Add(i % 10);
                i /= 10;
            }

            digits.Add(i % 10);
            return digits;
        }
    }
}