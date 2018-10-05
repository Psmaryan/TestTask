using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Util
{
    public static class StringExtension
    {
        public static int CountWord(this string str, string input)
        {
            if (input == " ")
                return 0;

            int count = 0;

            string inputNew = input.Trim();
            string[] words = str.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (String.Compare(word, inputNew, true) == 0)
                {
                    ++count;
                }
            }

            return count;
        }
    }
}