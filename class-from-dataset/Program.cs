using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;


namespace class_from_dataset
{
    class Program
    {
        public static string testDataPath = @"hygdata_v3.csv";
        public static string outputPath = @"output.class";
        public static List<string> illigalWords = File.ReadLines(@"ForbiddenWords.txt").ToList();
        public static List<string> inputData = File.ReadLines(testDataPath).ToList();
        public static List<string> dataSamples;
        public static string headers = inputData.ElementAt(0);


        static void Main(string[] args)
        {
            if (File.Exists(outputPath)) { File.Delete(outputPath); }
            File.WriteAllLines(outputPath, CreateClass(GetHeaders(headers)));
            
            GetDataSamples();
            Console.ReadKey();
        }

        static void GetDataSamples()
        {
            dataSamples = inputData.GetRange(1, 5);
        }

        static List<string> GetHeaders(string input)
        {
            List<string> output = input.Replace(" ", "").Split(',').ToList<string>();

            return output;
        }

        static List<string> CreateClass(List<string> headers)
        {
            List<string> output = new List<string>();

            string classline = "class ";
            string bracesStart = "{";
            string type = "\tpublic string ";
            string getset = " { get; set; }";
            string breacesEnd = "}";

            Console.WriteLine(classline);
            output.Add(classline);
            Console.WriteLine(bracesStart);
            output.Add(bracesStart);
            foreach (string item in headers)
            {
                string str = type + UppercaseFirst(CheckIfLegal(item)) + getset;

                Console.WriteLine(str);
                output.Add(str);
            }
            Console.WriteLine(breacesEnd);
            output.Add(breacesEnd);

            return output;
        }

        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        static string CheckIfLegal(string s)
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
