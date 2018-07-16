using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_from_dataset
{
    static class StringUtilities
    {
        public static List<string> illigalWords = File.ReadLines(@"ForbiddenWords.txt").ToList();

        public static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static string CheckIfLegal(string s)
        {
            string output;
            bool legal = true;

            foreach (var item in illigalWords)
            {
                if (s == item)
                {
                    legal = false;
                }
            }

            if (legal) { output = s; }
            else { output = s + "_"; }

            return output;
        }
    }
}
